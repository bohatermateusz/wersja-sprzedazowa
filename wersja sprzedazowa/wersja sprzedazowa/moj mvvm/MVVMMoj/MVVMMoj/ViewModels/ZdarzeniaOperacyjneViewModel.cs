using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using MVVMMoj.Commands;
using MVVMMoj.Uslugi;
using MVVMMoj.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMMoj.ViewModels
{




    class ZdarzeniaOperacyjneViewModel : INotifyPropertyChanged
    {

        //Deklaracje


        /// <summary>
        /// Deklaracja nowego modelu
        /// </summary>
        public Models.Uzytkownik Uzytkownik { get; set; }

        /// <summary>
        /// Wartosci potrzebne do stworzenia wykresu
        /// </summary>
        private ChartValues<int> _MyValues;
        public ChartValues<int> MyValues
        {
            get { return _MyValues; }

            set
            {
                _MyValues = value;
                OnPropertyChanged("MyValues");
            }

        }
        /// <summary>
        /// Wartosci potrzebne do stworzenia opisow na wykresie
        /// </summary>
        public ChartValues<string> MyLabels { get; set; }
        /// <summary>
        /// Deklaracja przycisku inicującego zapis do bazy
        /// </summary>
        public ICommand Zapisz { get; private set; }
        /// <summary>
        /// Inicjacja klasy wykresu
        /// </summary>
        public CartesianChart konfiguracja_wykresu;
        /// <summary>
        /// Stworzenie "listy/tabeli", która została pobrana na podstawie połączenia z serwerm 
        /// </summary>
        private ObservableCollection<Zdarzenia> _WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne;
        public ObservableCollection<Zdarzenia> WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne
        {
            get
            {

                return _WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne;
            }
            set
            {
                _WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne = value;
                OnPropertyChanged("WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne");
            }
        }
        /// <summary>
        /// Wlaściwości zmiennych
        /// </summary>
        public String Imie { get; set; }
        public String InformacjeOUzytkowniku { get; set; }
        /// <summary>
        /// Inicjacja klas potrzebnych do śledzenia zmiany w okienku WPF
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(params string[] nazwyWłasności)
        {
            if (PropertyChanged != null)
            {
                foreach (string nazwaWłasności in nazwyWłasności)
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
            }
        }

        
        public ZdarzeniaOperacyjneViewModel()
        {

            


            ///<summary>
            ///Wczytanie wlasciwosci przycisku
            ///</summary>
            Zapisz = new ZapisDoBazyDanych(this);
            

            _WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne = WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne;

    
            ///<summary>
            ///wczytanie z BazyDanych danych dotyczacych zdarzen operacyjnych
            ///Wczytuje z Bazy Danych za posrednictwem uslug
            ///</summary>
            
                using (WebServiceSoapClient kontekst = new WebServiceSoapClient())
                {
                    WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne = new ObservableCollection<Zdarzenia>(kontekst.OdczytZBazyWartosciZdarzen());
                }
        
       
            Zczyt();

        }

        /// <summary>
        /// Metoda tworzaca dane do wykresu na podstawie danych uzyskanych z Bazy Danych
        /// </summary>
        public void Zczyt()
        {
            MyValues = new ChartValues<int>(WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne.Select(x => x.sprzedaż.Value));
            MyLabels = new ChartValues<string>(WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne.Select(x => x.data.Value.ToShortDateString()));

            ///<summary>
            ///konfiguracja wykresu
            ///</summary>
            konfiguracja_wykresu = new CartesianChart()
            {
                Series = new SeriesCollection()
                {
                    new LineSeries
                    {
                    Title= "Wolumen Sprzedaży",
                    Values = MyValues,
                    },
                },               

                AxisX = new AxesCollection
                {
                    new Axis
                    {
                        Title ="Daty",
                        Labels = MyLabels,
                    }
                },
        
            };
        }

        /// <summary>
        /// Zapis do Bazy Danych
        /// </summary>
        public void Zapis()
        {
          
                using (WebServiceSoapClient kontekst = new WebServiceSoapClient())
                {
                    kontekst.ZapisDoBazy(WyciagnieteDaneZBazyDanychZdarzeniaOperacyjne.ToArray());
                }
        
        }
    }
}
