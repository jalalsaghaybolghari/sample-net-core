
namespace ProjectManagment.Business.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string key)
    {
        Data.Add("key", key);
    }

    public NotFoundException(string key, List<KeyValuePair<string, object>> metadata) : base(key)
    {
        foreach (var kvp in metadata)
            Data.Add(kvp.Key, kvp.Value);
    }
}