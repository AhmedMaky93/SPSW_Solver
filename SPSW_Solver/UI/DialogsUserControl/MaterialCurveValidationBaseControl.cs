using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSW_Solver.BasicModel;

namespace SPSW_Solver
{
    public partial class MaterialCurveValidationBaseControl : UserControl
    {
        public DialogMaterialCurveControl ParentControl { get; set; }
        public MaterialCurveValidationBaseControl()
        {
            InitializeComponent();
        }
        public virtual bool ValidateInput()
        {
            return false;
        }
        public virtual Material CreateMaterial()
        {
            return null;
        }
        public virtual void ClearValidationMessages()
        {

        }
        public virtual void InitializeGraph()
        {

        }
    }
}
