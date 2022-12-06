using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Tutorial10.Commons;

namespace Tutorial10.DataContractExample
{
    internal class DataContractSerialization
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
            WriteObject("DataContractSerialization.xml", customer);
            ReadObject("DataContractSerialization.xml");

        }

        public static void WriteObject(string fileName, Customer customer)
        {
            using (FileStream writer = new FileStream(fileName, FileMode.Create))
            {
                DataContractSerializer ser =
                    new DataContractSerializer(typeof(Customer));
            ser.WriteObject(writer, customer);

            }
        }

        public static void ReadObject(string fileName)
        {
            using (FileStream fs = new FileStream(fileName,
            FileMode.Open))
            {
                XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(Customer));

                Customer deserializedPerson =
                    (Customer)ser.ReadObject(reader, true);
                reader.Close();

                CustomerHelper.Print(deserializedPerson);
            }
        }
    }
}
