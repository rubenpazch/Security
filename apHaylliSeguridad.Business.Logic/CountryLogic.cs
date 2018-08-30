using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apHaylliSeguridad.Common;
using apHaylliSeguridad.Business.Model;
using apHaylliSeguridad.DataAccess;

namespace apHaylliSeguridad.Business.Logic
{
    public class CountryLogic : IDisposable
    {
        private LoggingHandler _loggingHandler;


        public bool InsertCountry(Country entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new CountryRepository())
                {
                    bOpDoneSuccessfully = repository.Insert(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:EmployeesBusiness::InsertEmployee::Error occured.", ex);
            }
        }

        public bool UpdateCountry(Country entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new CountryRepository())
                {
                    bOpDoneSuccessfully = repository.Update(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:EmployeesBusiness::UpdateEmployee::Error occured.", ex);
            }
        }

        public bool DeleteCountryById(int empId)
        {
            try
            {
                using (var repository = new CountryRepository())
                {
                    return repository.DeleteById(empId);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:EmployeesBusiness::DeleteEmployeeById::Error occured.", ex);
            }
        }

        public Country SelectCountryById(int empId)
        {
            try
            {
                Country returnedEntity;
                using (var repository = new CountryRepository())
                {
                    returnedEntity = repository.SelectById(empId);
                    //if (returnedEntity != null)
                    //returnedEntity.NetSalary = GetNetSalary(returnedEntity.GrossSalary, returnedEntity.Age);
                }

                return returnedEntity;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:CountryBusiness::SelectCountryById::Error occured.", ex);
            }
        }

        public List<Country> SelectAllCuntries()
        {
            var returnedEntities = new List<Country>();

            try
            {
                using (var repository = new CountryRepository())
                {
                    foreach (var entity in repository.SelectAll())
                    {
                        //entity.NetSalary = GetNetSalary(entity.GrossSalary, entity.Age);
                        returnedEntities.Add(entity);
                    }
                }

                return returnedEntities;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:CountryBusiness::SelectAllCountry::Error occured.", ex);
            }
        }

        public CountryLogic()
        {
            _loggingHandler = new LoggingHandler();
        }


        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                    _loggingHandler = null;
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~CountryLogic() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.

        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
             GC.SuppressFinalize(this);
        }
        
        
        
        #endregion
    }
}
