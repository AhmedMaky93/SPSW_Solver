using SPSW_Solver.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPSW_Solver.UI.Selection
{
    public class SPBeyProperties : ObjectProperties
    {

        [Browsable(false)]
        public SPBey ShearPlate
        {
            get { return Obj as SPBey; }
        }

        [Category("Geometry")]
        [DisplayName("Floor")]
        public int Floor
        {
            get { return ShearPlate.FloorIndex +1; }
        }
        [Category("Geometry")]
        [DisplayName("Vertical Angle")]
        public double Angle
        {
            get { return Math.Round(ShearPlate.ActualVerticalAngle.Degrees,3,MidpointRounding.AwayFromZero); }
        }
        [Category("Geometry")]
        [DisplayName("Trusses Spacing")]
        public double TrussesSpace
        {
            get { return ShearPlate.TrussGroup.TrussesSpace; }
        }

        [Category("Section")]
        [DisplayName("Section Name")]
        public string Name
        {
            get { return ShearPlate.PlateSection.Name; }
        }
        [Category("Section")]
        [DisplayName("Thickness")]
        public double Thickness
        {
            get { return ShearPlate.PlateSection.Thickness; }
            //set
            //{
            //    if (value > 0)
            //    {
            //        ShearPlate.PlateThickness = value;
            //    }
            //}
        }

        [Category("Section")]
        [DisplayName("Material")]
        public string Material
        {
            get { return ShearPlate.PlateSection.Material.BasicData.Name; }
        }

        [Category("Analysis")]
        [DisplayName("Results")]
        public SPBeyResultEditor Results { get; set; }

        public SPBeyProperties(SPBey shearPlate):base(shearPlate,"Shear Plate")
        {
            Results = new SPBeyResultEditor(shearPlate);
        }


    }
}
