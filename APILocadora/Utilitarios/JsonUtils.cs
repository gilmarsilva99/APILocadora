using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Utilitarios
{
    public class JsonUtils
    {
        private static JsonSerializerSettings Configuracao()
        {
            return new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat };
        }

        public static string Serializar(object obj)
        {
            return JsonConvert.SerializeObject(obj, Configuracao());
        }

        public static T Deserializar<T>(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return (T)Activator.CreateInstance(typeof(T));

            return JsonConvert.DeserializeObject<T>(str, Configuracao());
        }

        public static object Deserializar(string str, Type tipo)
        {
            if (string.IsNullOrWhiteSpace(str))
                return new object();

            return JsonConvert.DeserializeObject(str, tipo);
        }
    }
}