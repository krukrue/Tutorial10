using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Tutorial10.Commons;

namespace Tutorial10.XmlSerializerExample
{
    internal class XmlSerialization
    {

        public static void Run()
        {
            Customer customer = new Customer()
            {
                Name = "Jan",
                Age = 30,
                Email = "jan@vsb.cz",
                Weight = 75.4,
                IsAlive = true,
                Orders = new Order[] {
                    new Order() {
                        Price = 400,
                        Name = "Dort"
                    },
                    new Order() {
                        Price = 20.5,
                        Name = "Koláč"
                    }
                }
            };

            WriteObject("XmlSerialization.xml", customer);
            ReadObject("XmlSerialization.xml");
        }

        public static void WriteObject(string FileName, Customer customer)
        {
            
            XmlSerializer ser = new XmlSerializer(typeof(Customer));
            using (TextWriter writer = new StreamWriter(FileName))
            {
                ser.Serialize(writer, customer);

            }
            
        }

        public static void ReadObject(string fileName)
        {
            XmlSerializer serializer =
            new XmlSerializer(typeof(Customer));
            Customer i;
            using (Stream reader = new FileStream(fileName, FileMode.Open))
            {
                i = (Customer)serializer.Deserialize(reader);
            }

            CustomerHelper.Print(i);
        }
    }
}
