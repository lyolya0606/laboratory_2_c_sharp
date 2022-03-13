namespace laboratory_2 {
    interface ICipher {
        string Encode(string str, int key);
        string Decode(string str, int key);
    }
}