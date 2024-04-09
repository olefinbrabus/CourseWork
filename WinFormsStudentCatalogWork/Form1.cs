using DataBase;

namespace WinFormsStudentCatalogWork
{
    public partial class Form1 : Form
    {
        private LinkedList<CourseWork> _courseWork;

        private LinkedList<GraduateWork> _graduateWorks;

        public Form1()
        {
            InitializeComponent();
            ListViewInit();
        }

        private void ListViewInit()
        {
            InfoWorksUpdate();
            AddGroupsListViewWorks();

        }

        public void InfoWorksUpdate()
        {
            DataBase.View dView = new();

            _courseWork = new( dView.ShowDataCourseWork());
            _graduateWorks = new(dView.ShowDataGraduateWork());

            
        }

        private void AddGroupsListViewWorks() 
        {
            ListViewGroup courseViewGroup = new("������");
            lvWorks.Groups.Add(courseViewGroup);

            foreach (var work in _courseWork)
            {
                ListViewItem lvi = new($"{work.Id}");
                lvi.SubItems.Add(work.WorkTheme);
                lvi.SubItems.Add(work.StudentFullName);
                lvi.SubItems.Add(work.TeacherFullName);
                lvi.SubItems.Add(work.Group);
                lvi.SubItems.Add($"{work.StudentFullName}");
                lvi.SubItems.Add(work.DisciplineName);
                lvi.SubItems.Add("");

                lvi.Group = courseViewGroup;
                lvWorks.Items.Add(lvi);
            }

            ListViewGroup graduateViewGroup = new("��������");
            lvWorks.Groups.Add(graduateViewGroup);

            foreach (var work in _graduateWorks)
            {
                ListViewItem lvi = new($"{work.Id}");
                lvi.SubItems.Add(work.WorkTheme);
                lvi.SubItems.Add(work.StudentFullName);
                lvi.SubItems.Add(work.TeacherFullName);
                lvi.SubItems.Add(work.Group);
                lvi.SubItems.Add($"{work.StudentFullName}");
                lvi.SubItems.Add("");
                lvi.SubItems.Add($"{work.DegreeLevel}");

                lvi.Group = graduateViewGroup;
                lvWorks.Items.Add(lvi);
            }
        }



        private void bAdd_Click(object sender, EventArgs e)
        {

        }

        private void bDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
