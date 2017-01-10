using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    public class Test
    {
        public int meth(ref int n)
        {
            return n;
        }

        public float meth(out float mun)
        {
            mun = 4.5f;
            return 3.0f;
        }

        public object Meth(int n) { return n; }
        public object Meth(out int n) { return n=3; }
    }
}
