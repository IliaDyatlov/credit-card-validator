namespace CreditCardValidator.CLI;

public class CreditCardValidator
{
    private string _card = string.Empty;

    public CreditCardValidator(string card)
    {
        if (string.IsNullOrEmpty(card)) 
        {
            throw new ArgumentNullException(nameof(card));
        }

        if (card.Length < 16 || card.Length >16)
        {
            throw new ArgumentOutOfRangeException(nameof(card));
        }

        if (card.Any(char.IsLetter))
        {
            throw new ArgumentException(nameof(card));
        }

        _card = card;
    }

    public string GetPaymentSystemIdentifier()
    {
        char[] cardNumber = _card.ToCharArray();
        int psi = cardNumber[0];
        switch (psi)
        {
            case '2':
                return "World";
            case '3':
                return "Maestro or American Express";
            case '4':
                return "Visa";
            case '5':
                return "Maestro or Master Card";
            case '6':
                return "Maestro or American Express";
            default:
                return "Unknown";
        }
       
    }

    public string GetBankIdentificationNumber()
    {
        string bin = _card[..6];
        return bin;
    }

    public string GetCardIdentificationNumber()
    {
        string cardID = _card[6..15];
        return cardID;
    }

    public bool GetLuhnAlgorithm()
    {
        int sum = 0;

        for (int i = _card.Length - 1; i > -1; i--)
        {
            int count = _card[i];
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
            return true;
        }

        return false;
    }
}


