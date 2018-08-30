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
    public class ServiceTypeLogic : IDisposable
    {
        private LoggingHandler _loggingHandler;
        public ServiceTypeLogic()
        {
            _loggingHandler = new LoggingHandler();
        }


        public bool InsertServiceType(ServiceType entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new ServiceTypeRepository())
                {
                    bOpDoneSuccessfully = repository.Insert(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:ServiceTypesBusiness::InsertServiceType::Error occured.", ex);
            }
        }

        public bool UpdateServiceType(ServiceType entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new ServiceTypeRepository())
                {
                    bOpDoneSuccessfully = repository.Update(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:ServiceTypesBusiness::UpdateServiceType::Error occured.", ex);
            }
        }

        public bool DeleteServiceTypeById(int empId)
        {
            try
            {
                using (var repository = new ServiceTypeRepository())
                {
                    return repository.DeleteById(empId);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:ServiceTypesBusiness::DeleteServiceTypeById::Error occured.", ex);
            }
        }

        public ServiceType SelectServiceTypeById(int empId)
        {
            try
            {
                ServiceType returnedEntity;
                using (var repository = new ServiceTypeRepository())
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

                throw new Exception("BusinessLogic:ServiceTypeBusiness::SelectServiceTypeById::Error occured.", ex);
            }
        }

        public List<ServiceType> SelectAllCuntries()
        {
            var returnedEntities = new List<ServiceType>();

            try
            {
                using (var repository = new ServiceTypeRepository())
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

                throw new Exception("BusinessLogic:ServiceTypeBusiness::SelectAllServiceType::Error occured.", ex);
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
        // ~ServiceTypeLogic() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion




    }
}
