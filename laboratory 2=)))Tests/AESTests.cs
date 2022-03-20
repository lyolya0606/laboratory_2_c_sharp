using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace laboratory_2.Tests {
    [TestClass()]
    public class AESTests {
        [TestMethod()]
        public void EncodeTest() {
            byte[] message = new byte[] { 104, 101, 108, 108, 111 };
            string key = "abc";
            byte[] expectedResult = new byte[] { 194, 218, 173, 52, 248, 101, 125, 58,
                                                 17, 56, 148, 118, 228, 182, 25, 102 };
            AES aes = new AES();
            byte[] actualResult = aes.Encode(message, key);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void DecodeTest() {
            byte[] message = new byte[] { 194, 218, 173, 52, 248, 101, 125, 58,
                                          17, 56, 148, 118, 228, 182, 25, 102 };
            string key = "abc";
            byte[] expectedResult = new byte[] { 104, 101, 108, 108, 111, 0, 
                                                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            AES aes = new AES();
            byte[] actualResult = aes.Decode(message, key);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}