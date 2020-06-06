using appReclamos.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace appReclamos.ViewModels
{
    public class InicioViewModel : BaseViewModel
    {
        #region Properties
        public string IdReclamo { get; set; }
        #endregion


        #region Metodos

        public async void Crear() 
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Create = new CreateViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CreatePage());

        }
        public async void Consultar() 
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Get = new GetViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new GetPage());
        }

        #endregion


        #region Commands

        public ICommand CrearCommand
        {
            get
            {
                return new RelayCommand(Crear);
            }

        }
        public ICommand ConsultarCommand
        {
            get
            {
                return new RelayCommand(Consultar);
            }

        }

        #endregion


    }
}
