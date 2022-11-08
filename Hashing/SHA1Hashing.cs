using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class Hashings : IHashing
    {
        public string SHA1HashValue(string formValue)
        {
            //Using closes when the code has been execuded
            //Using SHA1 hashing.
            using (SHA1 sha1Hashing = SHA1.Create())
            {
                //Encode the byte array.
                byte[] stringConvertedToBytes = Encoding.UTF8.GetBytes(formValue);
                byte[] result = sha1Hashing.ComputeHash(stringConvertedToBytes);


                //Hex Value
                Console.WriteLine(BitConverter.ToString(result));

                //Call to the string builder, with the bytearray to get a string back 
                return MyStringBuilder(result);
            }
        }        
        
        public string SHA256HashValue(string formValue)
        {
            //Using closes when the code has been execuded
            //Using SHA256 hashing.
            using (SHA256 sha1Hashing = SHA256.Create())
            {
                byte[] stringConvertedToBytes = Encoding.UTF8.GetBytes(formValue);
                byte[] result = sha1Hashing.ComputeHash(stringConvertedToBytes);

                Console.WriteLine(BitConverter.ToString(result));

                //Call to the string builder, with the bytearray to get a string back 
                return MyStringBuilder(result);
            }
        }        
        
        public string MD5HashValue(string formValue)
        {
            //Using closes when the code has been execuded
            //Using MD5 hashing.
            using (MD5 sha1Hashing = MD5.Create())
            {
                byte[] stringConvertedToBytes = Encoding.UTF8.GetBytes(formValue);
                byte[] result = sha1Hashing.ComputeHash(stringConvertedToBytes);

                Console.WriteLine(BitConverter.ToString(result));

                //Call to the string builder, with the bytearray to get a string back 
                return MyStringBuilder(result);
            }
        }

        public string MyStringBuilder(byte[] input)
        {
            //Use a string builder to assemble the bytes to a string with text format, instead of hexadecimal.
            StringBuilder sb = new StringBuilder();
            foreach (byte b in input)
            {
                //ToString("x2") is to format hexadecimal to text.
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public string CreateSalt(string saltSize)
        {            
            //Generate a cryptographic random number.
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            int saltSizeInt = Convert.ToInt32(saltSize);
            byte[] buff = new byte[saltSizeInt];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
    }
}
