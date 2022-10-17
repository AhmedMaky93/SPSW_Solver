using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BasicModel;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SPSW_Solver;
using SPSW_Solver.BasicModel;
using SPSW_Solver.Model;
using SPSW_Solver.UI.Selection;

namespace BasicModel
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(FrameTwoNodesElement))]
    [KnownType(typeof(RigidLink))]
    [KnownType(typeof(TrussElement))]
    [KnownType(typeof(RegularTrussElement))]
    [KnownType(typeof(RotSpring))]
    [KnownType(typeof(PlasticHinge))]
    public class TwoNodesElement : Element2d
    {
        #region Members
        [DataMember]
        protected Node _startNode;
        [DataMember]
        protected Node _endNode;
        #endregion

        #region Properties
        public Node StartNode
        {
            get { return _startNode; }
            set { _startNode= value; }
        }
        public Node EndNode
        {
            get { return _endNode; }
            set { _endNode = value; }
        }
        #endregion

        #region Constructors
        public TwoNodesElement()
        {

        }
        public TwoNodesElement(Node startNode, Node endNode) : base(++LastID)
        {
            _startNode = startNode;
            _endNode = endNode;
        }
        #endregion

        internal virtual void RenderDeformation(int loadcase, int index)
        {
            RenderOptions.Vertex2(_startNode.GetDeformedPoint(loadcase, index));
            RenderOptions.Vertex2(_endNode.GetDeformedPoint(loadcase, index));
        }
        public virtual void Render()
        {
            RenderOptions.Vertex2(_startNode.Point);
            RenderOptions.Vertex2(_endNode.Point);
        }
        internal virtual void RenderModeShape(int index, double Factor)
        {
            RenderOptions.Vertex2(_startNode.GetDeformedPoint(index, Factor));
            RenderOptions.Vertex2(_endNode.GetDeformedPoint(index, Factor));
        }
        public double GetLength()
        {
            return _startNode.Point.DistanceTo(_endNode.Point);
        }

    }

    [DataContract(IsReference = true)]
    public class RotSpring : TwoNodesElement, IRotspring
    {
        [DataMember]
        protected FrameElementFamily _family;

        public FrameElementFamily Family
        {
            get { return _family; }
        }
        public RotSpring()
        {
        }
        public RotSpring(Node startNode, Node endNode, FrameElementFamily Family) : base(startNode, endNode)
        {
            _family = Family;
        }
        public override void UpdateIDReference()
        {
            base.UpdateIDReference();
        }
    }

    [DataContract(IsReference = true)]
    public class PlasticHinge : TrussElement, IRotspring , IPlasticElement
    {
        #region Members
        [DataMember]
        protected FrameElementFamily _family;
        [DataMember]
        protected double _Lp;
        #endregion

        #region Properties
        public FrameElementFamily Family
        {
            get { return _family; }
        }
        public double Lp
        {
            get { return _Lp; }
            set { _Lp = value; }
        }
        #endregion

        #region Constructors
        public PlasticHinge()
        {

        }
        public PlasticHinge(Node startNode, Node endNode, FrameElementFamily Family, double Lp) : base(startNode, endNode, Family)
        {
            _family = Family;
            _Lp = Lp;
        }
        #endregion

        #region Methods
        internal override void RenderDeformation(int loadcase, int index)
        {
            if (_deformations.Any() && _deformations[loadcase].Any())
            {
                Color c = GetPlasticHingeColor(_deformations[loadcase][index]);
                if (c != RenderOptions.initStessColor)
                {
                    Point2D p1 = _startNode.GetDeformedPoint(loadcase, index);
                    Point2D p2 = _endNode.GetDeformedPoint(loadcase, index);
                    Point2D p = new Point2D(0.5 * (p1.X + p2.X), 0.5 * (p1.Y + p2.Y));
                    MainNode.RenderCircularNode(p, c, 0.8);
                }
            }
        }
        public static Color GetPlasticHingeColor(FrameElementFamily family , double Lp , double plasticRotation)
        {
            Material m = family.FlangeMaterial;

            double aPos = m.Getdy_Tension();
            double aNeg = m.Getdy_Compression();
            double bPos = m.GetdU_Tension();
            double bNeg = m.GetdU_Compression();
            double v = 0.5 * Math.Tan(plasticRotation) / Lp;
            if (v > aPos && Math.Abs(aPos) > 1e-6)
            {
                if (v > bPos && Math.Abs(bPos) > 1e-6)
                {
                    return RenderOptions.UltimateLimitColor;
                }
                return RenderOptions.ElasticLimitColor;
            }
            if (v < aNeg && Math.Abs(aNeg) > 1e-6)
            {
                if (v < bNeg && Math.Abs(bNeg) > 1e-6)
                {
                    return RenderOptions.UltimateLimitColor;
                }
                return RenderOptions.ElasticLimitColor;
            }
            return RenderOptions.initStessColor;
        }
        public Color GetPlasticHingeColor(double plasticRotation)
        {
            return GetPlasticHingeColor(_family,_Lp,plasticRotation);
        }
        internal override void AddAccumlativeResults(int loadCases, int k, bool srss)
        {
            base.AddAccumlativeResults(loadCases, k, srss);
        }
        public override void UpdateIDReference()
        {
            base.UpdateIDReference();
        }

        public double GetRelativeLocation(RegularFrameElement element)
        {
            Point2D start = element.Nodes.First().Point;
            Point2D end = element.Nodes.Last().Point;
            return Math.Round(_startNode.Point.DistanceTo(start) / start.DistanceTo(end),3);
        }
        public List<double> GetRotaions(int CurrentLoadCase)
        {
            return _deformations[CurrentLoadCase];
        }
        public List<double> GetMoment(int CurrentLoadCase)
        {
            return _forces[CurrentLoadCase];
        }
        #endregion
    }

    [DataContract(IsReference = true)]
    public class FrameTwoNodesElement : TwoNodesElement , IPlasticElement
    {
        #region Members
        [DataMember]
        protected List<List<SectionLocalForces>> _startSectionForces = new List<List<SectionLocalForces>>();
        [DataMember]
        protected List<List<SectionLocalForces>> _endSectionForces = new List<List<SectionLocalForces>>();
        [DataMember]
        protected List<List<SectionLocalForces>> _elasticDeformations = new List<List<SectionLocalForces>>();
        [DataMember]
        protected List<List<SectionLocalForces>> _plasticDeformations = new List<List<SectionLocalForces>>();
        [DataMember]
        protected FrameElementFamily _family;
        [DataMember]
        protected PlasticHingeApproach _approach;
        #endregion

        #region Properties
        public List<List<SectionLocalForces>> StartSectionForces
        {
            get { return _startSectionForces; }
            set { _startSectionForces = value; }
        }
        public List<List<SectionLocalForces>> EndSectionForces
        {
            get { return _endSectionForces; }
            set { _endSectionForces = value; }
        }
        public List<List<SectionLocalForces>> ElasticDeformation
        {
            get { return _elasticDeformations; }
            set { _elasticDeformations = value; }
        }
        public List<List<SectionLocalForces>> PlasticDeformation
        {
            get { return _plasticDeformations; }
            set { _plasticDeformations = value; }
        }
        public FrameElementFamily Family
        {
            get { return _family; }
            set { _family = value; }
        }
        public PlasticHingeApproach Representation
        {
            get { return _approach; }
        }
        #endregion

        #region Constructors
        public FrameTwoNodesElement()
        {

        }
        public FrameTwoNodesElement(Node startNode, Node endNode, FrameElementFamily family , PlasticHingeApproach approach ) : base(startNode, endNode)
        {
            _family = family;
            _approach = approach;
        }
        #endregion

        #region Methods
        public virtual void RenderDiagram(Vector2D vector, DiagramHandler handler, DiagramType type, int loadcase, int index)
        {
            double v1 = 0;
            double v2 = 0;
            Color c1;
            Color c2;
            switch (type)
            {
                case DiagramType.NormalForce:
                    v1 = _startSectionForces[loadcase][index].Nf;
                    v2 = _endSectionForces[loadcase][index].Nf;
                    break;
                case DiagramType.ShearForce:
                    v1 = _startSectionForces[loadcase][index].Sf;
                    v2 = _endSectionForces[loadcase][index].Sf;
                    break;
                case DiagramType.BendingMoment:
                    v1 = _startSectionForces[loadcase][index].FM;
                    v2 = _endSectionForces[loadcase][index].FM;
                    break;
                default:
                    break;
            }

            c1 = handler.GetColor(v1);
            v1 = handler.GetScaledDistance(v1);
            c2 = handler.GetColor(v2);
            v2 = handler.GetScaledDistance(v2);

            GL.Color4(c1);
            RenderOptions.Vertex2(_startNode.Point);
            RenderOptions.Vertex2(_startNode.Point + v1 * vector);
            GL.Color4(c2);
            RenderOptions.Vertex2(_endNode.Point + v2 * vector);
            RenderOptions.Vertex2(_endNode.Point);
        }
        public virtual void RenderDeformed(int loadcase, int index , RegularFrameElement parent)
        {
            Color color = GetRenderColor(loadcase , index ,parent);
            Vector2D v1 = _endNode.Point - _startNode.Point;
            Vector2D v2 = -1 * v1;
            v1 = v1.Rotate(Angle.FromRadians(_startNode.Deformations[loadcase][index].Dz));
            v2 = v2.Rotate(Angle.FromRadians(_endNode.Deformations[loadcase][index].Dz));
            RenderOptions.DrawCurve(_startNode.GetDeformedPoint(loadcase, index), v1, _endNode.GetDeformedPoint(loadcase, index), v2, color);
        }

        private Color GetRenderColor(int loadcase, int index, RegularFrameElement parent)
        {
            if (parent == null || !_elasticDeformations.Any() || !_plasticDeformations.Any())
                return RenderOptions.initStessColor;
            double Length = GetLength();
            if (_approach == PlasticHingeApproach.BeamWithHinges)
            {
                double SLP = 0.0;
                double Elp = 0.0;
                Point2D start = parent.Nodes.First().Point;
                Point2D end = parent.Nodes.Last().Point;
                (parent.Group.NumericalModel as BeamWithHingesModel).GetHingesDistances(this,
                    _startNode.Point.DistanceTo(start) < 1e-9, _endNode.Point.DistanceTo(end) < 1e-9, out SLP, out Elp);
                Length = SLP + Elp;
            }
            Length /= _family.Section.D;
            return PlasticHinge.GetPlasticHingeColor(_family,Length,_elasticDeformations[loadcase][index].FM + _plasticDeformations[loadcase][index].FM);
        }

        public virtual void RenderModeShape(int index, double factor, Color color)
        {
            Vector2D v1 = _endNode.Point - _startNode.Point;
            Vector2D v2 = -1 * v1;
            v1 = v1.Rotate(Angle.FromRadians(_startNode.ModeShapesDeformations[index].Dz * factor));
            v2 = v2.Rotate(Angle.FromRadians(_endNode.ModeShapesDeformations[index].Dz * factor));
            RenderOptions.DrawCurve(_startNode.GetDeformedPoint(index, factor), v1, _endNode.GetDeformedPoint(index, factor), v2, color);
        }
        internal virtual void AddAccumaltiveForces(int loadCases, int k, bool srss)
        {

            List<SectionLocalForces> startForcesList = new List<SectionLocalForces>();
            List<SectionLocalForces> endForcesList = new List<SectionLocalForces>();
            List<SectionLocalForces> ElasticDeformationList = new List<SectionLocalForces>();
            List<SectionLocalForces> plasticDeformationList = new List<SectionLocalForces>();
            if (srss)
            {
                for (int i = 0; i < k; i++)
                {
                    List<SectionLocalForces> temp1 = new List<SectionLocalForces>();
                    List<SectionLocalForces> temp2 = new List<SectionLocalForces>();
                    List<SectionLocalForces> temp3 = new List<SectionLocalForces>();
                    List<SectionLocalForces> temp4 = new List<SectionLocalForces>();

                    for (int j = 0; j < loadCases; j++)
                    {
                        temp1.Add(_startSectionForces[j][i]);
                        temp2.Add(_endSectionForces[j][i]);
                        temp3.Add(_elasticDeformations[j][i]);
                        temp4.Add(_plasticDeformations[j][i]);
                    }
                    startForcesList.Add(SectionLocalForces.SRSS(temp1));
                    endForcesList.Add(SectionLocalForces.SRSS(temp2));
                    ElasticDeformationList.Add(SectionLocalForces.SRSS(temp3));
                    plasticDeformationList.Add(SectionLocalForces.SRSS(temp4));
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    List<SectionLocalForces> temp1 = new List<SectionLocalForces>();
                    List<SectionLocalForces> temp2 = new List<SectionLocalForces>();
                    List<SectionLocalForces> temp3 = new List<SectionLocalForces>();
                    List<SectionLocalForces> temp4 = new List<SectionLocalForces>();

                    for (int j = 0; j < loadCases; j++)
                    {
                        temp1.Add(_startSectionForces[j][i]);
                        temp2.Add(_endSectionForces[j][i]);
                        temp3.Add(_elasticDeformations[j][i]);
                        temp4.Add(_plasticDeformations[j][i]);
                    }

                    startForcesList.Add(SectionLocalForces.Peak(temp1));
                    endForcesList.Add(SectionLocalForces.Peak(temp2));
                    ElasticDeformationList.Add(SectionLocalForces.Peak(temp3));
                    plasticDeformationList.Add(SectionLocalForces.Peak(temp4));
                }
            }
            _startSectionForces.Add(startForcesList);
            _endSectionForces.Add(endForcesList);
            _elasticDeformations.Add(ElasticDeformationList);
            _plasticDeformations.Add(plasticDeformationList);

        }

        internal void ClearRunResullts()
        {
            _startSectionForces.Clear();
            _endSectionForces.Clear();
            _elasticDeformations.Clear();
            _plasticDeformations.Clear();
        }

        public double GetRelativeLocation(RegularFrameElement element)
        {
            Point2D start = element.Nodes.First().Point;
            Point2D end = element.Nodes.Last().Point;

            return Math.Round(0.5 *(_startNode.Point.DistanceTo(start)+ _endNode.Point.DistanceTo(start)) / start.DistanceTo(end),3);
        }
        public List<double> GetRotaions(int CurrentLoadCase)
        {
            List<double> result = new List<double>();
            int count = Math.Min(_elasticDeformations[CurrentLoadCase].Count,_plasticDeformations[CurrentLoadCase].Count);
            for (int i = 0; i < count; i++)
            {
                result.Add(_elasticDeformations[CurrentLoadCase][i].FM + _plasticDeformations[CurrentLoadCase][i].FM);
            }
            return result;
        }
        public List<double> GetMoment(int CurrentLoadCase)
        {
            List<double> result = new List<double>();
            int count = Math.Min(_startSectionForces[CurrentLoadCase].Count, _endSectionForces[CurrentLoadCase].Count);
            for (int i = 0; i < count; i++)
            {
                result.Add(0.5 * (_startSectionForces[CurrentLoadCase][i].FM + _endSectionForces[CurrentLoadCase][i].FM));
            }
            return result;
        }
        #endregion
    }


  
}
