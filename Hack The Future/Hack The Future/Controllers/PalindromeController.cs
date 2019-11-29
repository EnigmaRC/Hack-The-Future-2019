using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hack_The_Future.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hack_The_Future.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalindromeController : ControllerBase
    {

        // POST: api/Palindrome
        [HttpPost]
        public int Post(Palindrome palindrome) 
        {
            int nextPalindrome = 0;

            for (int i = palindrome.value; i < Int32.MaxValue; i++)
            {
                if (IsPalindrome(i + ""))
                {
                    nextPalindrome = i;
                    break;
                };
            }
            return nextPalindrome;
        }

        public Boolean IsPalindrome(string input)
        {
            return input.SequenceEqual(input.Reverse());
        }

        // PUT: api/Palindrome/5
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
