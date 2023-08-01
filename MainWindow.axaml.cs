using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Threading;

namespace AvaloniaApplication5 {
    public partial class MainWindow : Window {
        byte a = 0;
        static int processorcount = Environment.ProcessorCount;
        int exit = 0;
        public void cpukiller() {
            while (true) {
                a++;
                if(exit == 1) {
                    break;
                }
            }
        }
        public MainWindow() {
            InitializeComponent();
            Label1.Content = $"CPUºËÐÄÊý:{processorcount}";
            Button2.IsEnabled = false ;
            win.Closed += Win_Closed;
        }

        private void Win_Closed(object? sender, EventArgs e) {
            exit = 1;
            Thread.Sleep(5000);
            for (int i = 0; i < cpukillers.Length; i++) {
                cpukillers[i].Join();

            }
        }

        Thread[] cpukillers= new Thread[processorcount];
        public void start(object s,RoutedEventArgs e) {
            Button1.IsEnabled = false;
            Button2.IsEnabled = true ;
            exit = 0;
            ProgressBar1.IsIndeterminate = true;
            for(int i = 0; i < cpukillers.Length; i++) {
                cpukillers[i] = new Thread(cpukiller);
                cpukillers[i].Start();
            }
        }
        public void stop(object s, RoutedEventArgs e) {
            Button1.IsEnabled = true;
            Button2.IsEnabled = false;
            exit = 1;
            Thread.Sleep(500);
            ProgressBar1.IsIndeterminate = false;
            for (int i = 0; i < cpukillers.Length; i++) {
                cpukillers[i].Join();

            }
        }
    }
}