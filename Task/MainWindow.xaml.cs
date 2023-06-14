using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task
{
    public partial class MainWindow : Window
    {
        private int clickCount = 0;
        private bool isProcessingClick = false;
        public MainWindow()
        {
            InitializeComponent();
            UpdateClickCountLabel();
        }

        private void UpdateClickCountLabel()
        {
            clickCountLabel.Content = clickCount.ToString();
        }

        private async void clickButton_Click(object sender, EventArgs e)
        {
            if (isProcessingClick)
                return;

            isProcessingClick = true;
            clickButton.IsEnabled = false;

            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                clickCount++;
            });

            isProcessingClick = false;
            clickButton.IsEnabled = true;
            UpdateClickCountLabel();
        }
    }
}
