using MVVMMoj.Models;
using MVVMMoj.ViewModels;
using MVVMMoj.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMMoj.Commands
{
    class CustomerUpdateCommand : ICommand
    {
        private UzytkownikViewModel viewModel;

        /// <summary>
        /// Odwołanie do ZdarzeniaViewModel
        /// </summary>
        private ZdarzeniaViewModel ZdarzeniaViewModel;
    
    
        /// <summary>
        /// Deklaracje
        /// </summary>
        public Models.Uzytkownik Uzytkownik { get; set; }

        public CustomerUpdateCommand(UzytkownikViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        /// <summary>
        /// Metoda przekazujaca informacje do następnego okna (To okno jest furtką do następnych ulepszen aplikacji - narazie nic nie przekazuje oprócz informacji o użytkowniku)
        /// </summary>
        public void Execute(object parameter)
        {
            NoweOkno Zdarzenia = new NoweOkno();
            Zdarzenia.DataContext = ZdarzeniaViewModel;
            Zdarzenia.ShowDialog();
        }



        /// <summary>
        /// Metoda sprawdzajaca czy przycisk jest "dostepny"
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(viewModel.Uzytkownik.Error);
        }

        public event EventHandler CanExecuteChanged;
    }
}
