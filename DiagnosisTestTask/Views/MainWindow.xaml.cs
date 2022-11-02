using System.Windows;
using DiagnosisTestTask.Services;
using DiagnosisTestTask.ViewModels;

namespace DiagnosisTestTask.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(new DefaultFileService(), new DefaultDialogService());
        }
    }
}
