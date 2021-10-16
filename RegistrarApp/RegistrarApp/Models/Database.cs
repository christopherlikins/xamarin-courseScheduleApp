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
    }
}
