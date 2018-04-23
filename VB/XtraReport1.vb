Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraReports.UI

Namespace WindowsFormsApplication1
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport
		Public Sub New()
			InitializeComponent()
			AddHandler BeforePrint, AddressOf OnBeforePrint
		End Sub
		Private Sub OnBeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
			Dim tree As New DevExpress.XtraTreeList.TreeList()
			AddHandler tree.ParentChanged, AddressOf tree_ParentChanged
			tree.BeginUpdate()
			Dim colName As New DevExpress.XtraTreeList.Columns.TreeListColumn()
			colName.Caption = "Name"
			colName.FieldName = "Name"
			colName.Name = "colName"
			colName.Visible = True
			colName.VisibleIndex = 0
			colName.Width = 45
			tree.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() { colName })

			Dim wcc As New WinControlContainer()
			Me.ReportHeader.Controls.Add(wcc)
			wcc.WinControl = tree
			tree.KeyFieldName = "Oid"
			tree.ParentFieldName = "Parent!Key"
			tree.DataSource = Me.DataSource
			tree.EndUpdate()
		End Sub
		Private Sub tree_ParentChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim treeList As DevExpress.XtraTreeList.TreeList = CType(sender, DevExpress.XtraTreeList.TreeList)
			treeList.ExpandAll()
			RemoveHandler treeList.ParentChanged, AddressOf tree_ParentChanged
		End Sub
	End Class
End Namespace