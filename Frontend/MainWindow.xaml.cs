using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjektWocheChat
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the username from the TextBox
            string username = UsernameTextBox.Text;

            // Check if the username is not empty
            if (!string.IsNullOrEmpty(username))
            {
                // Add the username to the Online Users ListBox
                OnlineUsersListBox.Items.Add(username);

                // Show a success message
                MessageBox.Show($"User {username} successfully registered!");

                // Switch to the Chat page (Set the visibilities of the Grids)
                LoginGrid.Visibility = Visibility.Collapsed;
                ChatGrid.Visibility = Visibility.Visible;
            }
            else
            {
                // Show an error message if the username is empty
                MessageBox.Show("Please enter a username!");
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the username from the TextBox
            string username = UsernameTextBox.Text;

            // Check if the username is in the Online Users ListBox
            if (OnlineUsersListBox.Items.Contains(username))
            {
                // Show a success message
                MessageBox.Show($"User {username} successfully logged in!");

                // Switch to the Chat page (Set the visibilities of the Grids)
                LoginGrid.Visibility = Visibility.Collapsed;
                ChatGrid.Visibility = Visibility.Visible;
            }
            else
            {
                // Show an error message if the username is not registered
                MessageBox.Show("Username not registered. Please register first!");
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            // Get the entered message from the TextBox
            string message = MessageTextBox.Text;

            // Check if the message is not empty
            if (!string.IsNullOrEmpty(message))
            {
                // Create a new ListBoxItem for the message
                ListBoxItem messageItem = new ListBoxItem();
                messageItem.Content = message;

                // Set the appearance of the ListBoxItem (blue background)
                messageItem.Background = Brushes.LightBlue;
                messageItem.Padding = new Thickness(5);

                // Add the ListBoxItem to the ChatListBox
                ChatListBox.Items.Add(messageItem);

                // Clear the text in the MessageTextBox after sending
                MessageTextBox.Clear();
            }
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed without the Shift modifier
            if (e.Key == Key.Enter && (Keyboard.Modifiers & ModifierKeys.Shift) == 0)
            {
                // Call the Send_Click method to handle sending the message
                Send_Click(sender, e);

                // Set Handled to true to prevent the default behavior of Enter key
                e.Handled = true;
            }
        }
    }
}
