using DataBase;
using View = DataBase.View;

namespace WinFormsStudentCatalogWork
{
    public partial class Form1 : Form
    {
        public LinkedList<CourseWork> _courseWork;

        public LinkedList<GraduateWork> _graduateWorks;

        public Form1() 
        {
            InitializeComponent();
            ListViewNormalSorting();
            AddFilters();
        }

        private void ListViewNormalSorting()  // �������� ����������
        {
            InfoWorksUpdate();
            AddGroupsListViewWorks(_courseWork.ToList(), _graduateWorks.ToList());

        }

        private void InfoWorksUpdate()  // ��������� ������ � ���� �����
        {
            View dView = new();

            _courseWork = new(dView.ShowDataCourseWork());
            _graduateWorks = new(dView.ShowDataGraduateWork());
        }

        private void AddGroupsListViewWorks(List<CourseWork> courses, List<GraduateWork> graduates)  // ���������� �� ��������������� ������
        {
            lvWorks.Items.Clear();

            ListViewGroup courseViewGroup = new("������");
            lvWorks.Groups.Add(courseViewGroup);

            foreach (var work in courses)
            {
                ListViewItem lvi = new($"{work.Id}");
                lvi.SubItems.Add(work.WorkTheme);
                lvi.SubItems.Add(work.StudentFullName);
                lvi.SubItems.Add(work.TeacherFullName);
                lvi.SubItems.Add(work.Group);
                lvi.SubItems.Add($"{work.Year}");
                lvi.SubItems.Add(work.DisciplineName);
                lvi.SubItems.Add("");

                lvi.Group = courseViewGroup;
                lvWorks.Items.Add(lvi);
            }

            ListViewGroup graduateViewGroup = new("�������");
            lvWorks.Groups.Add(graduateViewGroup);

            foreach (var work in graduates)
            {
                ListViewItem lvi = new($"{work.Id}");
                lvi.SubItems.Add(work.WorkTheme);
                lvi.SubItems.Add(work.StudentFullName);
                lvi.SubItems.Add(work.TeacherFullName);
                lvi.SubItems.Add(work.Group);
                lvi.SubItems.Add($"{work.Year}");
                lvi.SubItems.Add("");
                lvi.SubItems.Add($"{work.DegreeLevel}");

                lvi.Group = graduateViewGroup;
                lvWorks.Items.Add(lvi);
            }
        }

        private void AddFilters()  // ��������� ������� � ListBox
        {
            string[] filters = [
                "���� ������ �� �����������",
                "���� ������ �� ���������",
                "ҳ���� ������",
                "ҳ���� �������",
                "������. ������ �� �����",
                "�� �������� ��������",
                "�� �������� ��������"
            ];

            lbFilter.Items.AddRange(filters);
        }

        private void bAdd_Click(object sender, EventArgs e) // ³������� ����� ��� ��������� ��������
        {
            ControlWorks works = new();
            if (works.ShowDialog() == DialogResult.OK)
                ListViewNormalSorting();

        }

        private void bSearch_Click(object sender, EventArgs e) // ������ ������
        {
            SearchFilter(sender, e);
        }

        private void lbFilter_SelectedIndexChanged(object sender, EventArgs e)  // ������� ������ �� ��������
        {
            SearchFilter(sender, e);
        }

        private void SearchFilter(object sender, EventArgs e)  // ���� �������
        {
            Control control;
            switch (lbFilter.SelectedIndex)
            {
                case -1:
                    SearchByTheme();
                    break;
                case 0:
                    SearchByTheme();
                    lvWorks.Sorting = SortOrder.Ascending;
                    break;
                case 1:
                    SearchByTheme();
                    lvWorks.Sorting = SortOrder.Descending;
                    break;
                case 2:
                    SearchByCourseWork();
                    break;
                case 3:
                    SearchByGraduateWork();
                    break;
                case 4:
                    control = (Control)sender;
                    if (control.Name == "bSearch")
                        SearchByMasterDegreeByYear();
                    break;
                case 5:
                    control = (Control)sender;
                    if (control.Name == "bSearch")
                        SearchByStudent();
                    break;
                case 6:
                    control = (Control)sender;
                    if (control.Name == "bSearch")
                        SearchByTeacher();
                    break;
            }
        }

        private void SearchByTheme()    // ����� �� �����
        {
            string search = tbSearch.Text;


            if (search != "")
            {
                List<CourseWork> courses;
                List<GraduateWork> graduates;

                graduates = _graduateWorks
                    .Where(w => w.WorkTheme.Contains(search))
                    .ToList();

                courses = _courseWork
                    .Where(w => w.WorkTheme.Contains(search))
                    .ToList();

                AddGroupsListViewWorks(courses, graduates);
            }
        }

        private void SearchByCourseWork()    // ����� �� �������� �������
        {
            string search = tbSearch.Text;
            if (search != "")
            {
                AddGroupsListViewWorks(_courseWork.
                        Where(w => w.WorkTheme.Contains(tbSearch.Text)).ToList(),
                    new List<GraduateWork>());
            }
            else 
                AddGroupsListViewWorks(_courseWork.ToList(), new List<GraduateWork>());
            
        }

        private void SearchByGraduateWork()    // ����� �� ��������� �������
        {
            string search = tbSearch.Text;
            if (search != "")
            {
                AddGroupsListViewWorks(
                    new List<CourseWork>(),
                    _graduateWorks.
                        Where(w => w.WorkTheme.Contains(tbSearch.Text)).ToList());
            }
            else 
                AddGroupsListViewWorks( new List<CourseWork>(), _graduateWorks.ToList());
        }

        private void SearchByMasterDegreeByYear()    // ����� ������������ ���� �� �����
        {
            string search = tbSearch.Text;
            if (search != "")
            {
                List<GraduateWork> works = _graduateWorks
                    .Where(w => $"{w.Year}" == search && w.DegreeLevel == Degree.������).ToList();
                AddGroupsListViewWorks( new List<CourseWork>(), works);

            }
            else
                MessageBox.Show("�� �� ������� ��.");
            
        }

        private void SearchByStudent()    // ����� �� ϲ� ��������
            => AddGroupsListViewWorks(
                _courseWork.Where(w => w.StudentFullName.Contains(tbSearch.Text)).ToList(),
                _graduateWorks.Where(w => w.StudentFullName.Contains(tbSearch.Text)).ToList()
            );

        private void SearchByTeacher()    // ����� �� ϲ� �������
            => AddGroupsListViewWorks(
                _courseWork.Where(w => w.TeacherFullName.Contains(tbSearch.Text)).ToList(),
                _graduateWorks.Where(w => w.TeacherFullName.Contains(tbSearch.Text)).ToList()
            );
        

        private void bClear_Click(object sender, EventArgs e)     // �������� ����
        {
            lvWorks.Sorting = SortOrder.None;
            lbFilter.SelectedIndex = -1;
            ListViewNormalSorting();
            tbSearch.Text = "";
        }
    }
}
