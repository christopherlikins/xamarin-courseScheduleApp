﻿using RegistrarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistrarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTermPage : ContentPage
    {
        public EditTermPage()
        {
            InitializeComponent();
            PopulateEditTermFrom();
        }
        private void PopulateEditTermFrom()
        {
            TermNameEntryField.Text = Globals.CurrentTerm.TermName;
            TermStartDatePicker.Date = Globals.CurrentTerm.TermStart;
            TermEndDatePicker.Date = Globals.CurrentTerm.TermEnd;
        }

        private async void EditTermCoursesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesThisTermPage());
        }

        private async void SaveTermButton_Clicked(object sender, EventArgs e)
        {
            SavedDeletedTermLabel.Text = "Term Updated.";
            Term term = new Term()
            {
                TermID = Globals.CurrentTerm.TermID,
                TermName = TermNameEntryField.Text,
                TermStart = TermStartDatePicker.Date,
                TermEnd = TermEndDatePicker.Date

            };
            await App.Database.UpdateTermAsync(term);
        }

        private async void DeleteTermButton_Clicked(object sender, EventArgs e)
        {
            SavedDeletedTermLabel.Text = "Term Deleted. Go back and refresh the list.";
            TermNameEntryField.Text = string.Empty;
            await App.Database.DeleteTermAsync();
        }
    }
}