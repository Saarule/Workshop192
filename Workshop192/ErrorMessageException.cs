using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192
{
    public class ErrorMessageException : Exception
    {
        public ErrorMessageException(string message) : base(message) { }
    }
}
