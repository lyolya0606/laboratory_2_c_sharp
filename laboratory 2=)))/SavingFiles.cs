using System;
using System.IO;

namespace laboratory_2 {
    class SavingFiles {
        private const int SAVING = 1;
        private const int NOT_SAVING = 2;

        public void SavingInput(byte[] bytes) {
            Check check = new Check();

            Console.WriteLine("Press 1 if you want to save your input in the file");
            Console.WriteLine("Press 2 if you DON'T want to save your input in the file");
            int userChoice = check.GetInt();

            while (userChoice != SAVING && userChoice != NOT_SAVING) {
                Console.WriteLine("There is no such choice!");
                Console.WriteLine("Press 1 if you want to save your input in the file");
                Console.WriteLine("Press 2 if you DON'T want to save your input in the file");

                userChoice = check.GetInt();
            }

            if (userChoice == SAVING) {
                string path = check.OpenFileOutput();
                FileStream file = new FileStream($"{path}.txt", FileMode.Create);
                StreamWriter fileWriter = new StreamWriter(file);
                for (int i = 0; i < bytes.Length - 1; i++) {
                    fileWriter.Write(bytes[i]);
                    fileWriter.Write(" ");
                }
                fileWriter.Write(bytes[bytes.Length - 1]);

                Console.WriteLine("Your input is successfully saved!");
                fileWriter.Close();
            }
        }

        public void SavingTheResult(byte[] bytes) {
            Check check = new Check();

            Console.WriteLine("Press 1 if you want to save your result in the file");
            Console.WriteLine("Press 2 if you DON'T want to save your result in the file");
            int userChoice = check.GetInt();

            while (userChoice != SAVING && userChoice != NOT_SAVING) {
                Console.WriteLine("There is no such choice!");
                Console.WriteLine("Press 1 if you want to save your result in the file");
                Console.WriteLine("Press 2 if you DON'T want to save your result in the file");

                userChoice = check.GetInt();
            }

            if (userChoice == SAVING) {
                string path = check.OpenFileOutput();
                FileStream file = new FileStream($"{path}.txt", FileMode.Create);
                StreamWriter fileWriter = new StreamWriter(file);
                for (int i = 0; i < bytes.Length - 1; i++) {
                    fileWriter.Write(bytes[i]);
                    fileWriter.Write(" ");
                }
                fileWriter.Write(bytes[bytes.Length - 1]);

                Console.WriteLine("Your result is successfully saved!");
                fileWriter.Close();
            }
        }

        public void SavingTheKey(string str) {
            Check check = new Check();

            Console.WriteLine("Press 1 if you want to save your key in the file");
            Console.WriteLine("Press 2 if you DON'T want to save your key in the file");
            int userChoice = check.GetInt();

            while (userChoice != SAVING && userChoice != NOT_SAVING) {
                Console.WriteLine("There is no such choice!");
                Console.WriteLine("Press 1 if you want to save your key in the file");
                Console.WriteLine("Press 2 if you DON'T want to save your key in the file");

                userChoice = check.GetInt();
            }

            if (userChoice == SAVING) {
                string path = check.OpenFileOutput();
                FileStream file = new FileStream($"{path}.txt", FileMode.Create);
                StreamWriter fileWriter = new StreamWriter(file);
                fileWriter.WriteLine(str);

                Console.WriteLine("Your key is successfully saved!");
                fileWriter.Close();
            }
        }
    }
}