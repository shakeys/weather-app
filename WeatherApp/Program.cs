namespace HttpClientDemo
{
    public class Rootobject
    {
        public Coord? coord { get; set; }
        public List<Weather>? weather { get; set; }
        public string? @base { get; set; }
        public Main? main { get; set; }
        public int? visibility { get; set; }
        public Wind? wind { get; set; }
        public Clouds? clouds { get; set; }
        public int? dt { get; set; }
        public Sys? sys { get; set; }
        public int? timezone { get; set; }
        public int? id { get; set; }
        public string? name { get; set; }
        public int? cod { get; set; }
    }
    public class Coord
    {
        public float? lon { get; set; }
        public float? lat { get; set; }
    }

    public class Weather
    {
        public int? id { get; set; }
        public string? main { get; set; }
        public string? description { get; set; }
        public string? icon { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public float pressure { get; set; }
        public float humidity { get; set; }
    }

    public class Wind
    {
        public float? speed { get; set; }
        public int? deg { get; set; }
    }

    public class Clouds
    {
        public int? all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }


    class WeatherConsole
    {
        static HttpClient client = new HttpClient();

        static void ShowWeatherDetails(Rootobject weather)
        {
            Console.WriteLine("London Weather Information JSON\n");
            
            // Coordinates Details
            Console.WriteLine("Coordinates:");
            Console.WriteLine($"Longitude: "+weather?.coord?.lon);
            Console.WriteLine($"Latitude: " + weather?.coord?.lat);
            Console.WriteLine("\r");

            // Weather Details
            Console.WriteLine("Weather List:");
            foreach (var item in weather?.weather)
            {
                Console.WriteLine($"ID: " + item.id);
                Console.WriteLine($"Main: " + item.main);
                Console.WriteLine($"Description: " + item.description);
                Console.WriteLine($"Icon: " + item.icon);
                Console.WriteLine("\r");
            }

            // Base
            Console.WriteLine($"Base: " + weather?.@base);
            Console.WriteLine("\r");

            // Main
            Console.WriteLine("Main:");
            Console.WriteLine($"Temperature: " + weather?.main?.temp);
            Console.WriteLine($"Feels like: " + weather?.main?.feels_like);
            Console.WriteLine($"Minimum Temperature: " + weather?.main?.temp_min);
            Console.WriteLine($"Maximum Temperature: " + weather?.main?.temp_max);
            Console.WriteLine($"Pressure: " + weather?.main?.pressure);
            Console.WriteLine($"Humidity: " + weather?.main?.humidity);
            Console.WriteLine("\r");

            // Visibility
            Console.WriteLine($"Visibility: " + weather?.visibility);
            Console.WriteLine("\r");

            // Wind
            Console.WriteLine("Wind:");
            Console.WriteLine($"Speed: " + weather?.wind?.speed);
            Console.WriteLine($"Degree: " + weather?.wind?.deg);
            Console.WriteLine("\r");

            // Clouds
            Console.WriteLine("Clouds:");
            Console.WriteLine($"All: " + weather?.clouds?.all);
            Console.WriteLine("\r");

            // DT
            Console.WriteLine($"DT: " + weather?.dt);
            Console.WriteLine("\r");

            // Sys
            Console.WriteLine("Sys:");
            Console.WriteLine($"Type: " + weather?.sys?.type);
            Console.WriteLine($"ID: " + weather?.sys?.id);
            Console.WriteLine($"Country: " + weather?.sys?.country);
            Console.WriteLine($"Sunrise: " + weather?.sys?.sunrise);
            Console.WriteLine($"Sunset: " + weather?.sys?.sunset);
            Console.WriteLine("\r");

            // Timezone
            Console.WriteLine($"Timezone: " + weather?.timezone);
            // ID
            Console.WriteLine($"ID: " + weather?.id);
            // Name
            Console.WriteLine($"Name: " + weather?.name);
            // COD
            Console.WriteLine($"COD: " + weather?.cod);
        }

        static async Task<Rootobject> GetWeatherAsync()
        {
            Rootobject rootObject = null;
            HttpResponseMessage response = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?q=London&appId=ad57e8923cbc13aff9aef7a0e4dc7c1d");
            if (response.IsSuccessStatusCode)
            {
                rootObject = await response.Content.ReadAsAsync<Rootobject>();
            }
            return rootObject;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            try
            {
                Rootobject rootObject;
                // Get the weather details
                rootObject = await GetWeatherAsync();
                ShowWeatherDetails(rootObject);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}