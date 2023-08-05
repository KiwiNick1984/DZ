using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
internal class Program
{
    static List<string> CityNames = new List<string>()
    {
        "City_1",
        "City_2",
        "City_3",
        "City_4",
        "City_5",
    };
    static List<string> Countrise = new List<string>()
    {
        "Countri_1",
        "Countri_2",
        "Countri_3",
        "Countri_4",
        "Countri_5",
    };
    static List<string> Districts = new List<string>()
        {
        "District_1",
        "District_2",
        "District_3",
        "District_4",
        "District_5",
    };

    public record CityRec(string name, string countri, string district, double square, int population)
    {
        public override string ToString()
        {
            return $"{name}:{square};{population};{countri}({district})";
        }
    }

    private static void Main(string[] args)
            {
        List<string> citysInfo = new List<string>();
        Random rnd = new Random();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < 10000000; i++)
                {
            CityRec cityRec = new CityRec(
                CityNames[rnd.Next(0, CityNames.Count)],
                Countrise[rnd.Next(0, Countrise.Count)],
                Districts[rnd.Next(0, Districts.Count)],
                Math.Round(rnd.NextDouble() * rnd.Next(100, 1000), 2),
                rnd.Next(1, 5000)
                );
            citysInfo.Add(cityRec.ToString());
        }
        File.WriteAllLines("../../../../CityInfo.txt", citysInfo.Select(si => si.ToString()));
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }
}