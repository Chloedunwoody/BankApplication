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
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    MainMenu();

                    switch (Console.ReadLine().ToUpper())
                    {
                        case "A":
                            SavingsMenu();
                            break;
                        case "B":
                            ChequingMenu();
                            break;
                        case "C":
                            GlobalSavingsMenu();
                            break;
                        case "Q":
                            Environment.Exit(0);
                            break;
                    }
                    


                }
                while ();


            }

            catch (Exception ex)
            {
                Console.WriteLine("The program will be terminated. Due to " + ex.Message);
            }

            finally
            {

            }
        }

        private static void MainMenu()
        {
            Console.WriteLine("Welcome to the Bank of COVID\n" +
                        " Please make a selection from the following\n" +
                        "Bank Menu\n" +
                        "-------------" +
                        "A: Savings\n" +
                        "B: Checking\n" +
                        "C: GlobalSavings\n" +
                        "Q: Exit\n");
        }

        private static void SavingsMenu()
        {
            Console.WriteLine("Savings Menu\n" +
                           "-------------------" +
                           "A: Deposit\n" +
                           "B: Withdrawl\n" +
                           "C: Close + Report\n" +
                           "R: Return to Bank Menu\n");

            switch (Console.ReadLine().ToUpper())
            {
                case "A":
                    Savings.MakeDeposit();
                    break;
                case "B":
                    Savings.MakeWithdrawl();
                    break;
                case "C":
                    Savings.CloseAndReport();
                    break;
                case "R":
                    MainMenu();
                    break;

            }
        }
        private static void ChequingMenu()
        {
            Console.WriteLine("Chequing Menu\n" +
                           "--------------------" +
                           "A: Deposit\n" +
                           "B: Withdrawl\n" +
                           "C: Close + Report\n" +
                           "R: Return to Bank Menu\n");

            switch (Console.ReadLine().ToUpper())
            {
                case "A":
                    Chequing.MakeDeposit();
                    break;
                case "B":
                    Chequing.MakeWithdrawl();
                    break;
                case "C":
                    Chequing.CloseAndReport();
                    break;
                case "R":
                    MainMenu();
                    break;

            }
        }
        private static void GlobalSavingsMenu()
        {
            Console.WriteLine("Global Savings Menu\n" +
                            "-----------------------" +
                            "A: Deposit\n" +
                            "B: Withdrawl\n" +
                            "C: Close + Report\n" +
                            "D: Report Balance in USD\n" +
                            "R: Return to Bank Menu\n");

            switch (Console.ReadLine().ToUpper())
            {
                case "A":
                    GlobalSavingsAccount.MakeDeposit();
                    break;
                case "B":
                    GlobalSavingsAccount.MakeWithdrawl();
                    break;
                case "C":
                    GlobalSavingsAccount.CloseAndReport();
                    break;
                case "D":
                    GlobalSavingsAccount.BalanceinUSD();
                    break;
                case "R":
                    MainMenu();
                    break;

            }
           
        }

        
    }
}
