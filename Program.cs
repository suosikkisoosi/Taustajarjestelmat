using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace dotnettest
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2 && args[1].Equals("offline"))
            {
                var data = LoadOffline(args[0]);
                data.Wait();
            }
            else{
                var data = LoadOnline(args[0]);
                data.Wait();
            }
            
            
        }
        static public async Task<int> LoadOffline (string stationName){
            
            var fetcher = new OfflineCityBikeDataFetcher();
            try
            {
                var waiter = await fetcher.GetBikeCountInStation(stationName);
                Console.WriteLine(stationName + " " + waiter);
            }
            //Catch Invalid argument exception
            catch(ArgumentException e)
            {
                Console.WriteLine("ERROR: " +e.Message);
            }
            catch(NotFoundException e){
                Console.WriteLine(e);
            }

            return 0;
        }

        static public async Task<int> LoadOnline (string stationName){
            
            var fetcher = new RealTimeCityBikeDataFetcher();
            try
            {
                var waiter = await fetcher.GetBikeCountInStation(stationName);
                Console.WriteLine(stationName + " " + waiter);
            }
            //Catch Invalid argument exception
            catch(ArgumentException e)
            {
                Console.WriteLine("ERROR: " +e.Message);
            }
            catch(NotFoundException e){
                Console.WriteLine(e);
            }

            return 0;
        }
        public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher{
            static string FILE_NAME = "bikes.txt";

            Dictionary<string, string> dic = new Dictionary<string, string>();
            

            public async Task<int> GetBikeCountInStation(string stationName){
                if(stationName.Any(char.IsNumber))
                    throw new ArgumentException("Invalid argument");
                using(var reader = File.OpenText(FILE_NAME)){
                    var data = await reader.ReadToEndAsync();
                    
                    var split = data.Split("\n");

                    foreach(var s in split){
                        var f = s.Split(":");

                        dic.Add(f[0], f[1]);
                    }
                    if(dic.ContainsKey(stationName))
                        return int.Parse(dic[stationName]);
                    
                }
                throw new NotFoundException(stationName);
            }
        }
    }
}
