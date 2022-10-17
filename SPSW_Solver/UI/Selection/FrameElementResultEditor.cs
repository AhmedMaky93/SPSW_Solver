using BasicModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSW_Solver.UI.Selection
{
    [Editor(typeof(FrameElementResultFrmEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(FrameElementResultConverter))]
    public class FrameElementResultEditor
    {
         public RegularFrameElement Element { get; set; }

        public FrameElementResultEditor(RegularFrameElement Element)
        {
            this.Element = Element;
        }
    }
    internal class FrameElementResultFrmEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (value is FrameElementResultEditor && ObjectProperties.CurrentModel != null && ObjectProperties.CurrentModel.Solved)
            {
                FrameElementResultfrm frm = new FrameElementResultfrm((value as FrameElementResultEditor).Element);
                frm.ShowDialog();
            }
            return value;
        }
    }
    internal class FrameElementResultConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
                                         System.Globalization.CultureInfo culture,
                                         object value, Type destType)
        {
            if (destType == typeof(string) && value is FrameElementResultEditor && ObjectProperties.CurrentModel != null)
            {
                return ObjectProperties.CurrentModel.Solved ? "Show results" : "Not solved";
            }

            return base.ConvertTo(context, culture, value, destType);
        }
    }


    [Editor(typeof(FrameElementPlasticityResultFrmEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(FrameElementPlasticityResultConverter))]
    public class FrameElementPlasticityResultEditor
    {
        public RegularFrameElement Element { get; set; }

        public FrameElementPlasticityResultEditor(RegularFrameElement Element)
        {
            this.Element = Element;
        }
    }
    internal class FrameElementPlasticityResultFrmEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            bool showFrm = false;
            if (value is FrameElementPlasticityResultEditor && ObjectProperties.CurrentModel != null && ObjectProperties.CurrentModel.Solved)
            {
                RegularFrameElement element = (value as FrameElementPlasticityResultEditor).Element;
                if (element == null)
                    showFrm = false; ;

                if (element.Group.NumericalModel is FiberPlasticSections && element.PlasticHinges.Any())
                    showFrm = true;

                if (element.Group.NumericalModel is BeamWithHingesModel && element.Childs.Any(x => x.Representation == PlasticHingeApproach.BeamWithHinges))
                    showFrm = true;

                if (element.Group.NumericalModel is NonLinearBeams && element.Childs.Any(x => x.Representation == PlasticHingeApproach.NolinearBeamColumn))
                    showFrm = true;

                if (showFrm)
                {
                    PlasticityReuslts frm = new PlasticityReuslts(ObjectProperties.CurrentModel,element);
                    frm.ShowDialog();
                }
            }
            return value;
        }
    }
    internal class FrameElementPlasticityResultConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
                                         System.Globalization.CultureInfo culture,
                                         object value, Type destType)
        {
            if (destType == typeof(string) && value is FrameElementPlasticityResultEditor && ObjectProperties.CurrentModel != null)
            {
                if (ObjectProperties.CurrentModel.Solved)
                {
                    RegularFrameElement element = (value as FrameElementPlasticityResultEditor).Element;

                    if (element == null)
                        return "Not solved";

                    if (element.Group.NumericalModel is FiberPlasticSections && element.PlasticHinges.Any())
                        return "Show results";

                    if (element.Group.NumericalModel is BeamWithHingesModel && element.Childs.Any(x =>x.Representation == PlasticHingeApproach.BeamWithHinges ))
                        return "Show results";

                    if (element.Group.NumericalModel is NonLinearBeams && element.Childs.Any(x => x.Representation == PlasticHingeApproach.NolinearBeamColumn))
                        return "Show results";

                    return "No results to show";
                }
                else
                {
                    return "Not solved";
                }
            }

            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
