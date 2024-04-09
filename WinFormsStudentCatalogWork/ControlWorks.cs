using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

            Degree[] degrees = { Degree.Бакалавр, Degree.Спеціаліст, Degree.Магістр };
            foreach (var degree in degrees)
                lbDegrees.Items.Add($"P{degree}");

            nudYear.Text = $"{nudYear.Maximum}";
            


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

        private bool IndexToWork(out int index)
        {
            index = lbWorks.SelectedIndex;
            if (index > CourseWorks.Count)
            {
                index -= CourseWorks.Count;
                return false;
            }
            return true;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbTheme.Text = "";
            tbStudent.Text = "";
            tbTeacher.Text = "";
            tbGroup.Text = "";
            tbDiscipline.Text = "";

            nudGrade.Text = $"{nudGrade.Minimum}";
            nudYear.Text = $"{nudYear.Maximum}";

            lbDegrees.SelectedIndex = -1;



        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            DataBase.View dView = new();

            bool isCourse = IndexToWork(out int index);

            if (index == -1)
                return;
            var result = MessageBox.Show("Ви впевнені, що хочете удалити з каталогу цю роботу?",
            "Видалити роботу",
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);

            if(result == DialogResult.No)
                return;
            
            if (isCourse)
            {
                CourseWork work = CourseWorks[index];
                dView.Delete(work);
            }
            else
            {
                GraduateWork work = GraduateWorks[index];
                dView.Delete(work);
            }
            ShowListBoxWorks();
        }



        
    }
}
