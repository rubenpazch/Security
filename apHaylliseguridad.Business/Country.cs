using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace apHaylliSeguridad.Business.Model
{
    public class Country : IDisposable
    {
        #region Class Property Declarations
        [Required(ErrorMessage = "You must enter an country ID.")]
        public  int CountryID { get; set; }

        [Required(ErrorMessage = "You must enter an country name.")]
        public string nameCountry { get; set; }

        [Required(ErrorMessage = "You must enter an country short name.")]
        [StringLength(3,MinimumLength =1,ErrorMessage = "verife you have 3 digits")]
        public string shortNameCountry { get; set; }


        public List<State> states { get; set; }

       /* public Country(int countryID, string nameCountry, string shortNameCountry, List<State> states)
        {
            CountryID = countryID;
            this.nameCountry = nameCountry;
            this.shortNameCountry = shortNameCountry;
            this.states = states;
        }
        public Country(int countryID, string nameCountry, string shortNameCountry)
        {
            CountryID = countryID;
            this.nameCountry = nameCountry;
            this.shortNameCountry = shortNameCountry;
        }*/
        /*public Country() { }/*

        #endregion

        #region IDisposable Support
       // private bool disposedValue = false; // Para detectar llamadas redundantes

     /*   protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }*/

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~Country() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
           // Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}
