namespace DataBase
{
    public enum Degree // Перерахування кваліфікацій
    {
        Бакалавр,
        Спеціаліст,
        Магістр
    }

    public class CreativeWork // Базовий клас роботи
    {
        public int Id { get; set; } // ідентифікатор роботи

        public string WorkTheme { get; set; } // Тема роботи

        public string StudentFullName { get; set; } // Повне ім'я студента

        public string TeacherFullName { get; set; } // Повне ім'я викладача

        public string Group  { get; set; } // Група студента

        public int Year { get; set; } // Рік захисту

        public int Grade { get; set; } // Оцінка

        public override string ToString() // Перевизначений метод для показу усіх атрібутів роботи
            => $"Id - {Id}, Тема - {WorkTheme}, ПІБ студента - {StudentFullName}, ПІБ викладача - {TeacherFullName}, Група - {Group}, Рік - {Year}, Оцінка - {Grade}";
    }

    public class CourseWork : CreativeWork // Наслідуваний клас курсової роботи
    {
        public string DisciplineName { get; set; } // Базовий клас роботи

        public override string ToString() // Перевизначений метод для показу усіх атрібутів курсової роботи
            => "Курсова робота: " + base.ToString() + $", Дисциплина - {DisciplineName}";
    }

    public class GraduateWork : CreativeWork // Наслідуваний клас дипломної роботи
    {
        public Degree DegreeLevel { get; set; } // Кваліфікація

        public override string ToString() // Перевизначений метод для показу усіх атрібутів дипломної роботи
            => "Дипломна робота: " + base.ToString() + $", Рівень - {DegreeLevel}";
    }
}