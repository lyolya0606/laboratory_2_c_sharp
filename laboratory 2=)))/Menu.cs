using System;

namespace laboratory_2 {
    class Menu {
        public void Greeting() {
            Console.WriteLine("Laboratory work 2, variant 1");
            Console.WriteLine("заданиееееее");
            Console.WriteLine("Student of group number 403, Bezdudnaya Olga. 2022 year");
            Console.WriteLine();
        }

        public void MenuForSelectionCipher() {
            Console.WriteLine();
            Console.WriteLine("Press 1 if you want to work with the Caesar cipher");
            Console.WriteLine("Press 2 if you want to work with the AES cipher");
        }

        public void MenuForSelectionCipherWork() {
            Console.WriteLine("Press 1 for encoding");
            Console.WriteLine("Press 2 for decoding");
        }

        public void MenuWork() {
            Console.WriteLine("Press 1 to enter data from the keyboard");
            Console.WriteLine("Press 2 to enter data randomly");
            Console.WriteLine("Press 3 to enter data from the file");
        }
    }
}