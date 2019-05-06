using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace wk.nOorm.lib.da
{
    public class cOlumna
    {
        public List<ei.cOlumna> Listar(ei.tAbla tabla, da.dAtaAccess dataAccess)
        {
            List<ei.cOlumna> _resultado = new List<ei.cOlumna>();

            using (SqlCommand _sqlCommand = new SqlCommand())
            {
                _sqlCommand.Connection = dataAccess._SqlConnection;
                _sqlCommand.CommandText = this.CrearListaConsulta(tabla);
                _sqlCommand.CommandType = CommandType.Text;

                using (SqlDataReader _sqlDataReader = _sqlCommand.ExecuteReader())
                {
                    while (_sqlDataReader.Read())
                    {
                        ei.cOlumna _columna = new ei.cOlumna();
                        _columna.nOmbre = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("COLUMN_NAME"));
                        _columna.tIpo = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("DATA_TYPE"));

                        object _objeto = _sqlDataReader.GetValue(_sqlDataReader.GetOrdinal("CHARACTER_MAXIMUM_LENGTH"));

                        if (_objeto == DBNull.Value)
                        {
                            _columna.cAracteres = 0;
                        }
                        else
                        {
                            _columna.cAracteres = Convert.ToInt32(_objeto);
                        }

                        _objeto = _sqlDataReader.GetValue(_sqlDataReader.GetOrdinal("NUMERIC_PRECISION"));

                        if (_objeto == DBNull.Value)
                        {
                            _columna.digitos = 0;
                        }
                        else
                        {
                            _columna.digitos = Convert.ToInt32(_objeto);
                        }

                        _objeto = _sqlDataReader.GetValue(_sqlDataReader.GetOrdinal("NUMERIC_SCALE"));

                        if (_objeto == DBNull.Value)
                        {
                            _columna.decimales = 0;
                        }
                        else
                        {
                            _columna.decimales = Convert.ToInt32(_objeto);
                        }

                        _objeto = _sqlDataReader.GetValue(_sqlDataReader.GetOrdinal("ORDINAL_POSITION"));

                        if (_objeto == DBNull.Value)
                        {
                            _columna.eSLlavePrimaria = false;
                        }
                        else
                        {
                            _columna.eSLlavePrimaria = true;
                        }
                        _resultado.Add(_columna);
                    }
                }
            }

            return _resultado;
        }


        private string CrearListaConsulta(ei.tAbla tabla)
        {
            StringBuilder _stringBuilder = new StringBuilder();

            _stringBuilder.Append(" SELECT ISC.COLUMN_NAME, ISC.DATA_TYPE,ISC.CHARACTER_MAXIMUM_LENGTH, ISC.NUMERIC_PRECISION , ISC.NUMERIC_SCALE ,ISK.ORDINAL_POSITION ");
            _stringBuilder.Append(" FROM INFORMATION_SCHEMA.COLUMNS ISC");
            _stringBuilder.Append(" LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE ISK");
            _stringBuilder.Append(" ON ISC.TABLE_CATALOG = ISK.TABLE_CATALOG");
            _stringBuilder.Append(" AND ISC.TABLE_SCHEMA = ISK.TABLE_SCHEMA");
            _stringBuilder.Append(" AND ISC.TABLE_NAME = ISK.TABLE_NAME");
            _stringBuilder.Append(" AND ISC.COLUMN_NAME = ISK.COLUMN_NAME");
            _stringBuilder.AppendFormat(" WHERE ISC.TABLE_CATALOG = '{0}'", tabla.bAseDatos);
            _stringBuilder.AppendFormat(" AND ISC.TABLE_SCHEMA = '{0}'", tabla.eSquema);
            _stringBuilder.AppendFormat(" AND ISC.TABLE_NAME = '{0}'", tabla.nOmbre);

            return _stringBuilder.ToString();
        }
    }
}
