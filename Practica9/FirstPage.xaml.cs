using ImapX.Collections;
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
using System.Collections.ObjectModel;

namespace Practica9
{
    /// <summary>
    /// Логика взаимодействия для FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        private ObservableCollection<Message> messagesCollection = new ObservableCollection<Message>();

        public FirstPage(string folderName)
        {
            InitializeComponent();
            LoadMessagesAsync(folderName);
        }

        private async void LoadMessagesAsync(string folderName)
        {
            try
            {
                loadingProgressRing.Visibility = Visibility.Visible;
                loadingProgressRing.IsActive = true;

                messagesCollection.Clear();

                var messages = await Task.Run(() => ImapHelper.GetMessagesForFolder(folderName));

                foreach (var message in messages)
                {
                    messagesCollection.Add(message);
                }

                messagesLV.ItemsSource = messagesCollection;

                loadingProgressRing.IsActive = false;
                loadingProgressRing.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

            }
        }

        private void MessagesLV_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (messagesLV.SelectedItem is Message selectedMessage)
            {
                SecondPage secondPage = new SecondPage(selectedMessage);
                NavigationService.Navigate(secondPage);
            }
        }

        private void OpenContext_Click(object sender, RoutedEventArgs e)
        {
            if (messagesLV.SelectedItem is Message selectedMessage)
            {
                SecondPage secondPage = new SecondPage(selectedMessage);
                NavigationService.Navigate(secondPage);
            }
        }

        private void SendContext_Click(object sender, RoutedEventArgs e)
        {
            ThirdPage thirdPage = new ThirdPage();
            NavigationService.Navigate(thirdPage);
        }
    }
}
