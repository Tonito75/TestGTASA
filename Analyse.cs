using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Analyse
    {
        public static void Analys()
        {

            byte[] file1 = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/sfw_stream0.ipl");
            byte[] file2 = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/countryw_stream0.ipl");
            Console.WriteLine("Getting 200 first bytes");
            Console.WriteLine("\n");
            for (int i = 0; i < 100; i++)
            {
                Console.Write(file1[i] + " ");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < 100; i++)
            {
                Console.Write(file2[i] + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("DECODING DATA");
            Console.WriteLine("\n");

            byte[] header = file1.Take(19 * 4).ToArray();
            for(int i = 0; i < header.Length; i++)
            {
                Console.Write(header[i] + " ");
            }

            int compteurvalid = 0;
            for (int i = header.Length; i < file1.Length - 40; i=i+40)
            {
               float x = BitConverter.ToSingle(new byte[4] { file1[i],file1[i+1],file1[i+2],file1[i+3] }, 0);
               float y = BitConverter.ToSingle(new byte[4] { file1[i+4], file1[i + 5], file1[i + 6], file1[i + 7] }, 0);
               float z = BitConverter.ToSingle(new byte[4] { file1[i + 8], file1[i + 9], file1[i + 10], file1[i + 11] }, 0);
                float rotx = BitConverter.ToSingle(new byte[4] { file1[i + 12], file1[i + 13], file1[i + 14], file1[i + 15] }, 0);
                float roty = BitConverter.ToSingle(new byte[4] { file1[i + 16], file1[i + 17], file1[i + 18], file1[i + 19] }, 0);
                float rotz = BitConverter.ToSingle(new byte[4] { file1[i + 20], file1[i + 21], file1[i + 22], file1[i + 23] }, 0);
                float rotw = BitConverter.ToSingle(new byte[4] { file1[i + 24], file1[i + 25], file1[i + 26], file1[i + 27] }, 0);
                int id = BitConverter.ToInt32(new byte[4] { file1[i + 28], file1[i + 29], file1[i + 30], file1[i + 31] }, 0);
                Console.WriteLine("id : " + id + " pos x y z : " + x + " " + y + " " + z);
                if(id>0 && id < 10000)
                {
                    compteurvalid++;
                }
            }

            Console.WriteLine();
            int nboccurences = BitConverter.ToInt32(new byte[4] { file1[4], file1[5], file1[6], file1[7] }, 0);
            Console.WriteLine("nb occurences : " + nboccurences);
            Console.WriteLine("nb occ valides : " + compteurvalid);
            int nbparkedcars = BitConverter.ToInt32(new byte[4] { file1[20], file1[21], file1[22], file1[23] }, 0);
            Console.WriteLine("nb parked cars : " + nbparkedcars);
            Console.WriteLine("file lenght : " + file1.Length);
            int nboccverif = file1.Length / 40;
            Console.WriteLine("nb occurences verif  : " + nboccverif);
            

        }
        

    }
}
