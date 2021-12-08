using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Logic.Exceptions
{
    public class IdMissingException:Exception
    {
        public IdMissingException(string msg):base(msg)
        {

        }
    }
}
