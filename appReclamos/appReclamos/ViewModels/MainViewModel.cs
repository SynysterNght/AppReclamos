using appReclamos.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace appReclamos.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public InicioViewModel Inicio { get; set; }
        public CreateViewModel Create { get; set; }
        public GetViewModel Get { get; set; }
        public ModifyViewModel Modify { get; set; }
        #endregion

        #region Contructor
        public MainViewModel()
        {
            instance = this;
            this.Inicio = new InicioViewModel();

            ///this.Create = new CreateViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }

        #endregion
    }
}

