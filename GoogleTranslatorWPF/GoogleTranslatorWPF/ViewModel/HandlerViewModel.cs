using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * Sample application. 
 * Author: Pawel Pietrzak
 * p.d.pietrzak@gmail.com
 * Date: 14th of October
 * */

namespace GoogleTranslatorWPF.ViewModel
{
    public interface HandlerViewModel
    {
        event EventHandler SwitchOnClipBoardHandling;
        event EventHandler SwitchOffClipBoardHandling;

        event EventHandler TranslateText;
        event EventHandler ClearInputText;
        event EventHandler CopyToClipboardOutputText;

        event EventHandler ChooseSourceLanguage;
        event EventHandler ChooseDestinationLanguage;
        event EventHandler ChooseLanguageVersion;

        event EventHandler SwapLanguages;
    }
}
