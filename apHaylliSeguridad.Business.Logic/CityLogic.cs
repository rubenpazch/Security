using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apHaylliSeguridad.Business.Model;
using apHaylliSeguridad.Common;
using apHaylliSeguridad.DataAccess;

namespace apHaylliSeguridad.Business.Logic
{
    public class CityLogic :IDisposable
    {
        private LoggingHandler _loggingHandler;
        public CityLogic()
        {
            _loggingHandler = new LoggingHandler();
        }




        public bool InsertCity(City entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new CityRepository())
                {
                    bOpDoneSuccessfully = repository.Insert(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:CitysBusiness::InsertCity::Error occured.", ex);
            }
        }

        public bool UpdateCity(City entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new CityRepository())
                {
                    bOpDoneSuccessfully = repository.Update(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:CitysBusiness::UpdateCity::Error occured.", ex);
            }
        }

        public bool DeleteCityById(int empId)
        {
            try
            {
                using (var repository = new CityRepository())
                {
                    return repository.DeleteById(empId);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:CitysBusiness::DeleteCityById::Error occured.", ex);
            }
        }

        public City SelectCityById(int empId)
        {
            try
            {
                City returnedEntity;
                using (var repository = new CityRepository())
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

                throw new Exception("BusinessLogic:CityBusiness::SelectCityById::Error occured.", ex);
            }
        }

        public List<City> SelectAllCuntries()
        {
            var returnedEntities = new List<City>();

            try
            {
                using (var repository = new CityRepository())
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

                throw new Exception("BusinessLogic:CityBusiness::SelectAllCity::Error occured.", ex);
            }
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
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~CityLogic() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion




    }
}
