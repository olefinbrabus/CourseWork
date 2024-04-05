using DataBase;
using System.Text;
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
            InputEncoding = Encoding.UTF8;

            InfoWorksUpdate();
            
            int choice;
            WriteLine("Каталог робіт");
            do
            {
                WriteLine($"\n0 - Вийти, 1 - Показати Курсові, 2 - Показати Дипломні, 3 - Добавити роботу, 4 - Оновити роботу, " +
                          $"\n5 - Пошук Роботи, 6 - Видалити роботу, 7 - Показати за абеткою, 8");
                try
                {
                    choice = int.Parse(ReadLine());
                }
                catch (FormatException e)
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
                case 0:
                    break;
                case 1:
                    ShowCourse();
                    break;
                case 2:
                    ShowGraduate();
                    break;
                case 3:
                    AddWork();
                    break;
                case 6:
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

                    dView.Add(courseWork);
                }
                else
                {
                    Degree[] degrees = [Degree.Бакалавр, Degree.Спеціаліст, Degree.Магістр];
                    WriteLine("Оберіть Кваліфікацію За номером:");
                    foreach (var degree in degrees)
                        Write($"{degree}, ");
                    Degree degreeWork = degrees[int.Parse(ReadLine())];

                    //Добавляємо поля які користувач вказав вище для дипломної роботи
                    GraduateWork gradulateWork = new GraduateWork();
                    gradulateWork.WorkTheme = workTheme;
                    gradulateWork.StudentFullName = studentFullName;
                    gradulateWork.TeacherFullName = teacherFullName;
                    gradulateWork.Group = group;
                    gradulateWork.Year = year;
                    gradulateWork.Grade = grade;
                    gradulateWork.DegreeLevel = degreeWork;

                    dView.Add(gradulateWork);
                }
            }
            catch (Exception e)
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
    }
}
