using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConsoleAppJson
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = File.OpenText("json/tinh_tp.json"))
            {
                //Get values tinh_tp
                string json = r.ReadToEnd();
                var js = JObject.Parse(json);
                IList<JToken> values = js.Properties().Select(x => x.First).ToList();
                List<Province> provinces = new List<Province>();
                foreach (var item in values)
                {
                    Province pro = new Province();
                    pro = item.ToObject<Province>();
                    provinces.Add(pro);
                }
                Console.WriteLine("done!");
            }

            using (StreamReader r = File.OpenText("json/quan_huyen.json"))
            {
                //Get values tinh_tp
                string json = r.ReadToEnd();
                var js = JObject.Parse(json);
                IList<JToken> values = js.Properties().Where(x=>x.First.SelectToken("parent_code").ToString() == "92").Select(x => x.First).ToList();
                List<Distrist> distrists = new List<Distrist>();
                foreach (var item in values)
                {
                    Distrist pro = new Distrist();
                    pro = item.ToObject<Distrist>();
                    distrists.Add(pro);
                }
                Console.WriteLine("done!");
            }

            using (StreamReader r = File.OpenText("json/xa_phuong.json"))
            {
                //Get values tinh_tp
                string json = r.ReadToEnd();
                var js = JObject.Parse(json);
                IList<JToken> values = js.Properties().Where(x => x.First.SelectToken("parent_code").ToString() == "916").Select(x => x.First).ToList();
                List<Ward> wards = new List<Ward>();
                foreach (var item in values)
                {
                    Ward pro = new Ward();
                    pro = item.ToObject<Ward>();
                    wards.Add(pro);
                }
                Console.WriteLine("done!");
            }
        }
    }
    public class Province
    {
        public string name { get; set; }
        public string slug { get; set; }
        public string type { get; set; }
        public string name_with_type { get; set; }
        public string code { get; set; }

    }
    public class Distrist
    {
        public string name { get; set; }
        public string slug { get; set; }
        public string type { get; set; }
        public string name_with_type { get; set; }
        public string path { get; set; }
        public string path_with_type { get; set; }
        public string code { get; set; }
        public string parent_code { get; set; }
    }
    public class Ward
    {
        public string name { get; set; }
        public string slug { get; set; }
        public string type { get; set; }
        public string name_with_type { get; set; }
        public string path { get; set; }
        public string path_with_type { get; set; }
        public string code { get; set; }
        public string parent_code { get; set; }
    }

}
