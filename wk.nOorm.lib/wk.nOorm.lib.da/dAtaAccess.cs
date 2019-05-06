using System;
using System.Text;
using System.Data.SqlClient;

namespace wk.nOorm.lib.da
{
    public class dAtaAccess: IDisposable 
    {
        internal SqlConnection _SqlConnection;

        public dAtaAccess(ei.dBXml.cOnexion conexion)
        {
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.AppendFormat("Server = {0}; Database = {1}; User Id={2}; Password={3};", 
                                                                                                            conexion.sErvidor, 
                                                                                                            conexion.bAseDatos,
                                                                                                            conexion.uSuario,
                                                                                                            conexion.cOntrasenia);

            this._SqlConnection = new SqlConnection(_stringBuilder.ToString());
            this._SqlConnection.Open();
        }


        public dAtaAccess(string servidor, string basedatos, string usuario, string contrasenia)
        {
            //this._SqlConnection = new SqlConnection();
            //SqlConnectionStringBuilder _conectionStringBuilder = new SqlConnectionStringBuilder();
            //_conectionStringBuilder.DataSource = servidor;
            //_conectionStringBuilder.InitialCatalog = basedatos;

            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.AppendFormat("Server = {0}; Database = {1}; User Id={2}; Password={3}; Connection Timeout=600;", servidor, basedatos, usuario, contrasenia);

            this._SqlConnection = new SqlConnection(_stringBuilder.ToString());
            
            this._SqlConnection.Open();
        }

        public void Dispose()
        {
            this._SqlConnection.Close();
            this._SqlConnection.Dispose();
        }
    }
}
