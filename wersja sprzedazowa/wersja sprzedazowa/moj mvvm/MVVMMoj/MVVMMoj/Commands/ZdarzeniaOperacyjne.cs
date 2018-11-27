using MVVMMoj.Models;
using MVVMMoj.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMMoj.Commands
{
    class ZdarzeniaOperacyjne : ICommand
    {

        private UzytkownikViewModel viewModel;

        /// <summary>
        /// Deklaracje
        /// </summary>
        public Models.Uzytkownik Uzytkownik { get; set; }

        public ZdarzeniaOperacyjne(UzytkownikViewModel viewModel)
        {

            this.viewModel = viewModel;

        }

        public ZdarzeniaOperacyjneViewModel ZdarzeniaOperacyjneViewModel { get; private set; }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Przycisk umozliwiajacy uruchomienie nowego VW
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(viewModel.Uzytkownik.Error);
        }

        /// <summary>
        /// Meotda inicująca nowe okno
        /// </summary>
        public void Execute(object parameter)
        {
            ///<summary>
            /// wczytanie nowego VM
            ///</summary>
            ZdarzeniaOperacyjneViewModel = new ZdarzeniaOperacyjneViewModel();
            Views.ZdarzeniaOperacyjne ZdarzeniaOperacyjne = new Views.ZdarzeniaOperacyjne()
            {
                DataContext = ZdarzeniaOperacyjneViewModel
            };

            ///<summary>
            ///Konfiguracja wykresu
            /// </summary>
            ZdarzeniaOperacyjne.Wykres.Series = ZdarzeniaOperacyjneViewModel.konfiguracja_wykresu.Series;
            ZdarzeniaOperacyjne.Wykres.AxisX = ZdarzeniaOperacyjneViewModel.konfiguracja_wykresu.AxisX;
            ZdarzeniaOperacyjne.ShowDialog();
        }

        

    }
}
