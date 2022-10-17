using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicModel;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using SPSW_Solver.BasicModel;
using SPSW_Solver.Model;
//using IronPython.Hosting;
//using Microsoft.Scripting.Hosting;

namespace SPSW_Solver.PythonTranslator
{
    public static class OpenSeesTranslator
    {
        public static string InputFile = "Input.tcl";
        public static string EarthQuakeFolder = "gmf";
        public static string OutPutFolder = "Data";
        public static string ModeShapesFolderName = "ModeShapes";
        public static string RunCmd = "Run.cmd";
        public static string ModalAnalysisReport = "Report.txt";

        public static string NodesFolder = "Nodes";
        public static string TrussFolder = "Trusses";
        public static string GravityColumnsResultspath = "GravityColumns";
        public static string PanelZoneElementsResultspath = "PanelZoneElements";
        public static string ElasticSegmentsResultspath = "Elastic";
        public static string DistributedPlasticityResultspath = "DP";
        public static string NonLinearEndsResultspath = "NonLinearBeamColumn";
        public static string BeamWithHingesResultspath = "BWH";
        public static string PlasticHinges = "PlasticHinges";

        public static string NodesDeformationPath = "Nodes.out";
        public static string SupportsReactionPath = "Supports.out";

        public static string TrussesResultspath = "Trusses.out";
        public static string TrussesStrainsResultspath = "TrussesStrains.out";
        public static string LinksForcesResultspath = "LinksForces.out";
        public static string LinksStrainsResultspath = "LinksStrains.out";

        public static string LocalForces = "LocalForces.out";
        public static string PlasticMoment = "PlasticMoment.out";
        public static string ElasticRotation = "ElasticRotation.out";
        public static string PlasticRotation = "PlasticRotation.out";

        public static int NodesRegionId = 1;
        public static int SupportRegionId = 2;
        public static int TrussesRegionId = 3;
        public static int LinksRegionId = 4;
        public static int GravityColumnssRegionId = 5;
        public static int PanelZonesRegionId = 6;
        public static int ElasticSegmentsRegionId = 7;
        public static int DistributedPlasticityRegionId = 8;
        public static int NonLinearEndsRegionId = 9;
        public static int BeamWithHingesRegionId = 10;
        public static int PlasticHingesRegionId = 11;

        public static double g = 386.4;
        public static bool Run()
        {
            try
            {
                string exepath = Assembly.GetExecutingAssembly().Location;
                string mainDirectory = Directory.GetDirectoryRoot(exepath);
                string folderPath = Path.Combine(Path.Combine(Path.GetDirectoryName(exepath), "OpenSees"), "bin");
                List<string> commands = new List<string>();
                //commands.Add(exepath);
                commands.Add(string.Format("cd {0}", folderPath));
                commands.Add(string.Format("OpenSees.exe {0}", InputFile));
                commands.Add("C:");

                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "cmd.exe";
                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = false;
                info.RedirectStandardError = false;

                using (Process p = Process.Start(info))
                {
                    commands.ForEach(x =>
                    {
                        p.StandardInput.WriteLine(x);
                        p.StandardInput.Flush();
                    });
                    p.StandardInput.Close();
                    p.WaitForExit();
                    p.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool ReadModalAnalysisOutPut(SPSW_Simple_Model model)
        {
            if (!ReadNodesModeShapes(model, model.ModeShapes))
                return false;
            if (!ReadModalAnalysisReport(model, model.ModeShapes))
                return false;
            return true;
        }
        private static bool ReadModalAnalysisReport(SPSW_Simple_Model model, int modeShapes)
        {
            try
            {
                List<double> doubleList;
                var modalData = model.ModalData;
                for (int i = 0; i < modeShapes; i++)
                {
                    modalData.ModeShapeData.Add(new ModeShapeData(i + 1));
                }
                using (var fs = new FileStream(GetModalAnalysisReport(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = "";

                        // read eigen analysis
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        int lineRecords = 5;
                        for (int i = 0; i < modeShapes; i++)
                        {
                            line = sr.ReadLine();
                            if (!ConvertLineToDoubleList(line, lineRecords, out doubleList))
                                return false;
                            modalData.ModeShapeData[i].LAMBDA = doubleList[1];
                            modalData.ModeShapeData[i].OMEGA = doubleList[2];
                            modalData.ModeShapeData[i].FREQUENCY = doubleList[3];
                            modalData.ModeShapeData[i].PERIOD = doubleList[4];
                        }

                        // read totalmass
                        line = sr.ReadLine();
                        line = sr.ReadLine();

                        line = sr.ReadLine();
                        lineRecords = 3;
                        if (!ConvertLineToDoubleList(line, lineRecords, out doubleList))
                            return false;

                        modalData.SumMx = doubleList[0];
                        modalData.SumMy = doubleList[1];
                        modalData.SumMrz = doubleList[2];

                        // read mode mass
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        lineRecords = 4;
                        for (int i = 0; i < modeShapes; i++)
                        {
                            line = sr.ReadLine();
                            if (!ConvertLineToDoubleList(line, lineRecords, out doubleList))
                                return false;
                            modalData.ModeShapeData[i].MX = doubleList[1];
                            modalData.ModeShapeData[i].MY = doubleList[2];
                            modalData.ModeShapeData[i].MRZ = doubleList[3];
                        }
                        // read mode aculumlative mass 
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        for (int i = 0; i < modeShapes; i++)
                        {
                            line = sr.ReadLine();
                            if (!ConvertLineToDoubleList(line, lineRecords, out doubleList))
                                return false;
                            modalData.ModeShapeData[i].SumMx = doubleList[1];
                            modalData.ModeShapeData[i].SumMy = doubleList[2];
                            modalData.ModeShapeData[i].SumMrz = doubleList[3];
                        }

                        sr.Close();
                    }
                    fs.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        internal static bool CreateInputFileModalAnalysis(SPSW_Simple_Model model)
        {
            ClearAnalysisFolder();
            string exepath = Assembly.GetExecutingAssembly().Location;
            string folderPath = Path.Combine(Path.Combine(Path.GetDirectoryName(exepath), "OpenSees"), "bin");
            string filePath = Path.Combine(folderPath, InputFile);
            model.ClearModalAnalysisRun();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
            {
                WriteModelInfo(file, model);
                AddGravityLoads(file, model);
                RunModalAnalysis(file, model);
            }
            return true;
        }
        internal static void WriteModelInfo(StreamWriter file, SPSW_Simple_Model model)
        {
            g = model.G;
            double Level = -1 * model.Levels[0].Elevation;
            SetMainInformation(file);
            AddNodesGeometry(file, model.GetAllNodes(true), Level);
            AddFixCommands(file, model.SupportsNodes);
            AddNodesMass(file, model);
            file.WriteLine(Properties.Resources.WSection2D);
            file.WriteLine("geomTransf PDelta 1;");
            file.WriteLine("geomTransf Linear 2;");
            file.WriteLine(@"proc rotSpring2D { eleID nodeR nodeC matID } {
                        element zeroLength $eleID $nodeR $nodeC -mat $matID -dir 6;
                        equalDOF    $nodeR     $nodeC     1     2;
                        }");

            int MaxMatId = 0;
            int maxSecId = 0;
            WriteDummyMaterials(file, model, ref MaxMatId);
            WriteUserDefinedMaterials(file, model, ref MaxMatId);
            AddTrusses(file, model.GetRegularTrussElements(), ref MaxMatId);
            AddRotSprings(file, model.GetRotSprings(), ref MaxMatId);
            AddFrameElementsElasticElements(file, model.GetGravityColumnsSegments(), GravityColumnssRegionId , model.GravityCoulmnModifier);
            AddLinks(file, model.RigdLinks, model.RigidLinkModifier);
            ElasticSegmentsRegionId = model.WriteFrameSegments(file,PlasticHingeApproach.None, ElasticSegmentsRegionId , ref maxSecId , ref MaxMatId) ? ElasticSegmentsRegionId : 0;
            DistributedPlasticityRegionId = model.WriteFrameSegments(file, PlasticHingeApproach.DistrubuitedPlasticity, DistributedPlasticityRegionId, ref maxSecId, ref MaxMatId) ? DistributedPlasticityRegionId : 0;
            NonLinearEndsRegionId = model.WriteFrameSegments(file, PlasticHingeApproach.NolinearBeamColumn, NonLinearEndsRegionId, ref maxSecId, ref MaxMatId) ? NonLinearEndsRegionId : 0;
            BeamWithHingesRegionId = model.WriteFrameSegments(file, PlasticHingeApproach.BeamWithHinges, BeamWithHingesRegionId, ref maxSecId, ref MaxMatId) ? BeamWithHingesRegionId : 0;
            PlasticHingesRegionId = model.WritePlasticHinges(file, PlasticHingesRegionId, ref maxSecId, ref MaxMatId)? PlasticHingesRegionId : 0;
            if (model.IncludePanelZones)
            {
                AddPanelZoneElements(file, model.GetMainNodesForRigidZones(), SPSW_Simple_Model.RotationalStiffnessRatio);
            }
            AddPointsEqualDof(file, model);
        }
        private static void AddPanelZoneElements(StreamWriter file, IEnumerable<MainNode> mainNodes , double factor =1.00)
        {
            Dictionary<int, double[]> valuesDict = new Dictionary<int, double[]>();
            Dictionary<FrameTwoNodesElement, int> elementsDict = new Dictionary<FrameTwoNodesElement, int>();
            foreach (var node in mainNodes)
            {
                var families = node.ConnectedRigidElements.Select(x => x.Family);
                valuesDict.Add(node.ID, new double[] {
                     families.Select(x=> x.Section.A).Average()
                    , families.Select(x=> x.Section.Ix).Average()
                    , families.Select(x=> x.initE).Average()
                });
                node.ConnectedRigidElements.ForEach(x => elementsDict.Add(x, node.ID));
            }
            foreach (var item in elementsDict.OrderBy(x => x.Key.ID))
            {
                var child = item.Key;
                double A = valuesDict[item.Value][0] * factor;
                double Ix = valuesDict[item.Value][1] * Math.Pow(factor, 2);
                double E = valuesDict[item.Value][2];
                file.WriteLine(string.Format("element elasticBeamColumn {0} {1} {2} {3} {4} {5} {6};",
                    child.ID, child.StartNode.ID, child.EndNode.ID, A, E, Ix, 1));
            }
            var ids = elementsDict.Select(x => x.Key.ID);
            file.WriteLine(string.Format("region {0} -eleRange {1} {2}", PanelZonesRegionId, ids.Min(), ids.Max()));
        }
        private static void AddRotSprings(StreamWriter file, List<RotSpring> rotSprings, ref int matId)
        {
            file.WriteLine("# Rot Springs Gravity Columns -------------------");
            foreach (var springs in rotSprings.GroupBy(x => x.Family.ElasticAnalysisNum))
            {
                file.WriteLine(string.Format("uniaxialMaterial Elastic {0} {1};", ++matId, springs.First().Family.E / Math.Pow(SPSW_Model.RotationalStiffnessRatio,2)));
                foreach (var spring in springs)
                {
                    file.WriteLine(string.Format("rotSpring2D {0} {1} {2} {3};", spring.ID
                        , spring.StartNode.ID, spring.EndNode.ID, matId));
                }
            }
            file.WriteLine("# ---------------------------- -------------------");
        }
        private static void WriteUserDefinedMaterials(StreamWriter file, SPSW_Simple_Model model, ref int MaxMatId)
        {
            file.WriteLine("# User Defined Materials -------------------");
            foreach (var material in model.GetMaterials())
            {
                MaxMatId = material.WriteMaterial(file, ++MaxMatId);
            }
            file.WriteLine("# ----------------------------------------");
        }
        private static void WriteDummyMaterials(StreamWriter file, SPSW_Simple_Model model, ref int MaxMatId)
        {
            file.WriteLine("# Elastic Materials -------------------");
            foreach (var group in model.GetAllFrameSectionFamily().GroupBy(x =>x.initE))
            {
                file.WriteLine(string.Format("uniaxialMaterial Elastic {0} {1}",++MaxMatId, group.Key));
                foreach (var family in group)
                {
                    family.ElasticAnalysisNum = MaxMatId;
                }
            }
            file.WriteLine("# -----------------------------------");
        }
        internal static void AddRecorders(StreamWriter file, bool includePanelZones)
        {
            AddSupportsRecordes(file);
            AddNodesRecordes(file);
            AddTrussesRecords(file);
            AddElementRecords(file, GravityColumnsResultspath, GravityColumnssRegionId, true);
            AddElementRecords(file, ElasticSegmentsResultspath, ElasticSegmentsRegionId, true);
            AddElementRecords(file, DistributedPlasticityResultspath, DistributedPlasticityRegionId, true);
            AddElementRecords(file, NonLinearEndsResultspath, NonLinearEndsRegionId, false);
            AddElementRecords(file, BeamWithHingesResultspath, BeamWithHingesRegionId, false);
            if (PlasticHingesRegionId != 0)
            {
                AddPlasticHingesRecorder(file);
            }
            if (includePanelZones)
            {
                AddElementRecords(file, PanelZoneElementsResultspath, PanelZonesRegionId, true);
            }
        }
        private static void AddPlasticHingesRecorder(StreamWriter file)
        {
            file.WriteLine(string.Format("recorder Element -file {0}/{1}/{2} -time -region {3} deformation 3;", OutPutFolder, PlasticHinges, PlasticRotation, PlasticHingesRegionId));
            file.WriteLine(string.Format("recorder Element -file {0}/{1}/{2} -time -region {3} force 3;", OutPutFolder , PlasticHinges, PlasticMoment , PlasticHingesRegionId));
        }
        internal static bool CreateInputFile(SPSW_Simple_Model model)
        {
            try
            {
                ClearAnalysisFolder();
                string exepath = Assembly.GetExecutingAssembly().Location;
                string folderPath = Path.Combine(Path.Combine(Path.GetDirectoryName(exepath), "OpenSees"), "bin");
                string filePath = Path.Combine(folderPath, InputFile);
                string groundMotionFolder = Path.Combine(folderPath, EarthQuakeFolder);
                Directory.CreateDirectory(groundMotionFolder);
                //File.Create(filePath);
                model.ClearRunResults();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
                {
                    WriteModelInfo(file, model);
                    AddGravityLoads(file,model);
                    AddRecorders(file, model.IncludePanelZones);
                    if (model.AnalysisParameters.AnalysisMethod == AnalysisMethod.Monotonic_Pushover_Analysis)
                    {
                        AddProfilePushOver(file, model, AddPofilePushOverPattern);
                    }
                    else if (model.AnalysisParameters.AnalysisMethod == AnalysisMethod.Cyclic_Pushover)
                    {
                        AddCyclicProfilePushOver(file, model, AddPofilePushOverPattern);
                    }
                    else
                    {
                        AddDynamicLoads(file, model, groundMotionFolder);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private static void WriteSolvingOptions(StreamWriter file, SPSW_Simple_Model model)
        {
            SolverAanalysisOptions modelOptions = model.AnalysisOptions;

            file.WriteLine("wipeAnalysis;");
            string constrainsCommand = $"constraints {modelOptions.Constraint.ToString()} ";
            switch (modelOptions.Constraint)
            {
                case Constraints.Plain:
                case Constraints.Transformation:
                    constrainsCommand += ";";
                    break;
                case Constraints.Lagrange:
                case Constraints.Penalty:
                    constrainsCommand += $"{modelOptions.AlphaS} {modelOptions.AlphaM};";
                    break;
            }
            file.WriteLine(constrainsCommand);
            file.WriteLine($"numberer {modelOptions.Numberer.ToString()};");
            file.WriteLine($"system {modelOptions.System.ToString()};");
            if (modelOptions.TestType == TestType.FixedNumIter)
            {
                file.WriteLine(string.Format("test {0} {1};", modelOptions.TestType.ToString(), modelOptions.MaxIter));
            }
            else
            {
                file.WriteLine(string.Format("test {0} {1} {2};", modelOptions.TestType.ToString(), modelOptions.Tolerance, modelOptions.MaxIter));
            }
        }
        private static void AddGravityLoads(StreamWriter file, SPSW_Simple_Model model)
        {
            // static ID for gravity loads
            file.WriteLine("pattern Plain 1 Linear {");
            foreach (var mainNode in model.MainNodes)
            {
                file.WriteLine(string.Format("load {0} 0.0 {1} 0.0;", mainNode.ID, -1 * mainNode.NodeMass));
            }
            int numOfSteps = 10;
            file.WriteLine("}");

            WriteSolvingOptions(file,model);
            file.WriteLine("algorithm Newton;");
            file.WriteLine(string.Format("integrator LoadControl {0};",1.0/ numOfSteps));
            file.WriteLine("analysis Static;");
            file.WriteLine(string.Format("analyze {0};", numOfSteps));
            file.WriteLine("loadConst -time 0.0;");
        }
        private static void AddPointsEqualDof(StreamWriter file, SPSW_Simple_Model model)
        {
            for (int i = 1; i < model.Levels.Count; i++)
            {
                var mainNodes = model.Levels[i].GetMainNodes(model.VerticalLines);
                file.WriteLine(string.Format("equalDOF {0} {1} 1;" , mainNodes[0].ID, mainNodes[1].ID));
                file.WriteLine(string.Format("equalDOF {0} {1} 1;" , mainNodes[0].ID, mainNodes[2].ID));
            }
        }
        private static void RunModalAnalysis(StreamWriter file, SPSW_Simple_Model model)
        {
            int modeShapes = model.ModeShapes;
            if (modeShapes < 1)
                return;
            file.WriteLine("for { set k 1 } { $k <= " + modeShapes + " } { incr k } {");
            file.WriteLine(string.Format("  recorder Node -file [format \"{0}/{1}/mode%i.out\" $k] -region 1 -dof 1 2 3  \"eigen $k\"", OutPutFolder, ModeShapesFolderName));
            file.WriteLine("}");

            file.WriteLine(string.Format("set num_modes {0};", modeShapes));
            file.WriteLine(string.Format("set filename {0};", ModalAnalysisReport));
            file.WriteLine(Properties.Resources.ModalAnalysisScript);
        }
        public static List<string> GetSubFolderList()
        {
            return new List<string>()
            {
                ModeShapesFolderName,
                NodesFolder,
                TrussFolder,
                GravityColumnsResultspath,
                PanelZoneElementsResultspath,
                ElasticSegmentsResultspath,
                DistributedPlasticityResultspath,
                NonLinearEndsResultspath,
                BeamWithHingesResultspath,
                PlasticHinges,
           };

        }
        internal static void ClearAnalysisFolder()
        {
            string exepath = Assembly.GetExecutingAssembly().Location;
            string folderPath = Path.Combine(Path.Combine(Path.GetDirectoryName(exepath), "OpenSees"), "bin");
            List<string> folders = new List<string>();
            string outPutFolder = Path.Combine(folderPath, OutPutFolder);
            GetSubFolderList().ForEach(x=> folders.Add(Path.Combine(outPutFolder, x)));
            folders.Add(outPutFolder);
            folders.Add(Path.Combine(folderPath, EarthQuakeFolder));

            List<string> analysisFiles = new List<string>();
            analysisFiles.Add(Path.Combine(folderPath, InputFile));
            analysisFiles.Add(Path.Combine(folderPath, ModalAnalysisReport));
            analysisFiles.ForEach(x => {
                if (File.Exists(x))
                {
                    File.Delete(x);
                }
            });

            try
            {
                folders.ForEach(x => 
                {
                    if (Directory.Exists(x))
                    {
                        Directory.Delete(x, true);
                    }
                });
            }
            catch (Exception e)
            {
            }
        }
        internal static void AddAccumLoadCase(SPSW_Simple_Model model, bool Srss)
        {
            int loadCases = model.NumofLoadCases();
            int K = model.TimeSteps.Select(x => x.Count).Min();
            List<double> newTimeSteps = new List<double>();
            int i = 0;
            for (; i < K; i++)
            {
                newTimeSteps.Add(model.TimeSteps[0][i]);
            }
            model.TimeSteps.Add(newTimeSteps);

            model.SupportsNodes.ForEach(x => {
                x.AddAccumlativeReactions(loadCases, K, Srss);
            });
            foreach (var node in model.GetAllNodes(true))
            {
                node.AddAccumlativeNodeDeformation(loadCases, K, Srss);
            }
            foreach (var element in model.SPBeys.SelectMany(x => x.TrussGroup.Trusses).OrderBy(x => x.ID))
            {
                element.AddAccumlativeResults(loadCases, K, Srss);
            }
            model.GetPlasticHinges().ForEach(x => x.AddAccumlativeResults(loadCases, K, Srss));
            foreach (var element in model.Beams.SelectMany(x => x.Childs).OrderBy(x => x.ID))
            {
                element.AddAccumaltiveForces(loadCases, K, Srss);
            }
            foreach (var element in model.Columns.SelectMany(x => x.Childs).OrderBy(x => x.ID))
            {
                element.AddAccumaltiveForces(loadCases, K, Srss);
            }
            foreach (var element in model.GravityColumns.SelectMany(x => x.Childs).OrderBy(x => x.ID))
            {
                element.AddAccumaltiveForces(loadCases, K, Srss);
            }
            i= model.TimeSteps.Count - 1;
            model.ValuesRanges.Add(new ForcesRange());
            model.Beams.ForEach(x => model.SetRanges(x, i));
            model.Columns.ForEach(x => model.SetRanges(x, i));
            model.GravityColumns.ForEach(x => model.SetRanges(x, i));
        }
        internal static bool ReadElementsForcesData(SPSW_Simple_Model model)
        {
            List<int> K_values;
            if (!ReadSegments(model, GravityColumnsResultspath, model.GetGravityColumnsSegments(), out K_values, true) || K_values.Min() < 2)
                return false;
            PlasticHingeApproach[] approaches = new PlasticHingeApproach[] {PlasticHingeApproach.None , PlasticHingeApproach.DistrubuitedPlasticity
                                                            , PlasticHingeApproach.NolinearBeamColumn , PlasticHingeApproach.BeamWithHinges};
            int[] ids = new int[] { ElasticSegmentsRegionId,DistributedPlasticityRegionId,NonLinearEndsRegionId,BeamWithHingesRegionId };
            string[] paths = new string[] { ElasticSegmentsResultspath,DistributedPlasticityResultspath,NonLinearEndsResultspath,BeamWithHingesResultspath};
            bool[] flags = new bool[] { true,true,false,false};

            for (int i = 0; i < 4; i++)
            {
                if (ids[i] == 0)
                    continue;
                if (!ReadSegments(model,paths[i], model.GetFrameSgements(approaches[i]), out K_values, flags[i]) || K_values.Min() < 2)
                    return false;
                model.CheckTimeStepsCount(K_values);
            }
            if (PlasticHingesRegionId != 0)
            {
                if (!ReadTrussElementsResults(model, PlasticHinges, PlasticMoment, PlasticRotation,1,2,5,6, model.GetPlasticHinges().Cast<TrussElement>().ToList(), out K_values))
                    return false;
            }
            if (model.IncludePanelZones)
            {
                if (!ReadSegments(model, PanelZoneElementsResultspath, model.GetRigidZones(), out K_values, true) || K_values.Min() < 2)
                    return false;
            }
            model.ValuesRanges = new List<ForcesRange>();
            model.Beams.ForEach(x => x.ValuesRanges = new List<ForcesRange>());
            model.Columns.ForEach(x => x.ValuesRanges = new List<ForcesRange>());
            model.GravityColumns.ForEach(x => x.ValuesRanges = new List<ForcesRange>());
            model.MainNodes.ForEach(x => x.ValuesRanges = new List<ForcesRange>());
            model.SupportsNodes.ForEach(x => x.ValuesRanges = new List<ForcesRange>());
            for (int i = 0; i < model.NumofLoadCases(); i++)
            {
                model.ValuesRanges.Add(new ForcesRange());
                model.Beams.ForEach(x => model.SetRanges(x, i));
                model.Columns.ForEach(x => model.SetRanges(x, i));
                model.GravityColumns.ForEach(x => model.SetRanges(x, i));
                model.MainNodes.ForEach(x => model.SetRanges(x, i));
                model.SupportsNodes.ForEach(x => model.SetRanges(x, i));
            }
            return true;
        }
        private static bool ReadSegmentsPlasticRotations(SPSW_Simple_Model model, string subfolder, List<FrameTwoNodesElement> elements, out List<int> K_values)
        {
            try
            {
                K_values = new List<int>();
                string resultsFile = GetResultFile(subfolder, PlasticRotation);
                if (!File.Exists(resultsFile))
                    return false;

                int count = elements.Count;
                int lineRecords = count *3+ 1;
                SectionLocalForces forces = new SectionLocalForces(0, 0, 0);
                elements.ForEach(x =>
                {
                    x.PlasticDeformation = new List<List<SectionLocalForces>>();
                });
                double maxLoadCase = model.NumofLoadCases();
                for (int i = 0; i < maxLoadCase; i++)
                {
                    elements.ForEach(x =>
                    {
                        x.PlasticDeformation.Add(new List<SectionLocalForces>() { forces });
                    });
                    K_values.Add(1);
                }
                maxLoadCase--;
                double sum = 0;
                int LoadCase = 0;
                List<double> doubleList;
                using (var fs = new FileStream(resultsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line) && ConvertLineToDoubleList(line, lineRecords, out doubleList))
                        {
                            if (Math.Abs(doubleList[0]) < sum / model.TimeSteps[LoadCase].Count && LoadCase < maxLoadCase)
                            {
                                LoadCase++;
                                sum = 0;
                            }
                            sum += Math.Abs(doubleList[0]);
                            K_values[LoadCase]++;
                            for (int i = 0; i < elements.Count; i++)
                            {
                                int j = i * 3 + 1;
                                elements[i].PlasticDeformation[LoadCase].Add(new SectionLocalForces(doubleList[j], doubleList[j + 1], doubleList[j + 2]));
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
                return true;

            }
            catch (Exception e)
            {
                K_values = new List<int>();
                return false;
            }
        }
        private static bool ReadSegmentsElasticRotations(SPSW_Simple_Model model, string subfolder, List<FrameTwoNodesElement> elements, out List<int> K_values)
        {
            try
            {
                K_values = new List<int>();
                string resultsFile = GetResultFile(subfolder, ElasticRotation);
                if (!File.Exists(resultsFile))
                    return false;

                int count = elements.Count;
                int lineRecords = count *3+ 1;
                SectionLocalForces forces = new SectionLocalForces(0, 0, 0);
                elements.ForEach(x =>
                {
                    x.ElasticDeformation = new List<List<SectionLocalForces>>();
                });
                double maxLoadCase = model.NumofLoadCases();
                for (int i = 0; i < maxLoadCase; i++)
                {
                    elements.ForEach(x =>
                    {
                        x.ElasticDeformation.Add(new List<SectionLocalForces>() { forces });
                    });
                    K_values.Add(1);
                }
                maxLoadCase--;
                double sum = 0;
                int LoadCase = 0;
                List<double> doubleList;
                using (var fs = new FileStream(resultsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line) && ConvertLineToDoubleList(line, lineRecords, out doubleList))
                        {
                            if (Math.Abs(doubleList[0]) < sum / model.TimeSteps[LoadCase].Count && LoadCase < maxLoadCase)
                            {
                                LoadCase++;
                                sum = 0;
                            }
                            sum += Math.Abs(doubleList[0]);
                            K_values[LoadCase]++;
                            for (int i = 0; i < elements.Count; i++)
                            {
                                int j = i * 3 + 1;
                                elements[i].ElasticDeformation[LoadCase].Add(new SectionLocalForces(doubleList[j], doubleList[j + 1], doubleList[j + 2]));
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
                return true;

            }
            catch (Exception e)
            {
                K_values = new List<int>();
                return false;
            }
        }
        private static bool ReadTrussElementsStrains(SPSW_Simple_Model model, string subfolder, string filepath, List<TrussElement> elements , int start, int stride, out List<int> K_values)
        {
            try
            {
                K_values = new List<int>();
                string resultsFile = GetResultFile(subfolder, filepath);
                if (!File.Exists(resultsFile))
                    return false;

                int count = elements.Count;
                int lineRecords = count * stride+ 1;
                double maxLoadCase = model.NumofLoadCases();
                elements.ForEach(x =>
                {
                    x.Deformations = new List<List<double>>();
                });
                for (int i = 0; i < maxLoadCase; i++)
                {
                    foreach (var element in elements)
                    {
                        element.Deformations.Add(new List<double>() { 0.0 });
                    }
                    K_values.Add(1);
                }
                double sum = 0.0;
                maxLoadCase--;
                int LoadCase = 0;
                List<double> doubleList;
                using (var fs = new FileStream(resultsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line) && ConvertLineToDoubleList(line, lineRecords, out doubleList))
                        {
                            if (Math.Abs(doubleList[0]) < sum / model.TimeSteps[LoadCase].Count && LoadCase < maxLoadCase)
                            {
                                LoadCase++;
                                sum = 0;
                            }
                            sum += Math.Abs(doubleList[0]);
                            K_values[LoadCase]++;
                            for (int i = 0; i < elements.Count; i++)
                            {
                                int j = i * stride + start + 1;
                                elements[i].Deformations[LoadCase].Add(doubleList[j]);
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
                return true;

            }
            catch (Exception e)
            {
                K_values = new List<int>();
                return false;
            }
        }
        private static bool ReadTrussElementsForces(SPSW_Simple_Model model , string subfolder , string filepath, List<TrussElement> elements , int start, int stride, out List<int> K_values )
        {
            try
            {
                K_values = new List<int>();

                string resultsFile = GetResultFile(subfolder,filepath);
                if (!File.Exists(resultsFile))
                    return false;

                int count = elements.Count;
                int lineRecords = count * stride + 1;
                double maxLoadCase = model.NumofLoadCases();

                elements.ForEach(x =>
                {
                    x.Forces = new List<List<double>>();
                });

                for (int i = 0; i < maxLoadCase; i++)
                {
                    elements.ForEach(x =>
                    {
                        x.Forces.Add(new List<double>() { 0.0 });
                    });
                    K_values.Add(1);
                }

                maxLoadCase--;
                double sum = 0;
                int LoadCase = 0;
                List<double> doubleList;
                using (var fs = new FileStream(resultsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line) && ConvertLineToDoubleList(line, lineRecords, out doubleList))
                        {
                            if ( Math.Abs(doubleList[0]) < sum / model.TimeSteps[LoadCase].Count && LoadCase < maxLoadCase)
                            {
                                LoadCase++;
                                sum = 0;
                            }
                            sum += Math.Abs(doubleList[0]);
                            K_values[LoadCase]++;
                            for (int i = 0; i < elements.Count; i++)
                            {
                                int j = i * stride + 1 + start;
                                elements[i].Forces[LoadCase].Add(doubleList[j]);
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
                return true;

            }
            catch (Exception e)
            {
                K_values = new List<int>();
                return false;
            }
        }
        private static bool ReadSegments(SPSW_Simple_Model model, string subFolder, List<FrameTwoNodesElement> elements, out List<int> K_values , bool Elastic)
        {
            if (!ReadElementsForces(model, subFolder , elements, out K_values) || K_values.Min() < 2)
                return false;
            model.CheckTimeStepsCount(K_values);

            if (Elastic)
                return true;
            if (!ReadSegmentsElasticRotations(model, subFolder, elements, out K_values) || K_values.Min() < 2)
                return false;
            model.CheckTimeStepsCount(K_values);
            if (!ReadSegmentsPlasticRotations(model, subFolder, elements, out K_values) || K_values.Min() < 2)
                return false;
            model.CheckTimeStepsCount(K_values);
            return true;
        }
        private static bool ReadElementsForces(SPSW_Simple_Model model, string subFolder, List<FrameTwoNodesElement> elements, out List<int> K_values )
        {
            try
            {
                K_values =  new List<int>();
                string resultsFile = GetResultFile(subFolder, LocalForces);
                if (!File.Exists(resultsFile))
                    return false;

                int count = elements.Count;
                int lineRecords = count * 6 + 1;
                SectionLocalForces forces = new SectionLocalForces(0, 0, 0);
                elements.ForEach(x =>
                {
                    x.StartSectionForces = new List<List<SectionLocalForces>>();
                    x.EndSectionForces = new List<List<SectionLocalForces>>();
                });
                double maxLoadCase = model.NumofLoadCases();
                for (int i = 0; i < maxLoadCase; i++)
                {
                    elements.ForEach(x =>
                    {
                        x.StartSectionForces.Add(new List<SectionLocalForces>() { forces});
                        x.EndSectionForces.Add(new List<SectionLocalForces>() { forces });
                    });
                    K_values.Add(1);
                }
                maxLoadCase--;
                double sum = 0;
                int LoadCase = 0;
                List<double> doubleList;
                using (var fs = new FileStream(resultsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line) && ConvertLineToDoubleList(line, lineRecords, out doubleList))
                        {
                            if (Math.Abs(doubleList[0]) < sum / model.TimeSteps[LoadCase].Count &&LoadCase < maxLoadCase)
                            {
                                LoadCase++;
                                sum = 0;
                            }
                            sum += Math.Abs(doubleList[0]);
                            K_values[LoadCase]++;
                            for (int i = 0; i < elements.Count; i++)
                            {
                                int j = i * 6 + 1;
                                elements[i].StartSectionForces[LoadCase].Add(new SectionLocalForces(doubleList[j],  doubleList[j + 1], doubleList[j + 2]));
                                elements[i].EndSectionForces[LoadCase].Add(new SectionLocalForces(-1 * doubleList[j + 3], -1* doubleList[j + 4], -1 * doubleList[j + 5]));
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    fs.Close();
                }

                return true;

            }
            catch (Exception e)
            {
                K_values = new List<int>();
                return false;
            }
        }
        internal static bool ReadTrussElementsResults(SPSW_Simple_Model model, string subfolder, string forcesPath , string strainsPath , int start1,  int stride1 , int start2, int stride2, List<TrussElement> elements, out List<int> K_values)
        {
            if (!ReadTrussElementsStrains(model, subfolder, strainsPath, elements,start1, stride1, out K_values) || K_values.Min() < 2)
                return false;
            model.CheckTimeStepsCount(K_values);
            if (!ReadTrussElementsForces(model, subfolder, forcesPath, elements,start2, stride2, out K_values) || K_values.Min() < 2)
                return false;
            model.CheckTimeStepsCount(K_values);
            return true;
        }
        internal static bool ReadDeformationData(SPSW_Simple_Model model)
        {
            if (!ReadSupportsReactions(model))
                return false;
            List<int> K_values;
            if (!ReadNodesDeformations(model, out K_values) || K_values.Min() < 2)
                return false;
            model.CheckTimeStepsCount(K_values);

            if (TrussesRegionId == 0)
                return true;
            if (!ReadTrussElementsResults(model,TrussFolder, TrussesResultspath,TrussesStrainsResultspath, 0, 1, 0, 1, model.GetRegularTrussElements().Cast<TrussElement>().ToList(), out K_values) || K_values.Min() < 2)
                return false;
            return true;
        }
        private static string GetResultModeShapeFolder(string finalPath)
        {
            string exepath = Assembly.GetExecutingAssembly().Location;
            string folderPath = Path.Combine(Path.Combine(Path.GetDirectoryName(exepath), "OpenSees"), "bin");
            return Path.Combine(Path.Combine(folderPath, OutPutFolder), finalPath);
        }
        private static string GetModalAnalysisReport()
        {
            string exepath = Assembly.GetExecutingAssembly().Location;
            string folderPath = Path.Combine(Path.Combine(Path.GetDirectoryName(exepath), "OpenSees"), "bin");
            return Path.Combine(folderPath, ModalAnalysisReport);
        }
        private static string GetResultFile(string subFolder , string finalPath)
        {
            string exepath = Assembly.GetExecutingAssembly().Location;
            string folderPath = Path.Combine(Path.Combine(Path.GetDirectoryName(exepath), "OpenSees"), "bin");
            return Path.Combine(Path.Combine(Path.Combine(folderPath, OutPutFolder),subFolder), finalPath);
        }
        private static bool ReadNodesModeShapes(SPSW_Simple_Model model, int ModeShapes)
        {
            var allNodes = model.GetAllNodes(true);
            int count = allNodes.Count();
            int lineRecords = count * 3;
            string modeShapeFolder = GetResultModeShapeFolder(ModeShapesFolderName);
            for (int k = 0; k < ModeShapes; k++)
            {
                string file = Path.Combine(modeShapeFolder, string.Format("mode{0}.out", k + 1));
                if (!File.Exists(file))
                    return false;
                List<double> doubleList;
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line) && ConvertLineToDoubleList(line, lineRecords, out doubleList))
                        {
                            int i = 0;
                            foreach (var node in allNodes)
                            {
                                int j = i * 3;
                                node.ModeShapesDeformations.Add(new NodeDeformation(doubleList[j], doubleList[j + 1], doubleList[j + 2]));
                                i++;
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
            }
            return true;
        }
        private static bool ReadNodesDeformations(SPSW_Simple_Model model, out List<int> K_values )
        {
            try
            {
                K_values = new List<int>();
                string deformationFile = GetResultFile(NodesFolder, NodesDeformationPath);
                if (!File.Exists(deformationFile))
                    return false;

                var allNodes = model.GetAllNodes(true);
                int count = allNodes.Count();
                int lineRecords = count * 3 + 1;
                foreach (var node in allNodes)
                {
                    node.Deformations = new List<List<NodeDeformation>>();
                }
                NodeDeformation deformation = new NodeDeformation(0,0,0);
                double maxLoadCase = model.NumofLoadCases();
                for (int i = 0; i < maxLoadCase; i++)
                {
                    foreach (var node in allNodes)
                    {
                        node.Deformations.Add(new List<NodeDeformation>() { deformation});
                    }
                    K_values.Add(1);
                }
                maxLoadCase--;
                double sum = 0.0;
                int LoadCase = 0;
                List<double> doubleList;
                using (var fs = new FileStream(deformationFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line) && ConvertLineToDoubleList(line, lineRecords, out doubleList))
                        {
                            if (Math.Abs(doubleList[0]) < sum / model.TimeSteps[LoadCase].Count && LoadCase < maxLoadCase)
                            {
                                LoadCase++;
                                sum = 0;
                            }
                            sum += Math.Abs(doubleList[0]);
                            K_values[LoadCase]++;
                            int i = 0;
                            foreach (var node in allNodes)
                            {
                                int j = i * 3 + 1;
                                node.Deformations[LoadCase].Add(new NodeDeformation(doubleList[j], doubleList[j + 1], doubleList[j + 2]));
                                i++;
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
                return true;

            }
            catch (Exception e)
            {
                K_values = new List<int>();
                return false;
            }
            
        }
        private static bool ConvertLineToDoubleList(string line, int CheckCount, out List<double> doubleList)
        {
            doubleList = new List<double>();
            char[] whitespace = new char[] { ' ', '\t' };
            var strings = line.Split(whitespace).Where(x => !string.IsNullOrEmpty(x)).Select(s => double.Parse(s)).ToList();
            if (strings.Count != CheckCount)
                return false;

            foreach (var stringValue in strings)
            {
                doubleList.Add(stringValue);
            }
            return doubleList.Count == CheckCount;

        }
        private static bool ReadSupportsReactions(SPSW_Simple_Model model)
        {
            try
            {
                string supportsFile = GetResultFile(NodesFolder, SupportsReactionPath);
                if (!File.Exists(supportsFile))
                    return false;

                #region Init
                double maxLoadCase = model.NumofLoadCases();

                model.TimeSteps = new List<List<double>>();
                for (int i = 0; i < maxLoadCase; i++)
                {
                    model.TimeSteps.Add( new List<double>() { 0.0});
                }
                NodeReaction Reaction = new NodeReaction(0, 0, 0);
                model.SupportsNodes.ForEach(x => {
                x.Reactions = new List<List<NodeReaction>>();
                for (int i = 0; i < maxLoadCase; i++)
                {
                    x.Reactions.Add( new List<NodeReaction>() { Reaction });
                }});
                #endregion

                int lineRecords = model.SupportsNodes.Count * 3 + 1;
                 maxLoadCase--;
                int LoadCase = 0;
                double sum = 0.0;
                List<double> doubleList;
                using (var fs = new FileStream(supportsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line) && ConvertLineToDoubleList(line, lineRecords, out doubleList))
                        {                                                                      
                            if (Math.Abs(doubleList[0]) < (sum/ model.TimeSteps[LoadCase].Count-1) && LoadCase < maxLoadCase)
                            {
                                LoadCase++;
                                sum = 0;
                            }
                            sum += Math.Abs(doubleList[0]);
                            model.TimeSteps[LoadCase].Add(doubleList[0]);
                            for (int i = 0; i < model.SupportsNodes.Count; i++)
                            {
                                int j = i * 3 + 1;
                                model.SupportsNodes[i].Reactions[LoadCase].Add(new NodeReaction(doubleList[j], doubleList[j + 1], doubleList[j + 2]));
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        private static void AddDynamicLoads(StreamWriter file, SPSW_Simple_Model model, string newfolder)
        {
            TimeHistory_Parameters paramerters = model.AnalysisParameters.TimeHistory_Parameters;
            WriteSolvingOptions(file,model);
            file.WriteLine("set algorithmType ModifiedNewton;");
            file.WriteLine("algorithm $algorithmType;");
            switch (paramerters.Integrator) 
            {
                case Integrator.Central_Difference:
                    file.WriteLine("integrator CentralDifference;");
                    break;
                case Integrator.Explicit_Difference:
                    file.WriteLine("integrator Explicitdifference;");
                    break;
                case Integrator.HilberHughesTaylor_Method:
                    file.WriteLine($"integrator HHT {paramerters.IntegratorAlpha} {paramerters.Integrator_Beta} {paramerters.Integrator_Gamma};");
                    break;
                case Integrator.Newmark_Method:
                    file.WriteLine($"integrator Newmark {paramerters.IntegratorAlpha} {paramerters.Integrator_Beta};");
                    break;
                case Integrator.TRBDF2:
                    file.WriteLine("integrator TRBDF2;");
                    break;
                default:
                    file.WriteLine("integrator Newmark 0.5 0.25;");
                    break;
            }
            file.WriteLine("analysis Transient;");
            file.WriteLine(string.Format("set lambda [eigen {0}];", model.ModeShapes));
            double alpha = 0.0;
            double beta = 0.0;
            if (model.AnalysisParameters.TimeHistory_Parameters.UseConstantDamingRatio)
            {
                var OmegaValues = model.ModalData.ModeShapeData.Select(x => x.OMEGA);
                double minOmega = OmegaValues.Min();
                double maxOmega = OmegaValues.Max();
                beta = 2 * model.AnalysisParameters.TimeHistory_Parameters.DampingRatio * (minOmega + maxOmega);
                alpha = beta * minOmega * maxOmega;
            }
            else
            {
                alpha = paramerters.AlphaM;
                beta = paramerters.BetaK;
            }
            file.WriteLine(string.Format("rayleigh {0} 0. 0. {1}", alpha, beta));

            for (int i = 0; i < paramerters.GroundMotionFilePaths.Count; i++)
            {
                string path = paramerters.GroundMotionFilePaths[i];
                string fileName = Path.GetFileName(path);
                File.Copy(path, Path.Combine(newfolder, fileName), true);
                file.WriteLine("# DYNAMIC ground-motion analysis ------------------------------");
                string seriesString = string.Format("Series -dt {0} -filePath {1}/{2} -factor {3}", paramerters.TimpStep, EarthQuakeFolder, fileName,paramerters.LoadFactor);
                file.WriteLine("set accelSeries " + "\"" + seriesString + "\"" + ";");
                file.WriteLine(string.Format("pattern UniformExcitation {0} 1 -accel $accelSeries",i+2));
                file.WriteLine(string.Format("set DtAnalysis [expr {0}]", paramerters.TimpStep));
                file.WriteLine(string.Format("set TmaxAnalysis [expr {0}];", paramerters.NumberOfSteps * paramerters.TimpStep));
                file.WriteLine("set Nsteps [expr int($TmaxAnalysis/$DtAnalysis)];");
                file.WriteLine("set ok [analyze $Nsteps $DtAnalysis];");
                file.WriteLine(Properties.Resources.MotionAlgorithm);
                file.WriteLine("loadConst -time 0.0;");
            }
            
        }
        private static void AddPofilePushOverPattern(StreamWriter file , SPSW_Simple_Model model)
        {
            ResposeSpectrumData parameters = model.AnalysisParameters.SpectralResponse;
            double maxH = model.Levels.Last().Elevation;
            double minH = model.Levels.First().Elevation;
            double HT = maxH - minH;
            
            double v = 0.1;
            switch (parameters.Profile)
            {
                case PushOverProfile.SingleTop:
                    file.WriteLine(string.Format("load {0} {1} 0.0 0.0;", model.Levels.Last().GetFirstLeftNode().ID, v));
                    break;
                case PushOverProfile.Uniform:
                    for (int i = model.Levels.Count - 1; i > 0; i--)
                    {
                        file.WriteLine(string.Format("load {0} {1} 0.0 0.0;", model.Levels[i].GetFirstLeftNode().ID, v));
                    }
                    break;
                case PushOverProfile.StaticEquivalent:
                    var parmeters = model.AnalysisParameters.SpectralResponse;
                    double TotalWeight = model.GetTotalWeight();
                    double Vbase = model.GetDesginBaseShear();
                    double k = parmeters.GetK(parmeters.T);
                    List<double> Fvalues = new List<double>();
                    double minLevel = model.Levels[0].Elevation;
                    for (int i = 1; i < model.Levels.Count; i++)
                    {
                        double H = model.Levels[i].Elevation - minLevel;
                        double m = model.Levels[i].GetMainNodes(model.VerticalLines).Sum(x => x.NodeMass);
                        Fvalues.Add(m * Math.Pow(H, k));
                    }
                    Vbase /= Fvalues.Sum();
                    for (int i = 1; i < model.Levels.Count; i++)
                    {
                        Fvalues[i - 1] = Fvalues[i - 1] * Vbase;
                        file.WriteLine(string.Format("load {0} {1} 0.0 0.0;", model.Levels[i].GetFirstLeftNode().ID, /*0.5 */ Fvalues[i - 1]));
                    }
                    break;
                case PushOverProfile.Generic:
                    for (int i = model.Levels.Count - 1; i > 0; i--)
                    {
                        double H = model.Levels[i].Elevation;
                        v = 0.1 * Math.Pow((H - minH) / (HT), parameters.K);
                        file.WriteLine(string.Format("load {0} {1} 0.0 0.0;", model.Levels[i].GetFirstLeftNode().ID, v));
                    }
                    break;
            }
        }
        private static void AddCyclicProfilePushOver(StreamWriter file, SPSW_Simple_Model model, Action<StreamWriter, SPSW_Simple_Model> patternWriter)
        {
            file.WriteLine("# PUSH OVER analysis ------------------------------");
            file.WriteLine("pattern Plain 2 Linear {");
            patternWriter(file, model);
            file.WriteLine("}");
            AddCyclicpushOverpattern(file, model);
        }
        private static void AddCyclicpushOverpattern(StreamWriter file, SPSW_Simple_Model model)
        {
            file.WriteLine("# pushover: diplacement controlled static analysis");
            WriteSolvingOptions(file, model);
            file.WriteLine("set algorithmType Newton;");
            file.WriteLine("algorithm $algorithmType;");

            double Height = model.GetBuildingHeight() * 0.01;
            int NodeId = model.Levels.Last().GetFirstLeftNode().ID;
            file.WriteLine(@"proc PushCycle { Dmax Nsteps IDctrlNode IDctrlDOF} {");
            file.WriteLine("set Dincr [ expr $Dmax/$Nsteps ];");
            file.WriteLine("integrator DisplacementControl $IDctrlNode $IDctrlDOF $Dincr;");
            file.WriteLine("analysis Static	");;
            file.WriteLine("set ok [analyze $Nsteps];");
            file.WriteLine(Properties.Resources.RunMethods);           
            file.WriteLine("}");

            foreach (var record in model.AnalysisParameters.CyclicPushoOver.Records)
            {
                double v = record.Drift * Height;
                for (int i = 0; i < record.Cycles; i++)
                {
                    file.WriteLine(string.Format("PushCycle double({0}) {1} {2} {3};", v, record.Steps, NodeId, 1));
                    file.WriteLine(string.Format("PushCycle double({0}) {1} {2} {3};", -1 * v, record.Steps, NodeId, 1));
                    file.WriteLine(string.Format("PushCycle double({0}) {1} {2} {3};", -1 *v, record.Steps, NodeId, 1));
                    file.WriteLine(string.Format("PushCycle double({0}) {1} {2} {3};",  v, record.Steps, NodeId, 1));
                }
            }
        }
        private static void AddProfilePushOver(StreamWriter file, SPSW_Simple_Model model, Action<StreamWriter, SPSW_Simple_Model> patternWriter )
        {
            file.WriteLine("# PUSH OVER analysis ------------------------------");
            file.WriteLine("pattern Plain 2 Linear {");
            patternWriter(file,model);
            file.WriteLine("}");
            AddStaticpushOverpattern(file, model);
        }
        private static void AddStaticpushOverpattern(StreamWriter file, SPSW_Simple_Model model)
        {
            LateralProfilePushOverParameters parameters = model.AnalysisParameters.ProfilePushOverParameters;
            file.WriteLine("# pushover: diplacement controlled static analysis");
            WriteSolvingOptions(file, model);

            file.WriteLine("set algorithmType Newton;");
            file.WriteLine("algorithm $algorithmType;");
            file.WriteLine("set IDctrlDOF 1;");
            switch (parameters.ControlType)
            {
                case PushOverControl.DisplacementControl:
                    file.WriteLine(string.Format("set Dmax double({0});", model.GetBuildingHeight() * 0.01 * parameters.MaxDriftPercentage));
                    file.WriteLine(string.Format("set Dincr [ expr $Dmax/{0} ]", parameters.NumOfSteps));
                    file.WriteLine(string.Format("set IDctrlNode {0};", model.Levels.Last().GetFirstLeftNode().ID));
                    file.WriteLine("integrator DisplacementControl $IDctrlNode $IDctrlDOF $Dincr;");
                    break;
                case PushOverControl.LoadControl:
                    file.WriteLine(string.Format("set Dmax {0};", parameters.Omega * model.GetDesginBaseShear()));
                    file.WriteLine(string.Format("set Dincr [ expr $Dmax /{0} ];", parameters.NumOfSteps));
                    file.WriteLine("integrator LoadControl [ expr $Dincr];");
                    string s = "set  Supports {";
                    for (int i = 0; i < model.SupportsNodes.Count; i++)
                    {
                        s += string.Format(" {0}", model.SupportsNodes[i].ID);
                    }
                    s += " };";
                    file.WriteLine(s);
                    break;
            }
            file.WriteLine("analysis Static	");
            file.WriteLine("set Nsteps [expr int($Dmax /$Dincr)];");
            file.WriteLine("set ok [analyze $Nsteps];");
            switch (parameters.ControlType)
            {
                case PushOverControl.DisplacementControl:
                    file.WriteLine(Properties.Resources.RunMethods);
                    break;
                case PushOverControl.LoadControl:
                    file.WriteLine(Properties.Resources.LoadControlAlgorithm);
                    break;
            }
        }
        //private static void AddModalPushOverLoadsAFMP(StreamWriter file, SPSW_Simple_Model model)
        //{
        //    ApdativePushOverParameters parameters = model.AnalysisParameters.ApdativePushOverParamters;
        //    double maxH = model.Levels.Last().Elevation;
        //    double minH = model.Levels.First().Elevation;
        //    double HT = maxH - minH;
        //    file.WriteLine("# PUSH OVER analysis ------------------------------");
        //    for (int j = model.Levels.Count - 1; j > 0; j--)
        //    {
        //        file.WriteLine("pattern Plain " + (model.Levels.Count - j +1) + " Linear { ");
        //        List<double> F_Values = new List<double>();
        //        double LAMBDA = model.ModalData.ModeShapeData[j].LAMBDA;
        //        double Sa = parameters.ResposeSpectrumData.GetAgResponse(model.ModalData.ModeShapeData[j].PERIOD);
        //        for (int i = model.Levels.Count - 1; i > 0; i--)
        //        {
        //            var mainNodes = model.Levels[i].GetMainNodes();
        //            double m = mainNodes.Select(x => x.NodeMass).Sum();
        //            double Phi = mainNodes[0].ModeShapesDeformations[j].Dx;
        //            double v = LAMBDA * Sa * Phi * m;
        //            file.WriteLine(string.Format("load {0} {1} 0.0 0.0;", mainNodes[0].ID, v));
        //            F_Values.Add(v);
        //        }
        //        file.WriteLine("}");
        //        AddStaticpushOverpattern(file, model, parameters.Control, F_Values.Sum());
        //        file.WriteLine("loadConst -time 0.0;");
        //    }

        //}
        //private static void AddModalPushOverLoadsSMP(StreamWriter file, SPSW_Simple_Model model)
        //{
        //    ApdativePushOverParameters parameters = model.AnalysisParameters.ApdativePushOverParamters;
        //    double maxH = model.Levels.Last().Elevation;
        //    double minH = model.Levels.First().Elevation;
        //    double HT = maxH - minH;
        //    file.WriteLine("# PUSH OVER analysis ------------------------------");
        //    for (int j = 0; j < model.ModeShapes; j++)
        //    {
        //        file.WriteLine("wipeAnalysis;");
        //        file.WriteLine("pattern Plain "+(j+2)+" Linear { ");
        //        List<double> F_Values = new List<double>();
        //        double LAMBDA = model.ModalData.ModeShapeData[j].LAMBDA;
        //        double Sa = parameters.ResposeSpectrumData.GetAgResponse(model.ModalData.ModeShapeData[j].PERIOD);
        //        for (int i = model.Levels.Count - 1; i > 0; i--)
        //        {
        //            var mainNodes = model.Levels[i].GetMainNodes();
        //            double m = mainNodes.Select(x => x.NodeMass).Sum();
        //            double Phi = mainNodes[0].ModeShapesDeformations[j].Dx;
        //            double v = LAMBDA * Sa * Phi * m;
        //            file.WriteLine(string.Format("load {0} {1} 0.0 0.0;", mainNodes[0].ID, v));
        //            F_Values.Add(v);
        //        }
        //        file.WriteLine("}");
        //        AddStaticpushOverpattern(file, model, parameters.Control , F_Values.Sum());
        //        file.WriteLine("loadConst -time 0.0;");
        //    }

        //}
        private static void AddTrussesRecords(StreamWriter file)
        {
            if (TrussesRegionId == 0)
                return;
            file.WriteLine(string.Format("recorder Element -file {0}/{1}/{2} -time -region {3} deformations;", OutPutFolder, TrussFolder, TrussesStrainsResultspath, TrussesRegionId));
            file.WriteLine(string.Format("recorder Element -file {0}/{1}/{2} -time -region {3} basicForces;", OutPutFolder, TrussFolder, TrussesResultspath, TrussesRegionId));
        }
        private static void AddElementRecords(StreamWriter file ,string SubFolder, int elmentId , bool Elastic)
        {
            if (elmentId == 0)
                return;
            file.WriteLine(string.Format("recorder Element -file {0}/{1}/{2} -time -region {3} localForce;",OutPutFolder, SubFolder , LocalForces, elmentId));
            if (Elastic)
                return;
            file.WriteLine(string.Format("recorder Element -file {0}/{1}/{2} -time -region {3} basicDeformation;", OutPutFolder, SubFolder , ElasticRotation, elmentId));
            file.WriteLine(string.Format("recorder Element -file {0}/{1}/{2} -time -region {3} plasticDeformation;", OutPutFolder, SubFolder, PlasticRotation, elmentId));
        }
        private static void AddColumnsDrifts(StreamWriter file, List<Column> columns)
        {
            file.WriteLine("# Define Drifts Recordes-------------------");
            columns.ForEach(x => AddDriftRecorder(file,x.ID,x.Nodes.First().ID , x.Nodes.Last().ID));
        }
        private static void AddDriftRecorder(StreamWriter file , int columnID , int n1 , int n2)
        {
            file.WriteLine(string.Format("recorder Drift -file Data/Drifts/{0}.out -time -iNode {1} -jNode {2} -dof 1  -perpDirn 2 ;",columnID , n1 , n2));
        }
        private static void AddSupportsRecordes(StreamWriter file)
        {
            file.WriteLine("# Define Supports Recordes-------------------");
            file.WriteLine(string.Format("recorder Node -file {0}/{1}/{2} -time -region {3} -dof 1 2 3 reaction;",OutPutFolder,NodesFolder, SupportsReactionPath,SupportRegionId));
        }
        private static void AddNodesRecordes(StreamWriter file)
        {
            file.WriteLine("# Define MainNodes Recordes-------------------");
           file.WriteLine(string.Format("recorder Node -file {0}/{1}/{2} -time -region {3} -dof 1 2 3 disp;",OutPutFolder, NodesFolder, NodesDeformationPath,NodesRegionId));
        }
        private static void AddFrameElementsElasticElements(StreamWriter file, List<FrameTwoNodesElement> frameElements , int regionId , double areaModifier )
        {
            if (!frameElements.Any())
                return;
            foreach (var child in frameElements)
            {
                double E = child.Family.initE;
                Section sec = child.Family.Section;
                double A = sec.A * areaModifier;
                double Ix = sec.Ix;
                file.WriteLine(string.Format("element elasticBeamColumn {0} {1} {2} {3} {4} {5} {6};",
                    child.ID, child.StartNode.ID, child.EndNode.ID, A, E, Ix, 1));
            }
            file.WriteLine(string.Format("region {0} -eleRange {1} {2}", regionId, frameElements.First().ID, frameElements.Last().ID));
        }
        private static void AddTrusses(StreamWriter file , List<RegularTrussElement> Trusses  , ref int MaxMaterialId )
        {
            if (!Trusses.Any())
            {
                TrussesRegionId = 0;
                return;
            }
            file.WriteLine("# Infill Panels -------------------");
            Trusses.ForEach(truss =>
            {
                file.WriteLine(string.Format("element Truss {0} {1} {2} {3} {4};",
                    truss.ID, truss.StartNode.ID, truss.EndNode.ID, truss.Section.A * truss.PlateFamily.AreaModifier, truss.PlateFamily.Material.AnalysisID));
            });

            file.WriteLine(string.Format("region {0} -eleRange {1} {2}", TrussesRegionId, Trusses.First().ID, Trusses.Last().ID));
            file.WriteLine("# ----------------------------------");
        }
        private static void AddLinks(StreamWriter file, IEnumerable<RigidLink> rigdLinks , double areafactor)
        {
            file.WriteLine("# Rigid Links -------------------");
            foreach (var x in rigdLinks)
            {
                file.WriteLine(string.Format("element truss {0} {1} {2} {3} {4};",x.ID , x.StartNode.ID 
                 , x.EndNode.ID , x.FrameSectionFamily.Section.A * areafactor , x.FrameSectionFamily.ElasticAnalysisNum));
            }
            file.WriteLine(string.Format("region {0} -eleRange {1} {2}", LinksRegionId, rigdLinks.First().ID, rigdLinks.Last().ID));
            file.WriteLine("# ----------------------------------");
        }
        private static void AddTrussSection(StreamWriter file , int secId, RectangleSection trussesSection ,int matId)
        {
            double b = Math.Round(trussesSection.B *0.5,5);
            double t = Math.Round(trussesSection.D *0.5,5);
            file.WriteLine("section fiberSec "+ secId + " {");
            file.WriteLine(string.Format("patch quadr {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}"
                                                      , matId, 5 , 1 ,-b , -t ,-b , t, b, t, b, -t));
            file.WriteLine("}");
        }
        private static void AddNodesMass(StreamWriter file, SPSW_Simple_Model model)
        {
            file.WriteLine("# Define Nodes Mass-------------------");
            for (int i = 1; i < model.Levels.Count; i++)
            {
                var mainNodes = model.Levels[i].GetMainNodes(model.VerticalLines);
                double added = 0.5 * mainNodes[2].NodeMass;
                file.WriteLine(string.Format("mass {0} {1} 1.0e-9 1.0e-9;", mainNodes[0].ID,(mainNodes[0].NodeMass+added) /g ));
                file.WriteLine(string.Format("mass {0} {1} 1.0e-9 1.0e-9;", mainNodes[1].ID,(mainNodes[1].NodeMass+added) /g ));
            }
            file.WriteLine("# ------------------------------------");
        }
        private static void AddFixCommands(StreamWriter file, List<SupportsMainNode> supportsNodes)
        {
            file.WriteLine("# Define Nodes Constrains-------------------");
            foreach (SupportsMainNode node in supportsNodes)
            {
                int[]  vector = Node2DFixingCondition.GetSupportbytype(node.Type).ToVector();
                file.WriteLine(string.Format("fix {0} {1} {2} {3};", node.ID, vector[0] , vector[1] , vector[2]));
            }
            file.WriteLine(string.Format("region {0} -nodeRange {1} {2}", SupportRegionId, supportsNodes.First().ID, supportsNodes.Last().ID));
            file.WriteLine("# -----------------------------------------");
        }
        private static void AddNodesGeometry(StreamWriter file, IEnumerable<Node> Nodes, double elevation)
        {
            file.WriteLine("# Define Nodes -------------------");
            foreach (Node node in Nodes)
            {
                file.WriteLine(string.Format("node {0} {1} {2};", node.ID , Math.Round(node.Point.X,5) , Math.Round(node.Point.Y + elevation,5)));
            }
            file.WriteLine(string.Format("region {0} -nodeRange {1} {2}", NodesRegionId, Nodes.First().ID, Nodes.Last().ID));
            file.WriteLine("# --------------------------------");
        }
        private static void SetMainInformation(StreamWriter file)
        {
            #region ResetIds
            TrussesRegionId = 3;
            ElasticSegmentsRegionId = 6;
            DistributedPlasticityRegionId = 7;
            NonLinearEndsRegionId = 8;
            BeamWithHingesRegionId = 9;
            PlasticHingesRegionId = 10;
            #endregion

            file.WriteLine("# SET UP -------------------");
            file.WriteLine("wipe;  # clear opensees model");
            file.WriteLine("model basic -ndm 2 -ndf 3;  # 2 dimensions, 3 dof per node");
            file.WriteLine(string.Format("file mkdir {0}; # create outPut directory",OutPutFolder));
            GetSubFolderList().ForEach(x => file.WriteLine(string.Format("file mkdir {0}/{1}; # create ModeShapes directory", OutPutFolder, x)));
            file.WriteLine("# -------------------------");
        }
    }
}
