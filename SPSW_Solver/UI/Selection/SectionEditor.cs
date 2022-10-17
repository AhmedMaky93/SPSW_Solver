using BasicModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;

namespace SPSW_Solver.UI.Selection
{
    [Editor(typeof(SectionAttactchmentEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(SectionConverter))]
    public class SectionEditor
    {
        public IRenderable Obj { get;  protected set; }
        public SectionEditor(IRenderable obj)
        {
            this.Obj = obj;
        }
    }

    public class SectionAttactchmentEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            SelectionFrm frm = new SelectionFrm();
            frm.Text = "Select section";
            List<IShapeSection>  sections = ObjectProperties.CurrentModel.SectionsList;
            if (sections != null && sections.Any())
            {
                IShapeSection Currentsection = null;
                IRenderable obj = (value as SectionEditor).Obj;
                if (obj is RegularFrameElement)
                {
                    Currentsection = (obj as RegularFrameElement).Family.Section as IShapeSection;
                }
                frm.LoadAction = () =>
                {
                    frm.listBox.DataSource = new List<IShapeSection>(sections);
                    frm.listBox.DisplayMember = "Name";
                    frm.listBox.SelectedIndex = sections.IndexOf(Currentsection);
                };
                frm.OkAction = () =>
                {
                    //if (obj is RegularFrameElement)
                    //{
                    //    (obj as RegularFrameElement).Section = frm.listBox.SelectedItem as Section;
                    //}
                };
                frm.ShowDialog();
            }
            return value;
        }

    }
    internal class SectionConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
                                         System.Globalization.CultureInfo culture,
                                         object value, Type destType)
        {
            if (destType == typeof(string) && value is SectionEditor )
            {
                SectionEditor exl = (SectionEditor)value;

                string sectionName = "Not Assigned";

                if ((exl != null) && (exl.Obj != null))
                {
                    if (exl.Obj is RegularFrameElement)
                    {
                        RegularFrameElement frame = (exl.Obj as RegularFrameElement);
                        if (frame.Family.Section != null)
                        {
                            sectionName = frame.Family.Section.Name;
                        }
                    }
                }
                return sectionName;
            }

            return base.ConvertTo(context, culture, value, destType);
        }
    }

}