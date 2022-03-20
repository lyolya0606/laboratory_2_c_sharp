using System;
using System.IO;

namespace laboratory_2 {
    class Check {
        private const int FILE_HAS_DATA = 0;
        private const int OVERWRITE_FILE = 1;
        private const int OVERWRITE_PATH = 2;
        private const int FIRST_SYMBOL = 0;
        private const int LAST_SYMBOL = 256;
        public int GetInt() {
            int num;

            while (true) {

                if (int.TryParse(Console.ReadLine(), out num)) {
                    break;
                }

                Console.WriteLine("Input Error. Try again.");
            }

            return num;
        }

        public bool StringIsCorrect(string str) {
            bool stringIsCorrect = true; 

            foreach(int c in str) {
                if (c < FIRST_SYMBOL || c > LAST_SYMBOL) {
                    stringIsCorrect = false;
                }
            }

            return stringIsCorrect;
        }


        public string OpenFileOutput() {
            int userChoice;
            bool isCorrectPath;
            string path;

            do {

                Console.Write("Input the path to the file: ");
                path = Console.ReadLine();

                try {
                    using (FileStream file = new FileStream($"{path}.txt", FileMode.OpenOrCreate)) {
                        isCorrectPath = true;
                    }
                } catch (Exception) {
                    Console.WriteLine("Opening error! Try again.");
                    isCorrectPath = false;
                }

                if (isCorrectPath == true) {
                    string[] generalString = File.ReadAllLines($"{path}.txt");


                    if (generalString.Length != FILE_HAS_DATA) {
                        Console.WriteLine("This file has some data. Do you want to overwrite the file?");
                        Console.WriteLine("Press 1 if you want to overwrite this file");
                        Console.WriteLine("Press 2 if you DON'T want to overwrite this file");


                        userChoice = GetInt();

                        while (userChoice != OVERWRITE_PATH && userChoice != OVERWRITE_FILE) {
                            Console.WriteLine("There is no such choice!");
                            Console.WriteLine("Press 1 if you want to overwrite this file");
                            Console.WriteLine("Press 2 if you DON'T want to overwrite this file");
                            userChoice = GetInt();
                        }

                        if (userChoice == OVERWRITE_PATH) {
                            isCorrectPath = false;
                        }

                        if (userChoice == OVERWRITE_FILE) {
                            isCorrectPath = true;
                        }
                    }
                }

            } while (isCorrectPath == false);

            return path;
        }

        public string OpenFileInput() {
            string path;
            bool isCorrectPath;

            do {
                Console.Write("Input the path to the file: ");
                path = Console.ReadLine();

                try {
                    using (FileStream file = new FileStream($"{path}.txt", FileMode.Open)) {
                        isCorrectPath = true;
                    }
                } catch (Exception) {
                    Console.WriteLine("Opening error! Try again.");
                    isCorrectPath = false;
                }

                if (isCorrectPath == true) {
                    string[] generalString = File.ReadAllLines($"{path}.txt");

                    if (generalString.Length == FILE_HAS_DATA) {
                        Console.WriteLine("This file is empty");
                        isCorrectPath = false;
                    }
                }

            } while (isCorrectPath == false);

            return path;
        }
    }

}