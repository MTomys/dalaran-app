using DalaranApp.Domain.Auth.ValueObjects;

namespace DalaranApp.Tests.Domain.Auth;

public class SecretPassphraseTests 
{
    [Fact]
    public void SecretPhrases_ShouldYieldEqual_WhenPassphrasesAreIdentical()
    {
        var passphraseOne = new SecretPassphrase();
        var passphraseTwo = new SecretPassphrase();
        // TODO: DODAJ BINDA DO ODPALENIA WSZYSTKICH TESTÓW W VIEW
        
        Assert.Equal(passphraseOne, passphraseTwo);
    }
}