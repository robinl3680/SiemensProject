using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadDownloader
{
    public class NotCorrectFormatException:ApplicationException
    {
        public NotCorrectFormatException(string msg) : base(msg)
        {

        }
    }
}
