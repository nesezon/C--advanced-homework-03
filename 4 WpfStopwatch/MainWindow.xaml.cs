using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

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
    private string clocktxt;
    public string Clocktxt {
      get { return clocktxt; }
      set {
        clocktxt = value;
        OnPropertyChanged("Clocktxt");
      }
    }

    DispatcherTimer dispatcherTimer = new DispatcherTimer();
    Stopwatch stopWatch = new Stopwatch();
    string currentTime = string.Empty;

    public MainWindow() {
      InitializeComponent();
      DataContext = this;
      dispatcherTimer.Tick += new EventHandler(dt_Tick);
      dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
      Clocktxt = "00:00:00";
    }

    void dt_Tick(object sender, EventArgs e) {
      if (stopWatch.IsRunning) {
        TimeSpan ts = stopWatch.Elapsed;
        currentTime = String.Format("{0:00}:{1:00}:{2:00}",
          ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        Clocktxt = currentTime;
      }
    }

    private void Start_Click(object sender, RoutedEventArgs e) {
      stopWatch.Start();
      dispatcherTimer.Start();
    }

    private void Stop_Click(object sender, RoutedEventArgs e) {
      if (stopWatch.IsRunning) {
        stopWatch.Stop();
      }
    }

    private void Reset_Click(object sender, RoutedEventArgs e) {
      stopWatch.Reset();  
      Clocktxt = "00:00:00"; 
    }
  }
}
