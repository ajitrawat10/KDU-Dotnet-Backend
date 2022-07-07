using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializeDeserializeXMLData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string xmlString = SerializeObjectToXmlString();
            Console.WriteLine(xmlString);


            DeserializeXmlStringToObject(xmlString);
        }

        // Serializing  Method 
        private static string SerializeObjectToXmlString()
        {
            var member = new Member
            {
                Name = "Pradeep",
                Email = "pradepp23@gmail.com",
                Age = 23,
                JoiningDate = DateTime.Now,
            };

            var xmlSerializer = new XmlSerializer(typeof(Member));
            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, member); ;
                var xmlContent = writer.ToString();
                return xmlContent;
            }
        }

        //Deserializing Method
        private static void DeserializeXmlStringToObject(string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(Member));
            using (var reader = new StringReader(xmlString))
            {
                var member = (Member)xmlSerializer.Deserialize(reader);

            }
        }

    }
}
