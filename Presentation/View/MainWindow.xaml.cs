using System;
using System.Windows;

namespace Presentation
{
    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new ViewModel(new Model());
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => DataContext = viewModel;
        }
    }
}
