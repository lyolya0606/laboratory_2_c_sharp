using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_2 {
    interface ICipher {
        byte[] Decode(byte[] message, string key);
        byte[] Encode(byte[] message, string key);
    }
}
