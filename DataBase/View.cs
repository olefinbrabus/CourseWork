using System.Text.RegularExpressions;

namespace DataBase
{
    public class View  // Інтерфейс для доступа к базі даних
    {
        private readonly Context _context = new();  // Доступ до бази даних

        public void Add(CreativeWork work)  // Добавити роботу
        {
            _context.Add(work);
            _context.SaveChanges();
        }

        public List<CourseWork> ShowDataCourseWork()
            => _context.courseWorks.Select(cw => cw).ToList();  // Данні про курсові роботи

        public List<GraduateWork> ShowDataGraduateWork()
            => _context.graduateWorks.Select(cw => cw).ToList();  // Данні про дипломні роботи

        public void Delete(CreativeWork work)  // Видалити роботу
        {
            _context.Remove(work);
            _context.SaveChanges();
        }

        public void Update(CreativeWork work)  //  Змінити роботу
        {
            _context.Update(work);
            _context.SaveChanges();
        }
    }
}
