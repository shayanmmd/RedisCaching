using Domain;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System.Text;

namespace Application;

public class RedisCache
{
    private static RedisCache _instance = null;

    private RedisCache()
    {

    }

    public static RedisCache GetInstance()
    {
        if (_instance == null)
            _instance = new RedisCache();
        return _instance;
    }
    public void HandlePerson(object sender, Person person)
    {
        using (RedisClient redis = new())
        {
            var serilizedObj = JsonConvert.SerializeObject(person);
            var content = Encoding.ASCII.GetBytes(serilizedObj);
            redis.Set($"{person}:{person.Id}", content);
        };
    }
}
