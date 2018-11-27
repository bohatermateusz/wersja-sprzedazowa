using MVVMMoj.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMMoj.Models;

namespace MVVMMoj.Commands
{
    class ZapisDoBazyDanych : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ZdarzeniaOperacyjneViewModel viewModel { get; set; } 
        public ZapisDoBazyDanych(ZdarzeniaOperacyjneViewModel viewModel)
        {
            this.viewModel = viewModel;

        }

        /// <summary>
        /// Przycisk umożliwiający zapis do bazy danych
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Metoda zapisujaca do bazy danych
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            viewModel.Zapis();
        }
    }
}
