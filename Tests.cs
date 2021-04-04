using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tests
{
    public static class Tests
    {
        public static Random r = new Random();
        public static void vehiclecol()
        {
            byte[] file = System.IO.File.ReadAllBytes("DATA/models/coll/peds.col");
            Console.WriteLine("lenght : " + file.Length);
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
                    if (zerocpt < 3)
                    {
                        if (r.Next(0, 3) == 0)
                        {
                            //file[i] = (byte)r.Next(1, 5);
                        }
                    }
                    
                }
            }
            File.WriteAllBytes("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/models/coll/peds.col", file); 
        }
        public static void RdmCars()
        {
            try
            {
                StreamReader read = new StreamReader("DATA/data/carcols.dat");
                StreamWriter sortie = new StreamWriter("D:/Program Files (x86)/Steam/steamapps/common/Grand Theft Auto San Andreas/data/carcols.dat");
                sortie.Flush();
                string line = read.ReadLine();
                int i = 0;
                while (line != null)
                {
                    string[] ligne = line.Split(',');
                    if (i > 40)
                    {
                        ligne = ligne;
                    }

                    bool ok = false;
                    string SortieS = null;
                    try
                    {
                        int a = Convert.ToInt32(ligne[0]);
                        Console.WriteLine(i + " reussi : <" + ligne[0] + ">");
                        ok = true;
                    }
                    catch
                    {
                        Console.WriteLine(i +" echec");
                        ok = false;
                        SortieS = line;
                    }
                    if (ok == true)
                    {
                        Random r = new Random();
                        ligne[0] = Convert.ToString(r.Next(0, 255));//changer
                        ligne[1] = Convert.ToString(r.Next(0, 255));//changer
                        string[] fin = ligne[2].Split('\t');
                        //Console.WriteLine(fin[0]);
                        string ajout = null;
                        for (int f = 0; f < fin.Length; f++)
                        {
                            ajout = ajout + fin[f] + " ";
                        }
                        fin[0] = Convert.ToString(r.Next(0, 255));//changer
                        SortieS = ligne[0] + "," + ligne[1] + " " + ajout;
                        Console.WriteLine(SortieS);
                    }
                    i++;
                    sortie.WriteLine(SortieS);
                    line = read.ReadLine();
                }
                read.Close();
                sortie.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void MoreCars()
        {
            try
            {
                StreamReader read = new StreamReader("DATA/data/popcycle.dat");
                StreamWriter sortie = new StreamWriter("D:/Program Files (x86)/Steam/steamapps/common/Grand Theft Auto San Andreas/data/popcycle.dat");
                sortie.Flush();

                string line = read.ReadLine();
                int i = 0;
                
                while (line != null)
                {
                    string sortieS = null;
                    string[] ligne = line.Split(' ');
                    bool ok = false;
                    try
                    {
                        Convert.ToInt32(ligne[0]);
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                    }
                    if (ok)
                    {
                        ligne[1] = Convert.ToString(5000);
                        ligne[3] = Convert.ToString(5000);
                        foreach (string s in ligne)
                        {
                            sortieS = sortieS + " " + s;
                        }
                    }
                    else
                    {
                        sortieS = line;
                    }
                    Console.WriteLine(sortieS);
                    sortie.WriteLine(sortieS);
                    line = read.ReadLine();
                    i++;
                }
                sortie.Close();
                read.Close();

            }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
            }
        }
        public static void ModifyCars()
        {
            StreamReader read = new StreamReader("DATA/data/handling.cfg");
            StreamWriter sortie = new StreamWriter("D:/Program Files (x86)/Steam/steamapps/common/Grand Theft Auto San Andreas/data/handling.cfg");
            sortie.Flush();
            string line = read.ReadLine();
            while (line != null)
            {
                string[] ligne = line.Split(' ');
                //for(int i=0;i<ligne.Length;i++)
                //{
                //    Console.Write(ligne[i] + "|");
                //}
                bool ok = true;

                try
                {
                    Convert.ToString(ligne[0]);
                    foreach (string s in ligne)
                    {
                        foreach (char c in s)
                        {
                            if (ok)
                            {
                                if (c == '^' || c == ';' || c == '$' || c == '!' || c == '%')
                                {
                                    ok = false;
                                }
                                else
                                {
                                    ok = true;
                                }
                            }

                        }
                    }
                }
                catch
                {
                    return;
                }
                int cpt = 0;
                string sortieS = null;
                if (ok == true && cpt < 5)
                {
                    List<string> s = new List<string>();
                    foreach (string str in ligne)
                    {
                        s.Add(str);
                    }
                    s.RemoveAll(w => w == "");

                    string[] tab = new string[s.Count];
                    int i = 0;
                    foreach (string str in s)
                    {
                        tab[i] = str;
                        i++;
                    }
                    //tab[2] = "1"; //wtf
                    //tab[1] = "0.1"; //masse

                    tab[9] = "100";
                    tab[6] = "-3";
                    tab[8] = "300";
                    tab[11] = "10";
                    //tab[30] = "0";

                    //Console.WriteLine(cpt);

                    foreach (string str in tab)
                    {
                        sortieS = sortieS + str + " ";
                    }
                    cpt++;
                }
                else
                {
                    sortieS = line;
                }

                sortie.WriteLine(sortieS);


                line = read.ReadLine();
            }
            sortie.Close();
        }
        public static void objects()
        {
            StreamReader read = new StreamReader("DATA/data/object.dat");
            StreamWriter sortie = new StreamWriter("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/data/object.dat");
            sortie.Flush();
            string line = read.ReadLine();
            while (line != null)
            {
                bool ok;
                string[] ligne = line.Split(new char[] { ',', '\t',' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.Contains(';') || line.Contains('*') || ligne.Length<2)
                {
                    ok = false;
                }
                else
                {
                    ok = true;
                }
                if (ok)
                {

                    Console.WriteLine(ligne[9]);

                    string SortieS = "";

                    ligne[1] = "1000"; //mass
                    ligne[2] = "1"; //turnmass
                    ligne[3] = "0.99"; //air
                    ligne[4] = "7"; //ela
                    ligne[6] = "0";
                    ligne[7] = "0.0001"; //collision damage mult
                    ligne[8] = "20"; //collision damage effect
                    ligne[9] = "5";
                    ligne[11] = "2";
                    if (ligne[0].Contains("light"))
                    {
                        
                    }



                    for (int i = 0; i < ligne.Length; i++)
                    {
                        SortieS = SortieS + ligne[i] + " ";
                    }
                    sortie.WriteLine(SortieS);
                }
                else
                {
                    sortie.WriteLine(line);
                }
                line = read.ReadLine();
            }
            read.Close();
            sortie.Close();
        }
        

        public static void pedgrps()
        {
            StreamReader read = new StreamReader("DATA/data/pedgrp.dat");
            StreamWriter sortie = new StreamWriter("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/data/pedgrp.dat");
            sortie.Flush();
            string line = read.ReadLine();

            while(line != null)
            {
                bool ok = false;
                string[] ligne = line.Split(new char[] { ',', '#' }, StringSplitOptions.RemoveEmptyEntries);
                if (ligne.Length > 0 && !(line.Contains("file")) && !(line.Contains("the")))
                {
                    if (!ligne[0].Contains("\t") && !ligne[0].Contains(" "))
                    {
                        Console.WriteLine("-" + ligne[0] + "-");
                        sortie.WriteLine("BFYPRO, HFYPRO, WFYPRO, SFYPRO #");
                        ok = true;
                    }
                }
                if (!ok)
                {
                    sortie.WriteLine(line);
                }
               

                line = read.ReadLine();
            }
            read.Close();
            sortie.Close();
        }
        public static void resetpedgrp()
        {
            StreamReader read = new StreamReader("DATA/data/pedgrp.dat");
            StreamWriter sortie = new StreamWriter("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/data/pedgrp.dat");
            sortie.Flush();
            string tout = read.ReadToEnd();
            sortie.Write(tout);
            sortie.Close();
            read.Close();
        }
        public static void pedside()
        {
            StreamReader read = new StreamReader("DATA/data/peds.ide");
            StreamWriter sortie = new StreamWriter("D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/data/peds.ide");
            sortie.Flush();
            string line = read.ReadLine();
            int cpt = 0;
            while (line != null)
            {
                if (cpt > 44 && !line.Contains("#") && line !="" && !line.Contains("\t") && !line.Contains("end"))
                {
                    string[] ligne = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    //Console.WriteLine(ligne[3]);
                    ligne[3] = "PROSTITUTE";
                    ligne[6] = "130C";
                    ligne[7] = "100";
                    ligne[8] = "100";
                    ligne[9] = "100";
                    ligne[11] = "PED_TYPE_GEN";
                    
                    if (ligne.Length > 13)
                    {
                        if(!ligne[12].Contains("0"))
                        {
                            //Console.WriteLine(ligne[12] + " " + ligne[13]);
                            ligne[12] = "VOICE_GEN_SHFYPRO";
                            ligne[13] = "VOICE_GEN_SHFYPRO";
                        }
                        
                    }
                    string SortieS = "";
                    for (int i = 0; i < ligne.Length; i++)
                    {
                        if (i != ligne.Length - 1)
                        {
                            SortieS = SortieS + ligne[i] + ",";
                        }
                        else
                        {
                            SortieS = SortieS + ligne[i];
                        }


                    }

                    sortie.WriteLine(SortieS);
                    
                }
                else
                {
                    sortie.WriteLine(line);
                }


                line = read.ReadLine();
                cpt++;
            }
            read.Close();
            sortie.Close();
        }
       
        public static void polydensity()
        {
            StreamReader read = new StreamReader("DATA/data/maps/SF/SFSe.ipl");
            StreamWriter sortie =
                new StreamWriter(
                    "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/data/maps/SF/SFSe.ipl");
            string line = read.ReadLine();
            float x = -2005;
            while (line != null)
            {
                string[] ligne = line.Split(',');
                bool ok = false;
                if (ligne.Length > 5 && !line.Contains("SVCUNT"))
                {
                    ok = true;
                }

                //ok = false;


                string sortieS = "";
                if (ok)
                {
                    ligne[0] = "4550";
                    //ligne[2] = "256";
                    //ligne[3] = Convert.ToString(x);
                    //ligne[4] = "150";
                    //ligne[5] = "40";
                    //ligne[6] = "0";
                    //ligne[7] = "5";
                    //ligne[8] = "8";
                    //ligne[9] = "1";
                    //ligne[10] = "-1";
                    for (int i = 0; i < ligne.Length; i++)
                    {
                        if (i == ligne.Length - 1)
                        {
                            sortieS = sortieS + ligne[i];
                        }
                        else
                        {
                            sortieS = sortieS + ligne[i] + ",";
                        }
                    }
                }
                else
                {
                    sortieS = line;
                }
                sortie.WriteLine(sortieS);


                x=x+10;
                line = read.ReadLine();
            }
            sortie.Close();
            read.Close();
           
            
        }
        public static void wtf()
        {
            StreamReader read = new StreamReader("DATA/data/maps/generic/dynamic2.ide");
            StreamWriter sortie =
                new StreamWriter(
                    "D:/Program Files (x86)/Steam/Steamapps/common/Grand Theft Auto San Andreas/data/maps/generic/dynamic2.ide");
            string line = read.ReadLine();
            
            while (line != null)
            {
                string[] ligne = line.Split(',');
                bool ok = false;
                if (ligne.Length > 3)
                {
                    ok = true;
                }

                ok = false;


                string sortieS = "";
                if (ok)
                {
                    //ligne[1] = "petrolpump";
                    ligne[2] = "rock";
                    ligne[3] = "40";
                    ligne[4] = "128";
                    for (int i = 0; i < ligne.Length; i++)
                    {
                        if (i == ligne.Length - 1)
                        {
                            sortieS = sortieS + ligne[i];
                        }
                        else
                        {
                            sortieS = sortieS + ligne[i] + ",";
                        }
                    }
                }
                else
                {
                    sortieS = line;
                }
                sortie.WriteLine(sortieS);


               
                line = read.ReadLine();
            }
            sortie.Close();
            read.Close();
        }
        
    }
}
