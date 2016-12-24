using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RavSoft.GoogleTranslator;
using Google.API.Translate;
/*
 * Sample application. 
 * Author: Pawel Pietrzak
 * p.d.pietrzak@gmail.com
 * Date: 14th of October
 * */

namespace GoogleTranslatorWebService
{
    /// <summary>
    /// 
    /// </summary>
    public class Translator
    {
        public static Google.API.Translate.Language DefaultFrom = Google.API.Translate.Language.German;
        public static Google.API.Translate.Language DefaultTo = Google.API.Translate.Language.English;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static string PerformTranslation( string text, Language from, Language to)
        {
            RavSoft.GoogleTranslator.Translator t = new RavSoft.GoogleTranslator.Translator();
            t.SourceLanguage = from.ToString();
            t.TargetLanguage = to.ToString();
            t.SourceText = text;
            t.Translate();
            return t.Translation;
        }

        public static Language FromName(string name)
        {
            return (Language)Enum.Parse(typeof(Language), name);
        }
        /// <summary>
        /// List of available languages
        /// </summary>
        public static IEnumerable<Language> Languages
        {
            get
            {
                if (languages == null)
                    languages = new SortedSet<Language>(
                        Enum.GetValues(typeof(Language)).Cast<Language>()
                        );
                return languages;
            }
        }
        private static SortedSet<Language> languages=null;
    }
    
}
