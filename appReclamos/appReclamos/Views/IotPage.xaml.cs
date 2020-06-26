using appReclamos.Helpers;
using appReclamos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appReclamos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IotPage : ContentPage
    {
        private ApiService apiService;
        public IotPage()
        {
            InitializeComponent();
            this.apiService = new ApiService();
            ListarDataAsync();

        }

        private async void ListarDataAsync()
        {
            var response = await this.apiService.GetList<iot>(
                "https://consultardatossyniot.azurewebsites.net/",
                "api/",
                "ConsultarDatosIot"

                );


            if (response.IsSuccess)
            {

                var data = (List<iot>)response.Result;
                DatosListView.ItemsSource = data;

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   response.Message,
                   "Aceptar");
            }

        }
    }
}