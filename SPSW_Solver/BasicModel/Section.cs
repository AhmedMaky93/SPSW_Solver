using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BasicModel
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(RectangleSection))]
    [KnownType(typeof(IShapeSection))]
    public class Section
    {
        #region Static Members
        public static int LastID;
        #endregion

        #region Members
        [DataMember]
        protected string _name;
        [DataMember]
        protected int _ID;
        [DataMember]
        protected double _A;
        [DataMember]
        protected double _Ix;
        [DataMember]
        protected double _Iy;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public double A
        {
            get { return _A; }
        }
        public double Ix
        {
            get { return _Ix; }
        }
        public double Iy
        {
            get { return _Iy; }
        }
        #endregion

        #region Constructors
        public Section()
        {

        }
        #endregion
    }
    [DataContract(IsReference = true)]
    public class RectangleSection : Section
    {
        #region Members
        [DataMember]
        protected double _D;
        [DataMember]
        protected double _B;
        #endregion

        #region Properties
        public double D
        {
            get { return _D; }
        }
        public double B
        {
            get { return _B; }
        }
        #endregion

        #region Constructors
        public RectangleSection()
        {

        }
        public RectangleSection(int ID, string Name, double width, double depth)
        {
            _name = Name;
            _ID = ID;
            _B = width;
            _D = depth;
            SetProperties();
        }
        #endregion

        #region Methods
        private void SetProperties()
        {
            _A = _D * _B;
            _Ix = _B * Math.Pow(_D, 3) / 12.0;
            _Iy = _D * Math.Pow(_B, 3) / 12.0;
        }
        #endregion

    }
    [DataContract(IsReference = true)]
    public class IShapeSection : Section
    {
        #region Members
        [DataMember]
        protected double _Bf;
        [DataMember]
        protected double _D;
        [DataMember]
        protected double _Tf;
        [DataMember]
        protected double _Tw;
        #endregion

        #region Properties
        public double Bf
        {
            get { return _Bf; }
        }
        public double D
        {
            get { return _D; }
        }
        public double Tf
        {
            get { return _Tf; }
        }
        public double Tw
        {
            get { return _Tw; }
        }
        #endregion

        #region Constructors
        public IShapeSection()
        {

        }
        public static IShapeSection CreateDummySection(double d)
        {
            IShapeSection sec = new IShapeSection();
            sec.ID = 0;
            sec._D = d;
            return sec;
        }
        #endregion

        #region Methods
        internal static IShapeSection ReadRecord(XmlNode dr)
        {
            try
            {
                IShapeSection section = new IShapeSection();

                section._name = dr["Name"].InnerText;

                double value;

                if (!double.TryParse(dr["A"].InnerText, out value))
                    return null;
                section._A = value;

                if (!double.TryParse(dr["Ix"].InnerText, out value))
                    return null;
                section._Ix = value;

                if (!double.TryParse(dr["Iy"].InnerText, out value))
                    return null;
                section._Iy = value;

                if (!double.TryParse(dr["Bf"].InnerText, out value))
                    return null;
                section._Bf = value;

                if (!double.TryParse(dr["D"].InnerText, out value))
                    return null;
                section._D = value;

                if (!double.TryParse(dr["Tf"].InnerText, out value))
                    return null;
                section._Tf = value;

                if (!double.TryParse(dr["Tw"].InnerText, out value))
                    return null;
                section._Tw = value;
                return section;
            }
            catch
            {
                return null;
            }

        }

        internal static IShapeSection ReadRecord(DataRow dr)
        {
            try
            {
                IShapeSection section = new IShapeSection();
                
                section._name = dr.Field<string>("NAME");

                double value;

                if (!double.TryParse(dr.Field<string>("A"), out value))
                    return null;
                section._A = value;

                if (!double.TryParse(dr.Field<string>("Ix"), out value))
                    return null;
                section._Ix = value;

                if (!double.TryParse(dr.Field<string>("Iy"), out value))
                    return null;
                section._Iy = value;

                if (!double.TryParse(dr.Field<string>("Bf"), out value))
                    return null;
                section._Bf = value;

                if (!double.TryParse(dr.Field<string>("D"), out value))
                    return null;
                section._D = value;

                if (!double.TryParse(dr.Field<string>("Tf"), out value))
                    return null;
                section._Tf = value;

                if (!double.TryParse(dr.Field<string>("Tw"), out value))
                    return null;
                section._Tw = value;
                return section;
            }
            catch
            {
                return null;
            }

        }

        internal bool IsEgual(IShapeSection other)
        {
            double tolerance = 0.000001;

            if (Math.Abs(_A - other._A) > tolerance)
                return false;

            if (Math.Abs(_Ix - other._Ix) > tolerance)
                return false;

            if (Math.Abs(_Iy - other._Iy) > tolerance)
                return false;

            if (Math.Abs(_Bf - other._Bf) > tolerance)
                return false;

            if (Math.Abs(_D - other._D) > tolerance)
                return false;

            if (Math.Abs(_Tf - other._Tf) > tolerance)
                return false;

            if (Math.Abs(_Tw - other._Tw) > tolerance)
                return false;

            return true;
        }

        public double GetMy(double Fy)
        {
            return Fy * Calc_S();
        }
        public double Calc_S()
        {
            return 2 * _Ix / D;
        }
        public double GetMc(double Fy)
        {
            return Fy * Calc_Zp();
        }
        public double MCMY()
        {
            return  Calc_Zp() / Calc_S();
        }
        public double Calc_Zp()
        {
            return _Bf * _Tf * (_D - _Tf) + 0.25 * _Tw  * Math.Pow(_D-2* _Tf, 2);
        }
        #endregion

    }
}
