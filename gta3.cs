using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tests
{
    public static class gta3
    {
        public static int[] template = { 22,0,0,0,33,33,33,33,255,255,3,24,1,0,0,0,4,0,0,0,255,255,3,24,
                                                33,0,2,0,21,0,0,0,33,33,0,0,255,255,3,24,1,0,0,0,33,33,0,0,255,255,3,24,9,0,0,0,
                                                33,33,0,0,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,
                                                33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33
        ,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,33,68,88,84,0,33,33,33,33,16,33,4,33,0,33,0,0};
        public static Random r = new Random();
        public static string pathvierge = "DATA/models/gta3.img";
        public static string path = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta3.img";
        public static void setRhino()
        {
            byte[] rhino = System.IO.File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/rhino.txd");
            int testlen = 200;
            byte[] headerrhino = new byte[testlen];
            for (int i = 0; i < testlen; i++)
            {
                headerrhino[i] = rhino[i];
            }

            Console.WriteLine("starting...");
            //List<TXD> txds = new List<TXD>();
            byte[] file = File.ReadAllBytes(pathvierge);
            int cpt = 0;
            for(int i = 0; i < file.Length; i++)
            {
                bool ok = true;
                for(int c = 0; c < testlen; c++)
                {
                    if(headerrhino[c] != file[i + c])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    cpt++;
                    int len = BitConverter.ToInt32(new byte[4] { file[i + 4], file[i + 5], file[i + 6], file[i + 7] }, 0);
                    Console.WriteLine(len);
                    int mid = i + len / 2;
                    int datalow = i;
                    int datahigh = i + len;
                    int val = len/4;
                    for (int j = -val; j < val; j=j+4)
                    {
                        file[mid + j] = 255;
                        file[mid + j +1] = 0;
                        file[mid + j +2] = 0;
                        file[mid + j +3] = 255;
                    }
                }
                
            }
            Console.WriteLine("headers trouvés : " + cpt);
            Console.WriteLine("writing changes...");
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta3.img", file);
        }
        public static void setAllTXD()
        {
            byte[] file = System.IO.File.ReadAllBytes("DATA/models/gta3.img");
            int cpt = 0;
            int modifrefusées = 0;
            int modifs = 0;
            for(int i = 0; i < file.Length; i++)
            {
                if (i % 100000000 == 0)
                {
                    Console.WriteLine(i);
                }
                bool ok = true;
                for (int c = 0; c < template.Length; c++)
                {
                    if (template[c] != file[i + c] && template[c] !=33)
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    

                    int len = BitConverter.ToInt32(new byte[4] { file[i + 4], file[i + 5], file[i + 6], file[i + 7] }, 0);
                    if (len > 20000)
                    {
                        cpt++;
                        int mid = i + len / 2;
                        int datalow = i;
                        int datahigh = i + len;
                        int val = 100;
                        for (int j = -val; j < val; j++)
                        {
                            if(file[mid + j] != 0)
                            {
                                file[mid + j] = (byte)r.Next(0, 255);
                                modifs++;
                            }
                            else
                            {
                                modifrefusées++;
                            }
                        }
                    }
                    
                    
                }
            }
            Console.WriteLine("TXD founds : " + cpt);
            Console.WriteLine("modif refusées : " + modifrefusées);
            Console.WriteLine("modif : " + modifs);
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta3.img", file);
        }
        public static void setObjects()
        {
            Console.WriteLine("debut gta3.setobjects");
            byte[] file = File.ReadAllBytes(pathvierge);
            int cpt = 0;
            int i = 0;
            while (i < file.Length)
            {
                if (file[i] == 98 && file[i + 1] == 110 && file[i + 2] == 114 && file[i + 3] == 121)
                {
                    int nboccurences = BitConverter.ToInt32(new byte[4] { file[i+4], file[i+5], file[i+6], file[i+7] }, 0);
                    for(int j = i + 19*4 ; j < i + nboccurences * 40; j = j + 40)
                    {
                        int id = BitConverter.ToInt32(new byte[4] { file[j + 28], file[j + 29], file[j + 30], file[j + 31] }, 0);
                        if(id==1333)
                        {
                            float x = BitConverter.ToSingle(new byte[4] { file[j], file[j + 1], file[j + 2], file[j + 3] }, 0);
                            float y = BitConverter.ToSingle(new byte[4] { file[j + 4], file[j + 5], file[j + 6], file[j + 7] }, 0);
                            float z = BitConverter.ToSingle(new byte[4] { file[j + 8], file[j + 9], file[j + 10], file[j + 11] }, 0);
                            Console.WriteLine("id : " + id + " pos x y z : " + x + " " + y + " " + z);
                            byte[] bytes = BitConverter.GetBytes(1333);
                            Console.WriteLine(bytes.Length);


                        }
                       
                        
                    }
                    cpt++;
                }
                i++;
            }
           
            Console.WriteLine("ipl trouvés ; " + cpt);
        }
    }
}
