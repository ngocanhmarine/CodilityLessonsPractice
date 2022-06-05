using System;

namespace TestSendRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://www.google.com");
            System.Net.WebProxy myproxy = new System.Net.WebProxy("173.244.200.156", 34515);
            myproxy.BypassProxyOnLocal = false;
            request.Proxy = myproxy;
            request.Method = "GET";
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
        }
    }
}
