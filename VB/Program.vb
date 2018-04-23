Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace WindowsFormsApplication1
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Dim session As New Session()
			Dim root As TreeObject = session.FindObject(Of TreeObject)(CriteriaOperator.Parse("Name = 'Root'"))
			If root Is Nothing Then
				root = New TreeObject(session)
				root.Name = "Root"
				Dim child1 As New TreeObject(session)
				child1.Name = "Child1"
				child1.Parent = root
				child1.Save()
				root.Save()
				Dim child2 As New TreeObject(session)
				child2.Name = "Child2"
				child2.Parent = child1
				child2.Save()
			End If
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace
