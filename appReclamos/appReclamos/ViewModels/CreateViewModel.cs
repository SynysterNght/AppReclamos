

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
        public string IdReclamo { get; set; }
        public string IdCliente { get; set; }
        public string IdEmpleado { get; set; }
        public string IdOrden { get; set; }
        public string Tipo { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }



        #endregion

        #region Constructor
        public CreateViewModel()
        {
            this.apiService = new ApiService();
            
        }
        #endregion

        #region Metodos

        /*private async Task<bool> CreateSupport(Support data)
        {
            var res = await this.apiService.Post<Support>(
                "https://createsupportcmsyn.azurewebsites.net/",
                "api/",
                "FCreateSupport",
                data
                );
            return res;
        }*/

        private async void CreateAsync() {
            if (string.IsNullOrEmpty(this.IdReclamo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca Id Reclamo",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.IdCliente))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca Id Cliente",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.IdEmpleado))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca Id Empleado",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.IdOrden))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Introduzca numero de Orden",
                    "Aceptar");
                return;
            }

            var data = new Support
            {
                Id=this.IdReclamo,
                ClientId=this.IdCliente,
                EmployeeId=this.IdEmpleado,
                OrderId=this.IdOrden,
                Type=this.Tipo,
                Subject=this.Asunto,
                Description=this.Descripcion


            };

            var response = await this.apiService.Post(
                "https://createsupportcmsyn.azurewebsites.net/",
                "api/",
                "FCreateSupport",
                data
                );
            if(response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Success",
                   "Se ha registrado correctamente",
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
