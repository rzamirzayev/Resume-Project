using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    public interface ICryptoService
    {
        string Encrypt(string value, bool appliedUrlEncode = false);
        string Decrypt(string cipherText);
    }
}
