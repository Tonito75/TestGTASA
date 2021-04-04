using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace Tests
{
    public static class Textures
    {
        public static string playerimg = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/player.img";
        public static Random r = new Random();
        public static void tryGetImage()
        {
            byte[] file = System.IO.File.ReadAllBytes("DATA/models/generic/wheels.txd");
            for(int i = 0; i < file.Length; i++)
            {
                byte[] tab = new byte[i];
                for(int j = 0; j < tab.Length; j++)
                {
                    tab[j] = file[i];
                }
                try
                {
                    Image.FromStream(new MemoryStream(tab));
                    Console.WriteLine("YESSSS");
                }
                catch
                {
                    Console.WriteLine("no " + i);
                }
            }
            
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
                        if (r.Next(0,20) == 0)
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
        public static string getstringfrombytettab(byte[] a)
        {
            string s = "";
            for(int i = 0; i < a.Length; i++)
            {
                string esp = "";
                int len = Convert.ToString(a[i]).Length;
                if(len == 1)
                {
                    esp = "  ";
                }
                if (len == 2)
                {
                    esp = " ";
                }
                if (len == 3)
                {
                    esp = "";
                }
                s = s + a[i] + esp + "-";
            }
            return s;
        }
        public static void analyseSingleTXD()
        {
            byte[] hydra = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/hydra.txd");
            int i = 0;
            while (i < hydra.Length)
            {
                if(hydra[i] == 22 && hydra[i+1]==0 && hydra[i+2]==0 && hydra[i + 3] == 0)
                {
                    TXD t = new TXD(i, hydra);
                    if(t.data == null)
                    {
                        Console.WriteLine("Echec de la création du txd");
                    }
                    else
                    {
                        Console.WriteLine("Réussite de la création du txd");
                        Console.WriteLine("------ TXD : ");
                        Console.WriteLine("len : " + t.len);

                    }
                   
                }
                i++;
            }
            
        }
        public static void AnalyseTXD()
        {
            byte[] file = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/indust1.txd");
            Console.WriteLine("---Finding 9 0 0 0");
            Console.WriteLine("\n");
            for(int i = 0; i < file.Length; i++)
            {
                if(file[i] == 9 && file[i+1] == 0 && file[i + 2] == 0 && file[i + 3] == 0)
                {
                    Console.WriteLine("Trouvé à " + i);
                }
            }
            Console.WriteLine("\n");
            //9-0-0-0 : indique image.
            Console.WriteLine("-----Finding lenghts of the chunks");
            Console.WriteLine("\n");
            for (int i = 0; i < file.Length-40; i++)
            {
               
                if (file[i] == 9 && file[i + 1] == 0 && file[i + 2] == 0 && file[i + 3] == 0)
                {
                    for(int j = -40; j < 4 ; j++)
                    {
                        Console.Write(file[j +i ] + "-");
                    }
                    Console.WriteLine("\n\n");
                }
               
            }
        }
        public static void ReadCol()
        {
            byte[] file = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/law_1.col") ;
            byte[] file2 = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/levelmap_1.col");
            Console.WriteLine("len law1" + file.Length);
            Console.WriteLine("len lvlmap" + file2.Length);

            int a = BitConverter.ToInt32(new byte[4] { file[4], file[5], file[6], file[7] }, 0);
            Console.WriteLine(a);
            //Console.WriteLine(getstringfrombytettab(file));
            //Console.WriteLine(getstringfrombytettab(file2));
            for(int i = 0; i < file.Length; i++)
            {
                if (has9000(i, file))
                {
                    Console.WriteLine("omg");
                }
            }
        }
        public static bool has22000(int i, byte[] file)
        {
            if (file[i] == 22 && file[i + 1] == 0 && file[i + 2] == 0 && file[i + 3] == 0 && file[i + 7] == 0 && file[i + 8] == 255 && file[i + 9] == 255)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public static byte[] readBFF()
        {
            int len = 40;
            byte[] rhino = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/capzip.txd");
            byte[] indust1 = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/indust1.txd");
            byte[] libertygen = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/libertygen.txd");
            byte[] vgsschurch = File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/vgsschurch.txd");
            byte[] hydra = System.IO.File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/hydra.txd");
            byte[] vgs_shops = System.IO.File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/vgs_shops.txd").Take(len).ToArray();
            byte[] vgsecoast = System.IO.File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/vgsecoast.txd").Take(len).ToArray();
            byte[] vgsefreight = System.IO.File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/vgsefreight.txd").Take(len).ToArray();
            byte[] cuntwrail02 = System.IO.File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/cuntwrail02.dff").Take(len).ToArray();
            byte[] lodlawnland = System.IO.File.ReadAllBytes("D:/Mod menu GTA SA/files rdm/lodlawnland.txd").Take(len).ToArray();
            //List<byte[]> list = new List<byte[]>();
            //list.Add(rhino);
            //list.Add(hydra);
            //list.Add(vgs_shops);
            //list.Add(vgsecoast);
            //list.Add(vgsefreight);
            //list.Add(vgsschurch);
            //list.Add(indust1);
            //list.Add(libertygen);

            byte[] templatecompute = new byte[len];

            for(int i = 0; i < len; i++)
            {
                if(rhino[i] == indust1[i] && indust1[i] == libertygen[i] && libertygen[i] == vgsschurch[i]
                    && vgsschurch[i] == hydra[i] && hydra[i] == vgs_shops[i] && vgs_shops[i] == vgsecoast[i]
                    && vgsecoast[i] == vgsefreight[i] /*&& cuntwrail02[i] == vgsefreight[i]*/ && lodlawnland[i]==vgsefreight[i])
                {
                    templatecompute[i] = rhino[i];
                }
                else
                {
                    templatecompute[i] = 33;
                }
            }
            //int cpt33 = 0;
            //for(int i = 0; i < templatecompute.Length; i++)
            //{
            //    if(templatecompute[i] == 33)
            //    {
            //        cpt33++;
            //    }
            //    Console.Write(templatecompute[i] + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(cpt33 + " dynamic / " + templatecompute.Length);
            //Console.WriteLine("template found.");
            //Console.WriteLine();
            //Console.WriteLine("finding sub chunks hydra :");
            //for(int i = 8372; i < 8372+50; i++)
            //{
            //    Console.Write(hydra[i] + "-");
            //}
            
            //byte[] array = new byte[4] { hydra[8372 + 4], hydra[8372 + 5], hydra[8372 + 6], hydra[8372 + 7] };
            //int chunk = BitConverter.ToInt32(array, 0);
            //Console.WriteLine("sub chunk size : " + chunk +". shoulb be arround " + (12596-8372));
            //Console.WriteLine();
            //Console.WriteLine();
            //for (int i = 12596; i < 12596+50; i++)
            //{
            //    Console.Write(hydra[i] + "-");
            //}




            //Console.WriteLine("finding sub chunks indust :");
            //for (int i = 164404; i < 164404 + 50; i++)
            //{
            //    Console.Write(indust1[i] + "-");
            //}
            //byte[] array2 = new byte[4] { indust1[164404 + 4], indust1[164404 + 5], indust1[164404 + 6], indust1[164404 + 7] };
            //Console.WriteLine("\n");
            
            //int chunk2 = BitConverter.ToInt32(array2, 0);
            //Console.WriteLine("sub chunk size : " + chunk2 + ". shoulb be arround " + (180916 - 164404));
            //Console.WriteLine();
            //for (int i = 180916; i < 180916 + 50; i++)
            //{
            //    Console.Write(indust1[i] + "-");
            //}
            //Console.WriteLine("----------------");
            //int tofind = 213940 - 197428;
            //for(int i = 0; i < indust1.Length-4; i++)
            //{
            //    byte[] array3 = new byte[4] { indust1[i], indust1[i+1], indust1[i+2], indust1[i+3] };
            //    if (BitConverter.ToInt32(array3, 0) < tofind+20 && BitConverter.ToInt32(array3, 0) > tofind - 20)
            //    {
            //        Console.WriteLine("found at : " + i);
            //    }
            //}
            return templatecompute;

        }
        public static bool AllEqual<T>(params T[] values)
        {
            if (values == null || values.Length == 0)
                return true;
            return values.All(v => v.Equals(values[0]));
        }

        public static int nbDiffs(byte[] a, byte[] b)
        {
            int cpt = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    cpt++;
                }
            }
            return cpt;
        }
        public static void testvehicleheaders()
        {
            byte[] file = System.IO.File.ReadAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.txd");
            //967 988
            //1 230 260

            int[] poss = new int[14] { 52, 65716, 98612, 164276, 426548, 492212, 508724, 574388, 640052, 705716, 967988, 1230260,1295924,1300148};

            for(int i = 0; i < poss.Length-1; i++)
            {
                int middle = poss[i] + ((poss[i + 1] - poss[i]) / 2);
                int val = (middle - poss[i]) -5000;
                int a = 0;
                int b = 100;
                int c = 200;
                int dim = 0;
                double valsin = -val;
                for(int j = -val; j < val; j=j+4)
                {
                    if(a == 255)
                    {
                        a = 0;
                    }
                    if (b == 255)
                    {
                        b = 0;
                    }
                    if (c ==255)
                    {
                        c = 0;
                    }
                    file[j + middle] = 255;
                    file[j + middle + 1] = 0;
                    file[j + middle +2] = (byte) Convert.ToInt32(Scale(Math.Sin(valsin),-1,1,0,255));
                    file[j + middle + 3] = 255;
                    if (dim % 2== 0)
                    {
                        a++;
                        c++;
                        b++;
                    }
                    dim++;
                    valsin = valsin + 0.05;
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
        public static void bitmaptest()
        {
            byte[] file = System.IO.File.ReadAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/wheels.txd");
            Console.WriteLine("Lenght of file : " + file.Length);
            Console.WriteLine();
            for(int i = 0; i < 20; i++)
            {
                Console.Write(file[52 + i] +"-");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < 20; i++)
            {
                Console.Write(file[2228 + i] + "-");
            }
            Console.WriteLine("\n----------------");
            Console.WriteLine("\nFind smth arround 2176 :");
            for (int i = 0; i < 20; i++)
            {
                byte[] array = new byte[4] { file[52 + i], file[53 + i], file[54 + i], file[55 + i] };
                Console.WriteLine(BitConverter.ToInt32(array, 0));
            }
            Console.WriteLine("-----------");
            Console.WriteLine("Identifying headers : ");
            List<int> list = new List<int>();
            for(int i = 0; i < file.Length - 4; i++)
            {
                if(file[i]==8 && file[i+1] == 0 && file[i+2] == 0 && file[i+3] == 0 && file[i+4]==1 && file[i+5]==17)
                {
                    Console.WriteLine("header found at pos " + i);
                    list.Add(i);
                }
            }
            Console.WriteLine("\n\n-----------");
            Console.WriteLine("Finding positions : ");
            int[] posint = new int[list.Count];
            for(int i = 0; i < posint.Length; i++)
            {
                posint[i] = list[i];
                Console.WriteLine(posint[i]);
            }
            Console.WriteLine("\n\n-----------");
            Console.WriteLine("Changing values");
            int mid = (posint[1]-posint[0])/2;
            Console.WriteLine("mid : " + mid);
            for(int i = 0; i < posint.Length; i++)
            {
                posint[i] = posint[i] - mid;
            }
            Console.WriteLine("new posint :");
            for (int i = 0; i < posint.Length; i++)
            {
                Console.WriteLine(posint[i]);
            }
            Console.WriteLine("modifs en cours...");
            int cpt = 1;
            Console.WriteLine("filelenght : " + file.Length);
            for (int i = 0; i < file.Length; i++)
            {
                if (cpt < posint.Length)
                {
                    if (i == posint[cpt])
                    {
                        Console.WriteLine("----> Une modif");
                        cpt++;
                        for (int j = -700; j < 700; j++)
                        {
                            file[i + j] = (byte)r.Next(0, 255);
                        }
                    }
                }
                
            }
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/wheels.txd", file);


            // Console.WriteLine(file[52] +":"+ file[53] + "-" + file[2228]+":"+ file[2229] + "-" + file[4404] +":"+ file[4405]);

        }
        public static void RandomGTA3()
        {
            int cpt = 0;
            byte[] file = System.IO.File.ReadAllBytes("DATA/models/gta3.img");
            Console.WriteLine("lenght : " + file.Length);


            int a = 0;
            for (int i = 0; i < file.Length; i++)
            {
                if (i % 10000000 == 0)
                {
                    Console.WriteLine(i + "/" + file.Length);
                }
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
                    int uncpt = 0;
                    for (int y = -10; y < 10; y++)
                    {
                        if (file[i + y] == 1)
                        {
                            uncpt++;
                        }
                    }
                    if (zerocpt < 2 && uncpt <2)
                    {
                        if (r.Next(0, 5000) == 50)
                        {
                            if (file[i] > 200)
                            {
                                file[i] = (byte)r.Next(100, 255);
                                //Console.Write("-" + file[i] + "-");
                                cpt++;
                            }
                           

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
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta3.img", file);
        }
        public static void RandomVehicleTXD()
        {
            int cpt = 0;
            byte[] file = System.IO.File.ReadAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.dff");
            Console.WriteLine("lenght : " + file.Length);
            int a = 0;
            int[] tab = new int[256];
            foreach(int i in tab)
            {
                tab[i] = 0;
            }
            for (int i = 0; i < file.Length; i++)
            {
                if (i > 100 && i < file.Length - 100)
                {
                    
                    
                }
            }
            Console.WriteLine("modif : " + cpt);
            for(int o = 0; o < tab.Length; o++)
            {
                Console.WriteLine(o + " nb : " + tab[o]);
            }
                
            
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.txd", file);
        }
        public static void wheelssegements()
        {
            int cpt = 0;
            int tmp = 0;
            int modif = 0;
            byte[] file = System.IO.File.ReadAllBytes("DATA/models/generic/vehicle.txd");
            Console.WriteLine("lenght : " + file.Length);
            List<byte> total = new List<byte>();
            bool seg = false;
            int segment = 0;
            for (int i = 0; i < file.Length; i++)
            {
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




                    if (zerocpt > 7)
                    {
                        //Console.ForegroundColor = ConsoleColor.Red;
                        total.Add(file[i]);
                        seg = true;
                    }
                    else//segment de data 
                    {
                        if(seg)
                        {
                            if (tmp < 70)
                            {
                                total.Add(file[i]);
                                tmp++;
                            }
                            else
                            {
                                segment++;
                                List<byte> newseg = new List<byte>();
                                for (int d = 0; d < 10; d++)
                                {
                                    newseg.Add((byte)2);
                                }
                                //total.AddRange(newseg);
                                total.Add((byte)r.Next(2, 2));
                                //modif++;
                                //Console.ForegroundColor = ConsoleColor.Blue;
                                seg = false;
                                tmp = 0;
                            }
                            
                        }
                        else
                        {
                            total.Add(file[i]);
                        }
                        
                    }
                }
                else
                {
                    total.Add(file[i]);
                }
                
                //Console.Write(file[i]);


                //if (r.Next(0, 5000) == 20)
                //{
                //    file[i] = (byte)r.Next(0, 1);
                //}
            }
            Console.WriteLine("modif : " + modif);
            byte[] finalbytetab = new byte[total.Count];
            for (int y = 0; y < total.Count; y++)
            {
                finalbytetab[y] = total[y];
            }
            Console.WriteLine("original byte lenght : " + file.Length);
            Console.WriteLine("new byte lenght : " + finalbytetab.Length);
            Console.WriteLine("nb segments : " + segment);
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/generic/vehicle.txd",finalbytetab);
        }
        public static void Testbytetostring()
        {
            byte[] file = System.IO.File.ReadAllBytes("DATA/models/generic/vehicle.txd");
            string result = System.Text.Encoding.UTF8.GetString(file);
            Console.WriteLine(result);
        }
        public static void hud()
        {

            byte[] file = System.IO.File.ReadAllBytes("DATA/models/hud.txd");
            Console.WriteLine(file.Length);
            for (int i = 0; i < file.Length; i++)
            {
                Console.Write(file[i]);
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
                    if (zerocpt < 14)
                    {
                        if (r.Next(0, 100) == 0)
                        {
                            file[i] = (byte)r.Next(0, 5);
                        }

                    }
                }


                //if (r.Next(0, 5000) == 20)
                //{
                //    file[i] = (byte)r.Next(0, 1);
                //}
            }

            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta3.img", file);
        }
        public static void debughud()
        {
            byte[] file = System.IO.File.ReadAllBytes("DATA/models/hud.txd");
            byte[] file2 = System.IO.File.ReadAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/hud.txd");
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] != file2[i])
                {
                    Console.WriteLine("diff at ligne : " + i);
                }
            }
        }
    }
}
