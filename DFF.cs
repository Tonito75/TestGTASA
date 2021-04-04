using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tests
{
    public static class DFF
    {
        public static Random r = new Random();

        public static void analyse()
        {
            byte[] a = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/ambulan.dff");
            byte[] b = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/aprtmnts01_sfe.dff");
            byte[] c = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/arrow.dff");
            byte[] d = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/ballas3.dff");

            for(int i = 0; i < c.Length; i++)
            {
                if (i < 50)
                {
                    Console.Write(c[i] + " ");
                }
               
            }

            Console.WriteLine("\n\n");
            for (int i = 0; i < b.Length; i++)
            {
                if (i < 50)
                {
                    Console.Write(b[i] + " ");
                }

            }
            Console.WriteLine("\n\n");
            for (int i = 0; i < d.Length; i++)
            {
                if (i < 50)
                {
                    Console.Write(d[i] + " ");
                }

            }

            Console.WriteLine("\n\n");
            int w = BitConverter.ToInt32(new byte[4] { b[4], b[5], b[6], b[7] },0);
            Console.WriteLine("len : " + w);
        }
        public static void process()
        {
            byte[] file = File.ReadAllBytes("D:/Mod menu GTA SA/Saves/models/gta3.img");
            int cpt = 0;
            int i = 0;
            while (i < file.Length-100000)
            {
                if (has16000(i, file))
                {
                    int w = BitConverter.ToInt32(new byte[4] { file[4 + i], file[5 + i], file[6 + i], file[7 + i] }, 0);
                    if (w > 10000 && file[i+w-w/10]!=0)
                    {
                        cpt++;
                        int low = i;
                        int high = i + w;
                        int mid = low + (high - low) / 2;
                        int val = 10;

                        for (int j = mid - val; j < mid + val; j++)
                        {
                            if (file[j] != 255)
                            {
                                file[j] = (byte)(file[j] + 1);
                            }
                        }
                    }
                    i = i + w + 10000;
                }
                i++;
            }

            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta3.img", file);
            Console.WriteLine("16000 trouvés : " + cpt);
        }
        public static bool has16000(int i,byte[] file)
        {
            if (file[i] == 16 && file[i + 1] == 0 && file[i + 2] == 0 && file[i + 3] == 0 && file[i + 8] == 255 && file[i + 9] == 255
                && file[i+10] == 3 && file[i+11]==24 && file[i+12]==1 && file[i+13]==0 && file[i+14] == 0 && file[i+15] ==0
                && file[i + 16] == 12 && file[i+17]==0 && file[i+18] ==0 && file[i+19] == 0 && file[i+20] == 255 && file[i+21]==255
                && file[i+22] == 3 && file[i+23] == 24 &&file[i+24]==1
                && file[i+25] == 0 && file[i+26] == 0 && file[i+27] == 0 && file[i+28] == 0 && file[i+29] == 0 
                && file[i+30] == 0
                && file[i+31] == 0 && file[i+32] == 0 && file[i+33] == 0 && file[i+34] == 0 && file[i+35] == 0
                && file[i+36] == 14)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
