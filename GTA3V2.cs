using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tests
{
    public static class GTA3V2
    {
        public static Random r = new Random();
        public static string pathvierge = "DATA/models/gta3.img";
        public static string path = "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/gta3.img";
        public static void Analyse()
        {
            byte[] file = File.ReadAllBytes(path);
            Console.WriteLine("-----------");
            Console.WriteLine("Header");
            Console.WriteLine("-----------");

            byte[] data = new byte[4];
            data[0] = file[0];
            data[1] = file[1];
            data[2] = file[2];
            data[3] = file[3];
            string text = BitConverter.ToString(data, 0);
            Console.WriteLine("VER2 : " + text);
            int nboccgta3 = BitConverter.ToInt32(new byte[4] { file[4], file[5], file[6], file[7] }, 0);
            Console.WriteLine("nb occurences : " + nboccgta3);

            Console.WriteLine("-----------");

            Console.WriteLine("-----------");
            Console.WriteLine("Directory entries");
            Console.WriteLine("-----------");
            int i = 8;
            bool cond = true;
            int cpt = 0;
            while(i<file.Length && cond)
            {
                cpt++;
                int offset = bytetoint32(file, i) * 2048;
                i = i + 4;
                int streamingsize = BitConverter.ToInt16(new byte[2] { file[i], file[i + 1] }, 0);
                Console.WriteLine("streamingsize : " + streamingsize);
                i = i + 2;
                int sizezero = BitConverter.ToInt16(new byte[2] { file[i], file[i + 1] }, 0);
                i = i + 2;
                
                string name = "";
                for(int g = 0; g < 24; g=g+4)
                {
                    name = name + bytetostring(file, i);
                    i = i + 4;
                }
                Console.WriteLine("File name : " + name + " offset : " + offset);
                if (name.Contains("levelmap_stream0") && i>10000)
                {
                    cond = false;
                    Console.WriteLine("dernier entry : " + i);
                }
                //Console.WriteLine(bytetostring(file, offset));
            }
            

        }
        public static void replaceIPL()
        {
            byte[] file = File.ReadAllBytes(pathvierge);
            int offset = bytetoint32(file, 8) * 2048;
            int streamingsize = BitConverter.ToInt16(new byte[2] { file[12], file[13] }, 0);
            int len = streamingsize * 2048;
            int lgheader = 19 * 4;
            int lgobj = 40 * 4;

            int nbinstances = GTA3V2.bytetoint32(file, offset + 4);


            file[offset + 6 * 4] = 0; //nb parked cars
            file[offset + 6 * 4 +1] = 0;
            file[offset + 6 * 4 +2] = 0;
            file[offset + 6 * 4 +3] = 0;

            file[offset + 16 * 4] = 0; //offset parked cars
            file[offset + 16 * 4 + 1] = 0;
            file[offset + 16 * 4 + 2] = 0;
            file[offset + 16 * 4 + 3] = 0;

            int bytesdispo = (2048 * 4) - (19 * 4);

            for (int i = offset + 19 * 4; i < offset + nbinstances * 40; i = i + 40)
            {
                byte[] bytes = BitConverter.GetBytes(1333);
                file[i + 28] = bytes[0];
                file[i + 29] = bytes[1];
                file[i + 30] = bytes[2];
                file[i + 31] = bytes[3];

                //posx
                bytes = BitConverter.GetBytes((float)r.Next(-2015, -1983));

                file[i] = bytes[0];
                file[i + 1] = bytes[1];
                file[i + 2] = bytes[2];
                file[i + 3] = bytes[3];

                //posy
                bytes = BitConverter.GetBytes((float)r.Next(108, 232));
                file[i + 4] = bytes[0];
                file[i + 5] = bytes[1];
                file[i + 6] = bytes[2];
                file[i + 7] = bytes[3];

                //posz
                bytes = BitConverter.GetBytes((float)28);
                file[i + 8] = bytes[0];
                file[i + 9] = bytes[1];
                file[i + 10] = bytes[2];
                file[i + 11] = bytes[3];

                bytes = BitConverter.GetBytes((float)0);
                file[i + 12] = bytes[0];
                file[i + 13] = bytes[1];
                file[i + 14] = bytes[2];
                file[i + 15] = bytes[3];

                //rotw
                bytes = BitConverter.GetBytes((float)0);
                file[i + 16] = bytes[0];
                file[i + 17] = bytes[1];
                file[i + 18] = bytes[2];
                file[i + 19] = bytes[3];

                //rotx
                bytes = BitConverter.GetBytes((float)0);
                file[i + 20] = bytes[0];
                file[i + 21] = bytes[1];
                file[i + 22] = bytes[2];
                file[i + 23] = bytes[3];

                //rotw
                bytes = BitConverter.GetBytes((float)1);
                file[i + 24] = bytes[0];
                file[i + 25] = bytes[1];
                file[i + 26] = bytes[2];
                file[i + 27] = bytes[3];

                file[i + 32] = 0;
                file[i + 33] = 0;
                file[i + 34] = 0;
                file[i + 35] = 0;

                file[i + 36] = 255;
                file[i + 37] = 255;
                file[i + 38] = 255;
                file[i + 39] = 255;
            }

            File.WriteAllBytes(path, file);

        }
        public static void debug()
        {
            byte[] file = File.ReadAllBytes(path);
            for(int i = 0; i < file.Length; i=i+4)
            {
                Console.WriteLine(write(file, i) + "-" + bytetostring(file, i));
            }
        }
        public static byte[] get4bytes(byte[] file,int index)
        {
            return new byte[4] { file[index], file[index + 1], file[index + 2], file[index + 3] };
        }
        public static byte[] get2bytes(byte[] file, int index)
        {
            return new byte[2] { file[index], file[index + 1] };
        }
        public static string write(byte[] file, int index)
        {
            return file[index] + " " + file[index + 1] + " " + file[index + 2] + " " + file[index + 3];
        }
        public static string bytetorawstring(byte[] file, int index)
        {
            return BitConverter.ToString(new byte[4] { file[index], file[index + 1], file[index + 2], file[index + 3] }, 0);
        }
        public static string tosingle(byte[] file, int index)
        {
            return BitConverter.ToSingle(new byte[4] { file[index], file[index + 1], file[index + 2], file[index + 3] }, 0).ToString();
        }
        public static string bytetostring(byte[] file, int index)
        {
            return "" + Convert.ToChar(file[index]) +  Convert.ToChar(file[index + 1]) + Convert.ToChar(file[index + 2]) + Convert.ToChar(file[index + 3]) + "";
        }
        public static int bytetoint32(byte[] file, int index)
        {
            return BitConverter.ToInt32(new byte[4] { file[index], file[index + 1], file[index + 2], file[index + 3] }, 0);
        }
       
        public static byte[] createIPL()
        {
            List<byte> l = new List<byte>();

            int nbobj = 1000;

            l.Add(98);
            l.Add(110);
            l.Add(114);
            l.Add(121); //bnry

            byte[] b = new byte[4];
            b = BitConverter.GetBytes(nbobj);
            l.Add(b[0]);
            l.Add(b[1]);
            l.Add(b[2]);
            l.Add(b[3]);

            for(int i = 0; i < 4 * 5; i++) //unknowns
            {
                l.Add(0);
            }
            l.Add(76);
            l.Add(0);
            l.Add(0);
            l.Add(0);

            for(int i = 0; i < 11 * 4 ; i++)
            {
                l.Add(0);
            }
            //FIN HEADER

            int[] ids = new int[7] { 1333, 1370, 1331, 1334, 910, 1236, 1365 };

            

            for(int i = 0; i < nbobj; i++)
            {
                //x
                b = BitConverter.GetBytes((float)r.Next(-2256, -1741));
                l.Add(b[0]);
                l.Add(b[1]);
                l.Add(b[2]);
                l.Add(b[3]);

                //y
                b = BitConverter.GetBytes((float)r.Next(-195, 356));
                l.Add(b[0]);
                l.Add(b[1]);
                l.Add(b[2]);
                l.Add(b[3]);
                //z
                b = BitConverter.GetBytes((float)r.Next(28, 50));
                l.Add(b[0]);
                l.Add(b[1]);
                l.Add(b[2]);
                l.Add(b[3]);
                //rotx
                b = BitConverter.GetBytes((float)0);
                l.Add(b[0]);
                l.Add(b[1]);
                l.Add(b[2]);
                l.Add(b[3]);
                //roty
                b = BitConverter.GetBytes((float)0);
                l.Add(b[0]);
                l.Add(b[1]);
                l.Add(b[2]);
                l.Add(b[3]);
                //rotz
                b = BitConverter.GetBytes((float)-1);
                l.Add(b[0]);
                l.Add(b[1]);
                l.Add(b[2]);
                l.Add(b[3]);
                //rotw
                b = BitConverter.GetBytes((float)1);
                l.Add(b[0]);
                l.Add(b[1]);
                l.Add(b[2]);
                l.Add(b[3]);
                //id
                b = BitConverter.GetBytes(1333);
                l.Add(b[0]);
                l.Add(b[1]);
                l.Add(b[2]);
                l.Add(b[3]);
                //interior flags
                l.Add(0);
                l.Add(0);
                l.Add(0);
                l.Add(0);
                //flags
                l.Add(255);
                l.Add(255);
                l.Add(255);
                l.Add(255);
            }
            

            while (l.Count % 2048 !=0)
            {
                l.Add(0);
            }
            Console.WriteLine("longueur nouveau ipl : " + l.Count);

            byte[] ok = l.ToArray();
            int y = 0;
            for(int i = 0; i < ok.Length; i=i+4)
            {
                Console.WriteLine(y + "-" + write(ok, i) + "-" + bytetoint32(ok,i) + "-" + tosingle(ok,i));
                y++;
            }

            //File.WriteAllBytes("C:/users/antoi/Desktop/test.ipl", ok);

            return ok;
        }
        public static byte[] duplicateipl()
        {
            byte[] ipl = File.ReadAllBytes("DATA/a.ipl");
            List<byte> l = new List<byte>();
            int i = 19*4;

            int nb = 0;
            while (nb < 10)
            {
                byte[] b = BitConverter.GetBytes((float)r.Next(-2015, -1983));
                ipl[i] = b[0];
                ipl[i + 1] = b[1];
                ipl[i + 2] = b[2];
                ipl[i + 3] = b[3];

                b = BitConverter.GetBytes((float)r.Next(-2015, -1983));
                ipl[i + 4] = b[0];
                ipl[i + 5] = b[1];
                ipl[i + 6] = b[2];
                ipl[i + 7] = b[3];

                b = BitConverter.GetBytes((float)28);
                ipl[i + 8] = b[0];
                ipl[i + 9] = b[1];
                ipl[i + 10] = b[2];
                ipl[i + 11] = b[3];
            }

            

            return ipl;

        }
        public static void addIPL()
        {
            byte[] file = File.ReadAllBytes(pathvierge);

            byte[] newarr = createIPL();


            int nbtroncons = 0;
            for(int i = 0; i < newarr.Length; i++)
            {
                if (i % 2048 == 0)
                {
                    nbtroncons++;
                }
            }
            Console.WriteLine("Nb troncons : " + nbtroncons);
            Console.WriteLine("new arr len : " + newarr.Length);

            //+1 aux entrées
            int nboccgta3 = BitConverter.ToInt32(new byte[4] { file[4], file[5], file[6], file[7] }, 0);
            byte[] b = BitConverter.GetBytes(nboccgta3 + 1);
            file[4] = b[0];
            file[5] = b[1];
            file[6] = b[2];
            file[7] = b[3];

            int start = 521512;

            //offset
            int offset = 937680896 / 2048;
            byte[] boffset = BitConverter.GetBytes(offset);
            file[start] = boffset[0];
            file[start + 1] = boffset[1];
            file[start + 2] = boffset[2];
            file[start + 3] = boffset[3];

            Console.WriteLine("Ofset reconverti : " + bytetoint32(file, start));


            file[start + 4] = (byte)nbtroncons;
            file[start + 5] = 0;
            file[start + 6] = 0;
            file[start + 7] = 0;

            file[start + 8] = 97;
            file[start + 9] = 97;
            file[start + 10] = 97;
            file[start + 11] = 97;
            file[start + 12] = 97;
            file[start + 13] = 97;
            file[start + 14] = 97;
            file[start + 15] = 97;
            file[start + 16] = 97;
            file[start + 17] = 95;
            file[start + 18] = 115;
            file[start + 19] = 116;
            file[start + 20] = 114;
            file[start + 21] = 101;
            file[start + 22] = 97;
            file[start + 23] = 109;

            file[start + 24] = 46;
            file[start + 25] = 105;
            file[start + 26] = 112;
            file[start + 27] = 108;

            file[start + 28] = 0;
            file[start + 29] = 0;
            file[start + 30] = 177;
            file[start + 31] = 0;

            //b = BitConverter.GetBytes(937680896);
            //file[8] = b[0];
            //file[9] = b[1];
            //file[10] = b[2];
            //file[11] = b[3];




            byte[] tout = new byte[file.Length + nbtroncons*2048];

            

            for(int i = 0; i < file.Length; i++)
            {
                tout[i] = file[i];
            }
            int val = 0;
            for(int i = file.Length; i < tout.Length; i++)
            {
                Console.WriteLine("var :  " + val);
                tout[i] = newarr[val];
                val++;
            }
            Console.WriteLine(tout.Length);
            File.WriteAllBytes(path,tout);
        }
        public static void getStart() //pr des test, useless sinon
        {
            byte[] file = File.ReadAllBytes(pathvierge);
            byte[] col = File.ReadAllBytes("DATA/a.col");
            byte[] dff = File.ReadAllBytes("DATA/a.dff");
            byte[] ifp = File.ReadAllBytes("DATA/a.ifp");
            byte[] txd = File.ReadAllBytes("DATA/a.txd");
            byte[] ipl = File.ReadAllBytes("DATA/a.ipl");

            int y = 0;
            for(int i = 0; i <  ipl.Length; i = i + 4)
            {
                string s = bytetostring(ipl, i);

                Console.WriteLine(y +"-" +write(ipl, i));
                y++;
            }

        }
        
    }
}
