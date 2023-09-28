using ImapX.Collections;
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
    /// Логика взаимодействия для NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        private CommonFolderCollection folders = ImapHelper.GetFolders();

        public NewWindow()
        {
            InitializeComponent();
            folders = ImapHelper.GetFolders();

            foreach (var folder in folders)
            {
                Button folderButton = new Button();
                folderButton.Style = FindResource("FolderButton") as Style;
                folderButton.Content = folder.Name;
                folderButton.Click += FolderButton_Click;
                foldersTreeView.Items.Add(folderButton);
            }
        }

        private void FoldersTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (foldersTreeView.SelectedItem is TreeViewItem selectedNode)
            {
                string selectedFolderName = selectedNode.Header.ToString();
                FirstPage firstPage = new FirstPage(selectedFolderName);
                contentFrame.NavigationService.Navigate(firstPage);
            }
        }

        private void FolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string selectedFolderName = button.Content.ToString();
                FirstPage firstPage = new FirstPage(selectedFolderName);
                contentFrame.Content = firstPage;
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            ThirdPage thirdPage = new ThirdPage();
            contentFrame.NavigationService.Navigate(thirdPage);
        }
    }
}
