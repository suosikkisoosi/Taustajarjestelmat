using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace dotnettest
{
    
    
     class NotFoundException : Exception{
           public NotFoundException(string message) : base(message){

          }
          public override string ToString(){
                return $"Not found {Message}";
         }
     }
    class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {

        public async Task<int> GetBikeCountInStation(string stationName)
        {
            //Throw invalid argument exception
            if(stationName.Any(char.IsNumber))
                throw new ArgumentException("Invalid argument");

            var client = new HttpClient();
            var r = await client.GetAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            var rByte = await r.Content.ReadAsByteArrayAsync();
            var rString = System.Text.Encoding.UTF8.GetString(rByte);

            var stations = JsonConvert.DeserializeObject<Data>(rString);

            foreach(var s in stations.stations){
                if(s.name.Equals(stationName))
                    return s.bikesAvailable;
            }
            throw new NotFoundException(stationName);
        }
    }
}
