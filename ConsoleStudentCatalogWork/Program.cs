using DataBase;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace ConsoleStudentCatalogWork
{
    internal class Program
    {

        public static List<CourseWork> CourseWorks;
        public static List<GraduateWork> GraduateWorks;


        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;

            WriteLine("Каталог робіт");

            InfoWorksUpdate();
            int choice;
            do
            {
                WriteLine($"\n0 - Вийти, 1 - Показати Курсові, 2 - Показати Дипломні, 3 - Добавити роботу, 4 - Оновити роботу, " +
                          $"\n5 - Пошук Роботи за призвищем студента, 6 - Пошук тем магістерських робіт за роком , 7 - Показати за абеткою," +
                          $"\n8 - Пошук Роботи за призвищем Вчителя, 9 - Видалити роботу");
                try
                {
                    choice = int.Parse(ReadLine());
                }
                catch (FormatException)
                {
                    WriteLine("Введіть число.");
                    choice = -1;
                    continue;
                }

                HandleChoice(choice);

            } while (choice != 0);
        }

        public static void InfoWorksUpdate()
        {
            View dView = new();

            CourseWorks = dView.ShowDataCourseWork();
            GraduateWorks = dView.ShowDataGraduateWork();
        }

        private static void HandleChoice(int ch)
        {
            InfoWorksUpdate();

            switch (ch)
            {
                case 1:
                    ShowCourse();
                    break;
                case 2:
                    ShowGraduate();
                    break;
                case 3:
                    AddWork();
                    break;
                case 4:
                    ChangeWork();
                    break;
                case 5:
                    SearchBy();
                    break;
                case 6:
                    MasterDegreeSearchByYear();
                    break;
                case 7:
                    ShowABC();
                    break;
                case 8:
                    SearchByTeacher();
                    break;
                case 9:
                    Delete();
                    break;
            }
        }

        private static void ShowCourse()
        { 
            WriteLine("Курсові роботи:");
            foreach (var Cw in CourseWorks)
                WriteLine(Cw);
        }

        public static void ShowGraduate()
        {
            WriteLine("\nДипломні роботи:");
            foreach (var Gw in GraduateWorks)
                WriteLine(Gw);
        }

        private static void AddWork()
        {
            int choice;
            WriteLine("Оберіть яку роботу добавити: 1 - Курсова 2 - Дипломна.");
            try
            {
                choice = int.Parse(ReadLine());

                switch (choice)
                {
                    case 1:
                        SendAddWork();
                        break;
                    case 2:
                        SendAddWork(isCourse: false);
                        break;
                    default:
                        throw new NotImplementedException("Ви ввели не то число.");
                }
            }
            catch (FormatException)
            {
                WriteLine("Ви не ввели число.");
            }
            catch (NotImplementedException e)
            {
                WriteLine(e.Message);
            }
        }

        private static void SendAddWork(bool isCourse = true)
        {
            View dView = new();

            try
            {
                WriteLine("Введіть тему роботи:");
                string workTheme = ReadLine();
                WriteLine("Введіть ПІБ студента:");
                string studentFullName = ReadLine();
                WriteLine("Введіть ПІБ Викладача:");
                string teacherFullName = ReadLine();
                WriteLine("Введіть групу:");
                string group = ReadLine();
                WriteLine("Введіть рік захисту");
                int year = int.Parse(ReadLine());
                WriteLine("Введіть Оцінку:");
                int grade = int.Parse(ReadLine());
                if (isCourse)
                {
                    WriteLine("Оберіть дисціпліну:");
                    string disciplineName = ReadLine();

                    //Добавляємо поля які користувач вказав вище для курсової роботи
                    CourseWork courseWork = new CourseWork();
                    courseWork.WorkTheme = workTheme;
                    courseWork.StudentFullName = studentFullName;
                    courseWork.TeacherFullName = teacherFullName;
                    courseWork.Group = group;
                    courseWork.Year = year;
                    courseWork.Grade = grade;
                    courseWork.DisciplineName = disciplineName;

                    if (ValidateWork(courseWork))
                        dView.Add(courseWork);
                    else throw new InvalidOperationException("Неправильна форма курсової роботи");
                }
                else
                {
                    Degree[] degrees = [Degree.Бакалавр, Degree.Спеціаліст, Degree.Магістр];
                    WriteLine("Оберіть Кваліфікацію За номером:");
                    foreach (var degree in degrees)
                        Write($"{degree}, ");
                    Degree degreeWork = degrees[int.Parse(ReadLine()) - 1];

                    //Добавляємо поля які користувач вказав вище для дипломної роботи
                    GraduateWork graduateWork = new GraduateWork();
                    graduateWork.WorkTheme = workTheme;
                    graduateWork.StudentFullName = studentFullName;
                    graduateWork.TeacherFullName = teacherFullName;
                    graduateWork.Group = group;
                    graduateWork.Year = year;
                    graduateWork.Grade = grade;
                    graduateWork.DegreeLevel = degreeWork;

                    if (ValidateWork(graduateWork))
                        dView.Add(graduateWork);
                    else throw new InvalidOperationException("Неправильна форма курсової роботи");
                }
            }
            catch (Exception)
            {
                WriteLine("Ви ввели замість числел букви");
            }
        }

        public static void Delete()
        {
            int choice;
            WriteLine("Оберіть яку роботу Видалити: 1 - Курсова 2 - Дипломна.");
            try
            {
                choice = int.Parse(ReadLine());

                switch (choice)
                {
                    case 1:
                        DeleteSend();
                        break;
                    case 2:
                        DeleteSend(isCourse: false);
                        break;
                    default:
                        throw new NotImplementedException("Ви ввели не то число.");
                }
            }
            catch (FormatException)
            {
                WriteLine("Ви не ввели число.");
            }
            catch (NotImplementedException e)
            {
                WriteLine(e.Message);
            }
        }

        private static void DeleteSend(bool isCourse = true)
        {
            try
            {
                InfoWorksUpdate();
                View dView = new();

                WriteLine("Оберіть Id Для видалення:");
                if (isCourse)
                {
                    ShowCourse();

                    dView.Delete(
                        dView.ShowDataCourseWork()
                            .First(c => c.Id == int.Parse(ReadLine()))
                    );
                }
                else
                {
                    ShowGraduate();

                    dView.Delete(
                        dView.ShowDataGraduateWork()
                            .First(c => c.Id == int.Parse(ReadLine()))
                    );
                }
            }
            catch
            {
                WriteLine("Id не знайдено.");
            }
        }

        private static void SearchBy()
        {
            WriteLine("Введіть прізвище:");

            List<CreativeWork> works = [.. GraduateWorks, .. CourseWorks];
            string secondName = ReadLine();
            works = works.Where(w => w.StudentFullName.Contains(secondName)).ToList();

            foreach (var work in works)
                WriteLine(work);
        }

        private static void ShowABC()
        {
            WriteLine("Роботи по темі за абеткою:\n");
            List<CreativeWork> works = [.. GraduateWorks, .. CourseWorks];
            works = works.OrderBy(w => w.WorkTheme).ToList();

            foreach (var work in works)
                WriteLine(work.WorkTheme);
        }

        private static void ChangeWork()
        {
            int choice;
            WriteLine("Оберіть яку роботу Змінити: 1 - Курсова 2 - Дипломна.");
            try
            {
                choice = int.Parse(ReadLine());

                switch (choice)
                {
                    case 1:
                        SendChange();
                        break;
                    case 2:
                        SendChange(isCourse: false);
                        break;
                    default:
                        throw new NotImplementedException("Ви ввели не то число.");
                }
            }
            catch (FormatException)
            {
                WriteLine("Ви не ввели число.");
            }
            catch (NotImplementedException e)
            {
                WriteLine(e.Message);
            }
        }

        private static void SendChange(bool isCourse = true)
        {
            try
            {
                InfoWorksUpdate();
                View dView = new();

                CourseWork courseWork = new();
                GraduateWork graduateWork = new();

                WriteLine("Оберіть Id Для Змінення::");
                if (isCourse)
                {
                    ShowCourse();

                    courseWork = dView.ShowDataCourseWork()
                        .First(c => c.Id == int.Parse(ReadLine()));
                }
                else
                {
                    ShowGraduate();

                    graduateWork = dView.ShowDataGraduateWork()
                        .First(c => c.Id == int.Parse(ReadLine()));
                }

                WriteLine("Введіть тему роботи:");
                string workTheme = ReadLine();
                WriteLine("Введіть ПІБ студента:");
                string studentFullName = ReadLine();
                WriteLine("Введіть ПІБ Викладача:");
                string teacherFullName = ReadLine();
                WriteLine("Введіть групу:");
                string group = ReadLine();
                WriteLine("Введіть рік захисту");
                int year = int.Parse(ReadLine());
                WriteLine("Введіть Оцінку:");
                int grade = int.Parse(ReadLine());
                if (isCourse)
                {
                    WriteLine("Оберіть дисціпліну:");
                    string disciplineName = ReadLine();

                    //Добавляємо поля які користувач вказав вище для курсової роботи

                    courseWork.WorkTheme = workTheme;
                    courseWork.StudentFullName = studentFullName;
                    courseWork.TeacherFullName = teacherFullName;
                    courseWork.Group = group;
                    courseWork.Year = year;
                    courseWork.Grade = grade;
                    courseWork.DisciplineName = disciplineName;
                    if (ValidateWork(courseWork))
                        dView.Update(courseWork);
                    else throw new InvalidOperationException("Неправильна форма курсової роботи");
                }
                else
                {
                    Degree[] degrees = [Degree.Бакалавр, Degree.Спеціаліст, Degree.Магістр];
                    WriteLine("Оберіть Кваліфікацію За номером:");
                    foreach (var degree in degrees)
                        Write($"{degree}, ");
                    Degree degreeWork = degrees[int.Parse(ReadLine())];

                    //Добавляємо поля які користувач вказав вище для дипломної роботи
                    graduateWork.WorkTheme = workTheme;
                    graduateWork.StudentFullName = studentFullName;
                    graduateWork.TeacherFullName = teacherFullName;
                    graduateWork.Group = group;
                    graduateWork.Year = year;
                    graduateWork.Grade = grade;
                    graduateWork.DegreeLevel = degreeWork;
                    if (ValidateWork(graduateWork))
                        dView.Update(graduateWork);
                    else throw new InvalidOperationException("Неправильна форма курсової роботи");
                }

            }
            catch (FormatException)
            {
                WriteLine("Ви ввели букву, а не число.");
            }
            catch (InvalidOperationException e)
            {
                WriteLine(e.Message);
            }
            catch
            {
                WriteLine("Id не знайдено.");
            }
        }

        private static void MasterDegreeSearchByYear()
        {
            WriteLine("Оберіть число:");
            InfoWorksUpdate();
            int year;
            try
            {
                year = int.Parse(ReadLine());
            }
            catch (FormatException)
            {
                WriteLine("Ви ввели букву, а не число.");
                return;
            }

            GraduateWork[] work = GraduateWorks
                .Where(w => w.DegreeLevel == Degree.Магістр && w.Year == year)
                .ToArray();

            foreach (var graduateWork in work) 
                WriteLine(graduateWork);
        }

        private static void SearchByTeacher()
        {
            WriteLine("Введіть прізвище:");

            List<CreativeWork> works = [.. GraduateWorks, .. CourseWorks];
            string secondName = ReadLine();
            works = works.Where(w => w.TeacherFullName.Contains(secondName)).ToList();

            foreach (var work in works)
                WriteLine(work);
        }

        private static bool ValidateWork(CreativeWork work)
        {
            string pattern = @"^[A-Za-z\u0400-\u04FF\s]+$";
            return Regex.IsMatch(work.StudentFullName, pattern) &&
                Regex.IsMatch(work.TeacherFullName, pattern) &&
                Regex.IsMatch(work.WorkTheme, pattern) &&
                work.Year > 1970 || work.Year < 2024 &&
                work.Grade < 0 || work.Grade > 100;
        }
    }
}