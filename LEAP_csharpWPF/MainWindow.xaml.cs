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
using System.Threading;
using Leap;

namespace LEAP_csharpWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //Sample sample; //sample类
        //Thread sample_thread = null;//投币器进程
        private Controller controller = new Controller();
        private SampleListener listener;
        public MainWindow() {                   

            InitializeComponent();
            //Sample sample = new Sample();
            this.listener = new SampleListener();
            this.controller = new Controller();

            // Have the sample listener receive events from the controller
            this.controller.AddListener(listener);

            // Keep this process running until Enter is pressed
            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //sample = new Sample();
            /*try {
                sample_thread = new Thread(new ThreadStart(sample.initSample));
                sample_thread.Start();
            }  //初始化选择COM口
            catch {
                MessageBox.Show("leap启动失败"); Application.Current.Shutdown();
            }*/
            SampleListener listener = new SampleListener();
            Controller controller = new Controller();

            // Have the sample listener receive events from the controller
            controller.AddListener(listener);

            // Keep this process running until Enter is pressed
            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();
        }
    }
}
