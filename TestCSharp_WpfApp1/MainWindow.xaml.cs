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
using AddSubtractHugeNumbersCS; //Added 1/22/2020 Thomas C. Downes

namespace TestCSharp_WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source == ButtonOkay)
            {
                MessageBox.Show("The Okay button is pressed.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("The original source is: " + e.OriginalSource.ToString(), "",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (e.Source == ButtonClose)
            {
                MessageBox.Show("The Close button is pressed.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("The original source is: " + e.OriginalSource.ToString(), "", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (e.Source == ButtonAddNums  )
            {
                //MessageBox.Show("The Okay button is pressed.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                AddNumbersTogether_Master();
            }

        }

        private void AddNumbersTogether_Master()
        {
            //
            //Added 1/22/2020 thomas downes
            //
            //AddSubtractHugeNumbers_CS.AddingDecs objectAdd = new AddingDecs();  

            string strErrMessage = "";
            string strSumResult;

            strSumResult =
             AddingDecs.AddAnyTwoDecStrings(TextBox1.Text, TextBox2.Text, ref strErrMessage);

            if (strErrMessage == "")
            {
                //MessageBox.Show("The sum of the boxes is : " + strSumResult + ".", "TestCSharp_WpfApp1",
                //    MessageBoxButton.OK, MessageBoxImage.Information);
                TextBoxResult.Text = strSumResult;
            }

            if (strErrMessage != "")
            {
                TextBoxResult.Text = strErrMessage;
                MessageBox.Show("The error message states: " + strErrMessage + ".", "TestCSharp_WpfApp1",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {





        }
    }
}
