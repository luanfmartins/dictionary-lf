using System.Globalization;
using System.Text.Json.Serialization;

namespace DictionaryLF.Models
{
    public class DictionaryResponse
    {
        public required string Word { get; set; }
        public required List<Phonetic> Phonetics { get; set; }
        public required List<Meaning> Meanings { get; set; }
    }
    public class Phonetic
    {
        public string? Text { get; set; }
        public required string Audio { get; set; }
    }
    public class Meaning
    {
        public required string PartOfSpeech { get; set; }
        public required List<Definition> Definitions { get; set; }
    }
    public class Definition
    {
        [JsonPropertyName("definition")]
        public required string DefinitionText { get; set; }
        [JsonPropertyName("synonyms")]
        public required List<string> SynonymsList { get; set; }
        public string? Example { get; set; }
    }
}
