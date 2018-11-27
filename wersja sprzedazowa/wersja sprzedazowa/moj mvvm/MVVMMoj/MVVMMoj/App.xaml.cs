using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MVVMMoj
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Rejestracja zdarzenia
        /// </summary>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }


        /// <summary>
        /// Raportwanie zdarzenia
        /// </summary>
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
            ReportUnhandledException(e.ExceptionObject as Exception);
        }

        void ReportUnhandledException(Exception exception)
        {

        }
        /// <summary>
        /// Akcja, w przypadku wystąpienia błędu
        /// </summary>
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            var message = e.Exception.Message;
            MessageBox.Show(message);
        }
    }
}
