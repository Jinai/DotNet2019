using System;

namespace SMS.BusinessLogic
{
    public class TranslatedString
    {
        public string English { get; set; }
        public string French { get; set; }
        public string Dutch { get; set; }

        public TranslatedString(string english, string french, string dutch)
        {
            if (String.IsNullOrEmpty(english))
                throw new ArgumentException("Please specify an English name.");
            if (String.IsNullOrEmpty(french))
                throw new ArgumentException("Please specify a French name.");
            if (String.IsNullOrEmpty(dutch))
                throw new ArgumentException("Please specify a Dutch name.");

            this.English = english;
            this.French = french;
            this.Dutch = dutch;
        }

        public string ToString(Language lang)
        {
            return lang switch
            {
                Language.English => English,
                Language.French => French,
                Language.Dutch => Dutch,
                _ => English,
            };
        }
    }
}
