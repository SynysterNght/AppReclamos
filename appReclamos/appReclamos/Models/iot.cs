using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace appReclamos.Models
{
    public class iot
    {
       

        [JsonProperty("temperatura")]
        public string temperatura { get; set; }

        [JsonProperty("humedad")]
        public string humedad { get; set; }
    }
}
