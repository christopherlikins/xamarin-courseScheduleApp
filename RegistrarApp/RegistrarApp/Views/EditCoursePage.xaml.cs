using RegistrarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistrarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCoursePage : ContentPage
    {
        public EditCoursePage()
        {
            InitializeComponent();
            PopulateEditCourseFields();

        }
        private void PopulateEditCourseFields ()
        {
            CourseNameEntryField.Text = Globals.CurrentCourse.CourseName;
            CourseInstructorNameEntryField.Text = Globals.CurrentCourse.CourseInstructorName;
        }
        private void SaveButton_Clicked(object sender, EventArgs e)
        {

        }

        private void DeleteCourseButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}