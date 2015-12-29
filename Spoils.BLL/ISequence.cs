using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoils.BLL
{
    public interface ISequence
    {
        long FirstNumber { get; set; }

        long LastNumber { get; set; }
    }
}
