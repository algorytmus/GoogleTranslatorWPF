using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.API.Translate;

/*
 * Author: Pawel Pietrzak
 * p.d.pietrzak@gmail.com
 * Date: 14th of October
 * */

namespace GoogleTranslatorControls
{
    /// <summary>
    /// Interaction logic for ChooseLanguageDropDown.xaml
    /// </summary>
    public partial class ChooseLanguageDropDown : UserControl
    {
        public ChooseLanguageDropDown()
        {
            InitializeComponent();
        }
        public string Prefix
        {
            get { return _prefix; }
            set { 
                _prefix=value;
                SetValue(ChooseLanguageDropDown.PrefixProperty, _prefix = value);
            }
        }

        public Language SelectedLanguage
        {
            get 
            { 
                return _language;
            }
            set 
            {
                SetValue(ChooseLanguageDropDown.SelectedLanguageProperty, _language = value);
            }
        }

        public ICommand ChooseCommand
        {
            get { return _command; }
            set {
                SetValue(ChooseLanguageDropDown.CommandProperty, _command = value);
            }
        }

        private Language _language = GoogleTranslatorWebService.Translator.DefaultTo;
        private string _prefix = "->: ";
        private ICommand _command = null;

        public static readonly DependencyProperty SelectedLanguageProperty =
            DependencyProperty.RegisterAttached("SelectedLanguage", typeof(string), typeof(ChooseLanguageDropDown), new UIPropertyMetadata(null));
        public static readonly DependencyProperty PrefixProperty =
            DependencyProperty.RegisterAttached("Prefix", typeof(string), typeof(ChooseLanguageDropDown), new UIPropertyMetadata(null));
        
        public static readonly DependencyProperty CommandProperty =
           DependencyProperty.RegisterAttached("ChooseCommand", typeof(string), typeof(ChooseLanguageDropDown), new UIPropertyMetadata(null));
    }
}
