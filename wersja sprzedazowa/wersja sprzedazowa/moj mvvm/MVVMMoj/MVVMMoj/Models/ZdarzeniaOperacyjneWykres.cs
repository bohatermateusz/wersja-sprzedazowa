﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMMoj.Models
{
    public class ZdarzeniaOperacyjneWykres : INotifyPropertyChanged
    {

        private double _value;

        /// <summary>
        /// Initializes a new instance of ObservableValue class
        /// </summary>
        public ZdarzeniaOperacyjneWykres()
        { }



        /// <summary>
        /// Initializes a new instance of ObservableValue class with a given value
        /// </summary>
        /// <param name="value"></param>
        public ZdarzeniaOperacyjneWykres(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Value in he chart
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }




        #region INotifyPropertyChangedImplementation

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion



        
    }
}
