using BasicModel;
using MathNet.Spatial.Euclidean;
using SPSW_Solver.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SPSW_Solver
{
    public enum PlasticHingeApproach
    {
        None,
        ZeroLengthFiberSection,
        NolinearBeamColumn,
        DistrubuitedPlasticity,
        BeamWithHinges,
    }
    public enum EndFiberDistance
    {
        Zero,
        Depth,
        DepthAndConnection
    }
    public enum DistributedPlasticityOptions
    {
        AllSegments,
        EndSegments
    }
    public enum LengthRep
    {
       RelativeToDepth,
       RelativeToSegmentLength
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(ElasticElement))]
    [KnownType(typeof(DistrubutredPlasticity))]
    [KnownType(typeof(NonLinearBeams))]
    [KnownType(typeof(FiberPlasticSections))]
    [KnownType(typeof(BeamWithHingesModel))]
    public abstract class FrameElementNumericalModel
    {
        #region Members
        [DataMember]
        protected string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion

        #region Constractors
        public FrameElementNumericalModel()
        {

        }
        public static FrameElementNumericalModel GetInstance(string name, PlasticHingeApproach approach)
        {
            FrameElementNumericalModel result = null;
            switch (approach)
            {
                case PlasticHingeApproach.None:
                    result = new ElasticElement();
                    break;
                case PlasticHingeApproach.ZeroLengthFiberSection:
                    result = new FiberPlasticSections();
                    break;
                case PlasticHingeApproach.NolinearBeamColumn:
                    result = new NonLinearBeams();
                    break;
                case PlasticHingeApproach.DistrubuitedPlasticity:
                    result = new DistrubutredPlasticity();
                    break;
                case PlasticHingeApproach.BeamWithHinges:
                    result = new BeamWithHingesModel();
                    break;
            }
            result.Name = name;
            return result;
        }

        #region VirtualCreation
        public virtual void CreateSegments(RegularFrameElement element, PlasticHingeApproach plasticHingeApproach)
        {
            switch (plasticHingeApproach)
            {
                case PlasticHingeApproach.None:
                    CreateElasticSegments(element);
                    break;
                case PlasticHingeApproach.NolinearBeamColumn:
                    CreateNonLinearBeamSegments(element);
                    break;
                case PlasticHingeApproach.DistrubuitedPlasticity:
                    CreateDispBeamSegments(element);
                    break;
                case PlasticHingeApproach.BeamWithHinges:
                    CreateBeamHingSegments(element);
                    break;
            }
        }
        public virtual List<IPlasticElement> GetPlasticElements(RegularFrameElement element)
        {
            return new List<IPlasticElement>();
        }
        public virtual void CreateElasticSegments(RegularFrameElement element)
        { }
        public virtual void CreateNonLinearBeamSegments(RegularFrameElement element)
        { }
        public virtual void CreateDispBeamSegments(RegularFrameElement element)
        { }
        public virtual void CreateBeamHingSegments(RegularFrameElement element)
        { }
        #endregion

        #region Virtual Writing
        public virtual void WriteFrameSgments(StreamWriter file, RegularFrameElement element, PlasticHingeApproach plasticHingeApproach, ref int min, ref int max, ref int MaxSecId, ref int MaxMaterialId)
        {
            switch (plasticHingeApproach)
            {
                case PlasticHingeApproach.None:
                    WriteElasticSegments(file, element, ref min, ref max, ref MaxSecId, ref MaxMaterialId);
                    break;
                case PlasticHingeApproach.NolinearBeamColumn:
                    WriteNonLinearBeamSegments(file, element, ref min, ref max, ref MaxSecId, ref MaxMaterialId);
                    break;
                case PlasticHingeApproach.DistrubuitedPlasticity:
                    WriteDispBeamSegments(file, element, ref min, ref max, ref MaxSecId, ref MaxMaterialId);
                    break;
                case PlasticHingeApproach.BeamWithHinges:
                    WriteBeamHingSegments(file, element, ref min, ref max, ref MaxSecId, ref MaxMaterialId);
                    break;
            }
        }
        protected void UpdateIdsRanges(int id, ref int min, ref int max)
        {
            min = Math.Min(id, min);
            max = Math.Max(id, max);
        }
        public virtual void WriteElasticSegments(StreamWriter file, RegularFrameElement element, ref int min, ref int max, ref int MaxSecId, ref int MaxMaterialId)
        {
            foreach (var child in element.Childs.Where(x => x.Representation == PlasticHingeApproach.None))
            {
                UpdateIdsRanges(child.ID, ref min, ref max);
                double E = child.Family.initE;
                FrameElementFamily fam = child.Family;
                Section sec = fam.Section;
                double A = sec.A * fam.AreaModifier;
                double Ix = sec.Ix * fam.IntertiaModifier;
                file.WriteLine(string.Format("element elasticBeamColumn {0} {1} {2} {3} {4} {5} {6};",
                    child.ID, child.StartNode.ID, child.EndNode.ID, A, E, Ix, 1));
            }

        }
        public virtual void WriteNonLinearBeamSegments(StreamWriter file, RegularFrameElement element, ref int min, ref int max, ref int MaxSecId, ref int MaxMaterialId)
        { }
        public virtual void WriteDispBeamSegments(StreamWriter file, RegularFrameElement element, ref int min, ref int max, ref int MaxSecId, ref int MaxMaterialId)
        { }
        public virtual void WriteBeamHingSegments(StreamWriter file, RegularFrameElement element, ref int min, ref int max, ref int MaxSecId, ref int MaxMaterialId)
        { }
        #endregion

        public virtual void AddIntermediateNodes(List<Node> list, double depth, FEM_Axe axe , double StartAdjDepth , double EndAdjDepth)
        {
        }
        public void CreateAllSegmentsAs(RegularFrameElement element , PlasticHingeApproach option)
        {
            for (int i = 0; i < element.Nodes.Count - 1; i++)
            {
                element.Childs.Add(new FrameTwoNodesElement(element.Nodes[i], element.Nodes[i + 1], element.Family, option));
            }
        }
        public void CreateIntermediateSegmentsAs(RegularFrameElement element, PlasticHingeApproach option)
        {
            if (element.Nodes.Count < 4)
                return;

            for (int i = 1; i < element.Nodes.Count - 2; i++)
            {
                element.Childs.Add(new FrameTwoNodesElement(element.Nodes[i], element.Nodes[i + 1], element.Family, option));
            }
        }
        public void CreateEndSegmentsAs(RegularFrameElement element, PlasticHingeApproach option)
        {
            int n = element.Nodes.Count;
            if (n < 3)
            {
                element.CreateDefaultChild(option);
            }
            else
            {
                element.Childs.Add(new FrameTwoNodesElement(element.Nodes[0], element.Nodes[1], element.Family, option));
                element.Childs.Add(new FrameTwoNodesElement(element.Nodes[n-2], element.Nodes[n-1], element.Family, option));
            }
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class ElasticElement:FrameElementNumericalModel
    {
        public ElasticElement()
        {
        }
        public override void CreateElasticSegments(RegularFrameElement element)
        {
            CreateAllSegmentsAs(element, PlasticHingeApproach.None);
        }
    }
    [DataContract(IsReference = true)]
    public class DistrubutredPlasticity:FrameElementNumericalModel
    {
        #region Members
        [DataMember]
        protected DistributedPlasticityOptions _option = DistributedPlasticityOptions.AllSegments;
        [DataMember]
        protected int _IP = 3;
        #endregion

        #region Properties
        public DistributedPlasticityOptions ModelOption
        {
            get { return _option; }
            set { _option = value; }
        }
        public int IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        #endregion

        #region Constructor
        public DistrubutredPlasticity()
        {

        }
        #endregion

        #region Methods
        protected void WriteDisBeamSegment(StreamWriter file, FrameTwoNodesElement child, ref int min, ref int max, ref int MaxSecId, ref int MaxMatId)
        {
            UpdateIdsRanges(child.ID, ref min, ref max);
            file.WriteLine(string.Format("element dispBeamColumn {0} {1} {2} {3} {4} 1", child.ID, child.StartNode.ID
                , child.EndNode.ID, _IP, child.Family.WriteSection(file, -1, ref MaxSecId, ref MaxMatId)));
        }
        public override void WriteDispBeamSegments(StreamWriter file, RegularFrameElement element, ref int min, ref int max, ref int MaxSecId, ref int MaxMaterialId)
        {
            foreach (var child in element.Childs.Where(x => x.Representation == PlasticHingeApproach.DistrubuitedPlasticity))
            {
                WriteDisBeamSegment(file, child, ref min, ref max, ref MaxSecId, ref MaxMaterialId);
            }
        }
        public override void CreateElasticSegments(RegularFrameElement element)
        {
            if (_option == DistributedPlasticityOptions.AllSegments)
                return;

            CreateIntermediateSegmentsAs(element, PlasticHingeApproach.None);
        }
        public override void CreateDispBeamSegments(RegularFrameElement element)
        {
            switch (_option)
            {
                case DistributedPlasticityOptions.AllSegments:
                    CreateAllSegmentsAs(element, PlasticHingeApproach.DistrubuitedPlasticity);
                    break;
                case DistributedPlasticityOptions.EndSegments:
                    CreateEndSegmentsAs(element, PlasticHingeApproach.DistrubuitedPlasticity);
                    break;
            }
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class NonLinearBeams:FrameElementNumericalModel
    {
        #region Members
        [DataMember]
        protected LengthRep _rep = LengthRep.RelativeToDepth;
        [DataMember]
        protected double _nonLinearLengthFirst =0.9;
        [DataMember]
        protected double _nonLinearLengthLast = 0.9;
        [DataMember]
        protected int _IP = 3;
        #endregion

        #region Properties
        public LengthRep RepLength
        {
            get { return _rep; }
            set { _rep = value; }
        }
        public double NonLinearLengthFirst
        {
            get { return _nonLinearLengthFirst; }
            set { _nonLinearLengthFirst = value; }
        }
        public double NonLinearLengthLast
        {
            get { return _nonLinearLengthLast; }
            set { _nonLinearLengthLast = value; }
        }
        public int IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        #endregion

        #region Constructors
        public NonLinearBeams()
        {

        }
        #endregion

        #region Members
        public override List<IPlasticElement> GetPlasticElements(RegularFrameElement element)
        {
            if (element.Childs.Any(x => x.Representation == PlasticHingeApproach.NolinearBeamColumn))
                return element.Childs.Where(x => x.Representation == PlasticHingeApproach.NolinearBeamColumn).Cast<IPlasticElement>().ToList();

            return base.GetPlasticElements(element);
        }
        protected void WriteNonLinearSegment(StreamWriter file, FrameTwoNodesElement child , ref int min, ref int max , ref int MaxSecId, ref int MaxMatId)
        {
            UpdateIdsRanges(child.ID, ref min, ref max);
            file.WriteLine(string.Format("element nonlinearBeamColumn {0} {1} {2} {3} {4} 1", child.ID, child.StartNode.ID
                , child.EndNode.ID, _IP, child.Family.WriteSection(file, -1, ref MaxSecId, ref MaxMatId)));
        }
        public override void WriteNonLinearBeamSegments(StreamWriter file, RegularFrameElement element, ref int min, ref int max , ref int MaxSecId, ref int MaxMaterialId)
        {
            foreach (var child in element.Childs.Where(x => x.Representation == PlasticHingeApproach.NolinearBeamColumn))
            {
                WriteNonLinearSegment(file, child , ref min , ref max , ref MaxSecId , ref MaxMaterialId);
            }
        }
        public override void AddIntermediateNodes(List<Node> list, double depth, FEM_Axe axe, double StartAdjDepth, double EndAdjDepth)
        {
            int n = list.Count;
            if (n > 2)
            {
                AddIntermediateNode(list[0], list[1], depth, axe, _nonLinearLengthFirst);
                AddIntermediateNode(list[n - 1], list[n - 2], depth, axe, _nonLinearLengthLast);
            }
            else
            {
                AddIntermediateNode(list[n - 1], list[n - 2], depth, axe);
            }
            axe.SortNodes();
        }
        private void AddIntermediateNode(Node StartNode, Node EndNode , double depth, FEM_Axe axe , double nonlinearLength )
        {
            double elmentLength = EndNode.Point.DistanceTo(StartNode.Point);
            Vector2D v = (EndNode.Point - StartNode.Point).Normalize();
            double length = Math.Min(elmentLength,
                _rep == LengthRep.RelativeToDepth ? nonlinearLength * depth : nonlinearLength * elmentLength);
            axe.AddNode(StartNode.Point + v * length);
        }
        private void AddIntermediateNode(Node StartNode, Node EndNode, double depth, FEM_Axe axe)
        {
            double elmentLength = EndNode.Point.DistanceTo(StartNode.Point);
            Vector2D v = (EndNode.Point - StartNode.Point).Normalize();
            double length1 = Math.Min(elmentLength,
                _rep == LengthRep.RelativeToDepth ? _nonLinearLengthFirst * depth : _nonLinearLengthFirst * elmentLength);
            double length2 = Math.Min(elmentLength,
                _rep == LengthRep.RelativeToDepth ? _nonLinearLengthLast * depth : _nonLinearLengthLast * elmentLength);

            double length = (EndNode.Point.DistanceTo(StartNode.Point));
            double sum = (length1 + length2);
            if (sum > length+ 1e-9)
            {
                sum /= length;
                length1 /= sum;
                length2 /= sum;
            }
            axe.AddNode(StartNode.Point + v * length1);
            axe.AddNode(EndNode.Point - v * length2);
        }

        public override void CreateElasticSegments(RegularFrameElement element)
        {
            var list = element.Nodes;
            int n = list.Count;
            if (_nonLinearLengthFirst < 1e-9)
            {
                element.Childs.Add(new FrameTwoNodesElement(list[0], list[1], element.Family, PlasticHingeApproach.None));
            }
            CreateIntermediateSegmentsAs(element, PlasticHingeApproach.None);
            if (_nonLinearLengthLast < 1e-9)
            {
                element.Childs.Add(new FrameTwoNodesElement(list[n - 2], list[n - 1], element.Family, PlasticHingeApproach.None));
            }
        }
        public override void CreateNonLinearBeamSegments(RegularFrameElement element)
        {
            var list = element.Nodes;
            int n = list.Count;
            if (_nonLinearLengthFirst > 1e-9)
            {
                element.Childs.Add(new FrameTwoNodesElement(list[0], list[1] , element.Family , PlasticHingeApproach.NolinearBeamColumn ));
            }
            if (_nonLinearLengthLast > 1e-9)
            {
                element.Childs.Add(new FrameTwoNodesElement(list[n-2], list[n-1], element.Family, PlasticHingeApproach.NolinearBeamColumn));
            }

        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class FiberPlasticSections : FrameElementNumericalModel
    {
        #region Members
        [DataMember]
        protected EndFiberDistance _endsDistance = EndFiberDistance.Zero;
        [DataMember]
        protected bool _addStart = true;
        [DataMember]
        protected double _startLp = 0.5;
        [DataMember]
        protected bool _addEnd = true ;
        [DataMember]
        protected double _endLp =0.5;
        [DataMember]
        protected double[] _relativePositions;
        [DataMember]
        protected double[] _Lps;
        #endregion

        #region Properties
        public EndFiberDistance EndsDistance
        {
            get { return _endsDistance; }
            set { _endsDistance = value; }
        }
        public bool AddStart
        {
            get { return _addStart; }
            set { _addStart = value; }
        }
        public bool AddEnd
        {
            get { return _addEnd; }
            set { _addEnd = value; }
        }
        public double StartLp
        {
            get { return _startLp; }
            set { _startLp = value; }
        }
        public double EndLp
        {
            get { return _endLp; }
            set { _endLp = value; }
        }
        public double[] AdditionalRelativePositions
        {
            get { return _relativePositions; }
            set { _relativePositions = value; }
        }
        public double[] AdditionalLengths
        {
            get { return _Lps; }
            set { _Lps = value; }
        }
        #endregion

        #region Constructors
        public FiberPlasticSections()
        {

        }
        #endregion

        #region Members
        public override List<IPlasticElement> GetPlasticElements(RegularFrameElement element)
        {
            if (element.PlasticHinges.Any())
                return element.PlasticHinges.Cast<IPlasticElement>().ToList();

            return base.GetPlasticElements(element);
        }
        public virtual void CreatePlasticSegments(RegularFrameElement element, double StartAdjDepth , double EndAdjDepth)
        {
            element.PlasticHinges = new List<PlasticHinge>();
            var nodes = element.Nodes;
            double snapDistance = GetSnapLength(nodes.First().Point.DistanceTo(nodes.Last().Point)) ;

            for (int i = 0; i < element.Nodes.Count - 1; i++)
            {
                Node node1 = element.Nodes[i];
                Node node2 = element.Nodes[i + 1];
                double distance = node1.Point.DistanceTo(node2.Point);
                if (distance < snapDistance || Math.Abs(distance - snapDistance) < 1e-9)
                {
                    element.PlasticHinges.Add(new PlasticHinge(node1, node2, element.Family, distance/element.Family.Section.D));
                }
            }
        }
        private double GetSnapLength(double ElementLength)
        {
            return ElementLength / SPSW_Simple_Model.RotationalStiffnessRatio;
        }
        public List<double[]> GetFibersData(List<Node> list, double depth, FEM_Axe axe, double StartAdjDepth, double EndAdjDepth, out double snapDistance)
        {
            Point2D start = list.First().Point;
            Point2D end = list.Last().Point;
            double Length = start.DistanceTo(end);
            snapDistance = GetSnapLength(Length);
            return GetFibersData(list, Length, depth, StartAdjDepth, EndAdjDepth);
        }
        public List<Point2D[]> GetIntermediatedPoints(List<Node> list, double depth, FEM_Axe axe, double StartAdjDepth, double EndAdjDepth)
        {
            Point2D start = list.First().Point;
            Point2D end = list.Last().Point;
            Vector2D v = (end - start).Normalize();
            double Length = start.DistanceTo(end);
            double snapDistance;
            List<double[]> FibersData = GetFibersData(list, depth, axe, StartAdjDepth, EndAdjDepth, out snapDistance);
            if (FibersData == null)
                return null;
            List<Point2D[]> intermediatePoints = new List<Point2D[]>();
            foreach (var fiberData in FibersData)
            {
                double distance = fiberData[0];
                Point2D[] points = new Point2D[2];
                points[0] = start + v * distance;
                if (distance < 0.5 * Length)
                {
                    points[1] = start + v * (distance + snapDistance);
                }
                else
                {
                    points[1] = start + v * (distance - snapDistance);
                }
                intermediatePoints.Add(points);
            }
            return intermediatePoints;
        }
        public override void CreateElasticSegments(RegularFrameElement element)
        {
            var nodes = element.Nodes;
            double snapDistance = GetSnapLength(nodes.First().Point.DistanceTo(nodes.Last().Point));

            for (int i = 0; i < element.Nodes.Count - 1; i++)
            {
                Node node1 = element.Nodes[i];
                Node node2 = element.Nodes[i + 1];
                if (node1.Point.DistanceTo(node2.Point)>snapDistance + 1e-9)
                {
                    element.Childs.Add(new FrameTwoNodesElement(node1, node2, element.Family, PlasticHingeApproach.None));
                }
            }

        }    

        public override void AddIntermediateNodes(List<Node> list, double depth, FEM_Axe axe, double StartAdjDepth, double EndAdjDepth)
        {
            List<Point2D[]> intermediatePoints = GetIntermediatedPoints(list, depth, axe, StartAdjDepth, EndAdjDepth);
            if (intermediatePoints == null)
                return;
            foreach (var innerSegmenet in intermediatePoints)
            {
                axe.AddNode(innerSegmenet[0]);
                axe.AddNode(innerSegmenet[1]);
            }
            axe.SortNodes();
        }
        private List<double[]> GetFibersData(List<Node> NodeList, double Length, double depth, double StartAdjDepth, double EndAdjDepth)
        {
            List<double[]> FibersData = new List<double[]>();
            List<double> SnapDistances = new List<double>();
            for (int i = 0; i < NodeList.Count; i++)
            {
                SnapDistances.Add(NodeList[i].Point.DistanceTo(NodeList[0].Point));
            }
            int n = SnapDistances.Count;
            double endSegmentLength = SnapDistances[n - 1]- SnapDistances[n - 2];
            double startSegmentLength = SnapDistances[1];
            double startFiberDist = 0;
            double endFiberDist = Length;
            if (_addStart)
            {
                switch (_endsDistance)
                {
                    case EndFiberDistance.Depth:
                        startFiberDist += Math.Min(0.5 * depth, startSegmentLength);
                        break;
                    case EndFiberDistance.DepthAndConnection:
                        startFiberDist += Math.Min(0.5 * (depth + StartAdjDepth), startSegmentLength);
                        break;
                }
            }
            if (_addEnd)
            {
                switch (_endsDistance)
                {
                    case EndFiberDistance.Depth:
                        endFiberDist -= Math.Min(0.5 * depth, endSegmentLength);
                        break;
                    case EndFiberDistance.DepthAndConnection:
                        endFiberDist -= Math.Min(0.5 * (depth + EndAdjDepth), endSegmentLength);
                        break;
                }
            }
            if (startFiberDist + depth > endFiberDist - depth)
                return null; // one segment too stiff

            double snapDistance = GetSnapLength(Length);

            if (_addStart)
            {
                AddNewFiberData(FibersData, startFiberDist, _startLp, SnapDistances, snapDistance);
            }
            if (_addEnd)
            {
                AddNewFiberData(FibersData, endFiberDist, _endLp, SnapDistances, snapDistance);
            }

            if (_relativePositions != null && _Lps != null)
            {
                for (int i = 0; i < _relativePositions.Length; i++)
                {
                    AddNewFiberData(FibersData, _relativePositions[i] * Length, _Lps[i], SnapDistances, snapDistance);
                }
            }

            return FibersData;
        }
        private void AddNewFiberData(List<double[]> fibersData, double DistanceFromStart , double Lp , List<double> SnapDistances, double snapLength )
        {
            foreach (double snapDistance in SnapDistances)
            {
                if (Math.Abs(snapDistance - DistanceFromStart) < snapLength)
                {
                    DistanceFromStart = snapDistance;
                }
            }
            foreach (var fiberData in fibersData)
            {
                if (Math.Abs(fiberData[0] - DistanceFromStart) < snapLength)
                {
                    fiberData[1] = Math.Max(fiberData[1], Lp);
                    return;
                }
            }
            fibersData.Add(new double[] { DistanceFromStart , Lp});
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class BeamWithHingesModel : FrameElementNumericalModel
    {
        #region Members
        [DataMember]
        protected LengthRep _rep = LengthRep.RelativeToDepth;
        [DataMember]
        protected double _endsLength = 0.9;
        [DataMember]
        protected double _intermediateLength = 0.1;
        #endregion

        #region Properties
        public LengthRep RepLength
        {
            get { return _rep; }
            set { _rep = value; }
        }
        public double EndsLength
        {
            get { return _endsLength; }
            set { _endsLength = value; }
        }
        public double IntermediateLength
        {
            get { return _intermediateLength; }
            set { _intermediateLength = value; }
        }
        #endregion

        #region Constructors
        public BeamWithHingesModel()
        {

        }
        #endregion

        #region Methods
        protected void WriteBeamWithHingesSegment(StreamWriter file, FrameTwoNodesElement child , double SLP , double ELP, ref int min, ref int max, ref int MaxSecId, ref int MaxMatId)
        {
            UpdateIdsRanges(child.ID, ref min, ref max);
            int secTag = child.Family.WriteSection(file, -1, ref MaxSecId, ref MaxMatId);
            FrameElementFamily fam = child.Family;
            Section sec = fam.Section;
            double A = sec.A * fam.AreaModifier;
            double Iz = sec.Ix * fam.IntertiaModifier; /*+ sec.Iy*/
            file.WriteLine(string.Format("element beamWithHinges {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} 1;"
                , child.ID, child.StartNode.ID, child.EndNode.ID , secTag, SLP, secTag, ELP,child.Family.E, A, Iz));
            
        }
        public void GetHingesDistances(FrameTwoNodesElement child , bool start , bool end, out double SLP, out double Elp)
        {
            double length = child.GetLength();
            double factor = length;
            switch (_rep)
            {
                case LengthRep.RelativeToDepth:
                    factor = Math.Min(factor, child.Family.Section.D);
                    break;
            }
            SLP = start ? _endsLength * factor : _intermediateLength * factor;
            Elp = end ? _endsLength * factor : _intermediateLength * factor;
            double sum = (SLP + Elp);
            if (sum > length + 1e-9)
            {
                sum /= length;
                SLP /= sum;
                Elp /= sum;
            }
        }
        public override void WriteBeamHingSegments(StreamWriter file, RegularFrameElement element, ref int min, ref int max, ref int MaxSecId, ref int MaxMaterialId)
        {
            Point2D start = element.Nodes.First().Point;
            Point2D end = element.Nodes.Last().Point;
            foreach (var child in element.Childs.Where(x => x.Representation == PlasticHingeApproach.BeamWithHinges))
            {
                double SLP;
                double Elp;
                GetHingesDistances(child , child.StartNode.Point.DistanceTo(start) < 1e-9 
                    , child.EndNode.Point.DistanceTo(end) < 1e-9, out SLP, out Elp);
                WriteBeamWithHingesSegment(file, child ,SLP , Elp , ref min, ref max, ref MaxSecId, ref MaxMaterialId);
            }
        }
        public override void CreateElasticSegments(RegularFrameElement element)
        {
            if (Math.Abs(_endsLength) < 1e-9 && Math.Abs(_intermediateLength) < 1e-9)
            {
                CreateAllSegmentsAs(element, PlasticHingeApproach.None);
            }
            else if(Math.Abs(_intermediateLength) < 1e-9)
            {
                CreateIntermediateSegmentsAs(element, PlasticHingeApproach.None);
            }  
        }
        public override void CreateBeamHingSegments(RegularFrameElement element)
        {
            if (Math.Abs(_endsLength) > 1e-9 && Math.Abs(_intermediateLength) > 1e-9)
            {
                CreateAllSegmentsAs(element, PlasticHingeApproach.BeamWithHinges);
            }
            else if (Math.Abs(_endsLength) > 1e-9)
            {
                CreateIntermediateSegmentsAs(element, PlasticHingeApproach.BeamWithHinges);
            }
        }
        public override List<IPlasticElement> GetPlasticElements(RegularFrameElement element)
        {
            if (element.Childs.Any(x => x.Representation == PlasticHingeApproach.BeamWithHinges))
                return element.Childs.Where(x => x.Representation == PlasticHingeApproach.BeamWithHinges).Cast<IPlasticElement>().ToList();

            return base.GetPlasticElements(element);
        }
        #endregion
    }

}
