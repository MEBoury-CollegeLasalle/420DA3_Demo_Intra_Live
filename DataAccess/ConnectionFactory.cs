using Microsoft.Data.SqlClient;
using System.Data;

namespace _420DA3_Demo_Intra_Live.DataAccess;
public class ConnectionFactory {

    private static SqlConnection? CONNECTION;

    public static SqlConnection GetConnection() {
        CONNECTION ??= new SqlConnection("Server=.\\SQL2022DEV;TrustServerCertificate=true;Integrated Security=true;Database=da3_preintra_live");
        return CONNECTION;
    }

    public static void CloseConnection() {
        if (CONNECTION is not null && CONNECTION.State == ConnectionState.Open) {
            CONNECTION.Close();
        }
    }
}
