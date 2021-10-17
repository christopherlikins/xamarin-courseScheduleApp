using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace RegistrarApp.Models
{
    public class Database
    {
        public readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Term>();
            _database.CreateTableAsync<Course>();            
        }
        public Task<List<Term>> GetTermsAsync()
        {
            return _database.Table<Term>().ToListAsync();
        }
        public Task<List<Course>> GetCoursesAsync()
        {
            return _database.Table<Course>().ToListAsync();
        }
        public Task<int> SaveCourseAsync(Course course)
        {
            return _database.InsertAsync(course);
        }
        public Task<int> DeleteCourseAsync()
        {
            return _database.Table<Course>().DeleteAsync(v => v.CourseID.Equals(Globals.CurrentCourse.CourseID));
        }
        public Task<int> SaveTermAsync (Term term)
        {
            return _database.InsertAsync(term);
        }
        public Task<int> DeleteTermAsync()
        {
            return _database.Table<Term>().DeleteAsync(v => v.TermID.Equals(Globals.CurrentTerm.TermID));
        }
        public async Task<List<Course>> GetCoursesThisTerm()
        {
            //var query = _database.Table<Course>().Where(s => s.CourseName.StartsWith("S"));
            var query = _database.Table<Course>().Where(s => s.TermID.Equals(Globals.CurrentTerm.TermID));
            var result = await query.ToListAsync();
            return result;
        }
        public async Task<int> UpdateTermAsync (Term term)
        {
            return await _database.UpdateAsync(term);
        }
        public async Task<int> UpdateCourseAsync (Course course)
        {
            return await _database.UpdateAsync(course);
        }
        public Task<List<Term>> GetAvailableTerms()
        {
            return _database.Table<Term>().ToListAsync();
        }

    }
}
