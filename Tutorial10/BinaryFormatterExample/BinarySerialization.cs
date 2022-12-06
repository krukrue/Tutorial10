using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Tutorial10.Commons;
using Tutorial10.DataContractExample;

namespace Tutorial10.BinaryFormatterExample
{
    internal class BinarySerialization
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
            WriteObject("BinarySerialization.dat", customer);
            ReadObject("BinarySerialization.dat");

        }

        public static void WriteObject(string FileName, Customer customer)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(FileName, FileMode.Create))
            {
                formatter.Serialize(fs, customer);

            }
        } 

        public static void ReadObject(string FileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(FileName, FileMode.Open))
            {
                var a = (Customer)formatter.Deserialize(fs);
                CustomerHelper.Print(a);
            }
        }
    }
}
