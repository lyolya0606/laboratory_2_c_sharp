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
                        ICipher cipher = new CaesarCipher();
                        EncodeOrDecodeChoosing(cipher);
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

        private void EncodeOrDecodeChoosing(ICipher cipher) {
            Menu menu = new Menu();
            Check check = new Check();
            int userChoice;
            bool stop;
            string str = "";
            int key;

            do {
                menu.MenuForSelectionCipherWork();
                userChoice = check.GetInt();

                switch (userChoice) {
                    case (int)ChoiceOfCode.ENCODE:
                        Console.WriteLine("Your choice is encoding");
                        str = InputChoosing();

                        do {
                            Console.Write("Enter the key: ");
                            key = check.GetInt();

                            if (key < 0) {
                                Console.WriteLine("The key cannot be less than zero. Try again");
                            }
                        } while (key < 0);

                        cipher.Encode(str, key);
                        stop = true;
                        break;
                    case (int)ChoiceOfCode.DECODE:
                        Console.WriteLine("Your choice is decoding");
                        str = InputChoosing();

                        do {
                            Console.Write("Enter the key: ");
                            key = check.GetInt();

                            if (key < 0) {
                                Console.WriteLine("The key cannot be less than zero. Try again");
                            }
                        } while (key < 0);

                        cipher.Decode(str, key);
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
