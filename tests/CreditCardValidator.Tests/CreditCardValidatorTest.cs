using NUnit.Framework;

namespace CreditCardValidator.Tests;

[TestFixture]
public class CreditCardValidatorTest
{
    [Test]
    public void ValidationTest()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            new CLI.CreditCardValidator(null);
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            new CLI.CreditCardValidator(string.Empty);
        });

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new CLI.CreditCardValidator("4561239877456");
        });

        Assert.Throws<ArgumentException>(() =>
        {
            new CLI.CreditCardValidator("25qw691479876542");
        });
    }

    [TestCase("1478523698746345", "Unknown")]
    [TestCase("2583691479876542", "World")]
    [TestCase("3692581479876542", "Maestro or American Express")]
    [TestCase("4561237899632584", "Visa")]
    [TestCase("5642318979638524", "Maestro or Master Card")]
    [TestCase("6549873219638524", "Maestro or American Express")]
    [TestCase("7896541236987456", "Unknown")]
    [TestCase("8521364798564751", "Unknown")]
    [TestCase("9874236451249875", "Unknown")]
    public void ReturnPSITest(string cardNumber, string expectedPsi)
    {
        var ccv = new CLI.CreditCardValidator(cardNumber);
        var result = ccv.GetPaymentSystemIdentifier();

        Assert.AreEqual(expectedPsi, result);
    }

    [TestCase("2583691479876542", "258369")]
    [TestCase("3692581479876542", "369258")]
    [TestCase("4561237899632584", "456123")]
    [TestCase("5642318979638524", "564231")]
    [TestCase("6549873219638524", "654987")]
    public void ReturnBINTest(string cardNumber, string expectedBin)
    {
        var ccv = new CLI.CreditCardValidator(cardNumber);
        var result = ccv.GetBankIdentificationNumber();

        Assert.AreEqual(expectedBin, result);
    }

    [TestCase("2583691479876542", "147987654")]
    [TestCase("3692581479876542", "147987654")]
    [TestCase("4561237899632584", "789963258")]
    [TestCase("5642318979638524", "897963852")]
    [TestCase("6549873219638524", "321963852")]
    public void ReturnCardIDTest(string cardNumber, string expectedCardID)
    {
        var ccv = new CLI.CreditCardValidator(cardNumber);
        var result = ccv.GetCardIdentificationNumber();

        Assert.AreEqual(expectedCardID, result);
    }

    [TestCase("4567891237539515", false)]
    [TestCase("3214569874123695", true)]
    public void ReturnLuhnTest(string cardNumber, bool expectedBool)
    {
        var ccv = new CLI.CreditCardValidator(cardNumber);
        var result = ccv.GetLuhnAlgorithm();

        Assert.AreEqual(expectedBool, result);
    }
}
