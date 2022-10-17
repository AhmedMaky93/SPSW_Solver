using BasicModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPSW_Solver.UI.Selection
{
    public class RigidLinkProperties : ObjectProperties
    {

        [Browsable(false)]
        public RigidLink RigidLink
        {
            get { return Obj as RigidLink; }
        }

        [Category("Geomertry")]
        [ReadOnly(true)]
        [DisplayName("Start Point")]
        public string StartPoint
        {
            get { return RigidLink.StartNode.Point.ToString(); }
        }

        [Category("Geomertry")]
        [ReadOnly(true)]
        [DisplayName("End Point")]
        public string EndPoint
        {
            get { return RigidLink.EndNode.Point.ToString(); }
        }

        public RigidLinkProperties(RigidLink frameElement) : base(frameElement, "Rigid Link")
        {

        }

    }

    public class RegularFrameElementProperties : ObjectProperties
    {

        [Browsable(false)]
        public RegularFrameElement FrameElement
        {
            get { return Obj as RegularFrameElement; }
        }

        [Category("Geomertry")]
        [ReadOnly(true)]
        [DisplayName("Start Point")]
        public string StartPoint
        {
            get { return FrameElement.Nodes.First().Point.ToString(); }
        }

        [Category("Geomertry")]
        [ReadOnly(true)]
        [DisplayName("End Point")]
        public string EndPoint
        {
            get { return FrameElement.Nodes.Last().Point.ToString(); }
        }

        [Category("Section")]
        [DisplayName("Section Name")]
        public string SectionName { get { return FrameElement.Family == null ? "Not Assigned" : FrameElement.Family.Name; } }
        [Category("Section")]
        [DisplayName("Flange Material")]
        public string FlangeMaterialName { get { return FrameElement.Family == null ? "Not Assigned" : FrameElement.Family.FlangeMaterial.BasicData.Name; } }
        [Category("Section")]
        [DisplayName("Web Material")]
        public string WebMaterialName { get { return FrameElement.Family == null ? "Not Assigned" : FrameElement.Family.WebMaterial.BasicData.Name; } }

        [Category("Section")]
        [DisplayName("Corss Section")]
        public string Section { get { return FrameElement.Family == null? "Not Assigned": FrameElement.Family.Section.Name; } }

        [Category("Section")]
        [DisplayName("Numerical Model")]
        public string NumericalModel { get { return FrameElement.Group == null ? "Not Assigned" : FrameElement.Group.NumericalModel.Name; } }

        [Category("Analysis")]
        [DisplayName("Results")]
        public FrameElementResultEditor Results { get; set; }

        [Category("Analysis")]
        [DisplayName("Moment-Rotation Results")]
        public FrameElementPlasticityResultEditor NonLinearResults { get; set; }

        public RegularFrameElementProperties(RegularFrameElement frameElement,string typename):base(frameElement , typename)
        {
            Results = new FrameElementResultEditor(frameElement);
            NonLinearResults = new FrameElementPlasticityResultEditor(frameElement);
        }
       
    }

    public class ColumnProperties : RegularFrameElementProperties
    {
        public ColumnProperties(Column column) :base(column,"Column")
        {

        }
    }
    public class BeamProperties : RegularFrameElementProperties
    {
        public BeamProperties(Beam beam):base(beam, "Beam")
        {

        }
    }
}
