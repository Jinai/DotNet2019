using System;
using System.Collections.Generic;
using System.Text;

namespace SMSBusinessLogic
{
    public class Fournisseur
    {
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public Language LanguageChoice { get; set; }
    }
}
