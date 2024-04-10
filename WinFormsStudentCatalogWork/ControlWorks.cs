using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accessibility;
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

            lbDegrees.Items.Clear();
            Degree[] degrees = { Degree.Бакалавр, Degree.Спеціаліст, Degree.Магістр };
            foreach (var degree in degrees)
                lbDegrees.Items.Add($"{degree}");

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
            CreativeWork? work = CreateWork();

            if (work != null)
            {
                DataBase.View dView = new();
                dView.Add(work);
                ShowListBoxWorks();
            }
        }

        private CreativeWork CreateWork()
        {
            if (!ValidateGeneralWork())
            {
                MessageBox.Show("Ви не правильно ввели основні данні.");
                return null;
            }

            CreativeWork work = CreateGeneralWork();

            if (IsCouseWork())
            {
                CourseWork course = (CourseWork)work;
                if (!IsMatchingDescipline())
                {
                    MessageBox.Show("Ви не правильно ввели дисципліну.");
                    return null;
                }

                course.DisciplineName = tbDiscipline.Text;
                return course;

            }
            else
            {
                GraduateWork graduate = (GraduateWork)work;

                Degree degree = getDegree();
                if (degree == null)
                {
                    MessageBox.Show("Ви не ввели кваліфікацію.");
                    return null;
                }
                graduate.DegreeLevel = degree;

                return graduate;
            }
        }

        private bool ValidateGeneralWork()
        {
            string pattern = @"[\u0410-\u044F\u0456\u0457\u0041-\u005A\u0061-\u007A\s]+";

            string[] toCheck = { tbTheme.Text, tbStudent.Text, tbTeacher.Text };

            foreach (string text in toCheck)
                if (!Regex.IsMatch(text, pattern))
                    return false;

            return true;
        }

        private CreativeWork CreateGeneralWork()
        {
            if (IsCouseWork())
                return new CourseWork
                {
                    WorkTheme = tbTheme.Text,
                    StudentFullName = tbStudent.Text,
                    TeacherFullName = tbTeacher.Text,
                    Group = tbGroup.Text,
                    Grade = int.Parse(nudGrade.Text),
                    Year = int.Parse(nudYear.Text)
                };
            return new GraduateWork
            {
                WorkTheme = tbTheme.Text,
                StudentFullName = tbStudent.Text,
                TeacherFullName = tbTeacher.Text,
                Group = tbGroup.Text,
                Grade = int.Parse(nudGrade.Text),
                Year = int.Parse(nudYear.Text)
            };
        }

        private bool IsCouseWork() => tcWorks.SelectedIndex == 0;

        private bool IsMatchingDescipline() => Regex.IsMatch(tbDiscipline.Text,
            @"[\u0410-\u044F\u0456\u0457\u0041-\u005A\u0061-\u007A\s]+");

        private Degree getDegree()
        {
            switch (lbDegrees.SelectedIndex)
            {
                case 0:
                    return Degree.Бакалавр;
                case 1:
                    return Degree.Спеціаліст;
                case 2:
                    return Degree.Магістр;
                default:
                    throw new NotImplementedException("Ви не ввели Кваліфікацію.");
            }
        }

        private void bChange_Click(object sender, EventArgs e)
        {
            InfoWorksUpdate();


        }

        private bool IndexToWork(out int index)
        {
            index = lbWorks.SelectedIndex;
            if (index > CourseWorks.Count - 1)
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
            lbWorks.SelectedIndex = -1;



        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            DataBase.View dView = new();

            bool isCourse = IndexToWork(out int index);

            if (index == -1)
                return;
            var result = MessageBox.Show("Ви впевнені, що хочете видалити з каталогу цю роботу?",
            "Видалити роботу",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.No)
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

        private void lbWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataBase.View dView = new();

            bool isCourse = IndexToWork(out int index);
            CreativeWork work;
            if (index == -1)
                return;
            if (isCourse)
            {
                work = CourseWorks[index];
            }
            else
            {
                work = GraduateWorks[index];
            }

            tbTheme.Text = work.WorkTheme;
            tbStudent.Text = work.StudentFullName;
            tbTeacher.Text = work.TeacherFullName;
            tbGroup.Text = work.Group;
            nudGrade.Text = $"{work.Grade}";
            nudYear.Text = $"{work.Year}";

            tcWorks.SelectedIndex = isCourse ? 0 : 1;

            if (isCourse)
            {
                CourseWork course = (CourseWork)work;
                tbDiscipline.Text = course.DisciplineName;
            }
            else
            {
                GraduateWork graduate = (GraduateWork)work;

                
                switch (graduate.DegreeLevel)
                {
                    case Degree.Бакалавр:
                        lbDegrees.SelectedIndex = 0;
                        break;
                    case Degree.Спеціаліст:
                        lbDegrees.SelectedIndex = 1;
                        break;
                    case Degree.Магістр:
                        lbDegrees.SelectedIndex = 2;
                        break;
                }


            }
        }
    }
}
