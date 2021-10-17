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
        public Task<int> SaveTermAsync (Term term)
        {
            return _database.InsertAsync(term);
        }
        public async Task<List<Course>> GetCoursesThisTerm()
        {
            var query = _database.Table<Course>().Where(s => s.CourseName.StartsWith("S"));

            var result = await query.ToListAsync();
            return result;
            //_database.Table<Course>().Where(v => v.TermID.CompareTo(Globals.CurrentTerm.TermID));
            //return _database.QueryAsync<Course> ("select * from Course where TermID = ?", Globals.CurrentTerm.TermID);
        }
        public Task<List<Term>> GetAvailableTerms()
        {
            return _database.Table<Term>().ToListAsync();
            
            //return _database.QueryAsync<Term>("SELECT TermName from Term");
        }

    }
}
