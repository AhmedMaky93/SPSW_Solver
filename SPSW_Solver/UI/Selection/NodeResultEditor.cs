using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing.Design;
using BasicModel;

namespace SPSW_Solver.UI.Selection
{
    [Editor(typeof(NodeResultFrmEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(NodeResultConverter))]
    public class NodeResultEditor
    {
        public MainNode Node { get; protected set; }
        public NodeResultEditor(MainNode node)
        {
            this.Node = node;
        }
    }

    internal class NodeResultFrmEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (value is NodeResultEditor  && ObjectProperties.CurrentModel != null && ObjectProperties.CurrentModel.Solved)
            {
                NodesGraphsFrm frm = new NodesGraphsFrm((value as NodeResultEditor).Node);
                frm.ShowDialog();
            }
            return value;
        }
    }

    internal class NodeResultConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
                                         System.Globalization.CultureInfo culture,
                                         object value, Type destType)
        {
            if (destType == typeof(string) && value is NodeResultEditor && ObjectProperties.CurrentModel != null)
            {
                return ObjectProperties.CurrentModel.Solved ? "Show results" : "Not solved"; 
            }

            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
