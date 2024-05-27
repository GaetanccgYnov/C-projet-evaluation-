using System;
using System.Data.SqlClient;
using System.Windows;

namespace CholletGaetan_Evaluation
{
    public partial class LoginWindow : Window
    {
        public string connectionString = "Server=.\\SQLEXPRESS01;Database=BreadyToomysDB3;Trusted_Connection=True;";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string pseudo = PseudoTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez entrer un pseudo et un mot de passe.", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ValidateUser(pseudo, password))
            {
                MessageBox.Show("Connexion réussie!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.DialogResult = true; 
            }
            else
            {
                MessageBox.Show("Pseudo ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool ValidateUser(string pseudo, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Utilisateur WHERE Pseudo = @Pseudo AND MotDePasse = @MotDePasse";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Pseudo", pseudo);
                    command.Parameters.AddWithValue("@MotDePasse", password);

                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
            }
        }

        private void InscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            string pseudo = PseudoTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez entrer un pseudo et un mot de passe.", "Erreur d'inscription", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CreateUser(pseudo, password))
            {
                MessageBox.Show("Inscription réussie!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Pseudo déjà utilisé.", "Erreur d'inscription", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CreateUser(string pseudo, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Utilisateur (Pseudo, MotDePasse) VALUES (@Pseudo, @MotDePasse)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Pseudo", pseudo);
                    command.Parameters.AddWithValue("@MotDePasse", password);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
