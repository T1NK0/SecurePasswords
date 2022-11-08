using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing.Factories
{
    public class HashingFactory : IHashingFactory
    {
        public IHashing CreateHashing()
        {
            return new Hashings();
        }
    }
}
