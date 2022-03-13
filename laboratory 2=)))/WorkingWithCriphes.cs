using System;
using System.Collections.Generic;
using System.Text;

namespace laboratory_2 {
    class WorkingWithCriphers {

        enum ChoiceOfCipher {
            CAESAR = 1,
            AES
        };

        enum ChoiceOfCode {
            ENCODE = 1,
            DECODE
        };

        enum ChoiceOfInput {
            KEYBOARD_INPUT = 1,
            RANDOM_INPUT,
            FILE_INPUT
        }

        public void CripherChoosing() {
            Menu menu = new Menu();
            Check check = new Check();
            int userChoice;
            bool stop;

            do {
                menu.MenuForSelectionCipher();
                userChoice = check.GetInt();

                switch (userChoice) {
                    case (int)ChoiceOfCipher.CAESAR:
                        Console.WriteLine("Your choice is caesar cripher");
                        stop = true;
                        break;
                    case (int)ChoiceOfCipher.AES:
                        Console.WriteLine("Your choice is AES cripher");
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                        stop = false;
                        break;
                }
            } while (stop == false);

        }

        private string EncodeOrDecodeChoosing() {
            Menu menu = new Menu();
            Check check = new Check();
            int userChoice;
            bool stop;
            string str = "";

            do {
                menu.MenuForSelectionCipherWork();
                userChoice = check.GetInt();

                switch (userChoice) {
                    case (int)ChoiceOfCode.ENCODE:
                        Console.WriteLine("Your choice is encoding");
                        str = InputChoosing();
                        stop = true;
                        break;
                    case (int)ChoiceOfCode.DECODE:
                        Console.WriteLine("Your choice is decoding");
                        str = InputChoosing();
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                        stop = false;
                        break;
                }
            } while (stop == false);

            return str;
        }

        private string InputChoosing() {
            Menu menu = new Menu();
            Input input = new Input();
            Check check = new Check();
            int userChoice;
            bool stop;
            string str = "";

            do {
                menu.MenuWork();
                userChoice = check.GetInt();
                switch (userChoice) {
                    case (int)ChoiceOfInput.KEYBOARD_INPUT:
                        str = input.KeyboardInput();
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.RANDOM_INPUT:
                        str = input.RandomInput();
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.FILE_INPUT:
                        str = input.FileInput();
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                        stop = false;
                        break;
                }


            } while (stop == false);

            return str;
        }
    }
}
