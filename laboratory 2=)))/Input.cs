using System;
using System.IO;

namespace laboratory_2 {
    class Input {
        private const int EMPTY_STRING = 0;
        private const int LEFT_BOARD = 33;
        private const int RIGHT_BOARD = 126;
        private const int LEFT_BOARD_OF_SIZE = 5;
        private const int RIGHT_BOARD_OF_SIZE = 25;
        public string KeyboardInput() {
            Check check = new Check();
            string str;

            do {
                Console.Write("Enter the string: ");
                str = Console.ReadLine();

                if (!check.StringIsCorrect(str)) {
                    Console.WriteLine("There are invalid symbols in the string. Try again");
                }

                if (str.Length == EMPTY_STRING) {
                    Console.WriteLine("This string is empty. Try again");
                }

            } while (!check.StringIsCorrect(str) || str.Length == EMPTY_STRING);

            return str;
        }

        public string RandomInput() {
            string str = "";
            Random rand = new Random();
            int numberOfSymbols = rand.Next(LEFT_BOARD_OF_SIZE, RIGHT_BOARD_OF_SIZE);

            for (int i = 0; i < numberOfSymbols; i++) {
                i = rand.Next(LEFT_BOARD, RIGHT_BOARD);
                str += (char)i;
            }

            return str;
        }

        public string FileInput() {
            Check check = new Check();
            string str;

            do {
                string path = check.OpenFileInput();
                str = File.ReadAllText($"{path}.txt");

                for (int i = 0; i < str.Length; i++) {
                    if (str[i] == '\r') {
                        str = str.Replace(str[i], ' ');
                    }
                }

                if (!check.StringIsCorrect(str)) {
                    Console.WriteLine("There are invalid symbols in the string. Try again");
                }

                if (str.Length == EMPTY_STRING) {
                    Console.WriteLine("File is empty. Try again");
                }

            } while (!check.StringIsCorrect(str) || str.Length == EMPTY_STRING);

            return str;
        }
    }
}
