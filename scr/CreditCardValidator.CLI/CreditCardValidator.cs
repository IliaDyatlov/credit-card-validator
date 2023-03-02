public class CreditCardValidator
{
    private string _card = string.Empty;

    public CreditCardValidator(string card)
    {
        _card = card;
    }

    public string GetPaymentSystemIdentifier()
    {
        char[] cardNumber = _card.ToCharArray();
        int psi = cardNumber[0];
        switch (psi)
        {
            case '2':
                return "Payment system identifier - World";
            case '3':
                return "Payment system identifier - Maestro or American Express";
            case '4':
                return "Payment system identifier - Visa";
            case '5':
                return "Payment system identifier - Maestro or Master Card";
            case '6':
                return "Payment system identifier - Maestro or American Express";
        }
        return "Payment system identifier belongs to another bank";
    }

    public string GetBankIdentificationNumber()
    {
        string bin = _card[..6];
        return $"Bank identification number(BIN) - {bin}";
    }

    public string GetCardIdentificationNumber()
    {
        string cardID = _card[6..15];
        return $"Card ID - {cardID}";
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


