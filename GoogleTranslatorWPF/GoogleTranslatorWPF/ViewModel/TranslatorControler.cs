using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleTranslatorWebService;
using System.Windows;

/*
 * Sample application. 
 * Author: Pawel Pietrzak
 * p.d.pietrzak@gmail.com
 * Date: 14th of October
 * */

namespace GoogleTranslatorWPF.ViewModel
{
    public class TranslatorControler
    {
        public TranslatorControler(TranslatorViewModel translatorViewModel)
        {
            this.translatorViewModel = translatorViewModel;
            translatorViewModel.TranslateText += delegate
            {
                Task task = Task.Factory.StartNew(
                 () =>
                     {
                         translatorViewModel.ResultTranslation =
                            Translator.PerformTranslation(
                                    translatorViewModel.Source,
                                    translatorViewModel.SourceLanguage,
                                    translatorViewModel.DestinationLanguage);
                     }
                );
            };
            translatorViewModel.CopyToClipboardOutputText += delegate
            {
                         if (translatorViewModel.ResultTranslation!=null)
                            Clipboard.SetText(translatorViewModel.ResultTranslation);
            };
            translatorViewModel.ClearInputText += delegate
            {
                         translatorViewModel.Source = "";
            };
            translatorViewModel.SwapLanguages += delegate
            {
                var lang1 = translatorViewModel.SourceLanguage;
                translatorViewModel.SourceLanguage = translatorViewModel.DestinationLanguage;
                translatorViewModel.DestinationLanguage = lang1;
            };
        }
        TranslatorViewModel translatorViewModel;
    }
}
