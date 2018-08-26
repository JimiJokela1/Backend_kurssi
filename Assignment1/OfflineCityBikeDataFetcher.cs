using System;
using System.Threading.Tasks;

namespace Assignment1 {
    public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher {
        public async Task<int> GetBikeCountInStation(string stationName) {
            try {
                string[] lines = await System.IO.File.ReadAllLinesAsync(@"C:\Koulu\Servut\Backend_kurssi\Assignment1\bikedata.txt");

                int bikes = 0;

                foreach (string line in lines) {
                    string[] subStrings = line.Split(" : ");

                    if (subStrings.Length >= 2 && subStrings[0] == stationName) {
                        bikes = Int32.Parse(subStrings[1]);
                    }
                }

                return bikes;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }
    }
}
