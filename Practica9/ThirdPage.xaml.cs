using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    /// Логика взаимодействия для ThirdPage.xaml
    /// </summary>
    public partial class ThirdPage : Page
    {
        public ThirdPage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.NavigationService.GoBack();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            var credentials = ImapHelper.GetCredentials();
            try
            {
                TextRange text = new TextRange(myRichTB.Document.ContentStart, myRichTB.Document.ContentEnd);

                MailMessage m = new MailMessage(credentials.Email, toTB.Text, subjectTB.Text, text.Text);
                m.IsBodyHtml = true;



                SmtpClient smtp = new SmtpClient(credentials.SmtpHost);
                smtp.Credentials = new NetworkCredential(credentials.Email, credentials.Pass);
                smtp.EnableSsl = true;
                smtp.Send(m);
                MessageBox.Show("Email sent successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
