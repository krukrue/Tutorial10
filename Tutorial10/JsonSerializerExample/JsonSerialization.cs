using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Text;
using System.Text.Json;
using Tutorial10.Commons;

namespace Tutorial10.JsonSerializerExample
{
    internal class JsonSerialization
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
            WriteObject("JsonSerialization.json", customer);
            ReadObject("JsonSerialization.json");

        }

        public static void WriteObject(string FileName, Customer customer)
        {

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping

            };
            string jsonString = JsonSerializer.Serialize(customer, serializeOptions);
            File.WriteAllText(FileName, jsonString);
        }

        public static void ReadObject(string FileName)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping

        };
            string jsonString = File.ReadAllText(FileName);

            Customer customer = JsonSerializer.Deserialize<Customer>(jsonString, serializeOptions)!;
            CustomerHelper.Print(customer);
        }
    }

}
