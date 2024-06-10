using Microsoft.Data.SqlClient;

namespace DatabaseApi.Repositories;

public class MsSqlDatabase
{
    public SqlConnection Connection = new()
    {
        ConnectionString =
            "Data Source= 127.0.0.1;Initial Catalog=DB_AndreVeiculos;User Id=sa;Password=SqlServer2019!;TrustServerCertificate=True"
    };
}