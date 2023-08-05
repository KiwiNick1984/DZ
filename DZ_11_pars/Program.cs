using System.Diagnostics;
using System.Text.Json;

internal class Program
{
    record CityInfo(string cityName, double square, int population, string country, string district);

    private static void Main(string[] args)
    {
        CityParser cityParser = new CityParser();
        cityParser.SimpleParser();
        cityParser.SpanParser();

    }
    public class CityParser
    {
        List<CityInfo> cityInfoList = new List<CityInfo>();

        public void SimpleParser()
        {
            string[] splitedLine;

            string cityName;
            double square;
            int population;
            string coutri;
            string district;

            cityInfoList.Clear();
            var sw = Stopwatch.StartNew();
            foreach (var line in File.ReadLines("../../../../CityInfo.txt"))
            {
                splitedLine = line.Split(':');
                cityName = splitedLine[0];

                splitedLine = splitedLine[1].Split(";");
                square = double.Parse(splitedLine[0]);
                population = int.Parse(splitedLine[1]);

                splitedLine = splitedLine[2].Split('(', ')');
                coutri = splitedLine[0];
                district = splitedLine[1];
                cityInfoList.Add(new CityInfo(cityName, square, population, coutri, district));
            }
            sw.Stop();
            Console.WriteLine($"SimpleParser: {sw.Elapsed}");
        }
        public void SpanParser()
        {
            ReadOnlySpan<char> lineSpan;

            string cityName;
            double square;
            int population;
            string coutri;
            string district;

            cityInfoList.Clear();
            var sw = Stopwatch.StartNew();
            foreach (var line in File.ReadLines("../../../../CityInfo.txt"))
            {
                lineSpan = line.AsSpan();

                cityName = lineSpan.Slice(0, line.IndexOf(':')).ToString();
                lineSpan = lineSpan.Slice(line.IndexOf(':') + 1);

                square = double.Parse(lineSpan.Slice(0, lineSpan.IndexOf(";")));
                lineSpan = lineSpan.Slice(lineSpan.IndexOf(';') + 1);

                population = int.Parse(lineSpan.Slice(0, lineSpan.IndexOf(';')));
                lineSpan = lineSpan.Slice(lineSpan.IndexOf(';') + 1);

                coutri = lineSpan.Slice(0, lineSpan.IndexOf("(")).ToString();
                lineSpan = lineSpan.Slice(lineSpan.IndexOf('(') + 1);

                district = lineSpan[..^1].ToString();


                cityInfoList.Add(new CityInfo(cityName, square, population, coutri, district));
            }
            sw.Stop();
            Console.WriteLine($"SpanParser: {sw.Elapsed}");

            using (FileStream fs = new FileStream("../../../../CityInfo.json", FileMode.OpenOrCreate))
            {
                foreach (var line in cityInfoList)
                {
                        JsonSerializer.Serialize<CityInfo>(fs, line);
                }
            }            
        }
        //City_3:265,79;4942;Countri_1(District_5)
    }

}