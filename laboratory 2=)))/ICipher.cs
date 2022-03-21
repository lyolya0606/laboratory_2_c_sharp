namespace laboratory_2 {
    interface ICipher {
        byte[] Decode(byte[] message, string key);
        byte[] Encode(byte[] message, string key);
    }
}
