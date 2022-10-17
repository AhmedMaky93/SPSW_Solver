using SPSW_Solver.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSW_Solver.UI.Selection
{
    [Editor(typeof(SPBeyResultFrmEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(SPBeyResultConverter))]
    public class SPBeyResultEditor
    {
        public SPBey ShearPlate { get; set; }
        public SPBeyResultEditor(SPBey shearPlate)
        {
            this.ShearPlate = shearPlate;
        }
    }
    internal class SPBeyResultFrmEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (value is SPBeyResultEditor && ObjectProperties.CurrentModel != null && ObjectProperties.CurrentModel.Solved)
            {
                ShearPlateResultFrm frm = new ShearPlateResultFrm((value as SPBeyResultEditor).ShearPlate);
                frm.ShowDialog();
                ObjectProperties.ReturnAction();
            }
            return value;
        }
    }
    internal class SPBeyResultConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
                                         System.Globalization.CultureInfo culture,
                                         object value, Type destType)
        {
            if (destType == typeof(string) && value is SPBeyResultEditor && ObjectProperties.CurrentModel != null)
            {
                return ObjectProperties.CurrentModel.Solved ? "Show results" : "Not solved";
            }

            return base.ConvertTo(context, culture, value, destType);
        }
    }

}
