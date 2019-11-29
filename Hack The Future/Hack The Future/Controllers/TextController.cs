using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack_The_Future.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hack_The_Future.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {

        // POST: api/Text
        [HttpPost]
        public string Post(Input text)
        {
                Dictionary<char, int> letterCount = new Dictionary<char, int>();
                string valueToReturn = "";
                for (int i = 0; i < text.Text.Length; i++)
                {
                    char currentChar = text.Text[i];
                    if (letterCount.ContainsKey(currentChar))
                    {
                        letterCount[currentChar]++;
                    } else
                    {
                        letterCount.Add(currentChar, 1);
                    }
                    valueToReturn += letterCount[currentChar] + "";
                }

                return valueToReturn;

        }

        // PUT: api/Text/5
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
