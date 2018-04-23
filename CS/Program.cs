using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace WindowsFormsApplication1 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Session session = new Session();
            TreeObject root = session.FindObject<TreeObject>(CriteriaOperator.Parse("Name = 'Root'"));
            if (root == null) {
                root = new TreeObject(session);
                root.Name = "Root";
                TreeObject child1 = new TreeObject(session);
                child1.Name = "Child1";
                child1.Parent = root;
                child1.Save();
                root.Save();
                TreeObject child2 = new TreeObject(session);
                child2.Name = "Child2";
                child2.Parent = child1;
                child2.Save();
            }
            Application.Run(new Form1());
        }
    }
}
