using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaAn.AdvancedRawEditor.Layers
{
    public class Tools
    {
        public static T[][] CreateArray<T>(int x, int y)
        {
            T[][] result = new T[x][];

            for (int i = 0; i < x; i++)
            {
                result[i] = new T[y];
            }

            return result;
        }
    }
}
