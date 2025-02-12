
public class BankMenu
{
    public void MyMenu()
    {
        BankMenu menu = new();
        Account account1 = new();
        bool running = true;

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\x1B[1m");
        Console.WriteLine("Welcome to Hasbunallah Banking App");
        Console.ResetColor();
        
        while (running)
        {
            Console.WriteLine("Press any key to contrinue: ");
            Console.ReadKey();
            Console.WriteLine("Enter your option from 0 - 6:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. View your Profile");
            Console.WriteLine("3. View your Account Profile");
            Console.WriteLine("4. Login");
            Console.WriteLine("0. Signout");

            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                    account1.CreateAccount();
                    Console.WriteLine("You are welcome to Hasbunallah Plc");
                    break;
                case 2:
                    account1.MyProfile();
                    break;
                case 3:
                    account1.ProfileAccount();
                    break;
                case 4:
                    account1.LoginSystem();
                    Console.WriteLine("Enter your option from 0 - 6:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Check your balance");
                    Console.WriteLine("3. Withdrawal");
                    Console.WriteLine("4. Transaction Log");

                    Console.WriteLine("Enter your choice: ");
                    int option = int.Parse(Console.ReadLine()!);
                    switch (option)
                    {
                        case 1:
                            account1.Deposit();
                            break;
                        case 2:
                            account1.CheckBalance();
                            break;
                        case 3:
                            account1.Withdrawal();
                            break;
                        case 4:
                            account1.TransactionLog();
                            break;
                        default:
                            throw new Exception("Invalid choice. please try again.");
                    }
                    break;
                case 5:
                    account1.TransactionLog();
                    break;
                case 0:
                    running = false;
                    Console.WriteLine("Signing Out...........");
                    break;
                default:
                    throw new Exception("Invalid choice. please try again.");
            }
        }
    }
}