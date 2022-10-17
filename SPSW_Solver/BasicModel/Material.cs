using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SPSW_Solver.BasicModel
{
    public enum MaterialBehaviorType
    {
        ElasticMaterial,
        ElasticPerfectlyPlasticMaterial,
        Steel01,
        HystereticMaterial
    }
    public enum MaterialCurve
    {
        StressAndStrain,
        AngleAndMoment
    }
    public enum MaterialType
    {
        Generic,
        NoCompression,
        TensionCompressionSymmetric
    }
    [DataContract(IsReference = true)]
    public class MaterialBasicData
    {
        #region Members

        [DataMember]
        protected string _name = "New Material";
        [DataMember]
        protected double _density = 0.2836;
        [DataMember]
        protected double _E = 29000;
        [DataMember]
        protected double _Nu = 0.3;
        [DataMember]
        protected MaterialType _type = MaterialType.Generic;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Density
        {
            get { return _density; }
            set { _density = value; }
        }
        public double E
        {
            get { return _E; }
            set { _E = value; }
        }
        
        public double Nu
        {
            get { return _Nu; }
            set { _Nu = value; }
        }
        public double Gs
        {
            get { return _E / (2 * (1 + _Nu)); }
        }
        public MaterialType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion

        #region Constructor
        public MaterialBasicData()
        {

        }
        public MaterialBasicData(MaterialBasicData other)
        {
            _density = other.Density;
            _E = other.E;
            _Nu = other.Nu;
            _type =other.Type;
        }
        #endregion

    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(ElasticMaterial))]
    [KnownType(typeof(ElasticPerfectlyPlasticMaterial))]
    [KnownType(typeof(Steel01Material))]
    [KnownType(typeof(HystereticMaterial))]
    public abstract class Material
    {
        #region Members
        [DataMember]
        protected MaterialBasicData _basicData;
        [DataMember]
        protected int _AnalysisID = 0;
        #endregion

        #region Properties
        public int AnalysisID
        {
            get { return _AnalysisID ; }
            set { _AnalysisID = value; }
        }
        public MaterialBasicData BasicData
        {
            get { return _basicData; }
            set { _basicData = value; }
        }
        #endregion

        #region Constructors
        public Material()
        {

        }
        #endregion

        #region Methods

        public virtual double GetfyPos()
        {
            return 0.0;
        }
        public virtual double GetfyNeg()
        {
            return 0.0;
        }
        public virtual double Getdy_Tension()
        {
            return 0.0;
        }
        public virtual double Getdy_Compression()
        {
            return 0.0;
        }
        public virtual double GetdU_Tension()
        {
            return 0.0;
        }
        public virtual double GetdU_Compression()
        {
            return 0.0;
        }
        public virtual double Getdmax_Tension()
        {
            return 0.0;
        }
        public virtual double Getdmax_Compression()
        {
            return 0.0;
        }
        public virtual Material Scale( double dx , double dy)
        {
            return null;
        }
        public virtual int WriteMaterial(StreamWriter file, int id)
        {
            return id;
        }

        public bool IsInRange(double v, double a, double b)
        {
            if (Math.Abs(a - b) < 1e-9)
                return false;
            if (Math.Abs(a - v) < 1e-9)
                return true;
            if (Math.Abs(b - v) < 1e-9)
                return true;
            double min = Math.Min(a, b);
            double max = Math.Max(a, b);
            return v > min && v < max;
        }
        internal Color GetColorByStrain(double strain)
        {
            if (this.BasicData.Type == MaterialType.NoCompression )
            { 
                if(strain < 0.0)
                    return RenderOptions.initStessColor;
            }
            if (IsInRange(strain, Getdy_Compression(), Getdy_Tension()))
                return RenderOptions.initStessColor;
            if (IsInRange(strain, Getdy_Compression(), GetdU_Compression()) || IsInRange(strain, Getdy_Tension(), GetdU_Tension()))
                return RenderOptions.ElasticLimitColor;
            if (IsInRange(strain, GetdU_Compression(), Getdmax_Compression()) || IsInRange(strain, GetdU_Tension(), Getdmax_Tension()))
                return RenderOptions.UltimateLimitColor;
           return RenderOptions.FailureLimitColor;
        }
        #endregion

    }

    [DataContract(IsReference = true)]
    public class ElasticMaterial : Material
    {
        #region Members
        [DataMember]
        protected double _eta = 0.0;
        [DataMember]
        protected double _Eneg = 0.0;
        [DataMember]
        protected double _dyPositive = 0.0;
        [DataMember]
        protected double _dyNegative = 0.0;
        #endregion

        #region Properties
        public double Eta
        {
            get { return _eta; }
            set { _eta = value; }
        }
        public double Enegative
        {
            get { return _Eneg; }
            set { _Eneg = value; }
        }
        public double DyPositive
        {
            get { return _dyPositive; }
            set { _dyPositive = value; }
        }
        public double DyNegative
        {
            get { return _dyNegative; }
            set { _dyNegative = value; }
        }
        #endregion

        #region Constructor
        public ElasticMaterial()
        {

        }
        public static ElasticMaterial CreateNoCompresstionMaterial(MaterialBasicData basicData, double dy, double eta = 0.0)
        {
            ElasticMaterial result = new ElasticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.NoCompression;

            result._dyPositive = dy;
            result._eta = eta;
            result._Eneg = 0.0;
            result._dyNegative = 0.0;

            return result;
        }
        public static ElasticMaterial CreateSymmetricMaterial(MaterialBasicData basicData, double dy, double eta = 0.0)
        {
            ElasticMaterial result = new ElasticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.TensionCompressionSymmetric;

            result._dyPositive = dy;
            result._eta = eta;
            result._Eneg = result._basicData.E;
            result._dyNegative = -1 * dy;

            return result;
        }
        public static ElasticMaterial CreateGenericMaterial(MaterialBasicData basicData, double dyPos, double dyNeg, double Eneg, double eta = 0.0)
        {
            ElasticMaterial result = new ElasticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.Generic;

            result._dyPositive = dyPos;
            result._eta = eta;
            result._Eneg = Eneg;
            result._dyNegative = dyNeg;

            return result;
        }
        #endregion

        #region Methods
        public override double GetfyPos()
        {
            return _dyPositive * _basicData.E;
        }
        public override double GetfyNeg()
        {
            return _dyNegative * Enegative;
        }
        public override double Getdy_Tension()
        {
            return _dyPositive;
        }
        public override double Getdy_Compression()
        {
            return _dyNegative;
        }
        public override double GetdU_Tension()
        {
            return _dyPositive;
        }
        public override double GetdU_Compression()
        {
            return _dyNegative;
        }
        public override double Getdmax_Tension()
        {
            return _dyPositive;
        }
        public override double Getdmax_Compression()
        {
            return _dyNegative;
        }
        public override int WriteMaterial(StreamWriter file, int id)
        {
            double E = _basicData.E;
            if (_basicData.Type == MaterialType.NoCompression)
            {
                Curve3Points points = Curve3Points.init();
                double Y1 = E * _dyPositive;
                file.WriteLine(string.Format("uniaxialMaterial Hysteretic {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}; "
               , id
               , 0.25*Y1, 0.25*_dyPositive
               , 0.5*Y1, 0.5*_dyPositive 
               , Y1, _dyPositive
               , points.P1.Y, points.P1.X
               , points.P2.Y, points.P2.X
               , points.P3.Y, points.P3.X
               , 1, 1e-9, 0, 0));
                file.WriteLine(string.Format("uniaxialMaterial MinMax {0} {1} -min {2} -max {3}", id + 1, id, double.MinValue, _dyPositive));
            }
            else
            {
                file.WriteLine(string.Format("uniaxialMaterial Elastic {0} {1} {2} {3};",id,E,_eta,_Eneg));
                file.WriteLine(string.Format("uniaxialMaterial MinMax {0} {1} -min {2} -max {3};", id+1, id ,_dyNegative , _dyPositive));
            }
            _AnalysisID = id + 1;
            return id+1;
        }
        public override Material Scale(double dx, double dy)
        {
            ElasticMaterial copy = new ElasticMaterial();
            copy._basicData = new MaterialBasicData(_basicData);
            copy._eta = _eta;
            copy._basicData.E *= dy;
            copy._Eneg = _Eneg * dy;
            copy._dyNegative = _dyNegative * dx;
            copy._dyPositive = _dyPositive * dx;
            return copy;
        }
        #endregion
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(Steel01Material))]
    public class ElasticPerfectlyPlasticMaterial:Material
    {
        #region Members
        [DataMember]
        protected double _dyPositive = 0.0;
        [DataMember]
        protected double _dyNegative = 0.0;
        [DataMember]
        protected double _duPositive = 0.0;
        [DataMember]
        protected double _duNegative = 0.0;
        #endregion

        #region Properties
        public double DyPositive
        {
            get { return _dyPositive; }
            set { _dyPositive = value; }
        }
        public double DyNegative
        {
            get { return _dyNegative; }
            set { _dyNegative = value; }
        }
        public double DuPositive
        {
            get { return _duPositive; }
            set { _duPositive = value; }
        }
        public double DuNegative
        {
            get { return _duNegative; }
            set { _duNegative = value; }
        }
        #endregion

        #region Constructor
        public ElasticPerfectlyPlasticMaterial()
        {

        }
        public static ElasticPerfectlyPlasticMaterial CreateNoCompresstionMaterial(MaterialBasicData basicData , double dy, double du)
        {
            ElasticPerfectlyPlasticMaterial result = new ElasticPerfectlyPlasticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.NoCompression;

            result._dyPositive = dy;
            result._duPositive = du;
                    
            result._dyNegative = 0.0;
            result._duNegative = 0.0;
            return result;
        }
        public static ElasticPerfectlyPlasticMaterial CreateSymmetricMaterial(MaterialBasicData basicData, double dy, double du)
        {
            ElasticPerfectlyPlasticMaterial result = new ElasticPerfectlyPlasticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.TensionCompressionSymmetric;

            result._dyPositive = dy;
            result._duPositive = du;
                    
            result._dyNegative = -1 * dy;
            result._duNegative = -1 * du;
            return result;
        }
        public static ElasticPerfectlyPlasticMaterial CreateGenericMaterial(MaterialBasicData basicData, double dyPos, double duPos, double dyNeg, double duNeg)
        {
            ElasticPerfectlyPlasticMaterial result = new ElasticPerfectlyPlasticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.Generic;

            result._dyPositive = dyPos;
            result._duPositive = duPos;

            result._dyNegative = dyNeg;
            result._duNegative = duNeg;
            return result;
        }
        #endregion

        #region Methods
        public override double GetfyPos()
        {
            return _dyPositive * _basicData.E;
        }
        public override double GetfyNeg()
        {
            return _dyNegative * _basicData.E;
        }
        public override double Getdy_Tension()
        {
            return _dyPositive;
        }
        public override double Getdy_Compression()
        {
            return _dyNegative;
        }
        public override double GetdU_Tension()
        {
            return _duPositive;
        }
        public override double GetdU_Compression()
        {
            return _duNegative;
        }
        public override double Getdmax_Tension()
        {
            return _duPositive;
        }
        public override double Getdmax_Compression()
        {
            return _duNegative;
        }
        public override int WriteMaterial(StreamWriter file, int id)
        {
            double E = _basicData.E;
            if (_basicData.Type == MaterialType.NoCompression)
            {
                Curve3Points points = Curve3Points.init();
                double Y1 = E * _dyPositive;
                file.WriteLine(string.Format("uniaxialMaterial Hysteretic {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}; "
               , id
               , Y1, _dyPositive
               , Y1, 0.5 * (_dyPositive + _duPositive)
               , Y1, _duPositive
               , points.P1.Y, points.P1.X
               , points.P2.Y, points.P2.X
               , points.P3.Y, points.P3.X
               , 1, 1e-9, 0, 0));
                file.WriteLine(string.Format("uniaxialMaterial MinMax {0} {1} -min {2} -max {3}", id + 1, id, double.MinValue, _duPositive));
            }
            else
            {
                file.WriteLine(string.Format("uniaxialMaterial ElasticPP {0} {1} {2} {3};", id, _basicData.E, _dyPositive , _dyNegative, 0.0));
                file.WriteLine(string.Format("uniaxialMaterial MinMax {0} {1} -min {2} -max {3};", id + 1, id, _duNegative, _duPositive));
            }
            _AnalysisID = id + 1;
            return id+1;
        }
        public override Material Scale(double dx, double dy)
        {
            ElasticPerfectlyPlasticMaterial copy = new ElasticPerfectlyPlasticMaterial();
            copy._basicData = new MaterialBasicData(_basicData);
            copy._basicData.E *= dy;
            copy._dyNegative = _dyNegative * dx;
            copy._dyPositive = _dyPositive * dx;
            copy._duPositive = _duPositive * dx;
            copy._duNegative = _duNegative * dx;
            return copy;
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class Steel01Material : ElasticPerfectlyPlasticMaterial
    {
        #region Members
        [DataMember]
        protected double _b =0.0;
        #endregion

        #region properties
        public double B
        {
            get { return _b; }
            set { _b = value; }
        }
        #endregion

        #region Constructor
        public Steel01Material()
        {

        }
        public static Steel01Material CreateNoCompresstionMaterial(MaterialBasicData basicData , double b, double dy, double du)
        {
            Steel01Material result = new Steel01Material();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.NoCompression;

            result._dyPositive = dy;
            result._duPositive = du;

            result._dyNegative = 0.0;
            result._duNegative = 0.0;

            result._b = b;
            return result;
        }
        public static Steel01Material CreateSymmetricMaterial(MaterialBasicData basicData , double b, double dy, double du)
        {
            Steel01Material result = new Steel01Material();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.TensionCompressionSymmetric;

            result._dyPositive = dy;
            result._duPositive = du;

            result._dyNegative = -1 * dy;
            result._duNegative = -1 * du;

            result._b = b;
            return result;
        }
        public static Steel01Material CreateGenericMaterial(MaterialBasicData basicData, double b, double dyPos, double duPos, double dyNeg, double duNeg)
        {
            Steel01Material result = new Steel01Material();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.Generic;

            result._dyPositive = dyPos;
            result._duPositive = duPos;

            result._dyNegative = dyNeg;
            result._duNegative = duNeg;

            result._b = b;
            return result;
        }
        #endregion

        #region Methods
        public override double GetfyPos()
        {
            return _dyPositive * _basicData.E;
        }
        public override double GetfyNeg()
        {
            return -1 * GetfyPos();
        }
        public override int WriteMaterial(StreamWriter file, int id)
        {
            double E = _basicData.E;
            double Y1 = E * _dyPositive;
            if (_basicData.Type == MaterialType.NoCompression)
            {
                Curve3Points points = Curve3Points.init();
                double Y2 = Y1 + _b * E * (_duPositive - _dyPositive); 
                file.WriteLine(string.Format("uniaxialMaterial Hysteretic {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}; "
               , id
               , Y1, _dyPositive
               , 0.5*(Y1+ Y2), 0.5 * (_dyPositive + _duPositive)
               , Y2, _duPositive
               , points.P1.Y, points.P1.X
               , points.P2.Y, points.P2.X
               , points.P3.Y, points.P3.X
               , 1, 1e-9, 0, 0));
                file.WriteLine(string.Format("uniaxialMaterial MinMax {0} {1} -min {2} -max {3}", id + 1, id, double.MinValue, _duPositive));
            }
            else
            {
                file.WriteLine(string.Format("uniaxialMaterial Steel01 {0} {1} {2} {3};", id, Y1, E, _b));
                file.WriteLine(string.Format("uniaxialMaterial MinMax {0} {1} -min {2} -max {3};", id + 1, id, _duNegative, _duPositive));
            }
            _AnalysisID = id + 1;
            return id+1;
        }
        public override Material Scale(double dx, double dy)
        {
            Steel01Material copy = new Steel01Material();
            copy._basicData = new MaterialBasicData(_basicData);
            copy._basicData.E *= dy;
            copy._b = _b;
            copy._dyNegative = _dyNegative * dx;
            copy._dyPositive = _dyPositive * dx;
            copy._duNegative = _duNegative * dx;
            copy._duPositive = _duPositive * dx;
            return copy;
        }
        #endregion

    }

    [DataContract(IsReference = true)]
    public class Curve3Points
    {
        #region Members
        [DataMember]
        protected Point2D _p1 = new Point2D();
        [DataMember]
        protected Point2D _p2 = new Point2D();
        [DataMember]
        protected Point2D _p3 = new Point2D();
        [DataMember]
        protected double _curveLimit = 0.0;
        #endregion

        #region Properties
        public Point2D P1
        {
            get { return _p1; }
            set { _p1 = value; }
        }
        public Point2D P2
        {
            get { return _p2; }
            set { _p2 = value; }
        }
        public Point2D P3
        {
            get { return _p3; }
            set { _p3 = value; }
        }
        public double CurveLimit
        {
            get { return _curveLimit; }
            set { _curveLimit = value; }
        }
        #endregion

        public Curve3Points()
        {

        }
        public static Curve3Points init()
        {
            double t = -1e-20;
            Curve3Points result = new Curve3Points();
            result._p1 = new Point2D(-0.1, t);
            result._p2 = new Point2D(-0.2, t);
            result._p3 = new Point2D(-0.3, t);
            result._curveLimit = 0.0;
            return result;
        }
        public static Curve3Points CreateNegativeOf(Curve3Points c1)
        {
            Curve3Points result = new Curve3Points();
            result._p1 = new Point2D( -1 * c1.P1.X, -1 * c1.P1.Y);
            result._p2 = new Point2D( -1 * c1.P2.X, -1 * c1.P2.Y);
            result._p3 = new Point2D( -1 * c1.P3.X, -1 * c1.P3.Y);
            result._curveLimit = -1* c1.CurveLimit;
            return result;
        }
        public Point2D GetLastPointPositive()
        {
            if (P2.Y < P3.Y)
            {
                Line2D line1 = new Line2D(P2,P3);
                Line2D line2 = new Line2D(new Point2D(CurveLimit,0) , new Point2D(CurveLimit, 1.00));
                return line1.IntersectWith(line2).Value;
            }
            else
            {
                return new Point2D(CurveLimit, P3.Y);
            }
        }
        public Point2D GetLastPointNegative()
        {
            if (P2.Y > P3.Y)
            {
                Line2D line1 = new Line2D(P2, P3);
                Line2D line2 = new Line2D(new Point2D(CurveLimit, 0), new Point2D(CurveLimit, 1.00));
                return line1.IntersectWith(line2).Value;
            }
            else
            {
                return new Point2D(CurveLimit, P3.Y);
            }
        }
        public List<Point2D> AsVector()
        {
            return new List<Point2D>() { P1,P2,P3};
        }

        private bool IsZeroSection()
        {
            return Math.Abs(_p1.Y) < 1e-9 &&
            Math.Abs(_p1.Y) < 1e-9 &&
            Math.Abs(_p1.Y) < 1e-9;
        }
        internal Point2D GetPointByX(double v , bool positive)
        {
            List<Point2D> points = AsVector();
            if (positive)
            {
                points.Add(GetLastPointPositive());
            }
            else
            {
                points.Add(GetLastPointNegative());
            }
            Line2D line2 = new Line2D(new Point2D(v, 0), new Point2D(v, 1.00));
            for (int i = 0; i < points.Count-1; i++)
            {
                Line2D line1 = new Line2D(points[i], points[i+1]);
                Point2D? p = line1.IntersectWith(line2);
                if (p != null && line1.ClosestPointTo(p.Value,true).DistanceTo(p.Value) < 1e-5)
                {
                    return p.Value;
                }
            }
            return new Point2D();
        }
        internal double GetElasticLimit()
        {
            if(IsZeroSection())
                return 0.0;
            Point2D zeroP = new Point2D();
            LineSegment2D segment = new LineSegment2D(zeroP, _p2);
            if (segment.ClosestPointTo(_p1).DistanceTo(_p1) > 1e-5)
                return _p1.X;

            segment = new LineSegment2D(zeroP, _p3);
            if (segment.ClosestPointTo(_p2).DistanceTo(_p2) > 1e-5)
                return _p2.X;

            return _p3.X;
        }
        internal double GetPlasticLimit()
        {
            if (IsZeroSection())
                return 0.0;
            Point2D zeroP = new Point2D();
            LineSegment2D segment = new LineSegment2D(zeroP, _p2);
            if (segment.ClosestPointTo(_p1).DistanceTo(_p1) > 1e-5)
                return _p2.X;

            return _p3.X;
        }
        public  Curve3Points Scale(double dx, double dy)
        {
            Curve3Points copy = new Curve3Points();
            copy._p1 = new Point2D(_p1.X *dx , _p1.Y * dy);
            copy._p2 = new Point2D(_p2.X * dx, _p2.Y * dy);
            copy._p3 = new Point2D(_p3.X * dx, _p3.Y * dy);
            copy._curveLimit = _curveLimit * dx;
            return copy;
        }
    }
    [DataContract(IsReference = true)]
    public class HystereticMaterial : Material
    {
        #region Members
        [DataMember]
        protected Curve3Points _tensionPart;
        [DataMember]
        protected Curve3Points _compressionPart;
        #endregion

        #region Properties
        public Curve3Points TensionPart
        {
            get { return _tensionPart; }
            set { _tensionPart = value; }
        }
        public Curve3Points CompressionPart
        {
            get { return _compressionPart; }
            set { _compressionPart = value; }
        }
        #endregion

        #region Constructor
        public HystereticMaterial()
        {

        }
        public static HystereticMaterial CreateNoCompresstionMaterial(MaterialBasicData basicData, Curve3Points tensionPart)
        {
            HystereticMaterial result = new HystereticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.NoCompression;
            result._tensionPart = tensionPart;
            result._compressionPart = Curve3Points.init();
            return result;
        }
        public static HystereticMaterial CreateSymmetricMaterial(MaterialBasicData basicData, Curve3Points tensionPart)
        {
            HystereticMaterial result = new HystereticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.TensionCompressionSymmetric;
            result._tensionPart = tensionPart;
            result._compressionPart = Curve3Points.CreateNegativeOf(tensionPart);
            return result;
        }
        public static HystereticMaterial CreateGenericMaterial(MaterialBasicData basicData, Curve3Points tensionPart , Curve3Points compressionPart)
        {
            HystereticMaterial result = new HystereticMaterial();

            result._basicData = basicData;
            result.BasicData.Type = MaterialType.Generic;
            result._tensionPart = tensionPart;
            result._compressionPart = compressionPart;

            return result;
        }
        #endregion

        #region Methods
        public override double GetfyPos()
        {
            return _tensionPart.GetPointByX(Getdy_Tension(),true).Y;
        }
        public override double GetfyNeg()
        {
            return _compressionPart.GetPointByX(Getdy_Compression(), false).Y;
        }
        public override double Getdy_Tension()
        {
            return _tensionPart.GetElasticLimit();
        }
        public override double Getdy_Compression()
        {
            return _compressionPart.GetElasticLimit();
        }
        public override double GetdU_Tension()
        {
            return _tensionPart.GetPlasticLimit();
        }
        public override double GetdU_Compression()
        {
            return _compressionPart.GetPlasticLimit();
        }
        public override double Getdmax_Tension()
        {
            return _tensionPart.CurveLimit;
        }
        public override double Getdmax_Compression()
        {
            return _compressionPart.CurveLimit;
        }
        public override Material Scale(double dx, double dy)
        {
            HystereticMaterial copy = new HystereticMaterial();
            copy._basicData = new MaterialBasicData(_basicData);
            copy._basicData.E *= dy;
            copy._tensionPart = _tensionPart.Scale(dx,dy);
            copy._compressionPart = _compressionPart.Scale(dx, dy);
            return copy;
        }
        public override int WriteMaterial(StreamWriter file, int id)
        {
            if (_basicData.Type == MaterialType.NoCompression)
            {
                file.WriteLine(string.Format("uniaxialMaterial Hysteretic {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}; "
               , id
               , _tensionPart.P1.Y, _tensionPart.P1.X
               , _tensionPart.P2.Y, _tensionPart.P2.X
               , _tensionPart.P3.Y, _tensionPart.P3.X
               , _compressionPart.P1.Y, _compressionPart.P1.X
               , _compressionPart.P2.Y, _compressionPart.P2.X
               , _compressionPart.P3.Y, _compressionPart.P3.X
               , 1, 1e-9, 0, 0));
                file.WriteLine(string.Format("uniaxialMaterial MinMax {0} {1} -min {2} -max {3}", id + 1, id, double.MinValue, _tensionPart.CurveLimit));
            }
            else
            {
                file.WriteLine(string.Format("uniaxialMaterial Hysteretic {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}; "
                 , id
                 , _tensionPart.P1.Y, _tensionPart.P1.X
                 , _tensionPart.P2.Y, _tensionPart.P2.X
                 , _tensionPart.P3.Y, _tensionPart.P3.X
                 , _compressionPart.P1.Y, _compressionPart.P1.X
                 , _compressionPart.P2.Y, _compressionPart.P2.X
                 , _compressionPart.P3.Y, _compressionPart.P3.X
                 , 1, 1, 0, 0));
                file.WriteLine(string.Format("uniaxialMaterial MinMax {0} {1} -min {2} -max {3}", id + 1, id, _compressionPart.CurveLimit, _tensionPart.CurveLimit));
            }
            _AnalysisID = id + 1;
            return id+1;
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class PlasticHingeProperties
    {
        [DataMember]
        protected bool _absoluteValue =true;
        [DataMember]
        protected double _a = 0.02;
        [DataMember]
        protected double _b = 0.04;
        [DataMember]
        private Dictionary<string, double> _properties = new Dictionary<string, double>();

        public Dictionary<string, double> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }
        public double A
        {
            get { return _a; }
            set { _a = value; }
        }
        public double B
        {
            get { return _b; }
            set { _b = value; }
        }
        public bool AbsoluteValue
        {
            get { return _absoluteValue; }
            set { _absoluteValue = value; }
        }

        public PlasticHingeProperties()
        {

        }
        public static PlasticHingeProperties init()
        {
            PlasticHingeProperties res = new PlasticHingeProperties();
            res._properties = new Dictionary<string, double>();
            res._properties.Add("LS", 1000.0);       //  basic strength deterioration (a very large # = no cyclic deterioration)
            res._properties.Add("LK", 1000.0);       //  unloading stiffness deterioration (a very large # = no cyclic deterioration)
            res._properties.Add("LA", 1000.0);       //  accelerated reloading stiffness deterioration (a very large # = no cyclic deterioration)
            res._properties.Add("LD", 1000.0);       //  post-capping strength deterioration (a very large # = no deterioration)
            res._properties.Add("cS", 1.0);          //  exponent for basic strength deterioration (c = 1.0 for no deterioration)
            res._properties.Add("cK", 1.0);          //  exponent for unloading stiffness deterioration (c = 1.0 for no deterioration)
            res._properties.Add("cA", 1.0);          //  exponent for accelerated reloading stiffness deterioration (c = 1.0 for no deterioration)
            res._properties.Add("cD", 1.0);          //  exponent for post-capping strength deterioration (c = 1.0 for no deterioration)
            res._properties.Add("th_pP", 0.025);     //  plastic rot capacity for pos loading
            res._properties.Add("th_pN", 0.025);     //  plastic rot capacity for neg loading
            res._properties.Add("th_pcP", 0.3);      //  post-capping rot capacity for pos loading
            res._properties.Add("th_pcN", 0.3);      //  post-capping rot capacity for neg loading
            res._properties.Add("ResP", 0.4);        //  residual strength ratio for pos loading
            res._properties.Add("ResN", 0.4);        //  residual strength ratio for neg loading
            res._properties.Add("th_uP", 0.4);       //  ultimate rot capacity for pos loading
            res._properties.Add("th_uN", 0.4);       //  ultimate rot capacity for neg loading
            res._properties.Add("DP", 1.0);          //  rate of cyclic deterioration for pos loading
            res._properties.Add("DN", 1.0);			//  rate of cyclic deterioration for neg loading
            return res;
        }

        public string Write()
        {
            string result = "";
            foreach (double v in Properties.Values)
            {
                result += string.Format(" {0}", v);
            }
            return result;
        }
    }

}
