using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_2 {
    public class CaesarCipher : ICipher {
        private const int FIRST_SYMBOL = 0;
        private const int LAST_SYMBOL = 256;
        public byte[] Decode(byte[] message, string key) {
            int keyInt = int.Parse(key);
            keyInt %= (LAST_SYMBOL - FIRST_SYMBOL);
            int decodedSymbol;
            byte[] result = new byte[message.Length];

            for (int i = 0; i < message.Length; i++) {
                decodedSymbol = message[i] - keyInt;

                if (decodedSymbol >= FIRST_SYMBOL) {
                    result[i] = (byte)decodedSymbol;
                } else {
                    result[i] = (byte)(decodedSymbol + (LAST_SYMBOL - FIRST_SYMBOL));
                }
            }

            return result;
        }

        public byte[] Encode(byte[] message, string key) {
            int keyInt = int.Parse(key);
            keyInt %= LAST_SYMBOL;
            int encodedSymbol;
            byte[] result = new byte[message.Length];

            for (int i = 0; i < message.Length; i++) {
                encodedSymbol = message[i] + keyInt;

                if (encodedSymbol < LAST_SYMBOL) {
                    result[i] = (byte)encodedSymbol;
                } else {
                    result[i] = (byte)(encodedSymbol - LAST_SYMBOL);
                }
            }

            return result;
        }
    }

}
