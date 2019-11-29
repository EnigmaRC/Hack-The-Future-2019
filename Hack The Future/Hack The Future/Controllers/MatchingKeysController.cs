using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Hack_The_Future.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace Hack_The_Future.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchingKeysController : ControllerBase
    {
        // GET: api/MatchingKeys
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MatchingKeys/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MatchingKeys
        [HttpPost]
        public string Post(MatchingKeys matchingKeys)
        {
            var keyholeBytes = Convert.FromBase64String(matchingKeys.Keyholes);
            var keyBytes = Convert.FromBase64String(matchingKeys.Keys);

            Stream keyholeStream = new MemoryStream(keyholeBytes);
            Stream keyStream = new MemoryStream(keyBytes);

            var keyholeImage = Bitmap.FromStream(keyholeStream);
            var keyImage = Bitmap.FromStream(keyStream);

            Dictionary<int, Image> KeyholeDictionary = new Dictionary<int, Image>();
            Dictionary<int, Image> KeyDictionary = new Dictionary<int, Image>();

            for (int i = 0; i < 4; i++)
            {
                KeyholeDictionary[i] = new Bitmap(50, 50);
                var graphics = Graphics.FromImage(KeyholeDictionary[i]);
                graphics.DrawImage(keyholeImage, new Rectangle(0, 0, 50, 50), new Rectangle(i * 50, 0, 50, 50), GraphicsUnit.Pixel);

                KeyDictionary[i] = new Bitmap(50, 50);
                graphics = Graphics.FromImage(KeyDictionary[i]);
                graphics.DrawImage(keyImage, new Rectangle(0, 0, 50, 50), new Rectangle(i * 50, 0, 50, 50), GraphicsUnit.Pixel);
                graphics.Dispose();
            }

            Dictionary<int, byte[]> KeyholeImageBytes = new Dictionary<int, byte[]>();
            Dictionary<int, byte[]> KeyImageBytes = new Dictionary<int, byte[]>();


            for (int i = 0; i < 4; i++)
            {
                using (var stream = new MemoryStream())
                {
                    KeyholeDictionary[i].Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    KeyholeImageBytes[i] = stream.ToArray();

                    KeyDictionary[i].Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    KeyImageBytes[i] = stream.ToArray();
                }
            }
            

            return "OK";
        }

        // PUT: api/MatchingKeys/5
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
