using SMS.Shared.Enums;
using System;

namespace SMS.Shared
{
    public class TranslatedString
    {
        public string English { get; set; }
        public string French { get; set; }
        public string Dutch { get; set; }

        public TranslatedString(string english, string french, string dutch)
        {
            this.English = english;
            this.French = french;
            this.Dutch = dutch;
            CheckParameters();
        }

        private void CheckParameters()
        {
            if (String.IsNullOrEmpty(English) || String.IsNullOrWhiteSpace(English))
                throw new ArgumentException(nameof(English));
            if (String.IsNullOrEmpty(French) || String.IsNullOrWhiteSpace(French))
                throw new ArgumentException(nameof(French));
            if (String.IsNullOrEmpty(Dutch) || String.IsNullOrWhiteSpace(Dutch))
                throw new ArgumentException(nameof(Dutch));
        }

        public string ToString(Language lang)
        {
            return lang switch
            {
                Language.English => English,
                Language.French => French,
                Language.Dutch => Dutch,
                _ => throw new Exception($"Unknown language: '{nameof(lang)}'")
            };
        }
    }
}
