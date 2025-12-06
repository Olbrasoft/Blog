# Olbrasoft.Text.Similarity

String similarity algorithms for fuzzy text matching.

## Installation

```bash
dotnet add package Olbrasoft.Text.Similarity
```

## Usage

```csharp
using Olbrasoft.Text.Similarity;

// Register in DI container
services.AddSingleton<IStringSimilarity, LevenshteinSimilarity>();

// Use in your service
public class MyService
{
    private readonly IStringSimilarity _similarity;
    
    public MyService(IStringSimilarity similarity)
    {
        _similarity = similarity;
    }
    
    public bool AreTextsSimilar(string text1, string text2)
    {
        double similarity = _similarity.Similarity(text1, text2);
        return similarity >= 0.75; // 75% threshold
    }
}
```

## Available Algorithms

- **LevenshteinSimilarity** - Normalized Levenshtein distance (0.0 to 1.0)

## License

MIT
