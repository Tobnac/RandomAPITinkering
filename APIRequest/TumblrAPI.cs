using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APIRequest
{
    public class TumblrAPI
    {
        private readonly string key = "fuiKNFp9vQFvjLNvx4sUwti4Yb5yGutBN4Xh10LXZhhRKjWlV4";
        private readonly string[] blogIdentList = { "info", "likes", "following", "followers", "posts", "posts/queue", "posts/drafts", "posts/submissions", "post" };
        private readonly string[] userIdentList = { "user/info", "user/dashboard", "user/likes", "user/following", "user/follow" };
        private readonly string[] generalIdentList = { "tagged" };

        private string lastTimeStamp = "99999999999999999999999999";
        private string blog = null;

        public List<string> Run(string searchTag)
        {            
            var ident = "tagged";
            var done = false;
            var result = "";
            var linkList = new List<string>();
            var url = this.BuildReqUrl(ident, blog, "tag="+searchTag, "limit=20", "before="+this.lastTimeStamp);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var list = this.ParseImageLinks(content);
            this.ParseLastTimestamp(content);
            return list;

            while (!done)
            {
                var req = GetRequest(url);
                result = GetInfo(req);
                //Console.WriteLine(result);
                //Console.WriteLine(time);

                linkList.AddRange(this.ParseImageLinks(result));

                done = true;
                Thread.Sleep(1000);
            }
            
            Console.WriteLine("DONE");
            return linkList;
        }

        private string BuildReqUrl(string ident, params string[] optionals)
        {
            var reqUrl = "https://api.tumblr.com/v2/" + ident + "?api_key=" + this.key;

            foreach (var opt in optionals)
            {
                reqUrl += "&" + opt;
            }

            return reqUrl.Replace(" ", "+");
        }

        private string GetInfo(Task<string> request)
        {
            var response = request;
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

            try
            {
                return response.Result;
            }
            catch (System.AggregateException e)
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(e.InnerException.Message);
                return "Error";
            }       
        }

        private async Task<string> GetBlogRequest(string ident, string blog, params string[] optionals)
        {
            var webClient = new WebClient();
            var reqUrl = "https://api.tumblr.com/v2/blog/" + blog + ".tumblr.com/" + ident + "?api_key=" + this.key;

            foreach (var opt in optionals)
            {
                reqUrl += "&" + opt;
            }

            using (webClient)
            {
                return await webClient.DownloadStringTaskAsync(reqUrl);
            }
        }

        private async Task<string> GetUserRequest(string ident, string user, params string[] optionals)
        {
            var webClient = new WebClient();
            var reqUrl = "https://api.tumblr.com/v2/user/" + user + ".tumblr.com/" + ident + "?api_key=" + this.key;

            foreach (var opt in optionals)
            {
                reqUrl += "&" + opt;
            }

            using (webClient)
            {
                return await webClient.DownloadStringTaskAsync(reqUrl);
            }
        }

        private async Task<string> GetRequest(string url)
        {
            var webClient = new WebClient();

            using (webClient)
            {
                return await webClient.DownloadStringTaskAsync(url);
            }
        }

        private void Temp()
        {
            var client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync("https://www.tumblr.com/oauth/request_token", content);
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

            var x = response.Result;

            //var responseString = response.Content.ReadAsStringAsync();
        }

        private List<string> ParseImageLinks(string fullResult)
        {
            // split by "url":"
            // [2] and [10] are interesting links

            // link = split until "

            var splitSeq = "\"url\":\"";
            var splits = fullResult.Split(new string[] { splitSeq }, StringSplitOptions.None);
            var result = new List<string>();
            var duplicated = new List<string>();

            // min 10 length
            // +7 for every img

            var imageCount = (splits.Length - 3) / 7;
            for (int i = 1; i < splits.Length; i++)
            {
                //if (!splits[i].Contains("_1280.")) continue;
                

                var index = i*7 + 2;
                var temp = splits[i];
                temp = temp.Substring(0, temp.IndexOf("\""));

                if (!temp.Contains("78.media.tumblr.com")) continue;

                string dupKey;
                if (temp.Contains("_"))
                {
                    dupKey = temp.Substring(0, temp.LastIndexOf("_"));
                }
                else
                {
                    dupKey = temp;
                }
                if (duplicated.Contains(dupKey)) continue;
                else duplicated.Add(dupKey);

                //Console.WriteLine(temp);
                result.Add(temp);
            }

            Console.WriteLine(result.Count + " images found.");
            return result;

        }

        private void ParseLastTimestamp(string content)
        {
            var x = content.Split(new String[] { "timestamp\":" }, StringSplitOptions.None)[20];
            x = x.Split(new String[] { "," }, StringSplitOptions.None)[0];
            this.lastTimeStamp = x;
        }

    }
}
