using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing.Factories
{
    public interface IHashingFactory
    {
        Hashings CreateHashing();
    }
}
