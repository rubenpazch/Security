﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business.Model
{
    public class ServiceType : IDisposable
    {
        [Required(ErrorMessage="You must insert and Id for type service")]
        public int serviceTypeId { get; set; }
        [Required(ErrorMessage ="You must insert a name for the service type")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "verife you have 3 digits at least")]
        public string nameServiceType { get; set; }
        [Required(ErrorMessage = "You must insert a name for the service type")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "verife you have 3 digits at least")]
        public string descriptionServiceType { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
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
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~ServiceType() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
             GC.SuppressFinalize(this);
        }
        #endregion



        /*public ServiceType(int idServiceType, string nameServiceType)
        {
            this.idServiceType = idServiceType;
            this.nameServiceType = nameServiceType;
        }*/
    }
}
