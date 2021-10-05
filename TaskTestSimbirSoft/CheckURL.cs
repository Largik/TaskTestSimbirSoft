using System.Net;

namespace TaskTestSimbirSoft
{
    public class CheckURL
    {
        public string Check(string url)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    return webClient.DownloadString(url);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}