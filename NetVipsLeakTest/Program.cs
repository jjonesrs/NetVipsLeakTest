using System;
using System.IO;
using NetVips;

namespace NetVipsLeakTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] imageBytes = File.ReadAllBytes(@"large-test-image.png");
            //byte[] imageBytes = File.ReadAllBytes(@"small-test-image.jpg");

            Base.LeakSet(1);

            Operation.VipsCacheSetMax(0);
            Operation.VipsCacheSetMaxFiles(0);

            for (int i = 0; i < 1000000; i++)
            {
                using (Image img = Image.NewFromBuffer(imageBytes))
                {
                    Console.WriteLine(img);
                }
            }
        }
    }
}
