public class CustomerIdentification
{
    public int CustomersId { get; set; }
    public string SurName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string MobileNumber { get; set; }
    public string DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string MaritalStatus { get; set; }
    public string EmailAddress { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    // public string ConfirmPassword { get; set; }
    public decimal AccountBalance { get; set; }
    public string Pin { get; set; }
    public long AccountNumber { get; set; }
    public long BankVerificationNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    // public int? Type {get; set;}
    public decimal Amount {get; set;}
    public CustomerIdentification(int customerId, string surName, string firstName, string middleName, string mobileNumber, string dateOfBirth, string gender, string maritalStatus, string emailAddress, string address, string password,  decimal accountBalance, string pin, long accountNumber, long bankVerificationNumber, decimal amount)
    {
        CustomersId = customerId;
        SurName = surName;
        FirstName = firstName;
        MiddleName = middleName;
        MobileNumber = mobileNumber;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        MaritalStatus = maritalStatus;
        EmailAddress = emailAddress;
        Address = address;
        Password = password;
        AccountBalance = accountBalance;
        Pin = pin;
        AccountNumber = accountNumber;
        BankVerificationNumber = bankVerificationNumber;
        TransactionDate = DateTime.Now;
        Amount = amount;
    }
}