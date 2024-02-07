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
