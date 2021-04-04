using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Tests
{
    public static class playerprocessing
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
        public static string gtaintvierge = "D:/Mod menu GTA SA/Saves/models/gta_int.img";
        public static string gtaint = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta_int.img";
        public static string playervierge = "DATA/models/player.img";
        public static string player = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/player.img";

        public static Random r = new Random();
        public static void process()
        {
            string read = gtaintvierge;
            string write = gtaint;
            byte[] file = File.ReadAllBytes(read);
            Console.WriteLine("staring process");
            int cpt9 = 0;
            int cpt22 = 0;
            int i = 0;
            
            int debpos = 0;
            int templen = 0;
            bool working = false;
            while (i < file.Length-4)
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
                        int val = len / 4 - 2000;

                        #region fordata
                        int a = 0;
                        int b = 100;
                        int c = 200;
                        int dim = 0;
                        double valsin = -val;
                        int reg = 0;
                        #endregion

                        for (int j = -val; j < val; j=j+4)
                        {
                            #region Data

                            if (reg == 0)
                            {
                                file[j + mid] = 0;
                                file[j + mid + 1] = 0;
                                file[j + mid + 2] = 0;
                                file[j + mid + 3] = 0;
                            }
                            if(reg == 1)
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
                                file[j + mid] = 255;
                                file[j + mid + 1] = 255;
                                file[j + mid + 2] = (byte)Convert.ToInt32(Scale(Math.Sin(valsin), -1, 1, 0, 255));
                                file[j + mid + 3] = 255;
                                if (dim % 15 == 0)
                                {
                                    a++;
                                    c++;
                                    b++;
                                }
                                dim++;
                                valsin = valsin + 0.1;
                            }
                            #endregion
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
        public static bool has22000(int i,byte[] file)
        {
            bool ok = true;
            for(int e = 0;e < test.Length; e++)
            {
                if(ok)
                {
                    if(test[e] !=33)
                    {
                        if(file[e+i] != test[e])
                        {
                            ok = false;
                        }
                    }
                }
            }
            return ok;
        }
        public static double Scale(double value, double min, double max, int minScale, int maxScale)
        {
            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            return scaled;
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
        public static bool hasEnd(int i,byte[] file)
        {
            if(file[i]==3 && file[i+1] == 0 && file[i+2] == 0 && file[i+3] == 0 && file[i+4] == 0 && file[i+5] == 0 && file[i+6] == 0 && file[i+7] == 0 && file[i+8] == 255 &&
                file[i+9] == 255 && file[i+10] == 3 && file[i+11] == 24 && file[i+12] == 21 && file[i+13] == 0 && file[i+14] == 0 && file[i+15] == 0 && file[i+20] == 255 && file[i+21] == 255 &&
                file[i+22] == 3 && file[i+23] == 24)
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
