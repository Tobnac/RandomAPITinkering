using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APIRequest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var poe = new PoEStashAPI();
            var tumblr = new TumblrAPI();
            var fb = new FBDatabase();

            //fb.Run();
            //Console.Read();

            tumblr.Run("");
            //Console.Read();

            while (true)
            {
                poe.Run();
            }
        }        
    }
}
