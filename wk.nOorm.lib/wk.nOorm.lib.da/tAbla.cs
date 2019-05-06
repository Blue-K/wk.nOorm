using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace wk.nOorm.lib.da
{
    public class tAbla
    {
        public List<ei.tAbla> Listar(da.dAtaAccess dataAccess)
        {
            List<ei.tAbla> _resultado = new List<ei.tAbla>();

            StringBuilder _consulta = new StringBuilder();
            _consulta.AppendLine(" SELECT TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME ");
            _consulta.AppendLine(" FROM INFORMATION_SCHEMA.TABLES ");
            _consulta.AppendLine(" WHERE TABLE_NAME != 'sysdiagrams' ");
            _consulta.AppendLine(" ORDER BY TABLE_SCHEMA; ");

            using (SqlCommand _sqlCommand = new SqlCommand())
            {
                _sqlCommand.Connection = dataAccess._SqlConnection;
                _sqlCommand.CommandText = _consulta.ToString();
                _sqlCommand.CommandType = CommandType.Text;

                using (SqlDataReader _sqlDataReader = _sqlCommand.ExecuteReader())
                {
                    while (_sqlDataReader.Read())
                    {
                        ei.tAbla _tabla = new ei.tAbla();
                        _tabla.bAseDatos = _sqlDataReader.GetString(0);
                        _tabla.eSquema = _sqlDataReader.GetString(1);
                        _tabla.nOmbre = _sqlDataReader.GetString(2);

                        _resultado.Add(_tabla);
                    }
                }
            }

            return _resultado;
        }
    }
}
