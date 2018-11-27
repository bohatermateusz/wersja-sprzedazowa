using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMMoj.Uslugi;
using System.Windows;

namespace MVVMMoj.Models
{
    class Uzytkownik  : INotifyPropertyChanged, IDataErrorInfo
    {
 
        public Uzytkownik()
        { }

        /// <summary>
        /// Model ze zmiennymi potrzebnymi przy kompilacji
        /// </summary>
        public string imie;
        public String Imie
        {
            get
            {
                return imie;
            }
            set
            {
                imie = value;
                OnPropertyChanged("Imie");
            }
        }


        public String InformacjeOUzytkowniku { get; set; }

        
        public string Error
        {
            get;
            private set;
        }

        public string this[string columnName] => throw new NotImplementedException();
               
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


    }
}
