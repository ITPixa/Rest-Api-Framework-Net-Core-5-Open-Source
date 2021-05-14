using Pixa.OpenApi.Framework.ClientApi.Controllers;
using System;

namespace Pixa.OpenApi.Framework.ClientApi
{
    
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
