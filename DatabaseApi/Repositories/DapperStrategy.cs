using System.Reflection.Metadata;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DatabaseApi.Repositories;

public class DapperStrategy : IStrategy
{
    private SqlConnection _connection;

    public DapperStrategy()
    {
        _connection = new MsSqlDatabase().Connection;
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

    public T? SelectOne<T>(string query, Tuple<string, object> namedParam) where T : new()
    {
        T? result = new();
        var (name, value) = namedParam;
        try
        {
            // Set dynamically the needed parameters
            var parameters = new DynamicParameters(new Dictionary<string, object>
            {
                { name, value }
            });
            _connection.Open();
            result = _connection.QueryFirstOrDefault<T>(query, parameters);
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
            _connection.Query<T>(query, newObject);
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
            var data = _connection.Execute(query, newObject);
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
        var (_, param) = namedParam;
        try
        {
            _connection.Open();
            var data = _connection.Execute(query, param);
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