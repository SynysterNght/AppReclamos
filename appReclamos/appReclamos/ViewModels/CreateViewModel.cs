

namespace appReclamos.ViewModels
{
    using appReclamos.Helpers;
    using appReclamos.Models;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CreateViewModel : BaseViewModel
    {

        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string idreclamo;
        private string idcliente;
        private string idempleado;
        private string idorden;
        private string tipo;
        private string asunto;
        private string descripcion;
       
        #endregion

        #region Properties
       

        
        #endregion

        #region Constructor
        public CreateViewModel()
        {
            this.apiService = new ApiService();
            
        }
        #endregion

        #region Metodos

        private async Task<bool> CreateSupport(Support data)
        {
            var res = await this.apiService.Post<Support>(
                "https://createsupportcmsyn.azurewebsites.net/",
                "api/",
                "FCreateSupport",
                data
                );
            return res;
        }

        private async void CreateAsync() {
            if (string.IsNullOrEmpty(this.idreclamo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca Id Reclamo",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.idcliente))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca Id Cliente",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.idempleado))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca Id Empleado",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.idorden))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca numero de Orden",
                    "Aceptar");
                return;
            }
        }
        #endregion

        #region Commands
        public ICommand CreateCommand
        { 
            get
            {
                return new RelayCommand(CreateAsync);
            }
        
        }

        



        #endregion

    }
}
