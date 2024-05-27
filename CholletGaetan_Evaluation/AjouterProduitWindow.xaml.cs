using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace CholletGaetan_Evaluation
{
    public partial class AjouterProduitWindow : Window
    {
        public string connectionString = "Server=.\\SQLEXPRESS01;Database=BreadyToomysDB3;Trusted_Connection=True;";

        public AjouterProduitWindow()
        {
            InitializeComponent();
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            string nom = NomTextBox.Text;
            string aliments = AlimentsTextBox.Text;
            string type = (TypeComboBox.SelectedItem as ComboBoxItem).Content.ToString();

            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(aliments) || string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Produits (Nom, ListeDesAliments, TypeProduit, Statut) VALUES (@Nom, @Aliments, @Type, 'Active')";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nom", nom);
                    command.Parameters.AddWithValue("@Aliments", aliments);
                    command.Parameters.AddWithValue("@Type", type);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Produit ajouté avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            Close();
        }
    }
}
