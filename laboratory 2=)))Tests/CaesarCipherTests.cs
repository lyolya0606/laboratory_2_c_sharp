using Microsoft.VisualStudio.TestTools.UnitTesting;
using laboratory_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_2.Tests {
    [TestClass()]
    public class CaesarCipherTests {
        [TestMethod()]
        public void EncodeTest() {
            byte[] message = new byte[] { 104, 101, 108, 108, 111 };
            string key = "3";
            byte[] expectedResult = new byte[] { 107, 104, 111, 111, 114 };
            CaesarCipher caesarCipher = new CaesarCipher();
            byte[] actualResult = caesarCipher.Encode(message, key);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void DecodeTest() {
            byte[] message = new byte[] { 107, 104, 111, 111, 114 };
            string key = "3";
            byte[] expectedResult = new byte[] { 104, 101, 108, 108, 111 };
            CaesarCipher caesarCipher = new CaesarCipher();
            byte[] actualResult = caesarCipher.Decode(message, key);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}