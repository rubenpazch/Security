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
    public class StateLogic : IDisposable
    {
        private LoggingHandler _loggingHandler;

        public bool InsertState(State entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new StateRepository())
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


        public bool UpdateState(State entity)
        {
            try
            {
                bool bOpDoneSuccessfully;
                using (var repository = new StateRepository())
                {
                    bOpDoneSuccessfully = repository.Update(entity);
                }

                return bOpDoneSuccessfully;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:StatesBusiness::UpdateState::Error occured.", ex);
            }
        }

        public bool DeleteStateById(int empId)
        {
            try
            {
                using (var repository = new StateRepository())
                {
                    return repository.DeleteById(empId);
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                throw new Exception("BusinessLogic:StatesBusiness::DeleteStateById::Error occured.", ex);
            }
        }

        public State SelectStateById(int empId)
        {
            try
            {
                State returnedEntity;
                using (var repository = new StateRepository())
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

                throw new Exception("BusinessLogic:StateBusiness::SelectStateById::Error occured.", ex);
            }
        }

        public List<State> SelectAllCuntries()
        {
            var returnedEntities = new List<State>();

            try
            {
                using (var repository = new StateRepository())
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

                throw new Exception("BusinessLogic:StateBusiness::SelectAllState::Error occured.", ex);
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
                    _loggingHandler = null;
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }
        
        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~StateLogic() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            //Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
             GC.SuppressFinalize(this);
        }
        #endregion


    }
}
