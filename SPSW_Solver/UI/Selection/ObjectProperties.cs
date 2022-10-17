using BasicModel;
using MathNet.Spatial.Euclidean;
using SPSW_Solver.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSW_Solver.UI.Selection
{    

    public abstract class ObjectProperties
    {
        [Category("Object type")]
        [ReadOnly(true)]
        [DisplayName("Type")]
        public string Type
        { get; set; }

        [Browsable(false)]
        public IRenderable Obj { get; protected set; }

        public static Action ModelChanged;
        public static Action ReturnAction;
        public static SPSW_Simple_Model CurrentModel;
        public ObjectProperties(IRenderable obj, string Name)
        {
            Type = Name;
            Obj = obj;
            SetProperties();
        }

        protected virtual void SetProperties()
        {
            
        }
    }
    public class MainNodeProperties : ObjectProperties
    {
        [Browsable(false)]
        public MainNode Node
        {
            get { return Obj as MainNode; }
        }

        [Category("Geomertry")]
        [ReadOnly(true)]
        [DisplayName("Point")]
        public string Point  
        { 
            get { return Node.Point.ToString(); }
        }
        [Category("Analysis")]
        [DisplayName("Results")]
        public NodeResultEditor Results { get; set; }

        [Category("Analysis")]
        [ReadOnly(true)]
        [DisplayName("Node mass")]
        public double NodeMass {

            get { return Math.Round(Node.NodeMass,4); }
        }
        public MainNodeProperties(MainNode Node):base(Node ,"Node")
        {
            Results = new NodeResultEditor(Node);
        }
        protected override void SetProperties()
        {

        }
    }
    public class SupportingMainNodeProperties : MainNodeProperties
    {
        [Browsable(false)]
        public SupportsMainNode SupportingNode
        {
            get { return Obj as SupportsMainNode; }
        }

        [Category("Support Type")]
        [DisplayName("Support")]
        public SupportType SupportType
        {
            get { return SupportingNode.Type; }
            set
            {
                SupportingNode.Type = value;
                ModelChanged();
            }
        }

        public SupportingMainNodeProperties(SupportsMainNode mainNode):base(mainNode)
        {

        }
    }
}
