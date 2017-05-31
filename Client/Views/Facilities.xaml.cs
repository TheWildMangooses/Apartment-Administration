using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Client.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Facilities : Page
    {
        public Facilities()
        {
            this.InitializeComponent();
        }
        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void LogOut_GotFocus(object sender, RoutedEventArgs e)
        {
            App.NavService.NavigateTo(typeof(Login), null);
        }

        private void Apartment_GotFocus(object sender, RoutedEventArgs e)
        {
            App.NavService.NavigateTo(typeof(ApartmentView), null);
        }

        private void GeneralOverview_GotFocus(object sender, RoutedEventArgs e)
        {
            App.NavService.NavigateTo(typeof(UserView), null);
        }

        private void CoResidents_GotFocus(object sender, RoutedEventArgs e)
        {
            App.NavService.NavigateTo(typeof(ResidentsView), null);
        }
    }
}
