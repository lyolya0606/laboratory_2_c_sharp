using System;

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

        private void PrintHex(byte[] message) {
            Console.WriteLine("String in ASCII hex symbols:");
            for (int i = 0; i < message.Length; i++) {
                Console.Write(message[i].ToString("x") + " ");               
            }
            Console.WriteLine();
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
                        ICipher cipherCaesar = new CaesarCipher();
                        EncodeOrDecodeChoosing(cipherCaesar, (int)ChoiceOfCipher.CAESAR);
                        stop = true;
                        break;
                    case (int)ChoiceOfCipher.AES:
                        Console.WriteLine("Your choice is AES cripher");
                        ICipher cipherAES = new AES();
                        EncodeOrDecodeChoosing(cipherAES, (int)ChoiceOfCipher.AES);
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

        private void EncodeOrDecodeChoosing(ICipher cipher, int typeOfCipher) {
            Menu menu = new Menu();
            Check check = new Check();
            SavingFiles savingFiles = new SavingFiles();
            int userChoice;
            bool stop;
            string keyCaesar;
            byte[] result;
            string keyAES;

            do {
                menu.MenuForSelectionCipherWork();
                userChoice = check.GetInt();

                switch (userChoice) {
                    case (int)ChoiceOfCode.ENCODE:
                        Console.WriteLine("Your choice is encoding");
                        byte[] messageForEncode = InputChoosing();
                        savingFiles.SavingInput(messageForEncode);

                        if (typeOfCipher == (int)ChoiceOfCipher.CAESAR) {
                            keyCaesar = ChoosingKeyCaesar();
                            savingFiles.SavingTheKey(keyCaesar);
                            result = cipher.Encode(messageForEncode, keyCaesar);
                        } else {
                            keyAES = ChoosingKeyAES();
                            savingFiles.SavingTheKey(keyAES);
                            result = cipher.Encode(messageForEncode, keyAES);

                        }
                        Console.WriteLine();
                        Console.WriteLine("The result of encoding:");
                        PrintHex(result);
                        savingFiles.SavingTheResult(result);
                        stop = true;
                        break;
                    case (int)ChoiceOfCode.DECODE:
                        Console.WriteLine("Your choice is decoding");
                        byte[] messageForDecode = InputChoosing();

                        if (typeOfCipher == (int)ChoiceOfCipher.CAESAR) {
                            keyCaesar = ChoosingKeyCaesar();
                            savingFiles.SavingTheKey(keyCaesar);
                            result = cipher.Decode(messageForDecode, keyCaesar);
                        } else {
                            keyAES = ChoosingKeyAES();
                            savingFiles.SavingTheKey(keyAES);
                            result = cipher.Decode(messageForDecode, keyAES);
                        }
                        Console.WriteLine();
                        Console.WriteLine("The result of decoding:");
                        PrintHex(result);
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

        private byte[] InputChoosing() {
            Menu menu = new Menu();
            Input input = new Input();
            Check check = new Check();
            int userChoice;
            bool stop;
            byte[] message = null;

            do {
                Console.WriteLine();
                Console.WriteLine("Choose how you want to get input:");
                menu.MenuWork();
                userChoice = check.GetInt();
                switch (userChoice) {
                    case (int)ChoiceOfInput.KEYBOARD_INPUT:
                        message = input.KeyboardInput();
                        PrintHex(message);
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.RANDOM_INPUT:
                        message = input.RandomInput();
                        PrintHex(message);
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.FILE_INPUT:
                        message = input.FileInput();
                        PrintHex(message);
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                        stop = false;
                        break;
                }

            } while (stop == false);

            return message;
        }

        private string ChoosingKeyCaesar() {
            Menu menu = new Menu();
            Input input = new Input();
            Check check = new Check();
            int userChoice;
            bool stop;
            int key = 0;

            do {
                Console.WriteLine();
                Console.WriteLine("Choose how you want to get the key:");
                menu.MenuWork();
                userChoice = check.GetInt();
                switch (userChoice) {
                    case (int)ChoiceOfInput.KEYBOARD_INPUT:
                        do {
                            Console.Write("Enter the key: ");
                            key = check.GetInt();
                            stop = true;
                            if (key < 0) {
                                Console.WriteLine("The key cannot be less rhan zero.");
                            }
                        } while (key < 0);
                        break;
                    case (int)ChoiceOfInput.RANDOM_INPUT:
                        key = input.RandomInputCaesar();
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.FILE_INPUT:
                        key = input.FileInputCaesar();
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                        stop = false;
                        break;
                }

            } while (stop == false);

            return key.ToString();
        }

        private string ChoosingKeyAES() {
            Menu menu = new Menu();
            Input input = new Input();
            Check check = new Check();
            int userChoice;
            bool stop;
            string key = "";

            do {
                Console.WriteLine();
                Console.WriteLine("Choose how you want to get the key:");
                menu.MenuWork();
                userChoice = check.GetInt();
                switch (userChoice) {
                    case (int)ChoiceOfInput.KEYBOARD_INPUT:
                        key = input.KeyboardInputAES();
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.RANDOM_INPUT:
                        key = input.RandomInputAES();
                        stop = true;
                        break;
                    case (int)ChoiceOfInput.FILE_INPUT:
                        key = input.FileInputAES();
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                        stop = false;
                        break;
                }

            } while (stop == false);

            return key.ToString();
        }
    }
}

