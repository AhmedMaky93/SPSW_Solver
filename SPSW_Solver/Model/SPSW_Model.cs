using BasicModel;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using SPSW_Solver.BasicModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SPSW_Solver.Model
{
    public enum DesignApproach
    {
        AISC_Tension_Field_Angle,
        cardiff,
        Basler,
        UserDefined
    }
    public enum SeismicityLevel
    {
        High,
        Medium,
        Low
    }
    public enum AnalysisMethod
    {
        Monotonic_Pushover_Analysis,
        Cyclic_Pushover,
        Time_History_Dynamic_Analysis
    }
    public enum PushOverApproach
    {
        SMP,
        AFMP
    }
    public enum PushOverProfile
    {
        SingleTop,
        Uniform,
        StaticEquivalent,
        Generic
    }
    public enum System
    {
        BandGeneral,
        BandSPD,
        ProfileSPD,
        SparseGEN,
        UmfPack,
        FullGeneral,
        SparseSYM,
    }
    public enum Constraints
    {
        Plain,
        Lagrange,
        Penalty,
        Transformation,
    }
    public enum Numberer
    {
        Plain,
        RCM,
        AMD
    }
    public enum PushOverControl
    {
        DisplacementControl,
        LoadControl
    }
    public enum TestType
    {
        NormUnbalance,
        NormDispIncr,
        EnergyIncr,
        RelativeNormUnbalance,
        RelativeNormDispIncr,
        RelativeTotalNormDispIncr,
        RelativeEnergyIncr,
        FixedNumIter
    }
    public enum Integrator
    {
        Central_Difference,
        Newmark_Method,
        HilberHughesTaylor_Method,
        TRBDF2,
        Explicit_Difference,
    }

    [DataContract(IsReference = true)]
    public class FloorHeightGroup
    {
        #region Members
        [DataMember]
        protected double _Height = 144.0;
        [DataMember]
        protected int _startFloorIndex = 0;
        [DataMember]
        protected int _endFloorIndex = 0;
        #endregion

        #region Members
        public double Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        public int StartIndex
        {
            get { return _startFloorIndex; }
            set { _startFloorIndex = value; }
        }
        public int EndIndex
        {
            get { return _endFloorIndex; }
            set { _endFloorIndex = value; }
        }
        public int FloorsCount
        {
            get { return _endFloorIndex - _startFloorIndex + 1; }
        }
        #endregion

        #region Constructor
        public FloorHeightGroup()
        {
        }
        #endregion

        #region Methods
        public bool IsContainingIndex(int index)
        {
            return index >= _startFloorIndex && index <= _endFloorIndex;
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class ModelLayout : ICloneable
    {
        #region Static Members
        public static double MinPanelApsectRatio = 0.7;
        public static double MaxPanelApsectRatio = 2.5;
        #endregion

        #region Members
        [DataMember]
        protected int _floorNo = 5;
        [DataMember]
        protected double _beamWidth = 240.0; //inch;
        [DataMember]
        protected List<FloorHeightGroup> _floorsGroupsHeights = new List<FloorHeightGroup>();
        #endregion

        #region Properties
        public int FloorNo
        {
            get { return _floorNo; }
            set { _floorNo = value; }
        }
        public double BeamWidth
        {
            get { return _beamWidth; }
            set { _beamWidth = value; }
        }
        public List<FloorHeightGroup> FloorsGroupsHeights
        {
            get { return _floorsGroupsHeights; }
            set { _floorsGroupsHeights = value; }
        }
        #endregion

        #region Constructors
        public ModelLayout()
        {

        }
        #endregion

        #region Methods
        public virtual double GetModelWidth()
        {
            return _beamWidth;
        }
        public virtual double GetFloorHeight(int index)
        {
            if (_floorsGroupsHeights == null)
                return 0;
            if (!_floorsGroupsHeights.Any())
                return 0;
            var group = _floorsGroupsHeights.FirstOrDefault(x=>x.IsContainingIndex(index));
            if (group == null)
                return 0;
            return group.Height;
        }
        public virtual double GetMinFloorHeight()
        {
            if (_floorsGroupsHeights == null)
                return 0;
            if (!_floorsGroupsHeights.Any())
                return 0;

            return _floorsGroupsHeights.Min(x=>x.Height);
        }
        public virtual double GetMaxFloorHeight()
        {
            if (_floorsGroupsHeights == null)
                return 0;
            if (!_floorsGroupsHeights.Any())
                return 0;

            return _floorsGroupsHeights.Max(x => x.Height);
        }
        public virtual double GetTotalHeight()
        {
            if (_floorsGroupsHeights == null)
                return 0;
            if (!_floorsGroupsHeights.Any())
                return 0;
            return _floorsGroupsHeights.Sum(x=>x.Height * x.FloorsCount);
        }
        public object Clone()
        {
            return new ModelLayout() {
                FloorNo = this.FloorNo,
                BeamWidth = this.BeamWidth,
                FloorsGroupsHeights = new List<FloorHeightGroup>(this.FloorsGroupsHeights)  
            };
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class BaseProperties
    {
        public static double Tolerance = 1e-9;

        #region Members
        [DataMember]
        protected bool _isFixed = false;
        [DataMember]
        protected double _baseOffset = 0.0;
        #endregion

        #region Properties
        public bool IsFixed
        {
            get { return _isFixed; }
            set { _isFixed = value; ReSetOffset(); }
        }
        public double BaseOffset
        {
            get { return _baseOffset; }
            set {
                    if (!_isFixed)
                    {
                        _baseOffset = Math.Max(0,value);
                    }
                }
        }
        public bool HasOffset
        {
            get { return _baseOffset > Tolerance; }
        }
        #endregion

        #region Constructors
        public BaseProperties()
        {

        }
        #endregion

        private void ReSetOffset()
        {
            if (_isFixed)
            {
                _baseOffset = 0.0;
            }
        }
        public int GetFirstBeamLevelIndex()
        {
            if (HasOffset)
                return 1;

            return 0;
        }
    }
    [DataContract(IsReference = true)]
    public class SolverAanalysisOptions
    {
        #region Members
        [DataMember]
        protected Constraints _constraints = Constraints.Plain;
        [DataMember]
        protected double _alphaS = 1.00;
        [DataMember]
        protected double _alphaM = 1.00;
        [DataMember]
        protected double _tolerance = 1.0e-9;
        [DataMember]
        protected int _maxIter = 100;
        [DataMember]
        protected System _system = System.BandGeneral;
        [DataMember]
        protected Numberer _numberer = Numberer.Plain;
        [DataMember]
        protected TestType _testType = TestType.NormDispIncr;
        #endregion

        #region Properties 
        public Constraints Constraint
        {
            get { return _constraints; }
            set { _constraints = value; }
        }
        public double AlphaS
        {
            get { return _alphaS; }
            set { _alphaS = value; }
        }
        public double AlphaM
        {
            get { return _alphaM; }
            set { _alphaM = value; }
        }
        public double Tolerance
        {
            get { return _tolerance; }
            set { _tolerance = value; }
        }
        public int MaxIter 
        {
            get { return _maxIter; }
            set { _maxIter = value; }
        }
        public System System
        {
            get { return _system; }
            set { _system = value; }
        }
        public Numberer Numberer
        {
            get { return _numberer; }
            set { _numberer = value; }
        }
        public TestType TestType
        {
            get { return _testType; }
            set { _testType = value; }
        }
        #endregion

        #region Constructor
        public SolverAanalysisOptions()
        {

        }
        #endregion

    }

    [DataContract(IsReference = true)]
    public class ModeShapeData
    {
        #region Members
        [DataMember]
        protected int _index = 0;
        [DataMember]
        protected double _lambda = 0;
        [DataMember]
        protected double _omega = 0;
        [DataMember]
        protected double _frequency = 0;
        [DataMember]
        protected double _period = 0;
        [DataMember]
        protected double _mx;
        [DataMember]
        protected double _my;
        [DataMember]
        protected double _mrz;
        [DataMember]
        protected double _sumMx;
        [DataMember]
        protected double _sumMy;
        [DataMember]
        protected double _sumMrz;
        #endregion

        #region Properties
        public int Index
        {
            get { return _index; }
        }
        public double LAMBDA
        {
            get { return _lambda; }
            set { _lambda = value; }
        }
        public double OMEGA
        {
            get { return _omega; }
            set { _omega = value; }
        }
        public double FREQUENCY
        {
            get { return _frequency; }
            set { _frequency = value; }
        }
        public double PERIOD
        {
            get { return _period; }
            set { _period = value; }
        }
        public double MX
        {
            get { return _mx; }
            set { _mx = value; }
        }
        public double MY
        {
            get { return _my; }
            set { _my = value; }
        }
        public double MRZ
        {
            get { return _mrz; }
            set { _mrz = value; }
        }
        public double SumMx
        {
            get { return _sumMx; }
            set { _sumMx = value; }
        }
        public double SumMy
        {
            get { return _sumMy; }
            set { _sumMy = value; }
        }
        public double SumMrz
        {
            get { return _sumMrz; }
            set { _sumMrz = value; }
        }
        #endregion

        #region Constructor
        public ModeShapeData(int index)
        {
            _index = index;
        }
        #endregion
    }

    [DataContract(IsReference = true)]
    public class ModalAnalysisData
    {
        #region Members
        [DataMember]
        protected List<ModeShapeData> _modeShapeData = new List<ModeShapeData>();
        [DataMember]
        protected double _sumMx;
        [DataMember]
        protected double _sumMy;
        [DataMember]
        protected double _sumMrz;
        #endregion

        #region Properties
        public List<ModeShapeData> ModeShapeData
        {
            get { return _modeShapeData; }
            set { _modeShapeData = value; }
        }
        public double SumMx
        {
            get { return _sumMx; }
            set { _sumMx = value; }
        }
        public double SumMy
        {
            get { return _sumMy; }
            set { _sumMy = value; }
        }
        public double SumMrz
        {
            get { return _sumMrz; }
            set { _sumMrz = value; }
        }
        #endregion

        #region Constructors
        public ModalAnalysisData()
        {

        }
        #endregion

    }
    [DataContract(IsReference = true)]
    public class FloorDeadLoad
    {
        [DataMember]
        public double ColumnsLoad;
        [DataMember]
        public double PlatesLoad;
    }

    [DataContract(IsReference = true)]
    public class ResposeSpectrumData
    {
        #region Members
        [DataMember]
        protected double _ts = 0.5;
        [DataMember]
        protected double _tl = 2.00;
        [DataMember]
        protected double _Sds = 0.5;
        [DataMember]
        protected double _Sd1 = 0.35;
        [DataMember]
        protected double _R = 6.0;
        [DataMember]
        protected double _I = 1.0;
        [DataMember]
        protected bool _useTa = false;
        [DataMember]
        protected double _cs = 0.3;
        [DataMember]
        protected double _T = 1.00;
        [DataMember]
        protected double _k = 1.00;
        [DataMember]
        protected PushOverProfile _profile = PushOverProfile.Generic;
        #endregion

        #region Peoperties
        public double Ts
        {
            get { return _ts; }
            set { _ts = value; }
        }
        public double TL
        {
            get { return _tl; }
            set { _tl = value; }
        }
        public double SDs
        {
            get { return _Sds; }
            set { _Sds = value; }
        }
        public double SD1
        {
            get { return _Sd1; }
            set { _Sd1 = value; }
        }
        public double R
        {
            get { return _R; }
            set { _R = value; }
        }
        public double I
        {
            get { return _I; }
            set { _I = value; }
        }
        public double Cs
        {
            get { return _cs; }
            set { _cs = value; }
        }
        public double T
        {
            get { return _T; }
            set { _T = value; }
        }
        public bool UseTa
        {
            get { return _useTa; }
            set { _useTa = value; }
        }
        public PushOverProfile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }
        public double K
        {
            get { return _k; }
            set { _k = value; }
        }
        #endregion

        #region Constructor
        public ResposeSpectrumData()
        {

        }
        #endregion

        #region Methods
        public double GetK(double T)
        {
            if (T < 0.5)
                return 1.0;
            if (T > 2.5)
                return 2.0;

            return 0.5 * T + 0.75; ;
        }
        public void SetTandCs(double H, double Tcomputed)
        {
            _ts = _Sd1 / _Sds;
            double Ta = GetNaturalPeriod(H);
            if (_useTa)
            {
                _T = Ta;
            }
            else
            {
                double Cu = GetCu(_Sd1);
                if (Tcomputed < Ta)
                {
                    _T = Ta;
                }
                else if (Tcomputed > Ta * Cu)
                {
                    _T = Ta * Cu;
                }
                else
                {
                    _T = Tcomputed;
                }
            }
            SetCs(_T);
        }
        private static double GetCu(double sD1)
        {
            if (sD1 < 0.1 || Math.Abs(sD1 - 0.1) < 1.0e-9)
                return 1.7;
            if (sD1 > 0.3 || Math.Abs(sD1 - 0.3) < 1.0e-9)
                return 1.4;

            Dictionary<double, double> result = new Dictionary<double, double>();
            result.Add(1.7, Math.Abs(sD1 - 0.1));
            result.Add(1.6, Math.Abs(sD1 - 0.15));
            result.Add(1.5, Math.Abs(sD1 - 0.2));
            result.Add(1.4, Math.Abs(sD1 - 0.3));
            return result.OrderBy(x => x.Value).First().Key;
        }
        public void SetCs(double T)
        {
            double cs = Math.Max(0.01, 0.044 * _Sds * _I);
            double V = _Sd1 * _I / _R;
            if (T < _tl)
            {
                cs = V / T;
            }
            else
            {
                cs = V * _tl / Math.Pow(T, 2);
            }
            _cs = Math.Min(cs, _Sds * _I / _R);
        }
        public double GetNaturalPeriod(double h)
        {
            return 0.02 * Math.Pow(h, 0.75);
        }
        public double GetResponseWithNaturalPeriod(double h)
        {
            return GetAgResponse(GetNaturalPeriod(h));
        }
        public double GetAgResponse(double t)
        {
            double t0 = 0.2 * _ts;
            double Sd1 = _Sd1 * _I / _R;
            double Sds = _Sds * _I / _R;
            if (t <= t0)
            {
                return (0.4 + 0.6 * t / t0) * Sds;
            }
            else if (t > t0 && t <= _ts)
            {
                return Sds;
            }
            else if (t > _ts && t <= _tl)
            {
                return Sd1 / t;
            }
            else if (t > _tl)
            {
                return Sd1 * _tl / Math.Pow(t, 2);
            }
            return 0.0;
        }
        #endregion

    }
    [DataContract(IsReference = true)]
    public class CyclicLoadRecord
    {
        #region DataMembers
        [DataMember]
        protected double _drift;
        [DataMember]
        protected int _cycles;
        [DataMember]
        protected int _steps;
        #endregion

        #region Properties
        public double Drift
        {
            get { return _drift; }
            set { _drift = value; }
        }
        public int Cycles
        {
            get { return _cycles; }
            set { _cycles = value; }
        }
        public int Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }
        #endregion

        #region Constructors
        public CyclicLoadRecord()
        {

        }
        public CyclicLoadRecord(double drift, int cycles, int steps)
        {
            _drift = drift;
            _cycles = cycles;
            _steps = steps;
        }
        #endregion

    }
    [DataContract(IsReference = true)]
    public class CyclicPushoOver
    {
        #region Members
        [DataMember]
        List<CyclicLoadRecord> _records = new List<CyclicLoadRecord>();
        #endregion

        #region Properties
        public List<CyclicLoadRecord> Records
        {
            get { return _records; }
            set { _records = value; }
        }
        #endregion

        #region Constructor
        public CyclicPushoOver()
        {

        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class TimeHistory_Parameters
    {
        #region Members
        [DataMember]
        protected double _timeStep = 0.02;
        [DataMember]
        protected int _numberOfSteps = 1000;
        [DataMember]
        protected bool _useConstantDamingRatio = true;
        [DataMember]
        protected double _dampingRatio = 0.05;
        [DataMember]
        protected SeismicityLevel _seismicityLevel = SeismicityLevel.Medium;
        [DataMember]
        protected List<string> _groundMotionFilePaths = new List<string>();
        [DataMember]
        protected double _alphaM = 0.0;
        [DataMember]
        protected double _betaK = 0.0005;
        [DataMember]
        protected double _LoadFactor = 10;
        [DataMember]
        protected double _Integrator_Alpha = 0.9;
        [DataMember]
        protected double _Integrator_Beta = 0.5;
        [DataMember]
        protected double _Integrator_Gamma = 0.9;
        [DataMember]
        protected Integrator _integrator = Integrator.Newmark_Method;
        #endregion

        #region Properties
        public double TimpStep
        {
            get { return _timeStep; }
            set { _timeStep = value; }
        }
        public int NumberOfSteps
        {
            get { return _numberOfSteps; }
            set { _numberOfSteps = value; }
        }
        public SeismicityLevel SeismicityLevel
        {
            get { return _seismicityLevel; }
            set { _seismicityLevel = value; }
        }
        public List<string> GroundMotionFilePaths
        {
            get { return _groundMotionFilePaths; }
            set { _groundMotionFilePaths = value; }
        }
        public double AlphaM
        {
            get { return _alphaM; }
            set { _alphaM = value; }
        }
        public double BetaK
        {
            get { return _betaK; }
            set { _betaK = value; }
        }
        public bool UseConstantDamingRatio
        {
            get { return _useConstantDamingRatio; }
            set { _useConstantDamingRatio = value; }
        }
        public double DampingRatio
        {
            get { return _dampingRatio; }
            set { _dampingRatio = value; }
        }
        public double LoadFactor
        {
            get { return _LoadFactor; }
            set { _LoadFactor = value; }
        }
        public double IntegratorAlpha
        {
            get { return _Integrator_Alpha; }
            set { _Integrator_Alpha = value; }
        }
        public double Integrator_Beta
        {
            get { return _Integrator_Beta; }
            set { _Integrator_Beta = value; }
        }
        public double Integrator_Gamma
        {
            get { return _Integrator_Gamma; }
            set { _Integrator_Gamma = value; }
        }
        public Integrator Integrator
        {
            get { return _integrator; }
            set { _integrator = value; }
        }
        #endregion

        #region Constructors
        public TimeHistory_Parameters()
        {

        }
        #endregion

        #region Methods

        #endregion
    }
    [DataContract(IsReference = true)]
    public class LateralProfilePushOverParameters
    {
        #region Members
        [DataMember]
        protected int _numOfSteps = 1000;
        [DataMember]
        protected double _maxDriftRatioPercentage = 2.00;
        [DataMember]
        protected double _Omega = 5.00;
        [DataMember]
        protected PushOverControl _control = PushOverControl.DisplacementControl;
        #endregion

        #region Properties
        public int NumOfSteps
        {
            get { return _numOfSteps; }
            set { _numOfSteps = value; }
        }
        public double MaxDriftPercentage
        {
            get { return _maxDriftRatioPercentage; }
            set { _maxDriftRatioPercentage = value; }
        }
        public double Omega
        {
            get { return _Omega; }
            set { _Omega = value; }
        }
        public PushOverControl ControlType
        {
            get { return _control; }
            set { _control = value; }
        }
        #endregion

        #region Constructors
        public LateralProfilePushOverParameters()
        {

        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class AnalysisParameters
    {
        public static double Tolerance = 1.0e-9;

        #region Members
        [DataMember]
        protected LateralProfilePushOverParameters _profilePushOverParamters = new LateralProfilePushOverParameters();
        [DataMember]
        protected ResposeSpectrumData _spectralResponse = new ResposeSpectrumData();
        [DataMember]
        protected CyclicPushoOver _cyclicPushoOver = new CyclicPushoOver();
        [DataMember]
        protected TimeHistory_Parameters _TimeHistoryparameters = new TimeHistory_Parameters();
        [DataMember]
        protected AnalysisMethod _analysisMethod;
        #endregion

        #region properties
        public CyclicPushoOver CyclicPushoOver
        {
            get { return _cyclicPushoOver; }
            set { _cyclicPushoOver = value; }
        }
        public ResposeSpectrumData SpectralResponse
        {
            get { return _spectralResponse; }
            set { _spectralResponse = value; }
        }
        public LateralProfilePushOverParameters ProfilePushOverParameters
        {
            get { return _profilePushOverParamters; }
            set { _profilePushOverParamters = value; }
        }
        public TimeHistory_Parameters TimeHistory_Parameters
        {
            get { return _TimeHistoryparameters; }
            set { _TimeHistoryparameters = value; }
        }
        public AnalysisMethod AnalysisMethod
        {
            get { return _analysisMethod; }
            set { _analysisMethod = value; }
        }
        #endregion

        #region Constructors
        public AnalysisParameters()
        {

        }
        #endregion

        public ResultsShowingOptions GetRunResultOptions()
        {
            return ResultsShowingOptions.ShowAll;
        }
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(FrameSectionGroup))]
    [KnownType(typeof(PlateSectionGroup))]
    public abstract class LevelsSectionGroup
    {
        [DataMember]
        protected int _minIndex;
        [DataMember]
        protected int _maxIndex;
        [DataMember]
        protected int _analysisNum;

        public int AnalysisNum
        {
            get { return _analysisNum; }
            set { _analysisNum = value; }
        }
        public int MinIndex
        {
            get { return _minIndex; }
            set { _minIndex = value; }
        }
        public int MaxIndex
        {
            get { return _maxIndex; }
            set { _maxIndex = value; }
        }

        public LevelsSectionGroup()
        {

        }
        public LevelsSectionGroup(int min, int max)
        {
            _minIndex = min;
            _maxIndex = max;
        }

    }
    [DataContract(IsReference = true)]
    public class FrameSectionGroup : LevelsSectionGroup
    {
        [DataMember]
        protected FrameElementFamily _frameSection = null;
        [DataMember]
        protected FrameElementNumericalModel _numericalModel = null;

        public FrameElementFamily FrameSection
        {
            get { return _frameSection; }
            set { _frameSection = value; }
        }
        public FrameElementNumericalModel NumericalModel
        {
            get { return _numericalModel; }
            set { _numericalModel = value; }
        }
        public FrameSectionGroup()
        {

        }
        public FrameSectionGroup(int min,int max,FrameElementFamily frameSection,FrameElementNumericalModel numericalModel) : base(min, max)
        {
            _frameSection = frameSection;
            _numericalModel = numericalModel;
        }
    }
    [DataContract(IsReference = true)]
    public class PlateSectionGroup : LevelsSectionGroup
    {
        [DataMember]
        protected PlateFamily _plateSection = null;

        public PlateFamily PlateSection
        {
            get { return _plateSection; }
            set { _plateSection = value; }
        }
        public PlateSectionGroup()
        {

        }
        public PlateSectionGroup(int min, int max, PlateFamily PlateFamily) : base(min, max)
        {
            _plateSection = PlateFamily;
        }
        
    }
    [DataContract(IsReference = true)]
    [KnownType(typeof(FrameElementFamily))]
    [KnownType(typeof(PlateFamily))]
    public abstract class SectionFamily
    {
        [DataMember]
        protected string _name;
        [DataMember]
        protected int _elasticAnalysis;
      
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
       
        public virtual double E
        {
            get { return 0.0; }
        }
        
        public int ElasticAnalysisNum
        {
            get { return _elasticAnalysis; }
            set { _elasticAnalysis = value; }
        }
        public SectionFamily()
        {

        }
    }
    [DataContract(IsReference = true)]
    public class FrameElementFamily : SectionFamily
    {
        #region Memeber
        [DataMember]
        protected IShapeSection _section;
        [DataMember]
        protected Material _webMaterial;
        [DataMember]
        protected double _initE = 29000;
        [DataMember]
        protected Material _flangeMaterial;
        [DataMember]
        protected double _areaModifier = 1.00;
        [DataMember]
        protected double _intertiaModifier = 1.00;
        [DataMember]
        protected int[] _fibersCoor = new int[] { 25, 2, 1, 15 };
        [DataMember]
        protected Dictionary<int, double> _ids = new Dictionary<int, double>();
        #endregion

        #region Properties
        public Dictionary<int, double> IDS
        {
            get { return _ids; }
            set { _ids = value; }
        }
        public override double E
        {
            get { return _initE; }
        }
        
        public IShapeSection Section
        {
            get { return _section; }
            set { _section = value; }
        }
        public double initE
        {
            get { return _initE; }
            set { _initE = value; }
        }
        public Material FlangeMaterial
        {
            get { return _flangeMaterial; }
            set { _flangeMaterial = value; }
        }
        public Material WebMaterial
        {
            get { return _webMaterial; }
            set { _webMaterial = value; }
        }
        public double AreaModifier
        {
            get { return _areaModifier; }
            set { _areaModifier = value; }
        }
        public double IntertiaModifier
        {
            get { return _intertiaModifier; }
            set { _intertiaModifier = value; }
        }
        public int[] FibersCoor
        {
            get { return _fibersCoor; }
            set { _fibersCoor = value; }
        }
        #endregion

        #region Constructor
        public FrameElementFamily()
        {

        }
        public FrameElementFamily(string name, double initE, Material WebMaterial, Material Flangematerial, IShapeSection section)
        {
            _name = name;
            _initE = initE;
            _webMaterial = WebMaterial;
            _flangeMaterial = Flangematerial;
            _section = section;
        }
        #endregion

        #region Methods
        public int WriteSection(StreamWriter file, double Lp, ref int MaxsecId, ref int MaxMaterialId)
        {
            if (_ids == null)
                _ids = new Dictionary<int, double>();

            if (_ids.Any(x => Math.Abs(x.Value - Lp) < 1e-9))
            {
                return _ids.First(x => Math.Abs(x.Value - Lp) < 1e-9).Key;
            }

            int flangeId = _flangeMaterial.AnalysisID;
            int webId = _webMaterial.AnalysisID;

            _ids.Add(++MaxsecId,Lp);

            if ( Lp > -1)
            {
                MaxMaterialId = flangeId = FlangeMaterial.Scale(Lp * Section.D, 1).WriteMaterial(file,++MaxMaterialId);
                if (FlangeMaterial == WebMaterial)
                {
                    webId = flangeId;
                }
                else
                {
                    MaxMaterialId = webId = WebMaterial.Scale(Lp * Section.D, 1).WriteMaterial(file, ++MaxMaterialId);
                }
            }

            file.WriteLine(string.Format("WSec {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10};",
                 flangeId, webId, MaxsecId, Section.D, Section.Tw, Section.Bf, Section.Tf, FibersCoor[0], FibersCoor[1], FibersCoor[2], FibersCoor[3]));

            return MaxsecId;
        }
        public double GetALong()
        {
            return (_flangeMaterial.BasicData.Density * _section.Bf * _section.Tf * 2)
                + (_webMaterial.BasicData.Density * _section.Tw * (_section.D - 2 * _section.Tf));
        }
        public double GetHingedRationalStiffnes(double length)
        {
            return 6.00 * _initE * _section.Ix * length;
        }
        public double GetYieldRotation(bool positive)
        {
            if (positive)
            {
                return Math.Atan(Math.Abs(2 * GetMYpositive() / _section.D));
            }
            else
            {
                return Math.Atan(Math.Abs(2 * GetMYnegitive() / _section.D));
            }
        }
        public void GetPlasticHingeProperties(double ElementLength, double th_pP, out double Ks, out double b, out double My, out double MyNeg)
        {
            Ks = GetHingedRationalStiffnes(ElementLength / SPSW_Simple_Model.RotationalStiffnessRatio);
            double Ks2 = GetHingedRationalStiffnes(ElementLength);
            My = GetMYpositive();
            MyNeg = GetMYnegitive();
            double StrainHardening = (My * (_section.MCMY() - 1.0)) / (Ks2 * th_pP);
            b = (StrainHardening) / (1.0 + (1.0 / SPSW_Simple_Model.RotationalStiffnessRatio) * (1.0 - StrainHardening));
        }
        public double GetMYpositive()
        {
            return _section.GetMy(_flangeMaterial.GetfyPos());
        }
        public double GetMYnegitive()
        {
            return _section.GetMy(_flangeMaterial.GetfyNeg());
        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class PlateFamily : SectionFamily
    {
        #region Memeber
        [DataMember]
        protected double _thickness;
        [DataMember]
        protected List<SPBey> _sPBeys = new List<SPBey>();
        [DataMember]
        protected Material _material;
        [DataMember]
        protected double _areaModifier = 1.00;
        #endregion

        #region Properties
        public override double E
        {
            get { return _material.BasicData.E; }
        }
       
        public double Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }
        public List<SPBey> SPBeys
        {
            get { return _sPBeys; }
            set { _sPBeys = value; }
        }
        public Material Material
        {
            get { return _material; }
            set { _material = value; }
        }
        public double AreaModifier
        {
            get { return _areaModifier; }
            set { _areaModifier = value; }
        }
        #endregion

        #region Constructor
        public PlateFamily()
        {

        }
        public PlateFamily(string name, Material material, double thickness, double secModifier)
        {
            _name = name;
            _material = material;
            _thickness = thickness;
            _areaModifier = secModifier;
        }
        #endregion

    }
   
    [DataContract(IsReference = true)]
    [KnownType(typeof(SPSW_Simple_Model))]
    public abstract class SPSW_Model
    {
        #region StaticMembers
        public static double RotationalStiffnessRatio = 1000.00;
        public static double DegreeTolerance { get; set; } = 5;
        #endregion

        #region DataMembers
        [DataMember]
        protected string _name = "Model1";
        [DataMember]
        protected DesignApproach _designApproach = DesignApproach.AISC_Tension_Field_Angle;
        [DataMember]
        protected Angle _userDefinedAngle = Angle.FromDegrees(45);
        [DataMember]
        protected List<Level> _levels = new List<Level>();
        [DataMember]
        protected List<VerticalLine> _verticalLines = new List<VerticalLine>();
        [DataMember]
        protected List<SupportsMainNode> _supportsNodes = new List<SupportsMainNode>();
        [DataMember]
        protected List<MainNode> _mainNodes = new List<MainNode>();
        [DataMember]
        protected List<SPBey> _sPBeys = new List<SPBey>();
        [DataMember]
        protected List<Column> _columns = new List<Column>();
        [DataMember]
        protected List<Column> _gravityColumns = new List<Column>();
        [DataMember]
        protected List<Beam> _beams = new List<Beam>();
        [DataMember]
        protected List<RigidLink> _rigdLinks = new List<RigidLink>();
        [DataMember]
        protected List<List<double>> _timeSteps = new List<List<double>>();
        [DataMember]
        protected BaseProperties _baseProperties = new BaseProperties();
        [DataMember]
        protected bool _solved = false;
        [DataMember]
        protected bool _modalSolved = false;
        [DataMember]
        protected ModalAnalysisData _modaldata = new ModalAnalysisData();
        [DataMember]
        protected bool _addDeadLoadsAutomatically = false;
        [DataMember]
        protected List<ForcesRange> _valuesRanges = new List<ForcesRange>();
        [DataMember]
        protected int _modeShapes = 1;
        [DataMember]
        protected List<FrameElementFamily> _frameFamilies = new List<FrameElementFamily>();
        [DataMember]
        protected List<PlateFamily> _plateFamilies = new List<PlateFamily>();
        [DataMember]
        protected PlasticHingeProperties _ColumnsBilinearProperties = PlasticHingeProperties.init();
        [DataMember]
        protected PlasticHingeProperties _BeamsBilinearProperties = PlasticHingeProperties.init();
        [DataMember]
        protected bool _includePanelZones = false;
        [DataMember]
        protected int _minStrips = 10; 
        #endregion

        #region Properties
        public int MinStrips
        {
            get { return _minStrips; }
            set { _minStrips = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public DesignApproach DesignApproach
        {
            get { return _designApproach; }
            set { _designApproach = value; }
        }
        public Angle UserDefinedAngle
        {
            get { return _userDefinedAngle; }
            set { _userDefinedAngle = value; }
        }
        
        public List<Level> Levels
        {
            get { return _levels; }
        }
        public List<VerticalLine> VerticalLines
        {
            get { return _verticalLines; }
        }
        public List<SupportsMainNode> SupportsNodes
        {
            get { return _supportsNodes; }
        }
        public List<MainNode> MainNodes
        {
            get { return _mainNodes; }
        }
        public List<SPBey> SPBeys
        {
            get { return _sPBeys; }
        }
        public List<Column> Columns
        {
            get { return _columns; }
        }
        public List<Column> GravityColumns
        {
            get { return _gravityColumns; }
        }
        public List<Beam> Beams
        {
            get { return _beams; }
        }
        public List<RigidLink> RigdLinks
        {
            get { return _rigdLinks; }
        }
        public List<List<double>> TimeSteps
        {
            get { return _timeSteps; }
            set { _timeSteps = value; }
        }
        public List<FrameElementFamily> FramesFamilies
        {
            get { return _frameFamilies; }
            set { _frameFamilies = value; }
        }
        public List<PlateFamily> PlateFamilies
        {
            get { return _plateFamilies; }
            set { _plateFamilies = value; }
        }
        public BaseProperties BaseProperties
        {
            get { return _baseProperties; }
            set { _baseProperties = value; }
        }
        public bool Solved
        {
            get { return _solved; }
            set { _solved = value; }
        }
        public bool AddDeadLoadsAutomatically
        {
            get { return _addDeadLoadsAutomatically; }
            set { _addDeadLoadsAutomatically = value; }
        }
        public List<ForcesRange> ValuesRanges
        {
            get { return _valuesRanges; }
            set { _valuesRanges = value; }
        }
        public bool ModalSolved
        {
            get { return _modalSolved; }
            set { _modalSolved = value; }
        }
        public ModalAnalysisData ModalData
        {
            get { return _modaldata; }
            set { _modaldata = value; }
        }
        public int ModeShapes
        {
            get { return _modeShapes; }
            set { _modeShapes = value; }
        }
        public PlasticHingeProperties BeamsBilinearProperties
        {
            get { return _BeamsBilinearProperties; }
            set { _BeamsBilinearProperties = value; }
        }
        public PlasticHingeProperties ColumnsBilinearProperties
        {
            get { return _ColumnsBilinearProperties; }
            set { _ColumnsBilinearProperties = value; }
        }
        public bool IncludePanelZones
        {
            get { return _includePanelZones; }
            set { _includePanelZones = value; }
        }
        #endregion

        #region Constructors
        public SPSW_Model()
        {

        }
        #endregion

        #region Methods
        
        public void AddNode(SupportsMainNode Node)
        {
            if (Node == null)
                return;
            if (_supportsNodes.Any(x => x.ID == Node.ID))
                return;
            _supportsNodes.Add(Node);
        }
        public void AddNode(MainNode Node)
        {
            if (Node == null)
                return;
            if (_mainNodes.Any(x => x.ID == Node.ID))
                return;
            _mainNodes.Add(Node);
        }
        
        public Level GetbottomLevelFromFloorIndex(int index)
        {
            if (_baseProperties.HasOffset)
            {
                return _levels[index + 1];
            }
            else
            {
                return _levels[index];
            }
        }
        public Level GetTopLevelFromFloorIndex(int index)
        {
            if (_baseProperties.HasOffset)
            {
                return _levels[index + 2];
            }
            else
            {
                return _levels[index + 1];
            }
        }
 
        internal void SetRanges(RegularFrameElement Element, int loadCase)
        {
            if (Element.ValuesRanges.Count == loadCase)
            {
                Element.ValuesRanges.Add(new ForcesRange());
            }
            Element.SetValuesRange(loadCase);
            _valuesRanges[loadCase].Set(Element.ValuesRanges[loadCase]);
        }
        internal void SetRanges(MainNode Element, int loadCase)
        {
            if (Element.ValuesRanges.Count == loadCase)
            {
                Element.ValuesRanges.Add(new ForcesRange());
            }
            Element.SetValuesRange(loadCase);
            _valuesRanges[loadCase].Set(Element.ValuesRanges[loadCase]);
        }
        internal virtual IEnumerable<Node> GetAllNodes(bool AddPlatesNodes)
        {
            return new List<Node>();
        }
        public virtual void ClearModalAnalysisRun()
        {
            _modalSolved = false;
            _modaldata = new ModalAnalysisData();
            foreach (var node in GetAllNodes(true))
            {
                node.ModeShapesDeformations = new List<NodeDeformation>();
            }
        }
        public virtual void ClearRunResults()
        {
            _frameFamilies.ForEach(x => x.IDS = new Dictionary<int, double>());
            if (!_solved)
                return;
            _solved = false;
            _valuesRanges = new List<ForcesRange>();
            _beams.ForEach(x => x.ClearRunResullts());
            _columns.ForEach(x => x.ClearRunResullts());
            _gravityColumns.ForEach(x => x.ClearRunResullts());
            _sPBeys.ForEach(x => x.TrussGroup.Trusses.ForEach(t => t.ClearRunResullts()));
            foreach (var node in GetAllNodes(true))
            {
                node.Deformations = new List<List<NodeDeformation>>();
            }
            _supportsNodes.ForEach(x => x.Reactions = new List<List<NodeReaction>>());
        }
        public double GetTotalWeight()
        {
            return _mainNodes.Sum(x => x.NodeMass);
        }
        
        #endregion
    }

    [DataContract(IsReference = true)]
    public class SPSW_Simple_Model : SPSW_Model
    {
        #region Static variables
        public static double Margin = 0.2;
        #endregion

        #region members
        [DataMember]
        protected double minX = 0.0f;
        [DataMember]
        protected double maxX = 100.0f;
        [DataMember]
        protected double minY = 0.0f;
        [DataMember]
        protected double maxY = 100.0f;
        [DataMember]
        protected ModelLayout _modelLayout = new ModelLayout();
        [DataMember]
        protected List<IShapeSection> _sectionsList = new List<IShapeSection>();
        [DataMember]
        protected List<Material> _materialList = new List<Material>();
        [DataMember]
        protected List<FrameElementNumericalModel> _numericalModels = new List<FrameElementNumericalModel>();
        [DataMember]
        protected FloorDeadLoad[] _floorsDeadLoads;
        [DataMember]
        protected List<FrameSectionGroup> _beamsSectionGroups = new List<FrameSectionGroup>();
        [DataMember]
        protected List<FrameSectionGroup> _columnsSectionGroups = new List<FrameSectionGroup>();
        [DataMember]
        protected List<PlateSectionGroup> _platesSectionGroups = new List<PlateSectionGroup>();
        [DataMember]
        protected AnalysisParameters _analysisParameters = new AnalysisParameters();
        [DataMember]
        protected ModelStage _stage = ModelStage.Dimensions;
        [DataMember]
        protected double _gravityCoulmnModifier = 100;
        [DataMember]
        protected double _rigidLinkModifier = 100;
        [DataMember]
        protected double _g = 386.4;
        [DataMember]
        protected SolverAanalysisOptions _analysisOptions = new SolverAanalysisOptions();
        #endregion

        #region Properties
        public double MinX
        {
            get { return minX; }
        }
        public double MaxX
        {
            get { return maxX; }
        }
        public double MinY
        {
            get { return minY; }
        }
        public double MaxY
        {
            get { return maxY; }
        }
        public ModelLayout Layout
        {
            get { return _modelLayout; }
        }
        public int FreeLevels
        {
            get { return _baseProperties.HasOffset ? _modelLayout.FloorNo + 1 : _modelLayout.FloorNo; }
        }

        public List<IShapeSection> SectionsList
        {
            get { return _sectionsList; }
            set { _sectionsList = value; }
        }
        public List<Material> Materials
        {
            get { return _materialList; }
            set { _materialList = value; }
        }
        public List<FrameElementNumericalModel> NumericalModels
        {
            get { return _numericalModels; }
            set { _numericalModels = value; }
        }
        public List<FrameSectionGroup> BeamsSectionGroups
        {
            get { return _beamsSectionGroups; }
            set { _beamsSectionGroups = value; }
        }
        public List<FrameSectionGroup> ColumnsSectionGroups
        {
            get { return _columnsSectionGroups; }
            set { _columnsSectionGroups = value; }
        }
        public List<PlateSectionGroup> PlatesSectionGroups
        {
            get { return _platesSectionGroups; }
            set { _platesSectionGroups = value; }
        }
        public FloorDeadLoad[] FloorsDeadLoads
        {
            get { return _floorsDeadLoads; }
            set { _floorsDeadLoads = value; ; }
        }
        public AnalysisParameters AnalysisParameters
        {
            get { return _analysisParameters; }
            set { _analysisParameters = value; }
        }
        public ModelStage Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }
        public double RigidLinkModifier
        {
            get { return _rigidLinkModifier; }
            set { _rigidLinkModifier = value; }
        }
        public double GravityCoulmnModifier
        {
            get { return _gravityCoulmnModifier; }
            set { _gravityCoulmnModifier = value; }
        }
        public double G
        {
            get { return _g; }
            set { _g = value; }
        }
        public SolverAanalysisOptions AnalysisOptions
        {
            get { return _analysisOptions; }
            set { _analysisOptions = value; }
        }
        #endregion

        #region Constructors
        public SPSW_Simple_Model()
        {
        }
        #endregion

        #region Methods
        public bool IsValidColumnsSectionGroup(List<FrameSectionGroup> groups)
        {
            if (!groups.Any())
                return false;
            if (groups.Count < 1 || groups.Count > _levels.Count - 1)
                return false;
            if (groups.First().MinIndex != 0)
                return false;
            if (groups.Last().MaxIndex != _levels.Count - 1)
                return false;
            if (groups.Any(x => x.MaxIndex <= x.MinIndex || x.FrameSection == null || !_frameFamilies.Contains(x.FrameSection)))
                return false;
            for (int i = 1; i < groups.Count; i++)
            {
                if (groups[i - 1].MaxIndex != groups[i].MinIndex)
                    return false;
            }
            return true;
        }

        public int CalcMaxBeamFamiliesGroup()
        {
            int result = _levels.Count - 1;
            if (!_baseProperties.HasOffset)
            {
                result++;
            }
            return result;
        }

        public bool IsValidBeamsSectionGroup(List<FrameSectionGroup> groups)
        {
            if (groups == null | !groups.Any())
                return false;
            if (groups.Count < 1 || groups.Count > CalcMaxBeamFamiliesGroup())
                return false;
            if (groups.First().MinIndex != _baseProperties.GetFirstBeamLevelIndex())
                return false;
            if (groups.Last().MaxIndex != _levels.Count - 1)
                return false;
            if (groups.Any(x => x.MaxIndex < x.MinIndex || x.FrameSection == null || !_frameFamilies.Contains(x.FrameSection)))
                return false;
            for (int i = 1; i < groups.Count; i++)
            {
                if (groups[i - 1].MaxIndex >= groups[i].MinIndex)
                    return false;
            }
            return true;
        }
        public bool IsValidPlatesSectionGroup(List<PlateSectionGroup> groups)
        {
            if (!groups.Any())
                return false;
            int floorNo = _modelLayout.FloorNo;
            if (groups.Count < 1 || groups.Count > floorNo)
                return false;
            if (groups.First().MinIndex != 1)
                return false;
            if (groups.Last().MaxIndex != floorNo)
                return false;
            if (groups.Any(x => x.MaxIndex < x.MinIndex || x.PlateSection == null || !_plateFamilies.Contains(x.PlateSection)))
                return false;
            for (int i = 1; i < groups.Count; i++)
            {
                if (groups[i - 1].MaxIndex >= groups[i].MinIndex)
                    return false;
            }
            return true;
        }
        public PlateSectionGroup GetPlateSectionGroup(int floorIndex)
        {
            int i = floorIndex + 1;
            return _platesSectionGroups.FirstOrDefault(x => x.MinIndex <= i && x.MaxIndex >= i);
        }
        public PlateFamily GetPlateFamily(int floorIndex)
        {
            PlateSectionGroup g = GetPlateSectionGroup(floorIndex);
            if (g != null)
                return g.PlateSection;
            return null;
        }
        public FrameElementFamily GetColumnFamilyByFloorIndex(int floorIndex)
        {
            return GetColumnFamilyByLowerLevelIndex(_baseProperties.HasOffset ? floorIndex + 1 : floorIndex);
        }
        public FrameSectionGroup GetColumnFrameSectionGroupByLowerLevelIndex(int levelIndex)
        {
            return _columnsSectionGroups.FirstOrDefault(x => x.MinIndex <= levelIndex && x.MaxIndex > levelIndex);
        }
        public FrameElementFamily GetColumnFamilyByLowerLevelIndex(int levelIndex)
        {
            FrameSectionGroup g = GetColumnFrameSectionGroupByLowerLevelIndex(levelIndex);
            if (g != null)
                return g.FrameSection;
            return null;
        }
        public FrameSectionGroup GetBeamFrameSectionGroupByLevelIndex(int levelIndex)
        {
            return _beamsSectionGroups.FirstOrDefault(x => x.MinIndex <= levelIndex && x.MaxIndex >= levelIndex);
        }
        public FrameElementFamily GetBeamFamilyByLevelIndex(int levelIndex)
        {
            FrameSectionGroup g = GetBeamFrameSectionGroupByLevelIndex(levelIndex);
            if (g != null)
                return g.FrameSection;
            return null;
        }
        public void GetBeamFamiliesByFloorIndex(int floorIndex, out FrameElementFamily lowerFamily, out FrameElementFamily upperFamily)
        {
            int levelIndex = _baseProperties.HasOffset ? floorIndex + 1 : floorIndex;
            lowerFamily = GetBeamFamilyByLevelIndex(levelIndex);
            upperFamily = GetBeamFamilyByLevelIndex(levelIndex + 1);
        }
        public void SetModelDimensions(ModelLayout layout, BaseProperties baseProperties)
        {
            _modelLayout = layout;
            _baseProperties = baseProperties;
        }
        internal void CreateMainLines()
        {
            UpdateMinMax();
            CreateGrids();
        }
        internal void CreateElements()
        {
            CreateSPBeys();
            CreateMainNodes();
            CreateSPBeysTrusses();
            CreateIntermediateNodes();
            SortNodes();
            CreateColumns();
            CreateBeams();
            CreateRigidLinks();
            CreateFrameSegments();
            CreatePlasticHinges();
            CreateRigidZones();
        }

        private void CreateRigidZones()
        {
            if (!_includePanelZones)
                return;
            _includePanelZones = CanIncludePanelZones();
            if (!_includePanelZones)
                return;
            Create_RigidZones();
        }

        private void Create_RigidZones()
        {
            int i = _baseProperties.GetFirstBeamLevelIndex();
            int j = i;
            for (; i < _levels.Count; i++)
            {
                FrameElementFamily lowerColumnFamily = GetColumnFamilyByLowerLevelIndex(Math.Max(0, i - 1));
                FrameElementFamily upperColumnFamily = GetColumnFamilyByLowerLevelIndex(Math.Min(_levels.Count - 2, i));
                double adjDepth = Math.Max(lowerColumnFamily.Section.D, upperColumnFamily.Section.D);
                _beams[i - j].CreateRigidZones(adjDepth, adjDepth);
            }
            i = 0;
            for (; i < _levels.Count - 1; i++)
            {
                double StartAdjDepth = i < j ? 0.0 : GetBeamFamilyByLevelIndex(i).Section.D;
                double EndAdjDepth = GetBeamFamilyByLevelIndex(i + 1).Section.D;
                _columns[2 * i].CreateRigidZones(StartAdjDepth, EndAdjDepth);
            }
        }

        private bool CanIncludePanelZones()
        {
            int i = _baseProperties.GetFirstBeamLevelIndex();
            int j = i;
            for (; i < _levels.Count; i++)
            {
                FrameElementFamily lowerColumnFamily = GetColumnFamilyByLowerLevelIndex(Math.Max(0, i - 1));
                FrameElementFamily upperColumnFamily = GetColumnFamilyByLowerLevelIndex(Math.Min(_levels.Count - 2, i));
                double adjDepth = Math.Max(lowerColumnFamily.Section.D, upperColumnFamily.Section.D);
                if (!_beams[i - j].IsValidToCutRigidZones(adjDepth, adjDepth))
                    return false;
            }
            i = 0;
            for (; i < _levels.Count - 1; i++)
            {
               double StartAdjDepth = i < j ? 0.0 : GetBeamFamilyByLevelIndex(i).Section.D;
               double EndAdjDepth = GetBeamFamilyByLevelIndex(i + 1).Section.D;
                if (!_columns[2 * i].IsValidToCutRigidZones(StartAdjDepth, EndAdjDepth))
                    return false;
            }
            return true;
        }
        private void CreatePlasticHinges()
        {
            int i = _baseProperties.GetFirstBeamLevelIndex();
            int j = i;
            for (; i < _levels.Count; i++)
            {
                FrameSectionGroup group = GetBeamFrameSectionGroupByLevelIndex(i);
                if (group == null)
                    continue;
                if (group.NumericalModel is FiberPlasticSections)
                {
                    FiberPlasticSections numModel = (group.NumericalModel as FiberPlasticSections);
                    FrameElementFamily lowerColumnFamily = GetColumnFamilyByLowerLevelIndex(Math.Max(0, i - 1));
                    FrameElementFamily upperColumnFamily = GetColumnFamilyByLowerLevelIndex(Math.Min(_levels.Count - 2, i));
                    double adjDepth = Math.Max(lowerColumnFamily.Section.D, upperColumnFamily.Section.D);
                    numModel.CreatePlasticSegments(_beams[i - j], adjDepth, adjDepth);
                }

            }
            i = 0;
            for (; i < _levels.Count - 1; i++)
            {
                FrameSectionGroup group = GetColumnFrameSectionGroupByLowerLevelIndex(i);
                if (group == null)
                    continue;
                if (group.NumericalModel is FiberPlasticSections)
                {
                    FiberPlasticSections numModel = (group.NumericalModel as FiberPlasticSections);
                    double StartAdjDepth = 0;
                    var BeamFamily = GetBeamFamilyByLevelIndex(i);
                    if (BeamFamily != null)
                    {
                        StartAdjDepth += BeamFamily.Section.D;
                    }
                    double EndAdjDepth = GetBeamFamilyByLevelIndex(i + 1).Section.D;
                    numModel.CreatePlasticSegments(_columns[2 * i], StartAdjDepth, EndAdjDepth);
                    numModel.CreatePlasticSegments(_columns[2 * i + 1], StartAdjDepth, EndAdjDepth);
                }
            }
        }
        private void CreateFrameSegments()
        {
            _gravityColumns.ForEach(x => x.CreateRotsprings());
            _gravityColumns.ForEach(x => x.CreateDefaultChild(PlasticHingeApproach.None));

            foreach (var option in new PlasticHingeApproach[] { PlasticHingeApproach.None , PlasticHingeApproach.NolinearBeamColumn
                 , PlasticHingeApproach.DistrubuitedPlasticity , PlasticHingeApproach.BeamWithHinges })
            {
                _beams.ForEach(x => x.Group.NumericalModel.CreateSegments(x, option));
                _columns.ForEach(x => x.Group.NumericalModel.CreateSegments(x, option));
            }
        }
        public double GetDesginBaseShear()
        {
            return GetTotalWeight() * _analysisParameters.SpectralResponse.Cs * _analysisParameters.SpectralResponse.R;
        }
        private void CreateIntermediateNodes()
        {

            _verticalLines[2].AddspringsHingeNodes(1.0 / RotationalStiffnessRatio);
            int i = _baseProperties.GetFirstBeamLevelIndex();
            for (; i < _levels.Count; i++)
            {
                FrameSectionGroup group = GetBeamFrameSectionGroupByLevelIndex(i);
                if (group == null)
                    continue;
                var mainNodes = _levels[i].DivideByMainNodes(_verticalLines)[0];
                FrameElementFamily lowerColumnFamily = GetColumnFamilyByLowerLevelIndex(Math.Max(0, i - 1));
                FrameElementFamily upperColumnFamily = GetColumnFamilyByLowerLevelIndex(Math.Min(_levels.Count - 2, i));
                double adjDepth = Math.Max(lowerColumnFamily.Section.D, upperColumnFamily.Section.D);
                group.NumericalModel.AddIntermediateNodes(mainNodes, group.FrameSection.Section.D, _levels[i], adjDepth, adjDepth);
            }
            i = 0;
            var mainNodes1 = _verticalLines[0].DivideByMainNodes();
            var mainNodes2 = _verticalLines[1].DivideByMainNodes();
            for (; i < _levels.Count - 1; i++)
            {
                FrameSectionGroup group = GetColumnFrameSectionGroupByLowerLevelIndex(i);
                if (group == null)
                    continue;
                double StartAdjDepth = 0;
                var BeamFamily = GetBeamFamilyByLevelIndex(i);
                if (BeamFamily != null)
                {
                    StartAdjDepth += BeamFamily.Section.D;
                }
                double EndAdjDepth = GetBeamFamilyByLevelIndex(i + 1).Section.D;
                group.NumericalModel.AddIntermediateNodes(mainNodes1[i], group.FrameSection.Section.D, _verticalLines[0], StartAdjDepth, EndAdjDepth);
                group.NumericalModel.AddIntermediateNodes(mainNodes2[i], group.FrameSection.Section.D, _verticalLines[1], StartAdjDepth, EndAdjDepth);
            }
        }

        internal void CheckTimeStepsCount(List<int> K_values)
        {
            for (int i = 0; i < K_values.Count; i++)
            {
                if (K_values[i] < _timeSteps[i].Count)
                {
                    _timeSteps[i].RemoveRange(K_values[i], _timeSteps[i].Count - K_values[i]);
                }
            }
        }
        private void CreateBeams()
        {
            _beams.Clear();
            int i = _baseProperties.GetFirstBeamLevelIndex();

            for (; i < _levels.Count; i++)
            {
                List<List<Node>> nodes = _levels[i].DivideByMainNodes(_verticalLines);
                if (nodes.Count == 2)
                {
                    _beams.Add(new Beam(nodes[0], _levels[i], GetBeamFrameSectionGroupByLevelIndex(i)));
                }
            }
        }
        private void CreateRigidLinks()
        {
            _rigdLinks.Clear();
            for (int i = 1; i < _levels.Count; i++)
            {
                List<List<Node>> nodes = _levels[i].DivideByMainNodes(_verticalLines);
                if (nodes.Count == 2)
                {
                    _rigdLinks.Add(new RigidLink(nodes[1].First(), nodes[1].Last(), GetBeamFamilyByLevelIndex(i)));
                }
            }
        }
        private void CreateColumns()
        {
            _columns.Clear();
            _gravityColumns.Clear();

            List<List<Node>> DividedList1 = _verticalLines[0].DivideByMainNodes();
            List<List<Node>> DividedList2 = _verticalLines[1].DivideByMainNodes();
            List<List<Node>> DividedList3 = _verticalLines[2].DivideByMainNodes();

            for (int i = 0; i < _levels.Count - 1; i++)
            {
                FrameSectionGroup group = GetColumnFrameSectionGroupByLowerLevelIndex(i);
                _columns.Add(new Column(DividedList1[i], _verticalLines[0], group));
                _columns.Add(new Column(DividedList2[i], _verticalLines[1], group));
                _gravityColumns.Add(new Column(DividedList3[i], _verticalLines[2], group));
            }
        }
        private void SortNodes()
        {
            _levels.ForEach(x => x.SortNodes());
            _verticalLines.ForEach(x => x.SortNodes());
        }
        private void CreateSPBeys()
        {
            _sPBeys.Clear();
            for (int i = 0; i < _modelLayout.FloorNo; i++)
            {
                _sPBeys.Add(new SPBey(this, i, 0));
            }
        }
        private void CreateSPBeysTrusses()
        {
            _platesSectionGroups.ForEach(x => {
                for (int i = x.MinIndex; i <= x.MaxIndex; i++)
                {
                    SPBey sPBey = _sPBeys[i-1];
                    sPBey.PlateSection = x.PlateSection;
                    x.PlateSection.SPBeys.Add(sPBey);
                    sPBey.CreateTrussesSection();
                };
            });
            _sPBeys.ForEach(x => x.CreateTrussGroup());
        }
        public int GetNumColumnsSegmentsByFloorIndex(int floorIndex, Angle angle, int numStrips)
        {
            if (floorIndex < 0)
                return 1;
            double l = _modelLayout.GetModelWidth();
            double h = _modelLayout.GetFloorHeight(floorIndex) * Math.Tan(angle.Radians);
            double delta = (h + l) / numStrips;
            return (int)(Math.Round(h / delta, 0));
        }
        public int GetNumBeamsSegmentsByFloorIndex(int floorIndex, Angle angle, int numStrips)
        {
            if (floorIndex < 0)
                return 0;
            double l = _modelLayout.GetModelWidth();
            double h = _modelLayout.GetFloorHeight(floorIndex) * Math.Tan(angle.Radians);
            double delta = (h + l) / numStrips;
            return (int)(Math.Round(l / delta, 0));
        }
        internal void ClearElements()
        {
            _beams.Clear();
            _columns.Clear();
            _gravityColumns.Clear();
            _rigdLinks.Clear();
            _mainNodes.Clear();
            _supportsNodes.Clear();
            _sPBeys.Clear();
            _levels.ForEach(x => x.LineNodes.Clear());
            _verticalLines.ForEach(x => x.LineNodes.Clear());
        }
        private void CreateMainNodes()
        {
            Level l = _levels[0];
            for (int j = 0; j < 3; j++)
            {
                VerticalLine Vl = _verticalLines[j];

                SupportsMainNode node1 = new SupportsMainNode(new Point2D(Vl.Distance, l.Elevation), SupportType.Hinged);
                l.AddNode(node1);
                Vl.AddNode(node1);
                AddNode(node1);
            }

            if (_baseProperties.IsFixed)
            {
                double space = _sPBeys[0].CalcBeamSegmentLength();
                ReferenceLine rLine = new ReferenceLine(_levels[0], new Line2D(_levels[0].LineNodes[0].Point, _levels[0].LineNodes[1].Point), space);
                rLine.MidPoints.ForEach(x => AddNode(rLine.Axe.AddNode(x, true) as SupportsMainNode));
            }


            for (int i = 1; i < _levels.Count; i++)
            {
                l = _levels[i];
                for (int j = 0; j < 3; j++)
                {
                    VerticalLine Vl = _verticalLines[j];
                    MainNode Node1 = new MainNode(new Point2D(Vl.Distance, l.Elevation));
                    l.AddNode(Node1);
                    Vl.AddNode(Node1);
                    AddNode(Node1);
                }
            }
        }
        public double GetBuildingHeight()
        {
            return _modelLayout.GetTotalHeight() + _baseProperties.BaseOffset;
        }
        private void UpdateMinMax()
        {
            SetRelativeDimension();
            double modelWidth = _modelLayout.GetModelWidth();
            double ModelHeight = GetBuildingHeight() + RenderOptions.LoadsArrowLength;
            double halfWidth = modelWidth * 1.5 / 2.00 + modelWidth * Margin;
            double halfheight = ModelHeight * 1.5 / 2.00 + ModelHeight * Margin;

            minX = (float)(-1 * halfWidth);
            maxX = (float)(halfWidth);
            minY = (float)(-1 * halfheight);
            maxY = (float)(halfheight);
        }
        public void ResetStaticVariables()
        {
            var nodes = GetAllNodes(true);
            Node.LastID = nodes.Any() ? nodes.Select(x => x.ID).Max() : 1;
            Element2d.LastID = 1;
            _sPBeys.ForEach(x =>
            {
                if (x.TrussGroup != null && x.TrussGroup.Trusses.Any())
                {
                    x.TrussGroup.Trusses.ForEach(t => t.UpdateIDReference());
                }
            });
            _mainNodes.ForEach(x => x.UpdateIDReference());
            _supportsNodes.ForEach(x => x.UpdateIDReference());
            _rigdLinks.ForEach(x => Element2d.LastID = Math.Max(x.ID, Element2d.LastID));
            _beams.ForEach(x => x.UpdateIDReference());
            _columns.ForEach(x => x.UpdateIDReference());
            _gravityColumns.ForEach(x => x.UpdateIDReference());
        }
        public override void ClearModalAnalysisRun()
        {
            base.ClearModalAnalysisRun();
            ResetStaticVariables();
            _frameFamilies.ForEach(x => x.IDS = new Dictionary<int, double>());
        }

        public void SetRelativeDimension()
        {
            RenderOptions.NodesRadius = 0.05 * Math.Min(_modelLayout.GetMinFloorHeight(), _modelLayout.GetModelWidth());
            RenderOptions.LoadsArrowLength = RenderOptions.LoadsArrowColumnRatio * _modelLayout.GetMinFloorHeight();
        }
        private void CreateGrids()
        {
            double height = GetBuildingHeight();
            double Width = _modelLayout.GetModelWidth() * 1.50;

            double minDistatnce = -1 * Width / 2.00;
            double minElevation = -1 * height / 2.00;
            _levels.Clear();
            _verticalLines.Clear();
            int n = _modelLayout.FloorNo;
            _levels.Add(new Level(minElevation, minX, maxX));
            if (_baseProperties.HasOffset)
            {
                minElevation += _baseProperties.BaseOffset;
                _levels.Add(new Level(minElevation, minX, maxX));
            }
            for (int i = 0; i < n; i++)
            {
                minElevation += _modelLayout.GetFloorHeight(i);
                _levels.Add(new Level(minElevation, minX, maxX));
            }
            _verticalLines.Add(new VerticalLine(minDistatnce, minY, maxY));
            _verticalLines.Add(new VerticalLine(minDistatnce + _modelLayout.GetModelWidth(), minY, maxY));
            _verticalLines.Add(new VerticalLine(minDistatnce + Width, minY, maxY));
        }
        internal override IEnumerable<Node> GetAllNodes(bool AddPlatesNodes)
        {
            List<Node> result = new List<Node>();
            _levels.ForEach(x => result.AddRange(x.LineNodes));
            _verticalLines.ForEach(x => result.AddRange(x.LineNodes));
            return result.Distinct().OrderBy(x => x.ID);
        }
        internal void CalculateNodesMass()
        {
            int i = 1;

            if (_addDeadLoadsAutomatically)
            {
                #region ColumnsLoad
                List<MainNode> mainNodes1 = _verticalLines[0].GetMainNodes();
                List<MainNode> mainNodes2 = _verticalLines[1].GetMainNodes();
                for (; i < _levels.Count; i++)
                {
                    FrameElementFamily family = GetColumnFamilyByLowerLevelIndex(i - 1);
                    double length = _levels[i].Elevation - _levels[i - 1].Elevation;
                    double CMassNode = 0.5 * length * family.GetALong();
                    List<MainNode> mainNodes = new List<MainNode>() { mainNodes1[i], mainNodes1[i - 1], mainNodes2[i], mainNodes2[i - 1] };
                    mainNodes.ForEach(x => x.NodeMass += CMassNode);
                }
                #endregion
                i = _baseProperties.GetFirstBeamLevelIndex();
                #region BeamLoad
                double bMassNode = 0.5 * _modelLayout.GetModelWidth();
                for (; i < _levels.Count; i++)
                {
                    FrameElementFamily family = GetBeamFamilyByLevelIndex(i);
                    if (family == null)
                        continue;
                    double SPmassNode = bMassNode * family.GetALong();
                    List<MainNode> mainNodes = _levels[i].GetMainNodes(_verticalLines);
                    mainNodes[0].NodeMass += SPmassNode;
                    mainNodes[1].NodeMass += SPmassNode;
                }
                #endregion
                #region PlateNodes
                double PMassNode = 0;
                for (i = 0; i < _sPBeys.Count; i++)
                {
                    PlateFamily family = _sPBeys[i].PlateSection;
                    PMassNode = 0.25 * _sPBeys[i].GetBeyWidth() * _sPBeys[i].GetBeyHeight();
                    double SPmassNode = PMassNode * family.Thickness * family.Material.BasicData.Density;
                    List<MainNode> BottomMainNodes = _sPBeys[i].GetBottomLevel().GetMainNodes(_verticalLines);
                    BottomMainNodes[0].NodeMass += SPmassNode;
                    BottomMainNodes[1].NodeMass += SPmassNode;

                    List<MainNode> TopMainNodes = _sPBeys[i].GetTopLevel().GetMainNodes(_verticalLines);
                    TopMainNodes[0].NodeMass += SPmassNode;
                    TopMainNodes[1].NodeMass += SPmassNode;
                }
                #endregion
            }

            for (i = 0; i < _floorsDeadLoads.Length; i++)
            {
                List<MainNode> mainNodes = _levels[i + 1].GetMainNodes(_verticalLines);
                mainNodes[0].NodeMass += _floorsDeadLoads[i].PlatesLoad * 0.5;
                mainNodes[1].NodeMass += _floorsDeadLoads[i].PlatesLoad * 0.5;
                mainNodes[2].NodeMass += _floorsDeadLoads[i].ColumnsLoad;
            }
            _mainNodes.ForEach(x => x.CreateLoadArrow());
        }
        internal void Serialize(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(SPSW_Simple_Model));
            ser.WriteObject(writer, this);
            writer.Close();
            fs.Close();
        }
        internal List<PlasticHinge> GetPlasticHinges()
        {
            List<PlasticHinge> res = new List<PlasticHinge>();
            _beams.ForEach(x => x.AddPlasticHingesToList(res));
            _columns.ForEach(x => x.AddPlasticHingesToList(res));
            return res.OrderBy(x => x.ID).ToList();
        }
        internal List<RegularTrussElement> GetRegularTrussElements()
        {
            var activesBeys = _sPBeys.Where(x => x.PlateSection.AreaModifier > 1e-9 && x.TrussesSection.A > 1e-9);
            if (!activesBeys.Any())
            {
                return new List<RegularTrussElement>();
            }
            return activesBeys.SelectMany(x => x.TrussGroup.Trusses).OrderBy(x => x.ID).ToList();
        }
        internal List<FrameTwoNodesElement> GetGravityColumnsSegments()
        {
            return _gravityColumns.SelectMany(x => x.Childs).OrderBy(x => x.ID).ToList();
        }
        internal IEnumerable<MainNode> GetMainNodesForRigidZones()
        {
            return MainNodes.Concat(SupportsNodes).Where(x => x.ConnectedRigidElements != null && x.ConnectedRigidElements.Any());
        }
        internal List<FrameTwoNodesElement> GetRigidZones()
        {
            return GetMainNodesForRigidZones().SelectMany(x => x.ConnectedRigidElements).OrderBy(x => x.ID).ToList();
        }
        internal List<FrameTwoNodesElement> GetFrameSgements(PlasticHingeApproach approach)
        {
            List<FrameTwoNodesElement> list = new List<FrameTwoNodesElement>();
            foreach (var beam in _beams)
            {
                list.AddRange(beam.Childs.Where(x =>x.Representation == approach));
            }
            foreach (var column in _columns)
            {
                list.AddRange(column.Childs.Where(x => x.Representation == approach));
            }
            return list;
        }
        internal bool WriteFrameSegments(StreamWriter file , PlasticHingeApproach approach , int regionId , ref int MaxSecId, ref int MaxMaterialId)
        {
            int minId = int.MaxValue;
            int maxId = int.MinValue;

            foreach (var beam in _beams)
            {
                beam.Group.NumericalModel.WriteFrameSgments(file, beam, approach, ref minId , ref maxId , ref MaxSecId , ref MaxMaterialId);
            }
            foreach (var column in _columns)
            {
                column.Group.NumericalModel.WriteFrameSgments(file, column, approach, ref minId, ref maxId, ref MaxSecId, ref MaxMaterialId);
            }
            if (maxId < minId)
                return false;
            file.WriteLine(string.Format("region {0} -eleRange {1} {2}", regionId, minId, maxId));
            return true;
        }
        internal bool WritePlasticHinges(StreamWriter file, int regionId, ref int MaxSecId, ref int MaxMaterialId)
        {
            List<PlasticHinge> plasticHinges = GetPlasticHinges();
            if (!plasticHinges.Any())
                return false;
            foreach (var Hinge in plasticHinges)
            {
                WritePlasticHinge(file, Hinge, Hinge.Family.WriteSection(file, Hinge.Lp, ref MaxSecId, ref MaxMaterialId));
            }
            file.WriteLine(string.Format("region {0} -eleRange {1} {2};", regionId, plasticHinges.First().ID, plasticHinges.Last().ID));
            return true;
        }
        private void WritePlasticHinge(StreamWriter file, PlasticHinge child, int AnalysisId)
        {
            file.WriteLine(string.Format("element zeroLengthSection {0} {1} {2} {3};"
                , child.ID, child.StartNode.ID, child.EndNode.ID, AnalysisId));
   
            if (child.StartNode.GetType() == typeof(MainNode))
            {
                MainNode master =_levels.FirstOrDefault(x => Math.Abs(x.Elevation-child.StartNode.Point.Y) < 1e-9).GetFirstLeftNode();
                if (master == child.StartNode)
                {
                    file.WriteLine(string.Format("equalDOF {0} {1} 1 2;", child.StartNode.ID, child.EndNode.ID));
                }
                else
                {
                    file.WriteLine(string.Format("equalDOF {0} {1} 1;", master.ID, child.EndNode.ID));
                    file.WriteLine(string.Format("equalDOF {0} {1} 2;", child.StartNode.ID, child.EndNode.ID));
                }
            }
            else if (child.EndNode.GetType() == typeof(MainNode))
            {
                MainNode master = _levels.FirstOrDefault(x => Math.Abs(x.Elevation - child.EndNode.Point.Y) < 1e-9).GetFirstLeftNode();
                if (master == child.EndNode)
                {
                    file.WriteLine(string.Format("equalDOF {0} {1} 1 2;", child.EndNode.ID, child.StartNode.ID));
                }
                else
                {
                    file.WriteLine(string.Format("equalDOF {0} {1} 1;", master.ID, child.StartNode.ID));
                    file.WriteLine(string.Format("equalDOF {0} {1} 2;", child.StartNode.ID, child.EndNode.ID));
                }
            }
            else
            {
                file.WriteLine(string.Format("equalDOF {0} {1} 1 2;", child.StartNode.ID, child.EndNode.ID));
            }
        }
        internal List<RotSpring> GetRotSprings()
        {
            List<RotSpring> result = new List<RotSpring>();
            result.AddRange(_gravityColumns.Select(x => x.StartHinge).Concat(_gravityColumns.Select(x => x.EndHinge))
                .Where(x => x != null).Cast<RotSpring>());
            return result.OrderBy(x => x.ID).ToList();
        }
        public int NumofLoadCases()
        {
            int res = 0;
            switch (_analysisParameters.AnalysisMethod)
            {
                case AnalysisMethod.Cyclic_Pushover:
                    res = 1;
                    break;
                case AnalysisMethod.Monotonic_Pushover_Analysis:
                    res = 1;
                    break;
                case AnalysisMethod.Time_History_Dynamic_Analysis:
                    res = _analysisParameters.TimeHistory_Parameters.GroundMotionFilePaths.Count;
                    break;
            }
            return res;
        }

        internal string GetAngleMethodName()
        {
            string res = "";
            switch (DesignApproach)
            {
                case DesignApproach.AISC_Tension_Field_Angle:
                    res = "AISC Tension Field Angle";
                    break;
                case DesignApproach.cardiff:
                    res = "Cardiff";
                    break;
                case DesignApproach.Basler:
                    res = "Basler";
                    break;
                case DesignApproach.UserDefined:
                    res = "User Defined";
                    break;
                default:
                    break;
            }
            return res;
        }
        internal double GetBaseShear( int currentLoadCase, int timeStep)
        {
            return -1 * SupportsNodes.Select(x => x.Reactions[currentLoadCase][timeStep].Rx).Sum();

        }
        internal double GetBaseShearOfFloor(int LevelIndex, int currentLoadCase, int timeStep)
        {
            List<Column> columns = new List<Column>();
            columns.Add(_columns[2*LevelIndex]);
            columns.Add(_columns[2* LevelIndex+1]);
            columns.Add(_gravityColumns[LevelIndex]);
            List<double> res = new List<double>();
            foreach (var col in columns)
            {
                if(col.Childs.Any())
                {
                    res.Add(Math.Abs(col.Childs[0].StartSectionForces[currentLoadCase][timeStep].Sf));
                }
            }
            
            return res.Sum();
        }
        public List<FrameElementFamily> GetAllFrameSectionFamily()
        {
            return _columnsSectionGroups.Select(x => x.FrameSection)
                .Concat(_beamsSectionGroups.Select(x => x.FrameSection))
                .Distinct().ToList();
        }
        public List<PlateFamily> GetAllPlateSectionFamily()
        {
             return _platesSectionGroups.Select(x => x.PlateSection).Distinct().ToList();
        }
        public List<Material> GetMaterials()
        {
            List<Material> result = new List<Material>();
            foreach (Material m in _columnsSectionGroups.Select(x =>x.FrameSection.FlangeMaterial)
                                 .Concat(_columnsSectionGroups.Select(x => x.FrameSection.WebMaterial))
                                 .Concat(_beamsSectionGroups.Select(x => x.FrameSection.FlangeMaterial))
                                 .Concat(_beamsSectionGroups.Select(x => x.FrameSection.WebMaterial))
                                 .Concat(_platesSectionGroups.Select(x => x.PlateSection.Material))
                                 .Distinct() )
            {
                if (!result.Contains(m))
                {
                    result.Add(m);
                }
            }
            return result;
        }

        internal void MatrialChanged(Material oldMatrial, Material newMaterial)
        {
            //if (!this.Materials.Contains(oldMatrial))
            //    return;

            //int i = Materials.IndexOf(oldMatrial);
            //Materials.Remove(newMaterial);
            //Materials.Insert(i, newMaterial);

            if (_frameFamilies != null)
            {
                foreach (var family in _frameFamilies.Where(x => x.WebMaterial.Equals(oldMatrial)))
                {
                    family.WebMaterial = newMaterial;
                }
                foreach (var family in _frameFamilies.Where(x => x.FlangeMaterial.Equals(oldMatrial)))
                {
                    family.FlangeMaterial = newMaterial;
                }

            }

            if (_plateFamilies != null)
            {
                foreach (var family in _plateFamilies.Where(x => x.Material.Equals(oldMatrial)))
                {
                    family.Material = newMaterial;
                }
            }
        }
        internal void NumModelListChanged()
        {
            if (_beamsSectionGroups != null)
            {
                _beamsSectionGroups.RemoveAll(x => !NumericalModels.Contains(x.NumericalModel));
            }
            if (_columnsSectionGroups != null)
            {
                _columnsSectionGroups.RemoveAll(x => !NumericalModels.Contains(x.NumericalModel));
            }
        }
        internal void MaterialListChanged()
        {
            if (_frameFamilies != null)
            {
                _frameFamilies.RemoveAll(x => !Materials.Contains(x.WebMaterial));
                _frameFamilies.RemoveAll(x => !Materials.Contains(x.FlangeMaterial));
            }

            if (_plateFamilies != null)
            {
                _plateFamilies.RemoveAll(x => !Materials.Contains(x.Material));
            }
        }
        internal void SectionListChanged()
        {
            if (_frameFamilies != null)
            {
                List<FrameElementFamily> toDeleteList = new List<FrameElementFamily>();
                foreach (var family in _frameFamilies.Where(x => !SectionsList.Contains(x.Section)))
                {
                    IShapeSection section = SectionsList.FirstOrDefault(x => x.IsEgual(family.Section));
                    if (section == null)
                    {
                        toDeleteList.Add(family);
                        continue;
                    }

                    family.Section = section;
                }
                toDeleteList.ForEach(x => _frameFamilies.Remove(x));
            }
        }

       
        #endregion
    }
    public enum ModelStage
    {
        Dimensions,
        Material,
        Sections,
        Families,
        Sketch,
        Deadloads,
        ModalAnalysis,
        LateralResistance,
        Lateralloads,
        Run,
        Results
    }
}
