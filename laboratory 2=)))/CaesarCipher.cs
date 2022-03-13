using System.Text;

namespace laboratory_2 {
    public class CaesarCipher : ICipher {
        const int FIRST_SYMBOL = 0;
        const int LAST_SYMBOL = 256;

        public string Encode(string str, int key) {
            key %= LAST_SYMBOL;
            int encodedSymbol;
            StringBuilder result = new StringBuilder();

            foreach (int c in str) {
                encodedSymbol = c + key;

                if (encodedSymbol < LAST_SYMBOL) {
                    result.Append((char)encodedSymbol);
                } else {
                    result.Append((char)(encodedSymbol - LAST_SYMBOL));
                }
            }

            return result.ToString();
        }

        public string Decode(string str, int key) {
            key %= (LAST_SYMBOL - FIRST_SYMBOL);
            int decodedSymbol;
            StringBuilder result = new StringBuilder();

            foreach (int c in str) {
                decodedSymbol = c - key;

                if (decodedSymbol >= FIRST_SYMBOL) {
                    result.Append((char)decodedSymbol);
                } else {
                    result.Append((char)(decodedSymbol + (LAST_SYMBOL - FIRST_SYMBOL)));
                }
            }

            return result.ToString();
        }
    }
}
