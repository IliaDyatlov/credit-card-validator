using System;

class Program
{
    static void Main(string[] args)
    {
        CreditCardValidator creditCardValidator = new CreditCardValidator();
        creditCardValidator.GetCardNumber();
    }
}

 class CreditCardValidator
{
    public static string card;

    public CreditCardValidator()
    {
        Console.Write("Enter card number: ");
        card = Console.ReadLine();
    }

    public void GetCardNumber()
    {
        GetPaymentSystemIdentifier();
        GetBankIdentificationNumber();
        GetCardIdentificationNumber();
        GetLuhnAlgorithm();
    }

    static void GetPaymentSystemIdentifier()
    {
        char[] cardNumber = card.ToCharArray();
        int psi = cardNumber[0];
        if (psi == '2')
        {
            Console.WriteLine($"Payment system identifier - World");
        }
        else if (psi == '3')
        {
            Console.WriteLine($"Payment system identifier - Maestro or American Express");
        }
        else if (psi == '4')
        {
            Console.WriteLine($"Payment system identifier - Visa");
        }
        else if (psi == '5')
        {
            Console.WriteLine($"Payment system identifier - Maestro or Master Card");
        }
        else if (psi == '6')
        {
            Console.WriteLine($"Payment system identifier - Maestro or China Union Pay");
        }
    }

    static void GetBankIdentificationNumber()
    {
        string bin = card[..6];
        Console.WriteLine($"Bank identification number(BIN) - {bin}");
    }

    static void GetCardIdentificationNumber()
    {
        string cardID = card[6..15];
        Console.WriteLine($"Card ID - {cardID}");
    }

    static void GetLuhnAlgorithm()
    {
        int sum = 0;

        for (int i = card.Length - 1; i > -1; i--)
        {
            int count = card[i];
            if ((i + 1) % 2 == 0)
            {
                count *= 2;
            }

            if (count > 9)
            {
                count -= 9;
                sum += count;
            }
        }

        if (sum % 10 == 0)
        {
            Console.WriteLine("Card number is true");
        }

        Console.WriteLine("Card number is false");
    }
}