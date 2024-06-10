using Microsoft.Data.SqlClient;

namespace DatabaseApi.Services;

public interface IStrategy
{
    public List<T> SelectAll<T>(string query) where T : new();
    public T SelectOne<T>(string query, Tuple<string, object> namedParam) where T : new();
    public T InsertOne<T>(string query, T newObject) where T : new();
    public bool UpdateOne<T>(string query, T newObject) where T : new();
    public bool DeleteOne(string query, Tuple<string, object> namedParam);
}