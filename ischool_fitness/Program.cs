using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Permission;
using K12.Presentation;
using System.ComponentModel;
using Campus.DocumentValidator;

namespace ischool_fitness
{
    // 體適能
    public class Program
    {
        // 背景載入資料
        static BackgroundWorker _bkWork;

        // 載入點
        [MainMethod()]
        public static void Main()
        {
            _bkWork = new BackgroundWorker();
            _bkWork.DoWork += new DoWorkEventHandler(_bkWork_DoWork);
            _bkWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bkWork_RunWorkerCompleted);
            _bkWork.RunWorkerAsync();

          // 體適能資料項目 加入
            K12.Presentation.NLDPanels.Student.AddDetailBulider<DetailContents.StudentFitnessContent>();

            // 匯出體適能
            NLDPanels.Student.RibbonBarItems["資料統計"]["匯出"]["匯出體適能"].Enable = UserAcl.Current["K12.Student.ExportFitness"].Executable;
            NLDPanels.Student.RibbonBarItems["資料統計"]["匯出"]["匯出體適能"].Click += delegate
            {
                SmartSchool.API.PlugIn.Export.Exporter exporter = new ImportExport.ExportStudentFitness();
                ImportExport.ExportStudentV2 wizard = new ImportExport.ExportStudentV2(exporter.Text, exporter.Image);
                exporter.InitializeExport(wizard);
                wizard.ShowDialog();
            };


            // 匯入體適能
            NLDPanels.Student.RibbonBarItems["資料統計"]["匯入"]["匯入體適能"].Enable = UserAcl.Current["K12.Student.ImportFitness"].Executable;
            NLDPanels.Student.RibbonBarItems["資料統計"]["匯入"]["匯入體適能"].Click += delegate
            {
                Global._AllStudentNumberStatusIDTemp = Utility.GetAllStudenNumberStatusDict();                
                Global._StudentStatusDBDict = Utility.GetStudentStatusDBValDict();
                ImportExport.ImportStudentFitnessRecord isfr = new ImportExport.ImportStudentFitnessRecord();
                isfr.Execute();
            };

            // 體適能資料項目權限
            Catalog catalog1 = RoleAclSource.Instance["學生"]["資料項目"];
            catalog1.Add(new DetailItemFeature("K12.Student.FitnessContent", "體適能"));

            // 匯出體適能權限
            Catalog catalog2 = RoleAclSource.Instance["學生"]["功能按鈕"];
            catalog2.Add(new RibbonFeature("K12.Student.ExportFitness", "匯出體適能"));

            // 匯入體適能權限
            Catalog catalog3 = RoleAclSource.Instance["學生"]["功能按鈕"];
            catalog3.Add(new RibbonFeature("K12.Student.ImportFitness", "匯入體適能"));            
        }

        static void _bkWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 當有錯誤訊息顯示
            if (Global._ErrorMessageList.Length > 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show(Global._ErrorMessageList.ToString());
            }
        }

        static void _bkWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // 檢查並建立UDT Table
                DAO.UDTTransfer.CreateFitnessUDTTable();

                #region 自訂驗證規則
                FactoryProvider.RowFactory.Add(new ValidationRule.FitnessRowValidatorFactory());
                #endregion

            }
            catch (Exception ex)
            {
                Global._ErrorMessageList.AppendLine("載入體適能發生錯誤：" + ex.Message);
            }
        }
    }
}
