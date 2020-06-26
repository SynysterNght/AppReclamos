using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace appReclamos.Models
{
    public class mensajesyn
    {
        [JsonProperty("mensaje")]
        public string mensajeiot { get; set; }
    }
}
