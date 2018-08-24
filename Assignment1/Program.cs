using System;
using System.Threading.Tasks;

namespace Assignment1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(args[0]);
            
            RealTimeCityBikeDataFetcher fetcher = new RealTimeCityBikeDataFetcher();

            string input = args[0];

            var task = fetcher.GetBikeCountInStation(input);
            task.Wait();
            int count = task.Result;

            Console.WriteLine("Bikes available: " + count.ToString());

        }
    }
}
