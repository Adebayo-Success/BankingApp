using ConsoleTables;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
public class Account : IUserAccount
{
    readonly List<CustomerIdentification> Accounts;
    public Account()
    {
        Accounts = [];
    }
    public void CreateAccount()
    {
        try
        {
            int customerId = Accounts.Count > 0 ? Accounts.Count + 1 : 1;

            Console.WriteLine("Personal Informations: ");

            Console.WriteLine("Surname");
            string surName = Console.ReadLine()!;
            ValidateNames(surName);

            Console.WriteLine("First name");
            string firstName = Console.ReadLine()!;
            ValidateNames(firstName);

            Console.WriteLine("Middle name");
            string middleName = Console.ReadLine()!;
            ValidateNames(middleName);

            Console.WriteLine("Mobile number");
            string mobileNumber = Console.ReadLine()!;
            ValidateMobleNumber(mobileNumber);

            Console.WriteLine("Gender");
            string gender = Console.ReadLine()!;

            Console.WriteLine("Date of birth (MM/dd/yyyy");
            string dateOfBirth = Console.ReadLine()!;
            ValidateDateOfBirth(dateOfBirth);

            Console.WriteLine("Marital status");
            string maritalStatus = Console.ReadLine()!;

            Console.WriteLine("Email Address");
            string emailAddress = Console.ReadLine()!;

            Console.WriteLine("Address");
            string address = Console.ReadLine()!;

            Console.WriteLine("Password");
            string password = Console.ReadLine()!;
            ValidatePassword(password);

            Console.WriteLine("Confirm password");
            string confirmPassword = Console.ReadLine()!;
            if (confirmPassword != password)
            {
                Console.WriteLine("confirm again");
                return;
            }
            decimal accountBalance = 0.00M;

            Random random = new Random();
            int pin = random.Next(1000, 9000);

            long accountNumber = random.NextInt64(1000000000, 9999999999);

            long bankVerificationNumber = random.NextInt64(10000000000, 99999999999);

            decimal amount = 0.00M; 

            Console.Clear();
            CustomerIdentification customerIdentification = new CustomerIdentification(customerId, surName, firstName, middleName, mobileNumber, dateOfBirth, gender, maritalStatus, emailAddress, address, password, accountBalance, pin, accountNumber, bankVerificationNumber, amount);
            Accounts.Add(customerIdentification);
            Console.WriteLine("Account Created Successfully");
        }
        catch (Exception)
        {
            Console.WriteLine("An error occured");
        }
    }
    public void MyProfile()
    {
        if (Accounts.Count == 0)
        {
            Console.WriteLine("No Account found.");
            return;
        }
        ConsoleTable table = new("Id", "SurName", " First Name", "Middle Name", "Mobile Number", "E-mail Address");
        foreach (var detail in Accounts)
        {
            table.AddRow(detail.CustomersId, detail.SurName, detail.FirstName, detail.MiddleName, detail.MobileNumber, detail.EmailAddress);
        }
        Console.WriteLine();
        table.Write(Format.Alternative);
        Console.WriteLine();
    }
    public void ProfileAccount()
    {
        Console.WriteLine("Customer Id");
        int id = int.Parse(Console.ReadLine()!);
        CustomerIdentification? customerIdentifications = Accounts.Find(a => a.CustomersId == id);
        if (customerIdentifications != null)
        {
            Console.WriteLine("grant access");
        }
        else
        {
            Console.WriteLine("Invalid Id");
        }

        if (Accounts.Count == 0)
        {
            Console.WriteLine("No Account found.");
        }
        else
        {
            foreach (var account in Accounts)
            {
                ConsoleTable table = new("Pin", "Account Balance", "Account Number", "BVN");
                foreach (var detail in Accounts)
                {
                    table.AddRow(account.Pin, account.AccountBalance, account.AccountNumber, account.BankVerificationNumber);
                }
                Console.WriteLine();
                table.Write(Format.Alternative);
                Console.WriteLine();
            }
        }
    }
    public void LoginSystem()
    {
        try
        {
            Console.WriteLine("Enter your Pin");
            int pin = int.Parse(Console.ReadLine()!);
            CustomerIdentification? account = Accounts.Find(a => a.Pin == pin);
            if (account != null)
            {
                Console.WriteLine("grant access");
            }
            else
            {
                Console.WriteLine("incorrect pin");
                return;
            }
        }
        catch (Exception)
        {
            throw new Exception("The account number you inputed does not exist");
        }
        return;

    }
    public void TransactionLog()
    {
        int? transactionType = Utility.SelectEnum("Deposit, Check Balance, Withdrawal:", 1, 3);
        foreach (var transaction in Accounts)
        {
            Console.WriteLine($"{transaction.CustomersId}  {transaction.TransactionDate}  {transaction.Amount}  {transactionType}  {transaction.Amount}");
        }
    }
    public void Deposit()
    {
        try
        {
            TransactionType.Deposit.ToString();
            Console.WriteLine("Enter your AccountNumber");
            long accountNumber = Convert.ToInt64(Console.ReadLine()!);

            Console.WriteLine("Enter Amount");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            CustomerIdentification? account = Accounts.Find(x => x.AccountNumber == accountNumber);
            if (account != null)
            {
                account.AccountBalance += amount;
                Console.WriteLine($"This account {accountNumber} has beign deposited with the sum of ${amount} dollars Successfully");
            }
        }
        catch (Exception)
        {
            throw new Exception("The account number you inputed does not exist");
        }
        return;
    }
    public void CheckBalance()
    {
        try
        {
            TransactionType.CheckBalance.ToString();
            Console.WriteLine("Enter your AccountNumber");
            long accountNumber = Convert.ToInt64(Console.ReadLine()!);

            CustomerIdentification? account = Accounts.Find(x => x.AccountNumber == accountNumber);
            if (account != null)
            {
                Console.Write($"The Account balance of this account number {accountNumber} is: $ + {account.AccountBalance}dollars");
                Console.WriteLine();
            }
        }
        catch (IOException)
        {
            Console.WriteLine($"The account number you entered does not exist");
            return;
        }
    }
    public void Withdrawal()
    {
        try
        {
            TransactionType.Withdrawal.ToString();
            Console.WriteLine("Enter the AccountNumber");
            long accountNumber = Convert.ToInt64(Console.ReadLine()!);

            Console.WriteLine("Enter Amount");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            CustomerIdentification? account = Accounts.Find(x => x.AccountNumber == accountNumber);
            if (account != null)
            {
                account.AccountBalance -= amount;
                Console.WriteLine($"This account {accountNumber} has beign debitted with the sum of ${amount} dollars Successfully");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("The account number you inputed does not exist.");
        }
    }

    public bool ValidateNames(string names)
    {
        if (names.Length < 3)
        {
            Console.WriteLine("Username must not be less than three charactrers");
            return false;
        }
        string namePattern = @"^[a-zA-Z@]+(?: [a-zA-Z@]+)*$";
        if (!Regex.IsMatch(names, namePattern))
        {
            return false;
        }
        return true;
    }
    public bool ValidateMobleNumber(string mobileNumber)
    {
        string phoneNumberPattern = @"^ [0-9]+ $";
        if (Regex.IsMatch(mobileNumber, phoneNumberPattern))
        {
            throw new Exception("Phone number can not contain a special character(s).");
        }
        if (mobileNumber.Length < 11 || mobileNumber.Length > 11)
        {
            throw new Exception("Phone number must be at least 11 digit.");
        }
        return true;
    }
    public bool ValidatePassword(string password)
    {
        string passwordPattern = @"^ [0-9]+ $";
        if (Regex.IsMatch(password, passwordPattern))
        {
            throw new Exception("Phone number can not contain a special character(s).");
        }
        if (password.Length < 6 || password.Length > 6)
        {
            throw new Exception("password must not be less than or greater than six digits.");
        }
        return true;
    }
    public void ValidateDateOfBirth(string dateOfBirth)
    {
        string dateOfBIrthPattern = @"^(MM/dd/yyyy)$";
        if (Regex.IsMatch(dateOfBirth, dateOfBIrthPattern))
        {
            throw new Exception("Date of birth can only be in this pattern (MM/dd/yyyy).");
        }
    }
    //     public bool ValidateLoginPin(string pin)
    //     {
    //         string pinPattern = @"^ [0-9]+ $";
    //         if (Regex.IsMatch(pin, pinPattern))
    //         {
    //             Console.WriteLine("Pin can not contain any form of character(s)");
    //             return false;
    //         }
    //         if (pin.Length < 4 || pin.Length > 4)
    //         {
    //             Console.WriteLine("Pin must not be less than or greater than four digits");
    //             return false;
    //         }
    //         return true;
    //     }
    //     public bool ValidateBankCode(string loginPin)
    //     {
    //         string bankCodePattern = @"^\*123#$";
    //         if (Regex.IsMatch(loginPin, bankCodePattern))
    //         {
    //             Console.WriteLine("GranAccess");
    //         }
    //         else
    //         {
    //             Console.WriteLine("Invalid Input");
    //             return false;
    //         }
    //         return true;
    //     }
    //     public bool ValidateLogoutCode(string logoutPin)
    //     {
    //         string bankCodePattern = @"^\*123#$";
    //         if (Regex.IsMatch(logoutPin, bankCodePattern))
    //         {
    //             Console.WriteLine("GranAccess");
    //         }
    //         else
    //         {
    //             Console.WriteLine("Invalid Input");
    //             return false;
    //         }
    //         return true;
    //     }
}