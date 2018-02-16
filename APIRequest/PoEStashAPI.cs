using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APIRequest
{
    class PoEStashAPI
    {
        private string nextID = "";
        private List<Task<string>> openRequests = new List<Task<string>>();

        public void Run()
        {
            var response = GetResponseAsync();
            var done = false;

            while (!done)
            {
                if (response.IsCompleted)
                {
                    //Console.WriteLine(response.Result.Substring(0, 200));
                    done = true;
                }

                else
                {
                    Console.WriteLine(response.Status);
                }

                Thread.Sleep(500);
            }

            PrintNames(response.Result);
            UpdateNextID(response.Result);
            //PrintEx(response.Result);

        }

        private async Task<string> GetResponseAsync()
        {
            var webClient = new WebClient();
            var reqUrl = "http://www.pathofexile.com/api/public-stash-tabs";

            if (this.nextID != "") reqUrl += "?id=" + this.nextID;

            using (webClient)
            {
                return await webClient.DownloadStringTaskAsync(reqUrl);
            }
        }

        private void PrintNames(string s)
        {
            var split = s.Split(new string[] { "\"accountName\":\"" }, StringSplitOptions.None);
            split.ToList().ForEach(x => Console.WriteLine("- " + x.Substring(0, x.IndexOf("\""))));
        }

        private void UpdateNextID(string s)
        {
            var nextID = s.Substring(19);
            nextID = nextID.Split('"')[0];
            this.nextID = nextID;
            Console.WriteLine(nextID);
        }

        private void PrintEx(string s)
        {
            var split = s.Split(new string[] { "Exalted" }, StringSplitOptions.None);
            if (split.Length > 1)
            {
                Console.WriteLine(split[1].Substring(0, 350));
            }
        }
    }
}
