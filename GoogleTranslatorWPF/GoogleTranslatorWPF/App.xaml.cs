using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using GoogleTranslatorWPF.ViewModel;

namespace GoogleTranslatorWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            TranslatorViewModel viewModel = new TranslatorViewModel();
            TranslatorControler controler = new TranslatorControler(viewModel);

            viewModel.ChooseSourceLanguage += delegate
            {
                MessageBox.Show("Source");
            };
            viewModel.ChooseDestinationLanguage += delegate
            {
                MessageBox.Show("Destination");
            };
            viewModel.ChooseLanguageVersion += delegate
            {
                MessageBox.Show("Version");
            };
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
