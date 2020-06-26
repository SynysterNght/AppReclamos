using appReclamos.Helpers;
using appReclamos.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace appReclamos.ViewModels
{
    public class IotViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string mensajeiot;
        private string temperatura;
        private string humedad;

        #endregion


        #region Properties
        public string MensajeIot { get; set; }
        public string Temperatura { get; set; }
        public string Humedad { get; set; }
        #endregion

        #region Constructor
        public IotViewModel()
        {
            this.apiService = new ApiService();

        }
        #endregion

        #region Metodos
        private async void SendMessageAsync()
        {
            if (string.IsNullOrEmpty(this.MensajeIot))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca Mensaje",
                    "Aceptar");
                return;
            }

            
            var data = new mensajesyn
            {
                mensajeiot= this.MensajeIot
            };


            var response = await this.apiService.Post(
                "https://sendmessageiotsyn.azurewebsites.net/",
                "api/",
                "SendMessage",
                data
                );
            if (response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Success",
                   "Se ha Enviado el mensaje correctamente",
                   "Aceptar");

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Se produjo un error",
                   "Aceptar");
            }
        }
        #endregion


        #region Commands
        public ICommand SendCommand
        {
            get
            {
                return new RelayCommand(SendMessageAsync);
            }

        }





        #endregion


    }
}
