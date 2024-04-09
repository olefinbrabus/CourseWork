using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace WinFormsStudentCatalogWork
{
    public partial class ControlWorks : Form
    {
        public static List<CourseWork> CourseWorks;
        public static List<GraduateWork> GraduateWorks;

        public ControlWorks()
        {
            InitializeComponent();
            ShowListBoxWorks();
        }

        private void ShowListBoxWorks()
        {
            InfoWorksUpdate();
            lbWorks.Items.Clear();
            lbWorks.Items.AddRange(CourseWorks.ToArray());
            lbWorks.Items.AddRange(GraduateWorks.ToArray());

        }

        public static void InfoWorksUpdate()
        {
            DataBase.View dView = new();

            CourseWorks = dView.ShowDataCourseWork();
            GraduateWorks = dView.ShowDataGraduateWork();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {

        }

        private void bChange_Click(object sender, EventArgs e)
        {

        }

        private void bClear_Click(object sender, EventArgs e)
        {

        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            DataBase.View dView = new();

            int index = lbWorks.SelectedIndex;
            if (index == -1)
                return;
            
            if (index < CourseWorks.Count)
            {
                CourseWork work = CourseWorks[index];
                dView.Delete(work);
            }
            else
            {
                GraduateWork work = GraduateWorks[index - CourseWorks.Count];
                dView.Delete(work);
            }
            ShowListBoxWorks();
        }
    }
}
