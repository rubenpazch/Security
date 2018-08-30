using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apHaylliSeguridad.DataAccess.Common;
using apHaylliSeguridad.Business.Model;
using apHaylliSeguridad.Common;
using System.Data;
using System.Data.Common;

namespace apHaylliSeguridad.DataAccess
{
    public class StateRepository : IRepository<State>, IDisposable
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
                sb.Append("DELETE FROM [dbo].[tState]");
                sb.Append("WHERE");
                sb.Append("[stateId]=@stateId;");
                sb.Append("SELECT @intErrorCode = @@ERROR;");

                var commanText = sb.ToString();
                sb.Clear();

                using (var dbConnection= _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection","the db connection can't be null");
                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                        {
                            throw new ArgumentNullException("dbCommand","the db Delete command for entity [State] can't be null");
                        }
                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commanText;

                        _dataHandler.AddParameterToCommand(dbCommand, "@stateId",csType.Int,ParameterDirection.Input,id);
                        _dataHandler.AddParameterToCommand(dbCommand, "@intErrorCode", csType.Int, ParameterDirection.Output, null);

                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("The Delete method for entity [state] reported the Database ErrorCode: " + _errorCode);
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
                throw new Exception("StateRepository::Delete::Error occured.", ex);
            }

            //throw new NotImplementedException();
        }

        public bool Insert(State entity)
        {

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY;");
                sb.Append("INSERT INTO [dbo].[tState]");
                sb.Append("(");
                sb.Append("[stateId],");
                sb.Append("[nameState],");
                sb.Append("[countryId]");
                sb.Append(")");
                sb.Append("VALUES");
                sb.Append("(");
                sb.Append("@stateId");
                sb.Append("@nameState");
                sb.Append("@countryId");
                sb.Append(");");
                sb.Append("SELECT @intErrorCode=@ERROR;");

                var commandText = sb.ToString();
                sb.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");
                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand= _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [State] can't be null. ");
                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        _dataHandler.AddParameterToCommand(dbCommand, "@stateId",csType.Int,ParameterDirection.Input,entity.StateId);
                        _dataHandler.AddParameterToCommand(dbCommand, "@nameState",csType.String,ParameterDirection.Input,entity.nameState);
                        _dataHandler.AddParameterToCommand(dbCommand, "@countryId", csType.Int, ParameterDirection.Input, entity.CountryID);

                        _dataHandler.AddParameterToCommand(dbCommand,"@intErrorCode",csType.Int,ParameterDirection.Output,null);

                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());


                        if (_errorCode != 0)
                        {
                            throw new Exception("The Insert method for entity [state] reported the Database ErrorCode: " + _errorCode);
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
                throw new Exception("StateRepository::Insert::Error occured.", ex);
            }

            //throw new NotImplementedException();
        }

        public List<State> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            var returnedEntities = new List<State>();

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("SELECT ");
                sb.Append("[stateId], ");
                sb.Append("[nameState], ");
                sb.Append("[countryId]");
                sb.Append("FROM [dbo].[tState]");
                sb.Append("ORDER BY [nameState]");
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
                                    var entity = new State();
                                    entity.StateId = reader.GetInt32(0);
                                    entity.nameState = reader.GetString(1);
                                    entity.CountryID  = reader.GetInt32(2);
                                    returnedEntities.Add(entity);
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

        public State SelectById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            var returnedEntities = new State();

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("SELECT ");
                sb.Append("[stateId], ");
                sb.Append("[nameState], ");
                sb.Append("[countryId]");
                sb.Append("FROM [dbo].[tState]");
                sb.Append("WHERE ");
                sb.Append("[stateId] = @stateId");
                sb.Append("ORDER BY [nameState];");
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
                                    var entity = new State();
                                    entity.StateId = reader.GetInt32(0);
                                    entity.nameState = reader.GetString(1);
                                    entity.CountryID = reader.GetInt32(2);
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

        public bool Update(State entity)
        {

            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var sb = new StringBuilder();
                sb.Append("SET DATEFORMAT DMY; ");
                sb.Append("UPDATE [dbo].[tState]");
                sb.Append("SET ");
                sb.Append("[nameState]  = @nameState, ");
                sb.Append("[countryId]  = @countryId ");
                sb.Append("WHERE ");
                sb.Append("[stateId] = @stateId; ");
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
                        
                        _dataHandler.AddParameterToCommand(dbCommand, "@nameState", csType.String, ParameterDirection.Input, entity.nameState);
                        _dataHandler.AddParameterToCommand(dbCommand, "@stateId", csType.Int, ParameterDirection.Input, entity.StateId);
                        _dataHandler.AddParameterToCommand(dbCommand, "@countryId", csType.Int, ParameterDirection.Input, entity.CountryID);

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
                            throw new Exception("The Update method for entity [state] reported the Database ErrorCode: " + _errorCode);
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

        public StateRepository()
        {
            //Repository Initializations
            _configurationHandler = new ConfigurationHandler();
            _loggingHandler = new LoggingHandler();
            _dataHandler = new DataHandler();
            _connectionString = _configurationHandler.ConnectionString;
            _connectionProvider = _configurationHandler.ConnectionProvider;
            _dbProviderFactory = DbProviderFactories.GetFactory(_connectionProvider);
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
                    _configurationHandler = null;
                    _loggingHandler = null;
                    _dataHandler = null;
                    _dbProviderFactory = null;

                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~StateRepository() {
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
