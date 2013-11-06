using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation;
using FISCA.Permission;
using Campus.Windows;

namespace ischool_fitness.DetailContents
{
    [FeatureCode("K12.Student.FitnessContent", "體適能")]
    public partial class StudentFitnessContent : DetailContent
    {
        // 背景處理
        private BackgroundWorker _bgWorker;
        bool _isBusy = false;

        // 資料變動檢查
        ChangeListener _ChangeListener;

        public StudentFitnessContent()
        {
            InitializeComponent();
            // 資料項目名稱
            this.Group = "體適能";

            _bgWorker = new BackgroundWorker();
            _ChangeListener = new ChangeListener();
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);
            _ChangeListener.StatusChanged += new EventHandler<ChangeEventArgs>(_ChangeListener_StatusChanged);
        }

        void _ChangeListener_StatusChanged(object sender, ChangeEventArgs e)
        {
            CancelButtonVisible = (e.Status == ValueStatus.Dirty);
            SaveButtonVisible = (e.Status == ValueStatus.Dirty);
        }

        void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_isBusy)
            {
                _isBusy = false;
                _bgWorker.RunWorkerAsync();
                return;
            }

            // 載入資料至畫面

        }

        void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // 資料處理
        }

        // 切換學生時
        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            
        }

        // 點 儲存 按鈕
        protected override void OnSaveButtonClick(EventArgs e)
        {
            
        }

        // 點 取消 按鈕
        protected override void OnCancelButtonClick(EventArgs e)
        {
            
        }

    }
}
