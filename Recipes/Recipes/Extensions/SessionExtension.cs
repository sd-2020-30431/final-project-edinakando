using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace Recipes.Extensions
{
    public static class SessionExtension
    {
        public static void Set<T>(this ISession session, String key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, String key)
        {
            String value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
