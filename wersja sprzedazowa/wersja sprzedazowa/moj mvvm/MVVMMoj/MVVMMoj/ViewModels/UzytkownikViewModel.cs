using MVVMMoj.Commands;
using MVVMMoj.Uslugi;
using MVVMMoj.Views;
using MVVMMoj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Wpf;

namespace MVVMMoj.ViewModels
{
    class UzytkownikViewModel
    {
        //Deklaracje
        /// <summary>
        /// Deklaracja tablicy(Listy) w której będą znajdować się dane wyciągnięte z Bazy Danych
        /// </summary>
        List<Uslugi.Uzytkownik> WyciagnieteDaneZBazyDanych;
        
        ///<summary>
        /// Deklaracja Przycisków
        /// </summary>  
        public ICommand UpdateCommand { get; private set; }
        public ICommand ZdarzeniaOperacyjne { get; private set; }

        
        /// <summary>
        /// Deklaracje
        /// </summary>
        public Models.Uzytkownik Uzytkownik { get; set; }

        public UzytkownikViewModel()
        {



            ///<summary>
            ///Wczytuje Model Danych Uzytkownik
            /// </summary>

            Uzytkownik = new Models.Uzytkownik();

            ///<summary>
            /// Wczytuje z Bazy Danych za posrednictwem Uslug
            ///</summary>

            using (WebServiceSoapClient kontekst = new WebServiceSoapClient())
            { 
            WyciagnieteDaneZBazyDanych = new List<Uslugi.Uzytkownik>(kontekst.OdczytZBazy());
            }

            ///<summary>
            /// Wyciąganie wynikow, ktore nas interesuja
            /// </summary>
            Uzytkownik.InformacjeOUzytkowniku = WyciagnieteDaneZBazyDanych.Select(x => "Dane o uzytkowniku: " + Environment.NewLine + x.Imie + " " + x.Nazwisko + Environment.NewLine + "Login: " + x.Login + Environment.NewLine + "Jednostka: " + x.Jednostka).First().ToString();
            Uzytkownik.Imie = WyciagnieteDaneZBazyDanych.Select(x => x.Imie).First().ToString();

            ///<summary>
            /// Wczytanie wlasciwosci przycisku 
            /// </summary>                           
            UpdateCommand = new CustomerUpdateCommand(this);
            ZdarzeniaOperacyjne = new Commands.ZdarzeniaOperacyjne(this);




        }



  

    }
}