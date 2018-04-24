using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageSizes
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Enter Image URL:");
            var url = Console.ReadLine();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var image = Image.FromStream(stream);

                    (float Width, float Height) dimensions = (image.PhysicalDimension.Width, image.PhysicalDimension.Height);

                    Console.WriteLine($"Width: {dimensions.Width}, Height: {dimensions.Height}");
                }

                Console.ReadKey();
            }
        }
    }
}
