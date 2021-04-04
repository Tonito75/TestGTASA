using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Saves
    {
        public static byte[] test = Textures.readBFF();
        public static string gta3vierge = "DATA/models/gta3.img";
        public static string gta3 = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta3.img";
        public static string vehiclevierge = "DATA/models/generic/vehicle.txd";
        public static string vehicle = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.txd";
        public static string wheelsvierge = "DATA/models/generic/wheels.txd";
        public static string wheels = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/wheels.txd";
        public static string cutscenevierge = "DATA/models/cutscene.img";
        public static string cutscene = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/cutscene.img";

        public static string playervierge = "DATA/models/player.img";
        public static string player = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/player.img";
        public static Random r = new Random();
        public static void ColorsVehicleTXD()
        {
            byte[] file = System.IO.File.ReadAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.txd");
            //967 988
            //1 230 260

            int[] poss = new int[14] { 52, 65716, 98612, 164276, 426548, 492212, 508724, 574388, 640052, 705716, 967988, 1230260, 1295924, 1300148 };

            for (int i = 0; i < poss.Length - 1; i++)
            {
                //Console.WriteLine(i);
                Console.WriteLine("pos i+1 : " + poss[i] + " ; pos i : " + poss[i + 1]);
                int middle = poss[i] + ((poss[i + 1] - poss[i]) / 2);
                Console.WriteLine("middle : " + middle);
                int val = (middle - poss[i]) - 5000;
                Console.WriteLine("val : " + val);
                for (int j = -val; j < val; j++)
                {
                    //Console.WriteLine("index file : " + j + middle);
                    file[j + middle] = (byte)r.Next(0, 255);
                }
                Console.WriteLine("-----------------");
            }
            #region olddata
            //int mid = 967988+((1230260 - 967988)/2);
            //for(int j = 0; j < file.Length; j++)
            //{
            //    if (j== mid)
            //    {
            //        Console.WriteLine("modify arround index : " + j);
            //        for (int i = -90000; i < 90000; i++)
            //        {
            //            file[i + j] = (byte)r.Next(0,255);
            //        }
            //    }

            //}
            ////phares
            ////574388
            ////640052
            ////705716
            //mid = 574388 + ((640052 - 574388) / 2);
            //for (int j = 0; j < file.Length; j++)
            //{
            //    if (j == mid)
            //    {
            //        Console.WriteLine("modify arround index : " + j);
            //        for (int i = -30000; i < 30000; i++)
            //        {
            //            file[i + j] = (byte)r.Next(0, 255);
            //        }
            //    }

            //}
            //mid = 640052 + ((705716 - 640052) / 2);
            //for (int j = 0; j < file.Length; j++)
            //{
            //    if (j == mid)
            //    {
            //        Console.WriteLine("modify arround index : " + j);
            //        for (int i = -30000; i < 30000; i++)
            //        {
            //            file[i + j] = (byte)r.Next(0, 255);
            //        }
            //    }

            //}
            //mid = 705716 + ((967988 - 705716) / 2);
            //for (int j = 0; j < file.Length; j++)
            //{
            //    if (j == mid)
            //    {
            //        Console.WriteLine("modify arround index : " + j);
            //        for (int i = -60000; i < 60000; i++)
            //        {
            //            file[i + j] = (byte)r.Next(0, 255);
            //        }
            //    }

            //}
            #endregion
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.txd", file);
        }
        public static double Scale(double value, double min, double max, int minScale, int maxScale)
        {
            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            return scaled;
        }
        public static void RandomPlayer()
        {
            int cpt = 0;
            byte[] file = System.IO.File.ReadAllBytes("DATA/models/player.img");
            Console.WriteLine("lenght : " + file.Length);


            int a = 0;
            for (int i = 0; i < file.Length; i++)
            {
                //Console.Write(file[i]);
                if (i > 100 && i < file.Length - 100)
                {
                    int zerocpt = 0;
                    for (int y = -10; y < 10; y++)
                    {
                        if (file[i + y] == 0)
                        {
                            zerocpt++;
                        }
                    }
                    if (zerocpt < 3)
                    {
                        if (r.Next(0, 50) == 0)
                        {
                            file[i] = (byte)r.Next(0, 9);
                            cpt++;
                        }
                    }
                    else
                    {
                        a = 0;
                    }
                }


                //if (r.Next(0, 5000) == 20)
                //{
                //    file[i] = (byte)r.Next(0, 1);
                //}
            }
            Console.WriteLine("modif : " + cpt);
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/player.img", file);
        }
        public static void Carsfromhell()
        {
            byte[] file = System.IO.File.ReadAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.txd");
            //967 988
            //1 230 260

            int[] poss = new int[14] { 52, 65716, 98612, 164276, 426548, 492212, 508724, 574388, 640052, 705716, 967988, 1230260, 1295924, 1300148 };

            for (int i = 0; i < poss.Length - 1; i++)
            {
                int middle = poss[i] + ((poss[i + 1] - poss[i]) / 2);
                int val = (middle - poss[i]) - 5000;
                int a = 0;
                int b = 100;
                int c = 200;
                int dim = 0;
                double valsin = -val;
                for (int j = -val; j < val; j = j + 4)
                {
                    if (a == 255)
                    {
                        a = 0;
                    }
                    if (b == 255)
                    {
                        b = 0;
                    }
                    if (c == 255)
                    {
                        c = 0;
                    }
                    file[j + middle] = 0;
                    file[j + middle + 1] = 0;
                    file[j + middle + 2] = (byte)Convert.ToInt32(Scale(Math.Sin(valsin), -1, 1, 0, 255));
                    file[j + middle + 3] = 0;
                    if (dim % 15 == 0)
                    {
                        a++;
                        c++;
                        b++;
                    }
                    dim++;
                    valsin = valsin + 0.1;
                }
                Console.WriteLine("-----------------");
            }
            #region olddata
            //int mid = 967988+((1230260 - 967988)/2);
            //for(int j = 0; j < file.Length; j++)
            //{
            //    if (j== mid)
            //    {
            //        Console.WriteLine("modify arround index : " + j);
            //        for (int i = -90000; i < 90000; i++)
            //        {
            //            file[i + j] = (byte)r.Next(0,255);
            //        }
            //    }

            //}
            ////phares
            ////574388
            ////640052
            ////705716
            //mid = 574388 + ((640052 - 574388) / 2);
            //for (int j = 0; j < file.Length; j++)
            //{
            //    if (j == mid)
            //    {
            //        Console.WriteLine("modify arround index : " + j);
            //        for (int i = -30000; i < 30000; i++)
            //        {
            //            file[i + j] = (byte)r.Next(0, 255);
            //        }
            //    }

            //}
            //mid = 640052 + ((705716 - 640052) / 2);
            //for (int j = 0; j < file.Length; j++)
            //{
            //    if (j == mid)
            //    {
            //        Console.WriteLine("modify arround index : " + j);
            //        for (int i = -30000; i < 30000; i++)
            //        {
            //            file[i + j] = (byte)r.Next(0, 255);
            //        }
            //    }

            //}
            //mid = 705716 + ((967988 - 705716) / 2);
            //for (int j = 0; j < file.Length; j++)
            //{
            //    if (j == mid)
            //    {
            //        Console.WriteLine("modify arround index : " + j);
            //        for (int i = -60000; i < 60000; i++)
            //        {
            //            file[i + j] = (byte)r.Next(0, 255);
            //        }
            //    }

            //}
            #endregion
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.txd", file);
        }
        public static void process()
        {
            string read = gta3vierge;
            string write = gta3;

            List<int> debuglen = new List<int>();

            byte[] file = File.ReadAllBytes(read);
            Console.WriteLine("staring process");
            int cpt = 0;
            int i = 0;

            List<int> poss = new List<int>();
            List<int> type = new List<int>();
            while (i < file.Length - 4)
            {
                if (has22000(i, file)) // des que y' a 22 0 0 0 -> début d une serie de txd
                {
                    int len = BitConverter.ToInt32(new byte[4] { file[i + 4], file[i + 5], file[i + 6], file[i + 7] }, 0); //taille du txd
                    debuglen.Add(len);
                    List<int> index = new List<int>();
                    for (int a = i; a < i + len; a++)
                    {
                        if (has9000(a, file)) //9 0 0 0 -> début d'une image
                        {
                            cpt++;
                            index.Add(a);   //on ajoute d'index. EX : 52 , 2000 , 3000 -> une image démarre a chacun de ces index

                        }
                    }
                    if (index.Count == 1)
                    {
                        index.Add(i + len); // is y un qu'un txd, l'index sup est la longueur de l image
                    }
                    if (len > 3000)
                    {
                        //index.RemoveAt(index.Count - 1);
                        for (int s = 1; s < index.Count; s++)
                        {
                            int l = index.ElementAt(s) - index.ElementAt(s - 1); //on trouve la longueurentre les index qui def l'image

                            if (l > 1000) //on réduit au cas ou, pour pas toucher au header
                            {
                                int posmid = index.ElementAt(s - 1) + l / 2; //pos réelle du middle
                                //Console.WriteLine(index.ElementAt(s-1) +  " : pos mid : " + posmid + " - l : " +l );
                                double vald = l / 5;
                                //Console.WriteLine("vald : " + vald);
                                int val = (int)Math.Round(vald);

                                int a = 0;
                                int b = 100;
                                int c = 200;
                                int dim = 0;
                                double valsin = -val;
                                int r = 2;
                                for (int j = posmid - val; j < posmid + val - 4; j = j + 4)
                                {
                                    #region Data process
                                    if (r == 1)
                                    {
                                        if (a == 255)
                                        {
                                            a = 0;
                                        }
                                        if (b == 255)
                                        {
                                            b = 0;
                                        }
                                        if (c == 255)
                                        {
                                            c = 0;
                                        }
                                        file[j] = 0;
                                        file[j + 1] = 0;
                                        file[j + 2] = (byte)Convert.ToInt32(Scale(Math.Sin(valsin), -1, 1, 0, 255));
                                        file[j + 3] = 0;
                                        if (dim % 15 == 0)
                                        {
                                            a++;
                                            c++;
                                            b++;
                                        }
                                        dim++;
                                        valsin = valsin + 0.1;
                                    }
                                    if (r == 2)
                                    {
                                        file[j] = 255;
                                        file[j + 1] = 0;
                                        file[j + 2] = 0;
                                        file[j + 3] = 255;
                                    }
                                    #endregion

                                }
                            }
                            else
                            {
                                //Console.WriteLine("non");
                            }

                        }
                    }

                    i = i + len;
                }
                i++;
            }
            foreach (int a in debuglen)
            {
                if (a < 1000)
                {
                    Console.WriteLine("chelou : " + a);
                }
            }

            Console.WriteLine("9000 detected : " + cpt);
            Console.WriteLine("Writing bytes...");
            File.WriteAllBytes(write, file);
        }
        public static void processfast()
        {
            string read = gta3vierge;
            string write = gta3;



            byte[] file = File.ReadAllBytes(read);
            Console.WriteLine("staring process");
            int cpt9 = 0;
            int cpt22 = 0;
            int i = 0;

            int debpos = 0;
            int templen = 0;
            bool working = false;
            while (i < file.Length - 4)
            {
                if (i % 1000000 == 0)
                {
                    Console.WriteLine(i + "/" + file.Length);
                }


                if (has9000(i, file))
                {
                    working = true;
                    debpos = i;
                }
                if (hasEnd(i, file))
                {
                    if (!working)
                    {

                    }
                    else
                    {
                        int len = i - debpos;
                        int mid = (int)(debpos + (double)len / 2);
                        int val = len / 5;
                        for (int j = -val; j < val; j=j+4)
                        {
                            file[j + mid] = 255;
                            file[j + mid +1] = 0;
                            file[j + mid +2] = 0;
                            file[j + mid +3] = 255;
                        }
                        working = false;
                        debpos = 0;
                        templen = 0;
                    }

                }
                if (templen > 10000000)
                {
                    working = false;
                    templen = 0;
                }
                templen++;
                i++;
            }

            Console.WriteLine("22000 detected : " + cpt22);
            Console.WriteLine("9000 detected : " + cpt9);
            Console.WriteLine("Writing bytes...");
            File.WriteAllBytes(write, file);
        }
        public static void processDFF()
        {
            byte[] file = File.ReadAllBytes("D:/Mod menu GTA SA/Saves/models/gta3.img");
            int cpt = 0;
            int i = 0;
            while (i < file.Length - 100000)
            {
                if (has16000(i, file))
                {
                    int w = BitConverter.ToInt32(new byte[4] { file[4 + i], file[5 + i], file[6 + i], file[7 + i] }, 0);
                    if (w > 10000)
                    {
                        cpt++;
                        int low = i;
                        int high = i + w;
                        int mid = low + (high - low) / 2;
                        int val = w / 1000;

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
        public static bool has16000(int i, byte[] file)
        {
            if (file[i] == 16 && file[i + 1] == 0 && file[i + 2] == 0 && file[i + 3] == 0 && file[i + 8] == 255 && file[i + 9] == 255
                && file[i + 10] == 3 && file[i + 11] == 24 && file[i + 12] == 1 && file[i + 13] == 0 && file[i + 14] == 0 && file[i + 15] == 0
                && file[i + 16] == 12 && file[i + 17] == 0 && file[i + 18] == 0 && file[i + 19] == 0 && file[i + 20] == 255 && file[i + 21] == 255
                && file[i + 22] == 3 && file[i + 23] == 24 && file[i + 24] == 1
                && file[i + 25] == 0 && file[i + 26] == 0 && file[i + 27] == 0 && file[i + 28] == 0 && file[i + 29] == 0
                && file[i + 30] == 0
                && file[i + 31] == 0 && file[i + 32] == 0 && file[i + 33] == 0 && file[i + 34] == 0 && file[i + 35] == 0
                && file[i + 36] == 14)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool has22000(int i, byte[] file)
        {
            bool ok = true;
            for (int e = 0; e < test.Length; e++)
            {
                if (ok)
                {
                    if (test[e] != 33)
                    {
                        if (file[e + i] != test[e])
                        {
                            ok = false;
                        }
                    }
                }
            }
            return ok;
        }
       
        public static bool has9000(int i, byte[] file)
        {
            if (file[i] == 9 && file[i + 1] == 0 && file[i + 2] == 0 && file[i + 3] == 0 && file[i + 5] == 17 && file[i + 6] == 0 && file[i + 7] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool hasEnd(int i, byte[] file)
        {
            if (file[i] == 3 && file[i + 1] == 0 && file[i + 2] == 0 && file[i + 3] == 0 && file[i + 4] == 0 && file[i + 5] == 0 && file[i + 6] == 0 && file[i + 7] == 0 && file[i + 8] == 255 &&
                file[i + 9] == 255 && file[i + 10] == 3 && file[i + 11] == 24 && file[i + 12] == 21 && file[i + 13] == 0 && file[i + 14] == 0 && file[i + 15] == 0 && file[i + 20] == 255 && file[i + 21] == 255 &&
                file[i + 22] == 3 && file[i + 23] == 24)
            {
                return true;
            }
            else
            {
                return false;
            }



            //byte[] tab = new byte[] { 3, 0, 0, 0, 0, 0, 0, 0, 255, 255, 3, 24,21,0,0,0,33,33,33,33,255,255,3,24 };
            //bool ok = true;
            //for(int id = 0; id < tab.Length; id++)
            //{
            //    if (ok)
            //    {
            //        if (tab[id] != 33)
            //        {
            //            if (tab[id] != file[id + i])
            //            {
            //                ok = false;
            //            }
            //        }

            //    }
            //}
            //return ok;
        }
    }
}
