using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TXD
    {
        public byte[] data;
        public int len;
        public bool valid = false;
        public List<int> SCI = new List<int>();
        public TXD(int indice,byte[] file)
        {
            if(file[indice + 52] == 9)
            {
                byte[] array = new byte[4] { file[indice + 4], file[indice + 5], file[indice + 6], file[indice + 7] };
                this.len = BitConverter.ToInt32(array, 0);
                this.data = new byte[len];
                for(int i = indice;i<indice+ len; i++)
                {
                    this.data[i] = file[i];
                }
                valid = true;
            }
            else
            {
                valid = false;
            }
            if (valid)
            {
                setSCI();
                if (SCI.Count > 1)
                {
                    for (int a = 1; a < SCI.Count; a++)
                    {
                        int mid = SCI.ElementAt(a) - SCI.ElementAt(a - 1);

                    }
                }
                
            }
        }
        public void setSCI()
        {
            for(int i =0; i < data.Length; i++)
            {
                if (has9000(i, data))
                {
                    SCI.Add(i);
                }
            }
        }
        public static bool has9000(int i,byte[] file)
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



    }
}
