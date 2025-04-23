namespace Core;

public enum Tense { Present, Imperative, Optative, Aorist, Future }
public enum Person { First, Second, Third }
public enum Number { Singular, Plural }
public enum Gender { Masculine, Feminine, Neuter }
public enum Case {
    Nominative, Vocative, Accusative, Instrumental,
    Dative, Ablative, Genitive, Locative
}

public class Verb
{
    public int Id { get; set; }
    public string Root { get; set; }  // Pali root
    public string Translation { get; set; } // English meaning
    public bool IsIrregular { get; set; } = false;

    public string Conjugate(Tense tense, Person person, Number number)
    {
        if (IsIrregular && IrregularForms.TryGetValue((tense, person, number), out var form))
            return form;

        var stem = GetPresentStem(); // Simplified assumption for demo
        var ending = VerbEndings.GetEnding(tense, person, number);
        return ApplySandhi(stem, ending);
    }

    string GetPresentStem()
    {
        // In production, this should be based on class pattern rules.
        return Root + "a"; // Example: pac -> paca
    }

    static string ApplySandhi(string stem, string ending)
    {
        // Simplified placeholder; you may apply vowel lengthening rules here
        if (stem.EndsWith("a") && ending.StartsWith("a"))
            return stem[..^1] + "ā" + ending[1..];
        return stem + ending;
    }

    public Dictionary<(Tense, Person, Number), string> IrregularForms { get; set; } = new();
}

public class Noun
{
    public int Id { get; set; }
    public string Stem { get; set; }
    public string Translation { get; set; }
    public Gender Gender { get; set; }
    public string DeclensionClass { get; set; } // e.g., masculine_a, feminine_ā, etc.

    public string Decline(Case nounCase, Number number)
    {
        if (IrregularForms.TryGetValue((nounCase, number), out var form))
            return form;

        var ending = NounEndings.GetEnding(DeclensionClass, nounCase, number);
        return Stem + ending;
    }

    public Dictionary<(Case, Number), string> IrregularForms { get; set; } = new();
}

public static class VerbEndings
{
    private static readonly Dictionary<Tense, Dictionary<Person, Dictionary<Number, string>>> endings = new()
    {
        [Tense.Present] = new Dictionary<Person, Dictionary<Number, string>>
        {
            [Person.First] = new() { [Number.Singular] = "āmi", [Number.Plural] = "āma" },
            [Person.Second] = new() { [Number.Singular] = "asi", [Number.Plural] = "atha" },
            [Person.Third] = new() { [Number.Singular] = "ati", [Number.Plural] = "anti" }
        },
        [Tense.Imperative] = new Dictionary<Person, Dictionary<Number, string>>
        {
            [Person.First] = new() { [Number.Singular] = "āmi", [Number.Plural] = "āma" },
            [Person.Second] = new() { [Number.Singular] = "āhi", [Number.Plural] = "atha" },
            [Person.Third] = new() { [Number.Singular] = "tu", [Number.Plural] = "ntu" }
        },
        [Tense.Optative] = new Dictionary<Person, Dictionary<Number, string>>
        {
            [Person.First] = new() { [Number.Singular] = "eyyāmi", [Number.Plural] = "eyyāma" },
            [Person.Second] = new() { [Number.Singular] = "eyyāsi", [Number.Plural] = "eyyātha" },
            [Person.Third] = new() { [Number.Singular] = "eyya", [Number.Plural] = "eyyuṃ" }
        },
        [Tense.Aorist] = new Dictionary<Person, Dictionary<Number, string>>
        {
            [Person.First] = new() { [Number.Singular] = "iṃ", [Number.Plural] = "imhā" },
            [Person.Second] = new() { [Number.Singular] = "i", [Number.Plural] = "ittha" },
            [Person.Third] = new() { [Number.Singular] = "i", [Number.Plural] = "iṃsu" }
        },
        [Tense.Future] = new Dictionary<Person, Dictionary<Number, string>>
        {
            [Person.First] = new() { [Number.Singular] = "ssāmi", [Number.Plural] = "ssāma" },
            [Person.Second] = new() { [Number.Singular] = "ssasi", [Number.Plural] = "ssatha" },
            [Person.Third] = new() { [Number.Singular] = "ssati", [Number.Plural] = "ssanti" }
        }
    };

    public static string GetEnding(Tense tense, Person person, Number number) =>
        endings[tense][person][number];
}

public static class NounEndings
{
    static readonly Dictionary<string, Dictionary<Case, Dictionary<Number, string>>> endings = new()
    {
        ["masculine_a"] = new Dictionary<Case, Dictionary<Number, string>>
        {
            [Case.Nominative] = new() { [Number.Singular] = "o", [Number.Plural] = "ā" },
            [Case.Vocative] = new() { [Number.Singular] = "a", [Number.Plural] = "ā" },
            [Case.Accusative] = new() { [Number.Singular] = "aṃ", [Number.Plural] = "e" },
            [Case.Instrumental] = new() { [Number.Singular] = "ena", [Number.Plural] = "ehi" },
            [Case.Dative] = new() { [Number.Singular] = "assa", [Number.Plural] = "ānaṃ" },
            [Case.Ablative] = new() { [Number.Singular] = "smā", [Number.Plural] = "ehi" },
            [Case.Genitive] = new() { [Number.Singular] = "assa", [Number.Plural] = "ānaṃ" },
            [Case.Locative] = new() { [Number.Singular] = "e", [Number.Plural] = "esu" }
        },
        ["feminine_ā"] = new Dictionary<Case, Dictionary<Number, string>>
        {
            [Case.Nominative] = new() { [Number.Singular] = "ā", [Number.Plural] = "āyo" },
            [Case.Vocative] = new() { [Number.Singular] = "e", [Number.Plural] = "āyo" },
            [Case.Accusative] = new() { [Number.Singular] = "aṃ", [Number.Plural] = "āyo" },
            [Case.Instrumental] = new() { [Number.Singular] = "āya", [Number.Plural] = "āhi" },
            [Case.Dative] = new() { [Number.Singular] = "āya", [Number.Plural] = "ānaṃ" },
            [Case.Ablative] = new() { [Number.Singular] = "āya", [Number.Plural] = "āhi" },
            [Case.Genitive] = new() { [Number.Singular] = "āya", [Number.Plural] = "ānaṃ" },
            [Case.Locative] = new() { [Number.Singular] = "āya", [Number.Plural] = "āsu" }
        }
        // Add more classes (neuter_a, masculine_i, etc.) as needed
    };

    public static string GetEnding(string declensionClass, Case nounCase, Number number) =>
        endings[declensionClass][nounCase][number];
}
