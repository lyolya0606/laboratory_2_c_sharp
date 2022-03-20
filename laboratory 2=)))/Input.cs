using System;
using System.Text;
using System.IO;

namespace laboratory_2 {
    class Input {
        private const int EMPTY_STRING = 0;
        private const int LEFT_BOARD = 50;
        private const int RIGHT_BOARD = 100;
        private const int LEFT_BOARD_OF_SIZE = 5;
        private const int RIGHT_BOARD_OF_SIZE = 20;
        private const int NUMBER_OF_ELEMENTS_IN_THE_STATE = 16;
        public byte[] KeyboardInput() {
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
            byte[] message = Encoding.ASCII.GetBytes(str);
            return message;
        }

        public byte[] RandomInput() {
            string str = "";
            Random rand = new Random();
            int numberOfSymbols = rand.Next(LEFT_BOARD_OF_SIZE, RIGHT_BOARD_OF_SIZE);

            for (int i = 0; i < numberOfSymbols; i++) {
                str += (char)rand.Next(LEFT_BOARD, RIGHT_BOARD);
            }

            Console.Write($"Random: {str}");
            Console.WriteLine();

            byte[] message = Encoding.ASCII.GetBytes(str);
            return message;
        }

        public byte[] FileInput() {
            Check check = new Check();
            string strLine = "";
            string fileText = "";
            string[] str = null;
            byte[] result;
            bool stop = true;

            do {
                string path = check.OpenFileInput();
                foreach (string line in File.ReadLines($"{path}.txt")) {
                    fileText = line;
                    str = line.Split(' ');
                    break;

                }
                byte[] strInt = new byte[str.Length];

                try {
                    for (int i = 0; i < str.Length; i++) {
                        strInt[i] = byte.Parse(str[i]);
                    }
                } catch (FormatException) {
                    Console.WriteLine("Invalid data");
                    stop = false;
                }

                result = strInt;
                for (int i = 0; i < strInt.Length; i++) {
                    strLine += (char)strInt[i];
                }

                if (!check.StringIsCorrect(strLine)) {
                    Console.WriteLine("There are invalid symbols in the string. Try again");
                }

                if (strLine.Length == EMPTY_STRING) {
                    Console.WriteLine("File is empty. Try again");
                }

            } while (!check.StringIsCorrect(strLine) || strLine.Length == EMPTY_STRING || stop == false);

            Console.Write($"File: {fileText}");
            Console.WriteLine();
            return result;
        }

        public int RandomInputCaesar() {
            int key;
            Random rand = new Random();
            key = rand.Next(LEFT_BOARD_OF_SIZE, RIGHT_BOARD_OF_SIZE);
            Console.Write($"Random key: {key}");
            Console.WriteLine();
            return key;
        }

        public int FileInputCaesar() {
            Check check = new Check();
            string str = "";
            int key = 0;
            bool stop = true;

            do {
                string path = check.OpenFileInput();
                foreach (string line in File.ReadLines($"{path}.txt")) {
                    str = line;
                    break;
                }

                try {
                    key = int.Parse(str);
                } catch (FormatException) {
                    Console.WriteLine("Incorrect data. Try again");
                    stop = false;
                }
            } while (stop == false);

            Console.Write($"Key from file: {key}");
            Console.WriteLine();
            return key;
        }

        public string KeyboardInputAES() {
            Check check = new Check();
            string str;

            do {
                Console.Write("Enter the key of length 16 or less: ");
                str = Console.ReadLine();

                if (str.Length > NUMBER_OF_ELEMENTS_IN_THE_STATE) {
                    Console.WriteLine("The length is more than 16. Try again");
                }

                if (!check.StringIsCorrect(str)) {
                    Console.WriteLine("There are invalid symbols in the string. Try again");
                }

                if (str.Length == EMPTY_STRING) {
                    Console.WriteLine("This string is empty. Try again");
                }

            } while (!check.StringIsCorrect(str) || str.Length == EMPTY_STRING || str.Length > NUMBER_OF_ELEMENTS_IN_THE_STATE);

            return str;
        }

        public string RandomInputAES() {
            string str = "";
            Random rand = new Random();

            for (int i = 0; i < NUMBER_OF_ELEMENTS_IN_THE_STATE; i++) {
                str += (char)rand.Next(LEFT_BOARD, RIGHT_BOARD);
            }

            Console.Write($"Random: {str}");
            Console.WriteLine();

            return str;
        }

        public string FileInputAES() {
            Check check = new Check();
            string strLine = "";
            string fileText = "";

            do {
                string path = check.OpenFileInput();
                foreach (string line in File.ReadLines($"{path}.txt")) {
                    fileText = line;
                    break;

                }


                if (!check.StringIsCorrect(strLine)) {
                    Console.WriteLine("There are invalid symbols in the string. Try again");
                }

                if (strLine.Length == EMPTY_STRING) {
                    Console.WriteLine("File is empty. Try again");
                }

            } while (!check.StringIsCorrect(strLine) || strLine.Length == EMPTY_STRING);

            Console.Write($"File: {fileText}");
            Console.WriteLine();
            return fileText;
        }
                
    }
}

