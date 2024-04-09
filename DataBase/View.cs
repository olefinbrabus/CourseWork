using System.Text.RegularExpressions;

namespace DataBase
{
    public class View
    {
        private Context _context = new();

        public void Add(CreativeWork work)
        {
            _context.Add(work);
            _context.SaveChanges();
        }

        public List<CourseWork> ShowDataCourseWork()
            => _context.courseWorks.Select(cw => cw).ToList();

        public List<GraduateWork> ShowDataGraduateWork()
            => _context.graduateWorks.Select(cw => cw).ToList();

        

        public void Delete(CreativeWork work)
        {
            _context.Remove(work);
            _context.SaveChanges();
        }

        public void Update(CreativeWork work)
        {
            _context.Update(work);
            _context.SaveChanges();
        }
    }
}
