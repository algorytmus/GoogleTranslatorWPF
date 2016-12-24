using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.API.Translate;

namespace GoogleTranslatorWPF.Model
{
    public class Translation
    {
        public string Source { get; set; }
        public Google.API.Translate.Language SourceLanguage { get; set; }
        public Google.API.Translate.Language DestinationLanguage { get; set; }
        public string ResultTranslation { get; set; }
        public Google.API.Translate.Language LanguageVersion { get; set; }
    }
}
