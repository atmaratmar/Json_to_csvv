using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace JSON_TO_CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"E:\A_EXAM\A_JSON to CSV\JSON_TO_CSV\MY_JSON.json");

            XDocument doc = JsonConvert.DeserializeXNode(json);

            StringBuilder sb = new StringBuilder();
            // we want to be separated with comma
            string delimiter = ",";
            // we have to load the csv
            // what we want her is to get all sudent so we use Descendants
            // Descendants return Ienumerable so we have to convert it to list first 
            doc.Descendants("Student")
                .ToList().ForEach(element => sb.Append(element.Attribute("Country").Value + delimiter
                + element.Element("Name").Value + delimiter +
                element.Element("Gender").Value + delimiter +
                element.Element("TotalMarks").Value + "\r\n"
                ));

            // now we have data comma separated in  the sb we have to save it to csv
            StreamWriter sw = new StreamWriter(@"E:\A_EXAM\A_JSON to CSV\JSON_TO_CSV\MY_CSV.csv");
            sw.WriteLine(sb.ToString());
            sw.Close();
        }
    }
}
