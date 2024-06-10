namespace DatabaseApi.Repositories;

public interface IStrategy
{
    public List<T> SelectAll<T>(string query) where T : new();
    public T SelectOne<T>(string query, Tuple<string, object> namedParam) where T : new();
    public void InsertOne<T>(string query, T newObject) where T : new();
    public void UpdateOne<T>(string query, T newObject) where T : new();
    public void DeleteOne(string query, Tuple<string, object> namedParam);
}