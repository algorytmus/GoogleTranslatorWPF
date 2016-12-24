using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GoogleTranslatorWPF.Model;
using Google.API.Translate;
/*
 * Sample application. 
 * Author: Pawel Pietrzak
 * p.d.pietrzak@gmail.com
 * Date: 14th of October
 * */

namespace GoogleTranslatorWPF.ViewModel
{
    public class TranslatorViewModel : BaseViewModel, HandlerViewModel
    {
        public event EventHandler SwitchOnClipBoardHandling;
        public event EventHandler SwitchOffClipBoardHandling;

        public event EventHandler TranslateText;
        public event EventHandler ClearInputText;
        public event EventHandler CopyToClipboardOutputText;

        public event EventHandler ChooseSourceLanguage;
        public event EventHandler ChooseDestinationLanguage;
        public event EventHandler ChooseLanguageVersion;

        public event EventHandler SwapLanguages;


        RelayCommand switchOnClipBoardHandlingCommand;
        RelayCommand switchOffClipBoardHandlingCommand;

        RelayCommand translateTextCommand;
        RelayCommand clearInputTextCommand;
        RelayCommand copyToClipboardOutputTextCommand;

        RelayCommand chooseSourceLanguageCommand;
        RelayCommand chooseDestinationLanguageCommand;
        RelayCommand chooseLanguageVersionCommand;

        RelayCommand swapLanguagesCommand;

        Language _languageVersion;

        private Translation translation = new Translation()
        {
            Source = "",
            ResultTranslation = "",
            SourceLanguage = GoogleTranslatorWebService.Translator.DefaultFrom,
            DestinationLanguage = GoogleTranslatorWebService.Translator.DefaultTo
        };

        public string Source
        {
            get { return translation.Source; }
            set 
            {
                if(value==null)
                    translation.Source = "";
                else
                    translation.Source = value;
                base.OnPropertyChanged("Source");
            }
        }
        public Google.API.Translate.Language SourceLanguage
        {
            get { return translation.SourceLanguage; }
            set
            {
                translation.SourceLanguage = value;
                base.OnPropertyChanged("SourceLanguage");
            }
        }
        public Google.API.Translate.Language DestinationLanguage
        {
            get { return translation.DestinationLanguage; }
            set
            {
                if (value == Google.API.Translate.Language.Unknown)
                    translation.DestinationLanguage = Google.API.Translate.Language.English;
                else
                    translation.DestinationLanguage = value;

                base.OnPropertyChanged("DestinationLanguage");
            }
        }
        public Google.API.Translate.Language LanguageVersion
        {
            get { return _languageVersion; }
            set
            {
                _languageVersion = value;
                base.OnPropertyChanged("LanguageVersion");
            }
        }
        public string ResultTranslation
        {
            get { return translation.ResultTranslation; }
            set
            {
                if (value!=null)
                    translation.ResultTranslation = value;
                base.OnPropertyChanged("ResultTranslation");
            }
        }

        public IEnumerable<Google.API.Translate.Language> Languages
        {
            get { return GoogleTranslatorWebService.Translator.Languages; }
        }
     
        public override ICommand SwitchOnClipBoardHandlingCommand
        {
            get
            {
                if (switchOnClipBoardHandlingCommand == null)
                    switchOnClipBoardHandlingCommand = new RelayCommand(par => this.OnSwitchOnClipBoardHandling());

                return switchOnClipBoardHandlingCommand;
            }
        }
        public override ICommand SwitchOffClipBoardHandlingCommand
        {
            get
            {
                if (switchOffClipBoardHandlingCommand == null)
                    switchOffClipBoardHandlingCommand = new RelayCommand(par => this.OnSwitchOnClipBoardHandling());
                return switchOffClipBoardHandlingCommand;
            }
        }
        public override ICommand TranslateTextCommand
        {
            get
            {
                if (translateTextCommand == null)
                    translateTextCommand = new RelayCommand(par => this.OnTranslateText());
                return translateTextCommand;
            }
        }
        public override ICommand ChooseSourceLanguageCommand
        {
            get
            {
                if (chooseSourceLanguageCommand == null)
                    chooseSourceLanguageCommand = new RelayCommand(par => this.OnOpenSourceLanguagePanel());
                return chooseSourceLanguageCommand;
            }
        }
        public override ICommand ChooseDestinationLanguageCommand
        {
            get
            {
                if (chooseDestinationLanguageCommand == null)
                    chooseDestinationLanguageCommand = new RelayCommand(par => this.OnOpenDestinationLanguagePanel());

                return chooseDestinationLanguageCommand;
            }
        }
        public override ICommand ChooseLanguageVersionCommand
        {
            get
            {
                if (chooseLanguageVersionCommand == null)
                    chooseLanguageVersionCommand = new RelayCommand(par => this.OnOpenLanguageVersionPanel());

                return chooseLanguageVersionCommand;
            }
        }
        public override ICommand ClearInputTextCommand
        {
            get
            {
                if (clearInputTextCommand == null)
                    clearInputTextCommand = new RelayCommand(par => this.OnClearInputText());

                return clearInputTextCommand;
            }
        }
        public override ICommand CopyToClipboardOutputTextCommand
        {
            get
            {
                if (copyToClipboardOutputTextCommand == null)
                    copyToClipboardOutputTextCommand = new RelayCommand(par => this.OnCopyToClipboardOutputText());

                return copyToClipboardOutputTextCommand;
            }
        }
        public override ICommand SwapLanguagesCommand
        {
            get
            {
                if (swapLanguagesCommand == null)
                    swapLanguagesCommand = new RelayCommand(par => this.OnSwapLanguages());

                return swapLanguagesCommand;
            }
        }
        void OnSwitchOnClipBoardHandling()
        {
            EventHandler handler = this.SwitchOnClipBoardHandling;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void OnSwitchOffClipBoardHandling()
        {
            EventHandler handler = this.SwitchOffClipBoardHandling;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void OnOpenSourceLanguagePanel()
        {
            EventHandler handler = this.ChooseSourceLanguage;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void OnOpenDestinationLanguagePanel()
        {
            EventHandler handler = this.ChooseDestinationLanguage;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void OnOpenLanguageVersionPanel()
        {
            EventHandler handler = this.ChooseLanguageVersion;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void OnTranslateText()
        {
            EventHandler handler = this.TranslateText;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void OnClearInputText()
        {
            EventHandler handler = this.ClearInputText;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void OnCopyToClipboardOutputText()
        {
            EventHandler handler = this.CopyToClipboardOutputText;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void OnSwapLanguages()
        {
            EventHandler handler = this.SwapLanguages;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
