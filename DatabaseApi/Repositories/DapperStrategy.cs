using Dapper;
using Microsoft.Data.SqlClient;

namespace DatabaseApi.Repositories;

public class DapperStrategy : IStrategy
{
    private SqlConnection _connection;

    public DapperStrategy(SqlConnection connection)
    {
        _connection = connection;
    }

    public List<T> SelectAll<T>(string query) where T : new()
    {
        List<T> results = new();
        try
        {
            _connection.Open();
            var data = _connection.Query<T>(query).ToList();
            foreach (var item in data)
                results.Add(item);
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

    public T SelectOne<T>(string query, Tuple<string, object> namedParam) where T : new()
    {
        T result = new();
        var (_, param) = namedParam;
        try
        {
            _connection.Open();
            var data = _connection.QuerySingleOrDefault<T>(query, param);
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

    public T InsertOne<T>(string query, T newObject) where T : new()
    {
        T result = new();
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

        return result;
    }

    public bool UpdateOne<T>(string query, T newObject) where T : new()
    {
        bool result;
        try
        {
            _connection.Open();
            var data = _connection.Execute(query, newObject);
            result = true;
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

    public bool DeleteOne(string query, Tuple<string, object> namedParam)
    {
        bool result;
        var (_, param) = namedParam;
        try
        {
            _connection.Open();
            var data = _connection.Execute(query, param);
            result = true;
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
}