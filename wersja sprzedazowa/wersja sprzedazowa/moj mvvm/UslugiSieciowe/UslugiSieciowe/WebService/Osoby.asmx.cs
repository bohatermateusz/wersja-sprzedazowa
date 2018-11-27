using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UslugiSieciowe;
using UslugiSieciowe.Domain;


namespace OsobyApp.WebService
{
    /// <summary>
    /// Opis podsumowujący dla Osoby
    /// </summary>
    [WebService(Namespace = "http://OsobyApp/WebService/Osoby/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class Osoby : System.Web.Services.WebService
    {

        


        [WebMethod]
        public string HelloWorld()
        {
            return "Witaj świecie";
        }


        [WebMethod]
        public List<Osoba> ListaOsob(int ilosc)
        {
            List<Osoba> lista = new List<Osoba>();
            for (int i = 1; i <= ilosc; i++)
            {
                lista.Add(new Osoba
                {
                    OsobaId = i,
                    Imie = "WanagaWanga" + i,
                    Nazwisko = "Nazwisko" + i
                });
            }
            return lista;
        }

        [WebMethod]
        public string ZczytajZBazyDanych(List<Zdarzenia> lista_poprawiona)
        {
            List<Zdarzenia> zdarzenia = new List<Zdarzenia>();

            //Zapełnianie Listy
            using (creatorEntities context = new creatorEntities())
            {

            //creatorModel

            //zdarzeniAA = context.Zdarzenia.ToList<Zdarzenia>();



                        
            }




            return "Ok";
        }


        [WebMethod]
        public void ZapiszDoBazyDanych(List<Zdarzenia> zdarzeniaAA)
        {

            List<Zdarzenia> zdarzeniAA = new List<Zdarzenia>();

          //  using (creatorEntities context = new creatorEntities())
          //  {


            /*
            foreach (var con in zdarzeniAA)
            {
                foreach (var value in context.Zdarzenia.ToList())
                {
                    if (value.id == con.id)
                    {
                        value.strata = con.strata;
                    }
                }
            }

             */

            //context.SaveChanges();


            //}
            
        
        }



    }
}
