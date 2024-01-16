using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class JsonMessageSerializer
    {
        public static JsonSerializerSettings ForConfigurationFiles()
        {
            var settings = new JsonSerializerSettings { Formatting = Formatting.None, TypeNameHandling = TypeNameHandling.Auto };
            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }

        public static string Serialize<T>(T source) where T : class
        {
            var s = JsonConvert.SerializeObject(source, ForConfigurationFiles());
            return s;
        }

        public static T Deserialize<T>(string source) where T : class
        {
            var d = JsonConvert.DeserializeObject<T>(source, ForConfigurationFiles());
            return d;
        }
    }
}
