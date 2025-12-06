using Olbrasoft.Text.Similarity;

namespace Text.Similarity.Tests;

public class LevenshteinSimilarityTests
{
    private readonly LevenshteinSimilarity _sut = new();

    #region Basic Similarity Tests

    [Fact]
    public void Similarity_IdenticalStrings_ReturnsOne()
    {
        // Arrange
        const string text = "hello world";

        // Act
        var result = _sut.Similarity(text, text);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Similarity_CompletelyDifferentStrings_ReturnsLowValue()
    {
        // Arrange
        const string a = "abc";
        const string b = "xyz";

        // Act
        var result = _sut.Similarity(a, b);

        // Assert
        Assert.True(result < 0.5);
    }

    [Fact]
    public void Similarity_SimilarStrings_ReturnsHighValue()
    {
        // Arrange
        const string a = "hello";
        const string b = "hallo";

        // Act
        var result = _sut.Similarity(a, b);

        // Assert
        Assert.True(result >= 0.75);
    }

    [Fact]
    public void Similarity_EmptyStrings_ReturnsOne()
    {
        // Act
        var result = _sut.Similarity("", "");

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Similarity_OneEmptyString_ReturnsZero()
    {
        // Act
        var result = _sut.Similarity("hello", "");

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Similarity_NullFirstString_ReturnsZero()
    {
        // Act
        var result = _sut.Similarity(null!, "hello");

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Similarity_NullSecondString_ReturnsZero()
    {
        // Act
        var result = _sut.Similarity("hello", null!);

        // Assert
        Assert.Equal(0.0, result);
    }

    #endregion

    #region Czech Language Tests (Real-world TTS echo scenarios)

    [Fact]
    public void Similarity_CzechTextWithDiacritics_HighSimilarity()
    {
        // Arrange - TTS output vs Whisper transcription
        const string tts = "Běží obě služby";
        const string whisper = "Běží obě služby";

        // Act
        var result = _sut.Similarity(tts, whisper);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Similarity_CzechTextWhisperErrors_StillSimilar()
    {
        // Arrange - Real scenario: TTS says correctly, Whisper makes errors
        const string tts = "Běží obě služby";
        const string whisper = "Věží obje služby"; // Whisper transcription errors

        // Act
        var result = _sut.Similarity(tts, whisper);

        // Assert - Should still be reasonably similar
        Assert.True(result >= 0.7, $"Expected similarity >= 0.7, but got {result}");
    }

    [Theory]
    [InlineData("Úspěšně dokončeno", "Uspesne dokonceno", 0.7)]
    [InlineData("Příliš žluťoučký kůň", "Prilis zlutoucky kun", 0.5)]
    [InlineData("Čeština je krásná", "Cestina je krasna", 0.7)]
    public void Similarity_CzechWithAndWithoutDiacritics_ReasonablySimilar(
        string withDiacritics, string withoutDiacritics, double minExpected)
    {
        // Act
        var result = _sut.Similarity(withDiacritics, withoutDiacritics);

        // Assert
        Assert.True(result >= minExpected, 
            $"Expected similarity >= {minExpected}, but got {result}");
    }

    #endregion

    #region Real-world Echo Detection Scenarios

    [Fact]
    public void Similarity_RealTtsEchoFromLog_DetectsMatch()
    {
        // Arrange - From actual log:
        // TTS: "Běží obě služby. ContinuousListener v terminálu a EdgeTTS server na pozadí."
        // Whisper: "Věží obje služby. Kontynuujte snad v terminálu a eštejte server na pozadní."
        const string tts = "Běží obě služby ContinuousListener v terminálu a EdgeTTS server na pozadí";
        const string whisper = "Věží obje služby Kontynuujte snad v terminálu a eštejte server na pozadní";

        // Act
        var result = _sut.Similarity(tts, whisper);

        // Assert - Should detect this is similar (echo)
        Assert.True(result >= 0.5, $"Expected similarity >= 0.5, but got {result}");
    }

    [Fact]
    public void Similarity_ShortTtsMessage_DetectsMatch()
    {
        // Arrange - Short TTS message
        const string tts = "Zjistím běžící služby";
        const string whisper = "Zjistím běžící služby";

        // Act
        var result = _sut.Similarity(tts, whisper);

        // Assert
        Assert.Equal(1.0, result);
    }

    #endregion

    #region Interface Implementation Tests

    [Fact]
    public void LevenshteinSimilarity_ImplementsInterface()
    {
        // Assert
        Assert.IsAssignableFrom<IStringSimilarity>(_sut);
    }

    [Fact]
    public void Similarity_ThroughInterface_Works()
    {
        // Arrange
        IStringSimilarity similarity = new LevenshteinSimilarity();

        // Act
        var result = similarity.Similarity("hello", "hello");

        // Assert
        Assert.Equal(1.0, result);
    }

    #endregion
}
