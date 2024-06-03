using Newtonsoft.Json.Linq;

var client = new HttpClient();
var appSettingsText = File.ReadAllText("appsettings.json");

var APIKey = JObject.Parse(appSettingsText)["key"].ToString();

Console.WriteLine("Please enter your zipcode");
var userZIPCode = int.Parse(Console.ReadLine());

var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={userZIPCode}&appid={APIKey}&units=imperial"; 
var URLResponse = client.GetStringAsync(weatherURL).Result;
var weather = JObject.Parse(URLResponse)["main"]["temp"].ToString();

var weatherAsInt = double.Parse(weather);

Console.WriteLine($"The temperature in your area is {weatherAsInt}");

if (weatherAsInt >= 90)
{
    Console.WriteLine("Looks like its a hot one today-- make sure to grab your sunscreen!");
}
if (weatherAsInt >= 80 && weatherAsInt < 90)
{
    Console.WriteLine("The weather isn't hot today as long as you stay in the shade!");
}
if (weatherAsInt >= 65 && weatherAsInt < 80)
{
    Console.WriteLine("Lucky you-- you have perfect weather today! Make sure to enjoy it!");
}
if (weatherAsInt >= 50 && weatherAsInt < 65)
{
    Console.WriteLine("Getting a little colder-- make sure to grab a jacket!");
}
if (weatherAsInt >= 40 && weatherAsInt < 50)
{
    Console.WriteLine("Gonna be a cold one, better grab your coat!");
}
if (weatherAsInt < 40)
{
    Console.WriteLine("Brrrrr it's too cold, best to just stay inside and play videogames today!");
}

