using System.ComponentModel;
using System.Windows;

namespace WpfStopwatch {
  public partial class MainWindow : Window, INotifyPropertyChanged {

    // реализация INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    // свойство зависиомости для связывания с TextBlock
    private double clocktxt;
    public double Clocktxt {
      get { return clocktxt; }
      set {
        clocktxt = value;
        OnPropertyChanged("Clocktxt");
      }
    }

    public MainWindow() {
      InitializeComponent();
      DataContext = this;
    }

    private void Start_Click(object sender, RoutedEventArgs e) {
      Clocktxt = 123;
    }

    private void Stop_Click(object sender, RoutedEventArgs e) {
      Clocktxt = 12345;
    }

    private void Reset_Click(object sender, RoutedEventArgs e) {
      Clocktxt = 123456789.7;
    }
  }
}
