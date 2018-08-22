using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assignment1 {
    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher {
        static HttpClient client = new HttpClient();

        public async Task<int> GetBikeCountInStation(string stationName) {
            HttpResponseMessage message = await client.GetAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");

            string messageText = System.Text.Encoding.UTF8.GetString(message.Content.ReadAsByteArrayAsync().Result);

            BikeRentalStationList stationList = (BikeRentalStationList)JsonConvert.DeserializeObject<BikeRentalStationList>(messageText);

            int bikes = 0;

            foreach(var station in stationList.stations) {
                if (station.name == stationName) {
                    bikes = station.bikesAvailable;
                    break;
                }
            }

            return bikes;
        }
    }
}
