using ImapX;
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

namespace Practica9
{
    /// <summary>
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Page
    {
        private Message _message;
        public SecondPage(Message message)
        {
            InitializeComponent();
            _message = message;

            SenderTextBlock.Text = _message.From.ToString();
            RecipientTextBlock.Text = _message.To.FirstOrDefault()?.Address;
            SubjectTextBlock.Text = _message.Subject;
            ContentTextBlock.Text = _message.Body.Text;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.NavigationService.GoBack();
        }

        private void ReplyBtn_Click(object sender, RoutedEventArgs e)
        {
            ThirdPage thirdPage = new ThirdPage();
            NavigationService.Navigate(thirdPage);
        }
    }
}
