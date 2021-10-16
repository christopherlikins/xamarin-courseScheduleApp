using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using RegistrarApp.Models;

namespace RegistrarApp.Services
{
    public static class CourseService
    {
        
        public static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db == null)
            {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "RegistrarAppData.db");
            var db = new SQLiteAsyncConnection(databasePath);
                await db.CreateTableAsync<Term>();
                await db.CreateTableAsync<Course>();
            }
            return;
        }
        public static async Task AddTerm(int termId, string termName, DateTime termStart, DateTime termEnd)
        {
            await Init();
            var term = new Term
            {
                TermID = termId,
                TermName = termName,
                TermStart = termStart,
                TermEnd = termEnd
            };
            await db.InsertAsync(term);
        }
        public static async Task DeleteTerm(int id)
        {
            await Init();
            await db.DeleteAsync<Term>(id);
        }

        public static async Task AddCourse(int courseId, int termId, string courseName, string courseStatus, DateTime courseStart, bool courseStartToday, DateTime courseEnd, bool courseEndToday, string courseInstructorName, string courseInstructorPhone, string courseInstructorEmail, string performanceAssessmentName, DateTime performanceAssessmentStart, bool paStartToday, DateTime performanceAssessmentEnd, bool paEndToday, string objectiveAssessmentName, DateTime objectiveAssessmentStart, bool oaStartToday, DateTime objectiveAssessmentEnd, bool oaEndToday, string courseNotes)
        {
            await Init();
            var course = new Course
            {
                CourseID = courseId,
                TermID = termId,
                CourseName = courseName,
                CourseStatus = courseStatus,
                CourseStart = courseStart,
                CourseStartToday = courseStartToday,
                CourseEnd = courseEnd,
                CourseEndToday = courseEndToday,
                CourseInstructorName = courseInstructorName,
                CourseInstructorPhone = courseInstructorPhone,
                CourseInstructorEmail = courseInstructorEmail,
                PerformanceAssessmentName = performanceAssessmentName,
                PerformanceAssessmentStart = performanceAssessmentStart,
                PaStartToday = paStartToday,
                PerformanceAssessmentEnd = performanceAssessmentEnd,
                PaEndToday = paEndToday,
                ObjectiveAssessmentName = objectiveAssessmentName,
                ObjectiveAssessmentStart = objectiveAssessmentStart,
                OaStartToday = oaStartToday,
                ObjectiveAssessmentEnd = objectiveAssessmentEnd,
                OaEndToday = oaEndToday,
                CourseNotes = courseNotes
            };
            await db.InsertAsync(course);
        }
        public static async Task DeleteCourse(int id)
        {
            await Init();
            await db.DeleteAsync<Course>(id);
        }
        public static async Task<IEnumerable<Term>> GetTerm()
        {
            await Init();
            var term = await db.Table<Term>().ToListAsync();
            return term;
        }
        public static async Task<IEnumerable<Course>> GetCourse()
        {
            await Init();
            var course = await db.Table<Course>().ToListAsync();
            return course;
        }

    }
}
