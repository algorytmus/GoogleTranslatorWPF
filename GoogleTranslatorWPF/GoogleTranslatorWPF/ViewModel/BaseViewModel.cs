using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
/*
 * Sample application. 
 * Author: Pawel Pietrzak
 * p.d.pietrzak@gmail.com
 * Date: 14th of October
 * */

namespace GoogleTranslatorWPF.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract ICommand SwitchOnClipBoardHandlingCommand { get; }
        public abstract ICommand SwitchOffClipBoardHandlingCommand { get; }
        public abstract ICommand TranslateTextCommand { get; }
        public abstract ICommand ChooseSourceLanguageCommand { get; }
        public abstract ICommand ChooseDestinationLanguageCommand { get; }
        public abstract ICommand ChooseLanguageVersionCommand { get; }
        public abstract ICommand ClearInputTextCommand { get; }
        public abstract ICommand CopyToClipboardOutputTextCommand { get; }
        public abstract ICommand SwapLanguagesCommand { get; }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public void Dispose()
        {
           
        }
    }
}
