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
    public class ModifyViewModel : BaseViewModel
    {

        #region Services
        private ApiService apiService;
        #endregion
        #region Attributes
        private string idreclamo;
        private string respuesta;

        #endregion


        #region Properties
        public string IdReclamo { get; set; }
        public string Respuesta { get; set; }
        #endregion
        #region Constructor
        public ModifyViewModel(string id)
        {
            this.apiService = new ApiService();
            this.IdReclamo = id;

        }
        #endregion


        private async void Respond()
        {
            var data = new Support();
            var response = await this.apiService.Put<Support>(
                "https://answersupportsyn.azurewebsites.net/",
                "api/",
                "Answer/"+this.IdReclamo+ "?respuesta=" + this.Respuesta,
                data
                );
            if (response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Success",
                   "Se ha registrado la respuesta correctamente",
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



        public ICommand RespondCommand
        {
            get
            {
                return new RelayCommand(Respond);
            }

        }
    }
}
