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

        private void ListViewNormalSorting()  // Загальна сортування
        {
            InfoWorksUpdate();
            AddGroupsListViewWorks(_courseWork.ToList(), _graduateWorks.ToList());

        }

        private void InfoWorksUpdate()  // Оновлення данних з бази даних
        {
            View dView = new();

            _courseWork = new(dView.ShowDataCourseWork());
            _graduateWorks = new(dView.ShowDataGraduateWork());
        }

        private void AddGroupsListViewWorks(List<CourseWork> courses, List<GraduateWork> graduates)  // Сортування за відфільтрованими даними
        {
            lvWorks.Items.Clear();

            ListViewGroup courseViewGroup = new("Курсові");
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

            ListViewGroup graduateViewGroup = new("Дипломні");
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

        private void AddFilters()  // Додавання фільтрів у ListBox
        {
            string[] filters = [
                "Теми роботи за зростаннням",
                "Теми роботи за спаданням",
                "Тільки курсові",
                "Тільки дипломні",
                "Магістр. роботи за роком",
                "За прізвищем студента",
                "За прізвищем керівника"
            ];

            lbFilter.Items.AddRange(filters);
        }

        private void bAdd_Click(object sender, EventArgs e) // Відкриття форми для управління роботами
        {
            ControlWorks works = new();
            if (works.ShowDialog() == DialogResult.OK)
                ListViewNormalSorting();

        }

        private void bSearch_Click(object sender, EventArgs e) // Кнопка пошуку
        {
            SearchFilter(sender, e);
        }

        private void lbFilter_SelectedIndexChanged(object sender, EventArgs e)  // Змінення пошуку за індексом
        {
            SearchFilter(sender, e);
        }

        private void SearchFilter(object sender, EventArgs e)  // Вибір фільтру
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

        private void SearchByTheme()    // Пошук за темою
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

        private void SearchByCourseWork()    // Пошук по курсовим роботам
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

        private void SearchByGraduateWork()    // Пошук по дипломним роботам
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

        private void SearchByMasterDegreeByYear()    // Пошук магістерських робіт за роком
        {
            string search = tbSearch.Text;
            if (search != "")
            {
                List<GraduateWork> works = _graduateWorks
                    .Where(w => $"{w.Year}" == search && w.DegreeLevel == Degree.Магістр).ToList();
                AddGroupsListViewWorks( new List<CourseWork>(), works);

            }
            else
                MessageBox.Show("Ви не вказали рік.");
            
        }

        private void SearchByStudent()    // Пошук по ПІБ студентів
            => AddGroupsListViewWorks(
                _courseWork.Where(w => w.StudentFullName.Contains(tbSearch.Text)).ToList(),
                _graduateWorks.Where(w => w.StudentFullName.Contains(tbSearch.Text)).ToList()
            );

        private void SearchByTeacher()    // Пошук по ПІБ вчителів
            => AddGroupsListViewWorks(
                _courseWork.Where(w => w.TeacherFullName.Contains(tbSearch.Text)).ToList(),
                _graduateWorks.Where(w => w.TeacherFullName.Contains(tbSearch.Text)).ToList()
            );
        

        private void bClear_Click(object sender, EventArgs e)     // Очистити поля
        {
            lvWorks.Sorting = SortOrder.None;
            lbFilter.SelectedIndex = -1;
            ListViewNormalSorting();
            tbSearch.Text = "";
        }
    }
}
