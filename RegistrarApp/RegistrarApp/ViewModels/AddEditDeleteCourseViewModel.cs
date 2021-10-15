using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RegistrarApp.ViewModels
{
    public class AddEditDeleteCourseViewModel : BindableObject
    {
        public AddEditDeleteCourseViewModel ()
        {
            DeleteCourse = new Command(OnUserChooseDelete);
            SaveCourse = new Command(OnUserChooseSave);
        }
        string TestPopulateNoteFieldPlaceholder = "Content Loaded";
        public string TestPopulateNoteFieldDisplay
        {
            get => TestPopulateNoteFieldPlaceholder;
            set
            {
                if (value == TestPopulateNoteFieldPlaceholder)
                    return;
                TestPopulateNoteFieldPlaceholder = value;
                OnPropertyChanged(nameof(TestPopulateNoteFieldDisplay));
            }
        }

        string DeletedAddedDisplayPlaceholder = "Course Deleted/Added";
        public string DeletedAddedDisplay
        {
            get => DeletedAddedDisplayPlaceholder;
            set
            {
                if (value == DeletedAddedDisplayPlaceholder)
                    return;
                DeletedAddedDisplayPlaceholder = value;
                OnPropertyChanged(nameof(DeletedAddedDisplay));
            }
        }

        public ICommand DeleteCourse { get; }
        void OnUserChooseDelete()
        {
            DeletedAddedDisplay = "Class Deleted";
        }
        public ICommand SaveCourse { get; }
        void OnUserChooseSave()
        {
            DeletedAddedDisplay = "Class Saved";
        }

    }
}
