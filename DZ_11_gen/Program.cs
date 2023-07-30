using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
internal class Program
{
    record CityInfo(string cityName, double square, int population, string country, string region);
    record ForRandomCityInfo(string [] cityName, string[] country, string[] region);

    private static void Main(string[] args)
    {
        string pathCityInfo;

        if (args.Length == 0)
            pathCityInfo = Path.GetTempPath() + "CityInfo_List.txt";
        else
            pathCityInfo = args[0];

        CityGen cityGen = new CityGen(pathCityInfo);
        cityGen.GetCity();
    }

    class CityGen
    {
        private Dictionary<int, string> _city = new Dictionary<int, string>();
        private Dictionary<int, string> _country = new Dictionary<int, string>();
        private Dictionary<int, string> _region = new Dictionary<int, string>();

        string _pathForRandomCityInfo = Path.GetTempPath() + "CityInfo_ForRandom.json";
        string _pathCityInfo;
        ForRandomCityInfo _randobData;
        CityInfo _cityInfo;
        Random rnd = new Random();

        public CityGen(string pathCityInfo)
        {
            _pathCityInfo = pathCityInfo;

            #region [  JsonSerializer.Serialize  ]
            ForRandomCityInfo forRandomCityInfo = new ForRandomCityInfo(new string[] { "Makeevka", "Odessa", "Donetsk", "Kiev", "Praha", "Berlin", "Montreal", "Ottawa", "Winnipeg" },
                                                            new string[] { "Ukraine", "USA", "Canada", "Uganda", "Germany" },
                                                            new string[] { "New Mexico", "New York", "North Carolina", "Michigan", "Washington", "Alaska" });
            using (FileStream fs = new FileStream(_pathForRandomCityInfo, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<ForRandomCityInfo>(fs, forRandomCityInfo);
            }
            #endregion

            #region [  JsonSerializer.Deserialize  ]
            int i;
            try
            {
                _randobData = JsonSerializer.Deserialize<ForRandomCityInfo>(File.ReadAllText(_pathForRandomCityInfo));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            i = 1;
            foreach (var item in _randobData.cityName)
            {
                _city.Add(i++, item);
            }
            i = 1;
            foreach (var item in _randobData.country)
            {
                _country.Add(i++, item);
            }
            i = 1;
            foreach (var item in _randobData.region)
            {
                _region.Add(i++, item);
            }
            #endregion
        }

        public void GetCity()
        {

            using (StreamWriter sw = new StreamWriter(_pathCityInfo))
            {
                for (int i = 0; i < 100_000; i++)
                {
                    _cityInfo = new CityInfo(_city[rnd.Next(1, _city.Count)],
                                            Math.Round(rnd.NextDouble() * 1000, 2),
                                            rnd.Next(0, 1_000_000),
                                            _country[rnd.Next(1, _country.Count)],
                                            _region[rnd.Next(1, _region.Count)]);
                    sw.WriteLine($"{_cityInfo.cityName};{_cityInfo.square};{_cityInfo.population};{_cityInfo.country}({_cityInfo.region})");
                }
            }
        }
    }
}