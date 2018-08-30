using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apHaylliSeguridad.DataAccess.Common;
using apHaylliSeguridad.Business.Model;
using apHaylliSeguridad.Common;
using System.Data.Common;
using System.Data;

namespace apHaylliSeguridad.DataAccess
{
    public class ServiceTypeRepository : IRepository<ServiceType>, IDisposable
    {

        private LoggingHandler _loggingHandler;
        private DataHandler _dataHandler;
        private ConfigurationHandler _configurationHandler;
        private DbProviderFactory _dbProviderFactory;
        private string _connectionString;
        private string _connectionProvider;
        private int _errorCode, _rowsAffected;

        public bool DeleteById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var sb = new StringBuilder();
                sb.Append("DELETE FROM [dbo].[tServiceType]");
                sb.Append("WHERE");
                sb.Append("[serviceTypeId]=@serviceTypeId;");
                sb.Append("SELECT @intErrorCode = @@ERROR;");

                var commanText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "the db connection can't be null");
                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                        {
                            throw new ArgumentNullException("dbCommand", "the db Delete command for entity [ServiceType] can't be null");
                        }
                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commanText;

                        _dataHandler.AddParameterToCommand(dbCommand, "@serviceTypeId", csType.Int, ParameterDirection.Input, id);
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", csType.Int, ParameterDirection.Output, null);

                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The Delete method for entity [ServiceType] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("ServiceTypeRepository::Delete::Error occured.", ex);
            }

        }

        public bool Insert(ServiceType entity)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY;");
                sb.Append("INSERT INTO [dbo].[tServiceType]");
                sb.Append("(");
                sb.Append("[serviceTypeId],");
                sb.Append("[nameServiceType],");
                sb.Append("[descriptionService]");
                sb.Append(")");
                sb.Append("VALUES");
                sb.Append("(");
                sb.Append("@serviceTypeId");
                sb.Append("@nameServiceType");
                sb.Append("@descriptionService");
                sb.Append(");");
                sb.Append("SELECT @intErrorCode=@ERROR;");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");
                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [ServiceType] can't be null. ");
                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        _dataHandler.AddParameterToCommand(dbCommand, "@serviceTypeId", csType.Int, ParameterDirection.Input, entity.serviceTypeId);
                        _dataHandler.AddParameterToCommand(dbCommand, "@nameServiceType", csType.String, ParameterDirection.Input, entity.nameServiceType);
                        _dataHandler.AddParameterToCommand(dbCommand, "@descriptionService", csType.Int, ParameterDirection.Input, entity.descriptionServiceType);

                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", csType.Int, ParameterDirection.Output, null);

                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());


                        if (_errorCode != 0)
                        {
                            throw new Exception("The Insert method for entity [ServiceType] reported the Database ErrorCode: " + _errorCode);
                        }

                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("ServiceTypeRepository::Insert::Error occured.", ex);
            }
        }

        public List<ServiceType> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            var returnedEntities = new List<ServiceType>();

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("SELECT ");
                sb.Append("[serviceTypeId], ");
                sb.Append("[nameServiceType], ");
                sb.Append("[descriptionService] ");
                sb.Append("FROM [dbo].[tServiceType]");
                sb.Append("ORDER BY [nameServiceType]");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db command for entity [ServiceType] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", csType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new ServiceType();
                                    entity.serviceTypeId = reader.GetInt32(0);
                                    entity.nameServiceType = reader.GetString(1);
                                    entity.descriptionServiceType = reader.GetString(2);
                                    returnedEntities.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The SelectAll method for entity [ServiceType] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return returnedEntities;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("EmployeesRepository::SelectAll::Error occured.", ex);
            }

        }

        public ServiceType SelectById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            var returnedEntities = new ServiceType();

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("SELECT ");
                sb.Append("[serviceTypeId], ");
                sb.Append("[nameServiceType], ");
                sb.Append("[descriptionService]");
                sb.Append("FROM [dbo].[tServiceType]");
                sb.Append("WHERE ");
                sb.Append("[serviceTypeId] = @serviceTypeId");
                sb.Append("ORDER BY [nameServiceType];");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db command for entity [state] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", csType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new ServiceType();
                                    entity.serviceTypeId = reader.GetInt32(0);
                                    entity.nameServiceType = reader.GetString(1);
                                    entity.descriptionServiceType  = reader.GetString(2);
                                    //returnedEntities.Add(entity);
                                    returnedEntities = entity;
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The SelectAll method for entity [State] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return returnedEntities;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("EmployeesRepository::SelectAll::Error occured.", ex);
            }

        }

        public bool Update(ServiceType entity)
        {

            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("UPDATE [dbo].[tServiceType]");
                sb.Append("SET ");
                sb.Append("[nameServiceType]  = @nameServiceType, ");
                sb.Append("[descriptionService]  = @descriptionService");
                sb.Append("WHERE ");
                sb.Append("[serviceTypeId] = @serviceTypeId; ");
                sb.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Update command for entity [Employees] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters

                        _dataHandler.AddParameterToCommand(dbCommand, "@nameServiceType", csType.String, ParameterDirection.Input, entity.nameServiceType);
                        _dataHandler.AddParameterToCommand(dbCommand, "@descriptionService", csType.String, ParameterDirection.Input, entity.descriptionServiceType);

                        //Output Parameters
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", csType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The Update method for entity [serviceType] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                //Bubble error to caller and encapsulate Exception object
                throw new Exception("CountryRepository::Update::Error occured.", ex);
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
        // ~ServiceTypeRepository() {
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
