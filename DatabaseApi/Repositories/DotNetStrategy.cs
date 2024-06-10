using Dapper;
using Microsoft.Data.SqlClient;

namespace DatabaseApi.Repositories;

public class DotNetStrategy : IStrategy
{
    private SqlConnection _connection;

    public DotNetStrategy()
    {
        _connection = new MsSqlDatabase().Connection;
    }

    public List<T> SelectAll<T>(string query) where T : new()
    {
        List<T> results = new();
        try
        {
            _connection.Open();
            var cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = query
            };

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new T();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var property = item.GetType().GetProperty(reader.GetName(i));
                        if (property != null && !reader.IsDBNull(i)) property.SetValue(item, reader.GetValue(i));
                    }

                    results.Add(item);
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL ERROR: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            throw;
        }
        finally
        {
            _connection.Close();
        }

        return results;
    }


    public T? SelectOne<T>(string query, Tuple<string, object> namedParam) where T : new()
    {
        T? result = new();
        var (paramName, param) = namedParam;
        try
        {
            _connection.Open();
            var cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = query
            };
            cmd.Parameters.AddWithValue("@" + paramName, param);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var property = result.GetType().GetProperty(reader.GetName(i));
                        if (property != null && !reader.IsDBNull(i)) property.SetValue(result, reader.GetValue(i));
                    }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL ERROR: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            throw;
        }
        finally
        {
            _connection.Close();
        }

        return result;
    }

    public void InsertOne<T>(string query, T newObject) where T : new()
    {
        try
        {
            _connection.Open();
            var data = _connection.Query<T>(query, newObject);
        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL ERROR: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            throw;
        }
        finally
        {
            _connection.Close();
        }
    }

    public void UpdateOne<T>(string query, T newObject) where T : new()
    {
        try
        {
            _connection.Open();
            var cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = query
            };

            // Mapeia os parametros para a query de tipo generico
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(newObject) ?? DBNull.Value;
                cmd.Parameters.AddWithValue($"@{property.Name}", value);
            }

            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL ERROR: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            throw;
        }
        finally
        {
            _connection.Close();
        }

    }


    public void DeleteOne(string query, Tuple<string, object> namedParam)
    {
        var (paramName, param) = namedParam;
        try
        {
            _connection.Open();
            var cmd = new SqlCommand
            {
                Connection = _connection,
                CommandText = query
            };
            cmd.Parameters.AddWithValue("@" + paramName, param);
            cmd.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL ERROR: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            throw;
        }
        finally
        {
            _connection.Close();
        }

    }
}