using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UslugiSieciowe.Domain
{
    public class Zdarzenia2
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public string opis { get; set; }
        public Nullable<float> strata { get; set; }
    }
}