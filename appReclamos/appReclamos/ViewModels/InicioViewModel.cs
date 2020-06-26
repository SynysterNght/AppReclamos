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
            mainViewModel.Get = new GetViewModel(IdReclamo);

            await Application.Current.MainPage.Navigation.PushAsync(new GetPage(this.IdReclamo));
        }

        public async void IoT()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Iot = new IotViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new IotPage());
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
        public ICommand IoTCommad
        {
            get
            {
                return new RelayCommand(IoT);
            }

        }
        #endregion


    }
}
