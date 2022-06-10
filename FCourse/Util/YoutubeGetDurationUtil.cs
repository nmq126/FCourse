using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace FCourse.Util
{
    public class YoutubeGetDurationUtil
    {
        public class YoutubeResponse
        {
            public List<Item> items { get; set; }
        }

        public class Item
        {
            public ContentDetail contentDetails { get; set; }
        }

        public class ContentDetail
        {
            public string duration { get; set; }
        }
        public static async Task<double> GetYoutubeVideoDurationAsync(string id)
        {
            string youtubeKey = "AIzaSyCnIeZUhlmzO9uejLeN3vZmu8nUsTMNwBY";
            string baseApi = "https://www.googleapis.com/youtube/v3/videos?id=" + id + "&key=" + youtubeKey + "&part=contentDetails";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseApi);
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    var videoInfo = JsonConvert.DeserializeObject<YoutubeResponse>(EmpResponse);
                    double sec = XmlConvert.ToTimeSpan(videoInfo.items.First().contentDetails.duration).TotalSeconds;
                    return sec;
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}