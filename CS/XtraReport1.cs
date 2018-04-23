using System;
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication1 {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public XtraReport1() {
            InitializeComponent();
            this.BeforePrint+=new System.Drawing.Printing.PrintEventHandler(OnBeforePrint);
        }
        private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            DevExpress.XtraTreeList.TreeList tree = new DevExpress.XtraTreeList.TreeList();
            tree.ParentChanged += new EventHandler(tree_ParentChanged);
            tree.BeginUpdate();
            DevExpress.XtraTreeList.Columns.TreeListColumn colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colName.Caption = "Name";
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 0;
            colName.Width = 45;
            tree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colName });

            WinControlContainer wcc = new WinControlContainer();
            this.ReportHeader.Controls.Add(wcc);
            wcc.WinControl = tree;
            tree.KeyFieldName = "Oid";
            tree.ParentFieldName = "Parent!Key";
            tree.DataSource = this.DataSource;
            tree.EndUpdate();
        }
        void tree_ParentChanged(object sender, EventArgs e) {
            DevExpress.XtraTreeList.TreeList treeList = (DevExpress.XtraTreeList.TreeList)sender;
            treeList.ExpandAll();
            treeList.ParentChanged -= new EventHandler(tree_ParentChanged);
        }
    }
}