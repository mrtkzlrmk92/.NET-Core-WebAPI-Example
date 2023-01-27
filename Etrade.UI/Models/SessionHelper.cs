using Newtonsoft.Json;

namespace Etrade.UI.Models
{
    public static class SessionHelper
    {
        public static int Count { get; set; }
        public static void Set(this ISession session,string key,object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T Get<T>(this ISession session,string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
