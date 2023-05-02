using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class MyList<T>:List<T>
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            bool b = true;
            foreach (var item in this)
            {
                if (!b) sb.Append(", ");
                sb.Append(item.ToString());
                b = false;
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
