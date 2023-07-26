using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services;
using Newtonsoft.Json;

public class JsonSerializer: IJsonSerializer
{
    public string Serialize<T>(T data)
    {
        return JsonConvert.SerializeObject(data);
    }

    public T Deserialize<T>(string value)
    {
        return JsonConvert.DeserializeObject<T>(value) !;
    }
}