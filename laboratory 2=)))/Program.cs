using System;

namespace laboratory_2 {
    class Program {
        enum EndOfProgram {
            QUIT = 1,
            CONTINUE
        };

        public static void Main(string[] args) {
            Menu menu = new Menu();
            Check check = new Check();
            WorkingWithCriphers workingWithCriphers = new WorkingWithCriphers();
            menu.Greeting();
            int userChoice;

            do {

                do {
                    workingWithCriphers.CripherChoosing();
                    Console.WriteLine();
                    Console.WriteLine("Press 1 to finish");
                    Console.WriteLine("Press 2 to continue");
                    userChoice = check.GetInt();

                    if (userChoice != (int)EndOfProgram.QUIT && userChoice != (int)EndOfProgram.CONTINUE) {
                        Console.WriteLine("There is no such choice!");
                        Console.WriteLine();
                    }

                } while (userChoice != (int)EndOfProgram.QUIT && userChoice != (int)EndOfProgram.CONTINUE);

            } while (userChoice != (int)EndOfProgram.QUIT);

        }

    }
}