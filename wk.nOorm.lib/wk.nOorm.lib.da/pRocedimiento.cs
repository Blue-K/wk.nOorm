using System.Data;
using System.Data.SqlClient;

namespace wk.nOorm.lib.da
{
    public class pRocedimiento
    {
        public void Crear(string consulta, da.dAtaAccess dataAccess)
        {
            using (SqlCommand _sqlCommand = new SqlCommand())
            {
                _sqlCommand.Connection = dataAccess._SqlConnection;
                _sqlCommand.CommandType = CommandType.Text;
                _sqlCommand.CommandText = consulta;
                int i = _sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
