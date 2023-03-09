using NUnit.Framework;

namespace CreditCardValidator.Tests;

[TestFixture]
public class CreditCardValidatorTest
{
    
    [TestCase("2", "World")]
    [TestCase("3", "Maestro or American Express")]
    [TestCase("4", "Visa")]
    [TestCase("5", "Maestro or Master Card")]
    [TestCase("6", "Maestro or American Express")]
    public void ReturnPSITest(string cardNumber, string expectedNumber)
    {
        var ccv = new CLI.CreditCardValidator(cardNumber);
        var result = ccv.GetPaymentSystemIdentifier();

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("2583691479876542", "BIN - 258369")]
    [TestCase("3692581479876542", "BIN - 369258")]
    [TestCase("4561237899632584", "BIN - 456123")]
    [TestCase("5642318979638524", "BIN - 564231")]
    [TestCase("6549873219638524", "BIN - 654987")]
    public void ReturnBINTest(string cardNumber, string expectedNumber)
    {
        var ccv = new CLI.CreditCardValidator(cardNumber);
        var result = ccv.GetBankIdentificationNumber();

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("2583691479876542", "Card ID - 147987654")]
    [TestCase("3692581479876542", "Card ID - 147987654")]
    [TestCase("4561237899632584", "Card ID - 789963258")]
    [TestCase("5642318979638524", "Card ID - 897963852")]
    [TestCase("6549873219638524", "Card ID - 321963852")]
    public void ReturnCardIDTest(string cardNumber, string expectedNumber)
    {
        var ccv = new CLI.CreditCardValidator(cardNumber);
        var result = ccv.GetCardIdentificationNumber();

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("4567891237539515", false)]
    [TestCase("3214569874123695", true)]
    public void ReturnLuhnTest(string cardNumber, bool expectedNumber)
    {
        var ccv = new CLI.CreditCardValidator(cardNumber);
        var result = ccv.GetLuhnAlgorithm();

        Assert.AreEqual(expectedNumber, result);
    }
}
