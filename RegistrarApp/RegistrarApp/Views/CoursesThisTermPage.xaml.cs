﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistrarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesThisTermPage : ContentPage
    {
        public CoursesThisTermPage()
        {
            InitializeComponent();
        }

        private async void AddCourseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseListPage());
            //onclick assign the courseid to populate the edit course page.
        }

        private async void TestCourseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCoursePage());
        }
    }
}