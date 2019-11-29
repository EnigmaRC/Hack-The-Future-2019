using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hack_The_Future.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hack_The_Future.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PandigitController : ControllerBase
    {
        // GET: api/Pandigit
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pandigit/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pandigit
        [HttpPost]
        public char[] Post(Pandigit request)
        {
            // https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
            List<long> values = new List<long>();

            char[] characters = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            GetPer(characters);

            return characters;
            //for (int i = 0; i < Math.Pow(2, 10); i++)
            //{
            //    KnuthShuffle(characters);
            //    if (!characters[0].Equals('0'))
            //    {
            //        values.Add(ConvertArrayOfCharactersToLongs(characters));
            //    }
            //}

            //values.Sort();

            //return values.GetRange(0, 10);
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public static void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private static void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                Console.Write(list);
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }

        long ConvertArrayOfCharactersToLongs(char[] characters)
        {
            string tempValue = "";
            foreach (char character in characters)
            {
                tempValue += character;
            }
            return long.Parse(tempValue);
        }

        public static void KnuthShuffle<T>(T[] array)
        {
            System.Random random = new System.Random();
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(i, array.Length); // Don't select from the entire array on subsequent loops
                T temp = array[i]; 
                array[i] = array[j]; 
                array[j] = temp;
            }
        }

        // PUT: api/Pandigit/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
