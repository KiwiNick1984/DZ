using System.Text.Json;

internal class Program
{
    record CityInfo(string cityName, double square, int population, string countryRegion);
    private static void Main(string[] args)
    {
        string pathCityInfo;
        if (args.Length == 0)
            pathCityInfo = Path.GetTempPath() + "CityInfo_List.txt";
        else
            pathCityInfo = args[0];

        string strForReadFile;
        string[] str;
        List<CityInfo> _cityInfo = new List<CityInfo>();
        using (StreamReader sr = new StreamReader(pathCityInfo))
        {
            strForReadFile = sr.ReadLine();

            while (strForReadFile != null)
            {
                str = strForReadFile.Split(';');

                _cityInfo.Add(new CityInfo(str[0], double.Parse(str[1]), int.Parse(str[2]), str[3]));
                strForReadFile = sr.ReadLine();
            }
        }
        using (FileStream fs = new FileStream(Path.GetTempPath() + "CityInfo_List.json", FileMode.OpenOrCreate))
        {
            foreach (var item in _cityInfo)
            {
                JsonSerializer.Serialize<CityInfo>(fs, item);
            }            
        }
    }

}