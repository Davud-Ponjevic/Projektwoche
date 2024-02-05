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
            // Holen Sie den Benutzernamen aus der TextBox
            string username = UsernameTextBox.Text;

            // Überprüfen Sie, ob der Benutzername nicht leer ist
            if (!string.IsNullOrEmpty(username))
            {
                // Fügen Sie den Benutzernamen zur ListBox der Online-Benutzer hinzu
                OnlineUsersListBox.Items.Add(username);

                // Zeigen Sie eine Erfolgsmeldung an
                MessageBox.Show($"Benutzer {username} erfolgreich registriert!");

                // Wechseln Sie zur Chat-Seite (Setzen Sie die Sichtbarkeiten der Grids)
                LoginGrid.Visibility = Visibility.Collapsed;
                ChatGrid.Visibility = Visibility.Visible;
            }
            else
            {
                // Zeigen Sie eine Fehlermeldung an, wenn der Benutzername leer ist
                MessageBox.Show("Bitte geben Sie einen Benutzernamen ein!");
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Holen Sie den Benutzernamen aus der TextBox
            string username = UsernameTextBox.Text;

            // Überprüfen Sie, ob der Benutzername in der ListBox der Online-Benutzer enthalten ist
            if (OnlineUsersListBox.Items.Contains(username))
            {
                // Zeigen Sie eine Erfolgsmeldung an
                MessageBox.Show($"Benutzer {username} erfolgreich eingeloggt!");

                // Wechseln Sie zur Chat-Seite (Setzen Sie die Sichtbarkeiten der Grids)
                LoginGrid.Visibility = Visibility.Collapsed;
                ChatGrid.Visibility = Visibility.Visible;
            }
            else
            {
                // Zeigen Sie eine Fehlermeldung an, wenn der Benutzername nicht registriert ist
                MessageBox.Show("Benutzername nicht registriert. Bitte registrieren Sie sich zuerst!");
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            // Holen Sie die eingegebene Nachricht aus dem TextBox
            string message = MessageTextBox.Text;

            // Überprüfen Sie, ob die Nachricht nicht leer ist
            if (!string.IsNullOrEmpty(message))
            {
                // Erstellen Sie ein neues ListBoxItem für die Nachricht
                ListBoxItem messageItem = new ListBoxItem();
                messageItem.Content = message;

                // Setzen Sie das Aussehen des ListBoxItems (blauer Hintergrund)
                messageItem.Background = Brushes.LightBlue;
                messageItem.Padding = new Thickness(5);

                // Fügen Sie das ListBoxItem zur ListBox hinzu
                ChatListBox.Items.Add(messageItem);

                // Löschen Sie den Text aus dem TextBox nach dem Senden
                MessageTextBox.Clear();
            }
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Verhindern Sie, dass der Zeilenumbruch im TextBox eingefügt wird
                e.Handled = true;

                // Senden Sie die Nachricht
                Send_Click(sender, e);
            }
        }

    }
}
