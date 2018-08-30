using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace apHaylliSeguridad.DataAccess.Common
{
    public class DataHandler
    {

        public void AddParameterToCommand(DbCommand command, string paramName, csType csDataType, ParameterDirection direction, object value)
        {
            if (command == null)
                throw new ArgumentNullException("command", "The AddParameterToCommand Command is null.");

            try
            {
                DbParameter param = command.CreateParameter();
                param.ParameterName = paramName;
                param.DbType = ConvertCsharpDataTypeToDbType(csDataType);
                param.Value = value ?? DBNull.Value;
                param.Direction = direction;
                command.Parameters.Add(param);
            }
            catch (Exception ex)
            {
                //Bubble error to caller and encapsulate Exception object
                throw new Exception("DataHandler::AddParameterToCommand::Error occured.", ex);
            }
        }
        private DbType ConvertCsharpDataTypeToDbType(csType csDataType)
        {
            var dbType = DbType.String;
            switch (csDataType)
            {
                case csType.String:
                    dbType = DbType.String;
                    break;
                case csType.Int:
                    dbType = DbType.Int32;
                    break;
                case csType.Long:
                    dbType = DbType.Int64;
                    break;
                case csType.Double:
                    dbType = DbType.Double;
                    break;
                case csType.Decimal:
                    dbType = DbType.Decimal;
                    break;
                case csType.DateTime:
                    dbType = DbType.DateTime;
                    break;
                case csType.Boolean:
                    dbType = DbType.Boolean;
                    break;
                case csType.Short:
                    dbType = DbType.Int16;
                    break;
                case csType.Guid:
                    dbType = DbType.Guid;
                    break;
                case csType.ByteArray:
                case csType.Binary:
                    dbType = DbType.Binary;
                    break;
            }
            return dbType;
        }
    }
}
