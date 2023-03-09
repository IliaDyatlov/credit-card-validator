namespace CreditCardValidator.CLI;

class Program
{
    public static void Main()
    {
        Console.Write("Enter card number: ");
        string card = Console.ReadLine();
        CreditCardValidator creditCardValidator = new(card);
        Console.WriteLine(creditCardValidator.GetPaymentSystemIdentifier());
        Console.WriteLine(creditCardValidator.GetBankIdentificationNumber());
        Console.WriteLine(creditCardValidator.GetCardIdentificationNumber());
        Console.WriteLine(creditCardValidator.GetLuhnAlgorithm());
    }
}