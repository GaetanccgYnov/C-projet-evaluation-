using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace CholletGaetan_Evaluation
{
    public partial class AjouterCommandeWindow : Window
    {
        public string connectionString = "Server=.\\SQLEXPRESS01;Database=BreadyToomysDB3;Trusted_Connection=True;";

        public AjouterCommandeWindow()
        {
            InitializeComponent();
            LoadProduits();
        }

        private void LoadProduits()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT IDProduit, Nom FROM Produits WHERE Statut = 'Active'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                ProduitComboBox.ItemsSource = dataTable.DefaultView;
            }
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProduitComboBox.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un produit.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int produitID = (int)ProduitComboBox.SelectedValue;
            string numeroCommande = NumeroCommandeTextBox.Text;
            string etatCommande = (EtatCommandeComboBox.SelectedItem as ComboBoxItem).Content.ToString();

            if (string.IsNullOrWhiteSpace(numeroCommande) || string.IsNullOrWhiteSpace(etatCommande))
            {
                MessageBox.Show("Veuillez entrer le numéro de commande et sélectionner l'état de la commande.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Commandes (IDProduit, NumeroCommande, EtatCommande) VALUES (@IDProduit, @NumeroCommande, @EtatCommande)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDProduit", produitID);
                    command.Parameters.AddWithValue("@NumeroCommande", numeroCommande);
                    command.Parameters.AddWithValue("@EtatCommande", etatCommande);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Commande ajoutée avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            Close();
        }
    }
}
