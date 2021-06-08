﻿using Newtonsoft.Json;

namespace MVVMBoiler.UI.Ultilities
{
    public static class MasterUltility
    {
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
