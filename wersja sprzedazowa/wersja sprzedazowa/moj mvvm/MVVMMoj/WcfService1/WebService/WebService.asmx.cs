using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WcfService1.WebService
{
    /// <summary>
    /// Opis podsumowujący dla WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        ///<summary>
        ///Listy do przechowywania Danych pozyskanych z bazy SQL
        ///</summary>
        List<Uzytkownik> UzytkownikAA = new List<Uzytkownik>();
        List<Zdarzenia> ZdarzeniaOperacyjne = new List<Zdarzenia>();

        ///<summary>
        ///Odczyt z tablicy dotyczącej uzytkownika
        ///</summary>
        [WebMethod]
        public List<Uzytkownik> OdczytZBazy()
        {

            using (creatorEntities2 kontekst = new creatorEntities2())
            {

                return UzytkownikAA = kontekst.Uzytkownik.ToList();

            }

        }

        /// <summary>
        /// Odczyt z tablicy dotyczacej wartosci zdarzen
        /// </summary>
        /// <returns>
        /// Zwraca Liste
        /// </returns>
        [WebMethod]
        public List<Zdarzenia> OdczytZBazyWartosciZdarzen()
        {

            using (creatorEntities2 kontekst = new creatorEntities2())
            {
                
                return ZdarzeniaOperacyjne = kontekst.Zdarzenia.ToList();

            }

        }
        /// <summary>
        /// Zapis do Bazy danych
        /// </summary>
        [WebMethod]
        public string ZapisDoBazy(List<Zdarzenia> listaZeZmienionymiZdarzeniami)
        {

            using (creatorEntities2 kontekst = new creatorEntities2())
            {

                ///<summary>
                ///Sprawdzanie ile w liscie jest pozycji po to, by dodac nowe "rekordy"
                ///</summary>
                int a = kontekst.Zdarzenia.ToList().Count();

                foreach (var con in listaZeZmienionymiZdarzeniami)
                 {
                    ///<summary>
                    ///Zmienianie elementów
                    ///</summary>
                    foreach (var value in kontekst.Zdarzenia.ToList())
                     {
                         if (value.id == con.id)
                         {
                            value.id = con.id;
                            value.data = con.data;
                            value.nazwa = con.nazwa;
                            value.opis = con.opis;
                            value.sprzedaż = con.sprzedaż;
                         }

                     }


                    ///<summary>
                    /// Dodawanie nowych elementów
                    ///</summary>
                    if (con.id >= a)
                    {
                        kontekst.Zdarzenia.Add(new Zdarzenia { id=con.id, data=con.data, nazwa=con.nazwa, opis=con.opis, sprzedaż = con.sprzedaż });
                    }

                }

                kontekst.SaveChanges();

            }

            return "Sukces";

        }
    }
}
