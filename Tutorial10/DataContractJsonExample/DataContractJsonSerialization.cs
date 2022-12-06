using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Tutorial10.Commons;

namespace Tutorial10.DataContractJsonExample
{
    internal class DataContractJsonSerialization
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
            WriteObject("DataContractJsonSerialization.json", customer);
            ReadObject("DataContractJsonSerialization.json");
        }
        public static void WriteObject(string fileName, Customer customer)
        {

            FileStream writer = new FileStream(fileName, FileMode.Create);
            DataContractJsonSerializer ser =
                new DataContractJsonSerializer(typeof(Customer));
            ser.WriteObject(writer, customer);
            writer.Close();

        }
        public static void ReadObject(string fileName)
        {
            var deserializedUser = new Customer();
            using (FileStream writer = new FileStream(fileName, FileMode.Open))
            {
                var ser = new DataContractJsonSerializer(deserializedUser.GetType());
                deserializedUser = ser.ReadObject(writer) as Customer;

            }
            CustomerHelper.Print(deserializedUser);
        }
    }
}