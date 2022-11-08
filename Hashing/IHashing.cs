using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public interface IHashing
    {
        string SHA1HashValue(string convertedKeyHashedValue);
        string SHA256HashValue(string convertedKeyHashedValue);
        string MD5HashValue(string convertedKeyHashedValue);
        string CreateSalt(string SaltSize);
    }
}
