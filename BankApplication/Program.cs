using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Program
    {
        //yey
        static void Main(string[] args)
        {
            Savings savingAcc = new Savings(5.00, 5);
            Chequing checkingAcc = new Chequing(5.00, 5);
            GlobalSavingsAccount globalSavingsAcc = new GlobalSavingsAccount(5.00, 0);

            bool stayLoop = true;

            Console.WriteLine("Welcome to the Bank of COVID\n");

            while (stayLoop) 
            {
                try
                { 
                    MainMenu();
                    string userMenuChoice = Console.ReadLine().ToUpper();

                    switch (userMenuChoice)
                    {
                        case "A":
                            SavingsMenu(savingAcc);
                            break;
                        case "B":
                            ChequingMenu(checkingAcc);
                            break;
                        case "C":
                            GlobalSavingsMenu(globalSavingsAcc);
                            break;
                        case "Q":
                            stayLoop = false;
                            Environment.Exit(0);
                            break;
                        default:
                            throw new ChoiceException(String.Format("\n{0} is not a listed choice\n", userMenuChoice));
                    }

                }
                catch (ChoiceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The program will be terminated. Due to " + ex.Message);
                }
                finally
                {

                }
            }
        }

        private static void MainMenu()
        {
            Console.WriteLine("Please make a selection from the following\n" +
                              "Bank Menu\n" +
                              "-------------\n" +
                              "A: Savings\n" +
                              "B: Checking\n" +
                              "C: GlobalSavings\n" +
                              "Q: Exit\n");
        }

        private static void SavingsMenu(Savings savings)
        {
            double userNumberImput;
            bool stayLoop = true;

            while (stayLoop)
            {
                Console.WriteLine("\nSavings Menu\n" +
                           "-------------------\n" +
                           "A: Deposit\n" +
                           "B: Withdrawl\n" +
                           "C: Close + Report\n" +
                           "R: Return to Bank Menu\n");
            
                string userMenuChoice = Console.ReadLine().ToUpper();
                try
                {
                    switch (userMenuChoice)
                    {
                        case "A":
                            userNumberImput = getUserInputNumber("deposit");
                            savings.MakeDeposit(userNumberImput);
                            break;
                        case "B":
                            userNumberImput = getUserInputNumber("withdrawl");
                            savings.MakeWithdrawl(userNumberImput);
                            break;
                        case "C":
                            Console.WriteLine(savings.CloseAndReport());
                            break;
                        case "R":
                            stayLoop = false; 
                            break;
                        default:
                            throw new ChoiceException(String.Format("{0} is not a listed choice", userMenuChoice));

                    }

                }
                catch (ChoiceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static void ChequingMenu(Chequing chequing)
        {
            double userNumberImput;
            bool stayLoop = true;

            while (stayLoop)
            {
                Console.WriteLine("\nChequing Menu\n" +
                           "--------------------\n" +
                           "A: Deposit\n" +
                           "B: Withdrawl\n" +
                           "C: Close + Report\n" +
                           "R: Return to Bank Menu\n");

            
                string userMenuChoice = Console.ReadLine().ToUpper();
                try
                {
                    switch (userMenuChoice)
                    {
                        case "A":
                            userNumberImput = getUserInputNumber("deposit");
                            chequing.MakeDeposit(userNumberImput);
                            break;
                        case "B":
                            userNumberImput = getUserInputNumber("withdrawl");
                            chequing.MakeWithdrawl(userNumberImput);
                            break;
                        case "C":
                            Console.WriteLine(chequing.CloseAndReport());
                            break;
                        case "R":
                            stayLoop = false;
                            break;
                        default:
                            throw new ChoiceException(String.Format("{0} is not a listed choice", userMenuChoice));

                    }
                }
                catch (ChoiceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        //Choices dont work in GlobalSavings 
        private static void GlobalSavingsMenu(GlobalSavingsAccount globalSavings)
        {
            double userNumberImput;
            bool stayLoop = true;

            while (stayLoop)
            {
                Console.WriteLine("\nGlobal Savings Menu\n" +
                            "-----------------------\n" +
                            "A: Deposit\n" +
                            "B: Withdrawl\n" +
                            "C: Close + Report\n" +
                            "D: Report Balance in USD\n" +
                            "R: Return to Bank Menu\n");

            
                string userMenuChoice = Console.ReadLine().ToUpper();
                try
                {
                    switch (userMenuChoice)
                    {
                        case "A":
                            userNumberImput = getUserInputNumber("deposit");
                            globalSavings.MakeDeposit(userNumberImput);
                            break;
                        case "B":
                            userNumberImput = getUserInputNumber("withdrawl");
                            globalSavings.MakeWithdrawl(userNumberImput);
                            break;
                        case "C":
                            Console.WriteLine(globalSavings.CloseAndReport());
                            break;
                        case "D":
                            Console.WriteLine((String.Format("USD: {0:C}",globalSavings.USValue(0.755770))));
                            break;
                        case "R":
                            stayLoop = false;
                            break;
                        default:
                            throw new ChoiceException(String.Format("{0} is not a listed choice", userMenuChoice));
                    }
                }
                catch (ChoiceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static double getUserInputNumber(string message)
        {
            double input = 0;
            bool correctNumberInput = false;
            while (correctNumberInput == false)
            {
                try
                {
                    input = 0;

                    Console.WriteLine("Enter number you wish to {0}", message);

                    input = double.Parse(Console.ReadLine());

                    if (input < 0)
                    {
                        throw new Exception("The number should be more than 0");
                    }
                    else if (Double.IsNaN(input))
                    {
                        throw new Exception("Your input should be a number");
                    }

                    correctNumberInput = true;
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
            return input;
        }
    }
}
