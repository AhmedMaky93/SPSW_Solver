using BasicModel;
using SPSW_Solver.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading;
using SPSW_Solver.UI.Selection;
using System.Runtime.Serialization;
using System.Xml;

namespace SPSW_Solver
{
    public partial class MainFrm : Form
    {
        protected SPSW_Simple_Model Model { get; set; }

        protected string path = "";
        protected List<IShapeSection> SectionsList { get; set; } = new List<IShapeSection>();

        internal DiagramHandler GetScaleHandler()
        {
            if (_viewer is DiagramViewer)
            {
                return (_viewer as DiagramViewer).ScaleHandler;
            }
            return null;
        }

        protected BasicViewer _viewer;
        public bool Running { get; set; } = false;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void PresentModel()
        {
            Model.SetRelativeDimension();
            Model.ResetStaticVariables();
            StageControl[] arr = new StageControl[]
            {
               modelStageControl1,
               materialControl1,
               sectionControl1,
               elementsFamilyControl1,
               sketchStageControl1,
               deadLoadsControl1,
               modalAnalysisControl1,
               lateralLoadSettingsControl1,
               lateralLoadsControl1,
               runControl1,
               resultControl1
            };
            int StageCase = 0;
            switch (Model.Stage)
            {
                case ModelStage.Dimensions:
                    StageCase = 0;
                    InitializeModelDialog();
                    break;
                case ModelStage.Material:
                    StageCase = 1;
                    InitializeMaterialDialog();
                    break;
                case ModelStage.Sections:
                    StageCase = 2;
                    InitializeSectionDialog();
                    break;
                case ModelStage.Families:
                    StageCase = 3;
                    InitializeFamiliesDialog();
                    break;
                case ModelStage.Sketch:
                    StageCase = 4;
                    InitializeSketchDialog();
                    break;
                case ModelStage.Deadloads:
                    StageCase = 5;
                    InitializeDeadLoadDialog();
                    break;
                case ModelStage.ModalAnalysis:
                    StageCase = 6;
                    InitializeModalAnalysisDialog();
                    break;
                case ModelStage.LateralResistance:
                    StageCase = 7;
                    InitializeResponseSpectrumDialog();
                    break;
                case ModelStage.Lateralloads:
                    StageCase = 8;
                    InitializeLateralLoadDialog();
                    break;
                case ModelStage.Run:
                    StageCase = 9;
                    InitializeRunDialog();
                    break;
                case ModelStage.Results:
                    StageCase = 10;
                    InitializeShowResultDialog();
                    break;
                default:
                    break;
            }
            for (int i = 0; i < StageCase; i++)
            {
                arr[i].Status = StageStatus.Accepted;
            }
            arr[StageCase].Status = StageStatus.Current;
            for (int i = StageCase+1; i < arr.Length; i++)
            {
                arr[i].Status = StageStatus.Default;
            }
        }
        private void OpenAboutFrm()
        {
            (new AboutDocsFrm()).ShowDialog();
        }
        private bool OpenFile()
        {
            Openfrm openfrm = new Openfrm();
            bool init = false;
            openfrm.NewFile += () =>
            {
                Model = new SPSW_Simple_Model();
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\" ;      
                saveFileDialog1.Title = "Select file name and directory";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "spsw";
                saveFileDialog1.Filter = "Steel Plate Shear Wall (*.spsw)|*.spsw";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                    init = true;
                    openfrm.Close();
                }
            };
            openfrm.OpenFile += () =>
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Open saved file";
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.DefaultExt = "spsw";
                openFileDialog1.Filter = "Steel Plate Shear Wall (*.spsw)|*.spsw";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    DataContractSerializer ser = new DataContractSerializer(typeof(SPSW_Simple_Model));
                    Model = ser.ReadObject(reader) as SPSW_Simple_Model;
                    fs.Close();
                    init = true;
                    openfrm.Close();
                }

            };
            openfrm.HelpWindow += OpenAboutFrm;
            openfrm.ShowDialog();
            return init;
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (OpenFile())
            {
                LoadSectionsList();
                RemoveRedundantSections();
                PresentModel();
            }
            else 
            {
                Close();
            }
        }
        private void RemoveRedundantSections()
        {
            Model?.SectionsList?.ForEach(x =>
            {
                SectionsList.RemoveAll(s => x.IsEgual(s));
                SectionsList.Add(x);
            });
            Model?.SectionListChanged();
            SectionsList = SectionsList.OrderBy(x => x.ID).ToList();
            for (int i = 0; i < SectionsList.Count; i++)
            {
                SectionsList[i].ID = i+1 ;
            }
        }

        private void LoadSectionsList()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Properties.Resources.Data); //myXmlString is the xml file in string //copying xml to string: string myXmlString = xmldoc.OuterXml.ToString();
            XmlNodeList xnList = xml.DocumentElement.ChildNodes;
            foreach (XmlNode xn in xnList)
            {
                IShapeSection section = IShapeSection.ReadRecord(xn);
                if (section != null)
                {
                    SectionsList.Add(section);
                }
            }

            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ISections.xlsx");
            //System.Data.DataTable tb = ReadDataExcel(path);
            //foreach (DataRow dr in tb.Rows)
            //{
            //    IShapeSection section = IShapeSection.ReadRecord(dr);
            //    if (section != null)
            //    {
            //        SectionsList.Add(section);
            //    }
            //}
            SectionsList = SectionsList.OrderBy(x => x.D).ThenBy(x=>x.Bf).ToList();
            for (int i = 0; i < SectionsList.Count; i++)
            {
                SectionsList[i].ID = i + 1;
            }
            Section.LastID = SectionsList.Count;
        }

        public System.Data.DataTable ReadDataExcel(string filepath)
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
            _Worksheet xlWorksheet = xlWorkbook.Sheets[1] as _Worksheet;
            Range xlRange = xlWorksheet.UsedRange;

            System.Data.DataTable dt = new System.Data.DataTable();
            for (int j = 1; j <= xlRange.Columns.Count; j++)
            {
                if (xlRange.Cells[1, j] != null)
                {
                    string str = (string)(xlRange.Cells[1, j] as Range).Value2;
                    dt.Columns.Add(str);
                }
            }

            for (int i = 2; i <= xlRange.Rows.Count; i++)
            {
                List<object> strs = new List<object>();
                for (int j = 1; j <= xlRange.Columns.Count; j++)
                {
                    if (xlRange.Cells[i, j] != null)
                    {
                        strs.Add((xlRange.Cells[i, j] as Range).Value2);
                    }
                }
                dt.Rows.Add(strs.ToArray());
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background

            //close and release
            xlWorkbook.Close(true);
            xlApp.Quit();

            //quit and release
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
            return dt;
        }
        internal void InitializeTheViewer()
        {
            IRenderable selectedObj = null;
            if ((_viewer as ModelViewer2D) != null)
            {
                selectedObj = _viewer.SelectedObject;
            }
            Drawing_Panel.Controls.Clear();
            _viewer?.Dispose();
            _viewer = new ModelViewer2D(this.Model);
            _viewer.SelectionChanged += UpdaterSelection;
            ObjectProperties.ModelChanged = null;
            ObjectProperties.ModelChanged += _viewer.UpdateEx;
            ObjectProperties.ReturnAction = null;
            ObjectProperties.ReturnAction += InitializeTheViewer;
            ObjectProperties.CurrentModel = this.Model;
            _viewer.SelectedObject = selectedObj;
            Drawing_Panel.Controls.Add(_viewer);
            _viewer.Dock = DockStyle.Fill;
        }
        internal void InitializeDeformationViewer()
        {
            _viewer?.ClearSelectionReference();
            Drawing_Panel.Controls.Clear();
            
            _viewer?.Dispose();
            _viewer = new DeformationViewer(this.Model);
            _viewer.SelectionChanged += UpdaterSelection;
            ObjectProperties.ModelChanged = null;
            ObjectProperties.ModelChanged += _viewer.UpdateEx;
            ObjectProperties.ReturnAction = null;
            ObjectProperties.ReturnAction += InitializeDeformationViewer;
            ObjectProperties.CurrentModel = this.Model;
           // _viewer.SelectedObject = selectedObj;
            Drawing_Panel.Controls.Add(_viewer);
            _viewer.Dock = DockStyle.Fill;
        }
        internal void InitializeModeShapeViewer()
        {
            _viewer?.ClearSelectionReference();
            Drawing_Panel.Controls.Clear();

            _viewer?.Dispose();
            _viewer = new ModelShapeViewer(this.Model, DialogModalAnalysisControl.CurrentModeShape);
            _viewer.SelectionChanged += UpdaterSelection;
            ObjectProperties.ModelChanged = null;
            ObjectProperties.ModelChanged += _viewer.UpdateEx;
            ObjectProperties.ReturnAction = null;
            ObjectProperties.ReturnAction += InitializeModeShapeViewer;
            ObjectProperties.CurrentModel = this.Model;
            // _viewer.SelectedObject = selectedObj;
            Drawing_Panel.Controls.Add(_viewer);
            _viewer.Dock = DockStyle.Fill;
        }
        private void SaveModel()
        {
            this.Model?.Serialize(path);
        }
        internal void InitializeNFDViewer()
        {
            _viewer?.ClearSelectionReference();
            Drawing_Panel.Controls.Clear();

            _viewer?.Dispose();
            _viewer = new DiagramViewer(this.Model,DiagramType.NormalForce);
            _viewer.SelectionChanged += UpdaterSelection;
            ObjectProperties.ModelChanged = null;
            ObjectProperties.ModelChanged += _viewer.UpdateEx;
            ObjectProperties.ReturnAction = null;
            ObjectProperties.ReturnAction += InitializeNFDViewer;
            ObjectProperties.CurrentModel = this.Model;
            // _viewer.SelectedObject = selectedObj;
            Drawing_Panel.Controls.Add(_viewer);
            _viewer.Dock = DockStyle.Fill;
        }
        internal void InitializeSFDViewer()
        {
            _viewer?.ClearSelectionReference();
            Drawing_Panel.Controls.Clear();

            _viewer?.Dispose();
            _viewer = new DiagramViewer(this.Model, DiagramType.ShearForce);
            _viewer.SelectionChanged += UpdaterSelection;
            ObjectProperties.ModelChanged = null;
            ObjectProperties.ModelChanged += _viewer.UpdateEx;
            ObjectProperties.ReturnAction = null;
            ObjectProperties.ReturnAction += InitializeSFDViewer;
            ObjectProperties.CurrentModel = this.Model;
            // _viewer.SelectedObject = selectedObj;
            Drawing_Panel.Controls.Add(_viewer);
            _viewer.Dock = DockStyle.Fill;
        }
        internal void InitializeBMDViewer()
        {
            _viewer?.ClearSelectionReference();
            Drawing_Panel.Controls.Clear();

            _viewer?.Dispose();
            _viewer = new DiagramViewer(this.Model, DiagramType.BendingMoment);
            _viewer.SelectionChanged += UpdaterSelection;
            ObjectProperties.ModelChanged = null;
            ObjectProperties.ModelChanged += _viewer.UpdateEx;
            ObjectProperties.ReturnAction = null;
            ObjectProperties.ReturnAction += InitializeBMDViewer;
            ObjectProperties.CurrentModel = this.Model;
            // _viewer.SelectedObject = selectedObj;
            Drawing_Panel.Controls.Add(_viewer);
            _viewer.Dock = DockStyle.Fill;
        }
        private void DeleteTheViewer()
        {
            Drawing_Panel.Controls.Clear();
            _viewer = null;
        }
        private void UpdaterSelection(IRenderable selectedObject)
        {
            propertyGrid1.SelectedObject = null;

            if (selectedObject != null)
            {
                propertyGrid1.SelectedObject = selectedObject.GetProperties();
            }

        }
        protected void BackModelDialog()
        {
            Model = new SPSW_Simple_Model();
            InitializeModelDialog();
        }
        protected void InitializeModelDialog()
        {
            Node.LastID = 1;
            Element2d.LastID = 1;
            Drawing_Panel.Controls.Clear();
            _viewer = null;
            Dialogs_Panel.Controls.Clear();
            ModelSettingDialogControl dialog = new ModelSettingDialogControl();
            dialog.SetMainData(this.Model , ModelStage.Dimensions, InitializeMaterialDialog, BackModelDialog, this.modelStageControl1);
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        
        protected void InitializeSectionDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogSectionControl dialog = new DialogSectionControl(SectionsList);
            dialog.SetMainData(this.Model, ModelStage.Sections, InitializeFamiliesDialog, InitializeMaterialDialog, this.sectionControl1);
            dialog.SelectedSectionList = this.Model.SectionsList;
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        protected void InitializeFamiliesDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogSectionFamiliesControl dialog = new DialogSectionFamiliesControl();
            dialog.SetMainData(this.Model, ModelStage.Families, InitializeSketchDialog, InitializeSectionDialog, this.elementsFamilyControl1);
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        
        protected void RefreshMainViewer()
        {
            if (_viewer == null)
            {
                InitializeTheViewer();
            }
            else if(!(_viewer is ModelViewer2D))
            {
                StopTimer();
                InitializeTheViewer();
            }
            _viewer?.UpdateEx();
        }
        protected void InitializeMaterialDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogMaterialControl dialog = new DialogMaterialControl();
            dialog.SetMainData(this.Model, ModelStage.Material, InitializeSectionDialog , InitializeModelDialog, this.materialControl1);
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        protected void InitializeSketchDialog()
        {
            Model.ResetStaticVariables();
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogSketchControl dialog = new DialogSketchControl();
            dialog.SetMainData(this.Model, ModelStage.Sketch, InitializeDeadLoadDialog, InitializeFamiliesDialog, this.sketchStageControl1);
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        protected void BackDeadLoadControl()
        {
            this.Model.MainNodes.ForEach(x => x.ClearNodeMass());
            this.Model.SupportsNodes.ForEach(x => x.ClearNodeMass());
            Model.ClearElements();
            InitializeSketchDialog();
        }
        protected void InitializeDeadLoadDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogDeadLoadControl dialog = new DialogDeadLoadControl();
            dialog.SetMainData(this.Model, ModelStage.Deadloads, InitializeModalAnalysisDialog, BackDeadLoadControl, this.deadLoadsControl1);
            dialog.FloorsDeadLoads = this.Model.FloorsDeadLoads;
            dialog.Modifiers = new double[] { this.Model.RigidLinkModifier, this.Model.GravityCoulmnModifier};
            Dialogs_Panel.Controls.Add(dialog);
            dialog.InitializeDataGridView();
            dialog.AutomaticDeadLoads_Chb.Checked = this.Model.AddDeadLoadsAutomatically;
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        protected void BackModalAnalysisDialog()
        {
            this.Model.ClearModalAnalysisRun();
            RefreshMainViewer();
            InitializeDeadLoadDialog();
        }
        protected void InitializeModalAnalysisDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogModalAnalysisControl dialog = new DialogModalAnalysisControl(this, Model.AnalysisOptions);
            dialog.SaveFile += SaveModel;
            dialog.ScaleChanged += OnScaleChanged;
            dialog.SetMainData(this.Model, ModelStage.ModalAnalysis, InitializeResponseSpectrumDialog, BackModalAnalysisDialog, this.modalAnalysisControl1);
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        protected void InitializeResponseSpectrumDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogLateralResistance dialog = new DialogLateralResistance();
            dialog.SetMainData(this.Model, ModelStage.ModalAnalysis, InitializeLateralLoadDialog, InitializeModalAnalysisDialog, this.lateralLoadSettingsControl1);
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        protected void InitializeLateralLoadDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogLateralLoadControl dialog = new DialogLateralLoadControl();
            dialog.SetMainData(this.Model, ModelStage.Lateralloads, InitializeRunDialog, InitializeResponseSpectrumDialog, this.lateralLoadsControl1);
            dialog.parameters = this.Model.AnalysisParameters;
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }
        protected void BackRunDialog()
        {
            this.Model.ClearRunResults();
            InitializeLateralLoadDialog();
        }
        protected void InitializeRunDialog()
        {
            this.Model.ClearRunResults();
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogRunControl dialog = new DialogRunControl(Model.AnalysisOptions);
            dialog.SaveFile += SaveModel;
            dialog.SetMainData(this.Model, ModelStage.Run, InitializeShowResultDialog, BackRunDialog,this.runControl1);
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }

        protected void BackShowResultDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogRunControl dialog = new DialogRunControl(Model.AnalysisOptions);
            dialog.SaveFile += SaveModel;
            dialog.SetMainData(this.Model, ModelStage.Run, InitializeShowResultDialog, BackRunDialog, this.runControl1);
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
        }
        protected void OnScaleChanged()
        {
            if (_viewer is DeformationViewer)
            {
                if (Running)
                    timer1.Stop();

                _viewer.RefreshEx();

                if (Running)
                    timer1.Start();
            }
            else if (_viewer is ModelShapeViewer)
            {
                if (Running)
                    timer1.Stop();

                _viewer.RefreshEx();

                if (Running)
                    timer1.Start();
            }
        }
        protected void InitializeShowResultDialog()
        {
            RefreshMainViewer();
            Dialogs_Panel.Controls.Clear();
            DialogResultControl dialog = new DialogResultControl(this);
            dialog.SetMainData(this.Model, ModelStage.Results, () =>
            {
                var res= MessageBox.Show("Do you want to start/open other model?", "Restart", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (OpenFile())
                    { 
                        RemoveRedundantSections();
                        PresentModel();
                    }
                }
                else if(res == DialogResult.No)
                {
                    Close();
                }
            }   
                , BackShowResultDialog, this.resultControl1);
            dialog.ScaleChanged += OnScaleChanged;
            Dialogs_Panel.Controls.Add(dialog);
            dialog.Dock = DockStyle.Fill;
            SaveModel();
        }

        internal void ResetTime()
        {
           _viewer.CurrentTimeStep = 0;
            trackBar1.Value = 0;
        }

        public void StopAnimation()
        {
            Animation_Btn.BackgroundImage = Properties.Resources.start;
            Running = false;
            timer1.Stop(); 
        }
        public void StopTimer()
        {
            trackBar1.Visible = Animation_Btn.Visible = false;
            StopAnimation();
        }
        private void ContinueAnimation()
        {
            if (_viewer.CurrentTimeStep == trackBar1.Maximum)
            {
                ResetTime();
            }
            Running = true;
            Animation_Btn.BackgroundImage = Properties.Resources.pause;
            timer1.Start();
        }

        public void StartInimation(int count)
        {
            trackBar1.Visible = Animation_Btn.Visible = true;
            trackBar1.Maximum = count;
            ResetTime();
            ContinueAnimation();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Running)
            {
                if (_viewer.Increment())
                {
                    trackBar1.Value = _viewer.CurrentTimeStep;
                }
                else
                {
                    StopAnimation();
                }
            }
        }

        private void Animation_Btn_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                StopAnimation();
            }
            else
            {
                ContinueAnimation();
            }
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (Running)
                timer1.Stop();

            _viewer.CurrentTimeStep = trackBar1.Value;
            _viewer.UpdateEx();

            if (Running)
                timer1.Start();
        }

        private void Help_Btn_Click(object sender, EventArgs e)
        {
            OpenAboutFrm();
        }
    }
}
