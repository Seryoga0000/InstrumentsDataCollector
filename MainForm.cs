using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InstrumentsDataCollector.Properties;
using UControlLibrary;
using UControlLibrary.Menus;

namespace InstrumentsDataCollector
{
    public partial class MainForm : Form
    {
        #region Controls

        DataCollectorStripPanel _dcsp = new DataCollectorStripPanel();
        DataCollectorStatusPanel _dcstsp = new DataCollectorStatusPanel();
        SplitContainer _mainSplitContainer = new SplitContainer() {Dock = DockStyle.Fill};
        UDataChart _mainChart = new UDataChart() {Dock = DockStyle.Fill};
        UDataTable _mainTable = new UDataTable() {Dock = DockStyle.Fill};

        # endregion

        Settings _sett;

        public MainForm()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
            InitializeComponent();
            InitializeComponent2();
        }

        private void InitializeComponent2()
        {
            _sett = new Settings() {Owner = this};
            
            #region MainFormInitial

            Text = Properties.LocResX.MainFormText;
            Width = 600;
            Height = 400;
            _dcsp.Initial();
            Controls.Add(_dcsp);
            //            Controls.Add(new Button(){Width = 100,Height = 100});
            _dcstsp.Initial();
            Controls.Add(_dcstsp);

            Controls.Add(_mainSplitContainer);

            _mainChart.Initial();
            _mainSplitContainer.Panel2.Controls.Add(_mainChart);

            _mainTable.Initial();
            _mainSplitContainer.Panel1.Controls.Add(_mainTable);

            _dcsp.SendToBack();
            _dcstsp.SendToBack();

            #endregion

            _dcsp.SettingButton.Click += (s, e) => _sett.Show();
        }
    }
}