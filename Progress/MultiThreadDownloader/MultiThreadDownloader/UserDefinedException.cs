using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadDownloader
{
    public class UserDefinedException : ApplicationException
    {
        public UserDefinedException(string message) : base(message)
        {

        }
    }
}
