using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using RegistrarApp.Views;

namespace RegistrarApp.ViewModels
{

    
    public class TermStartEndDateUpdateViewModel : BindableObject
    {
        public TermStartEndDateUpdateViewModel () 
        {
            SaveTermStartDate = new Command(OnUserSaveStartDate);
            SaveTermEndDate = new Command(OnUserSaveEndDate);
            EditThisTerm = new Command(OnUserChooseEditTerm);
        }

        public ICommand EditThisTerm { get; }
        void OnUserChooseEditTerm ()
        {
            //(new CoursesThisTermPage());
            //Somehow set the term class instance to the term ID clicked.
        }

        DateTime DefaultLocalDatePopulate = DateTime.Now.AddDays(1);
        public DateTime SetNewTermStartTime
        {
            get => DefaultLocalDatePopulate;
            set
            {
                if (value == DefaultLocalDatePopulate)
                    return;
                DefaultLocalDatePopulate = value;
                OnPropertyChanged(nameof(SetNewTermStartTime));
            }
        }
        public DateTime SetNewTermEndTime
        {
            get => DefaultLocalDatePopulate;
            set
            {
                if (value == DefaultLocalDatePopulate)
                    return;
                DefaultLocalDatePopulate = value;
                OnPropertyChanged(nameof(SetNewTermEndTime));
            }
        }
        public ICommand SaveTermStartDate { get; }
        void OnUserSaveStartDate()
        {
            //Save the date to the term in the current term object
        }
        public ICommand SaveTermEndDate { get; }
        void OnUserSaveEndDate()
        {
            //Save the date to the term in the current term object
        }

    }
}
