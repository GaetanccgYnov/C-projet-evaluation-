using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CholletGaetan_Evaluation
{
    public partial class AjouterRecetteWindow : Window
    {
        public string connectionString = "Server=.\\SQLEXPRESS01;Database=BreadyToomysDB3;Trusted_Connection=True;";

        public AjouterRecetteWindow()
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
            string etapes = EtapesTextBox.Text;

            if (string.IsNullOrWhiteSpace(etapes))
            {
                MessageBox.Show("Veuillez entrer les étapes de la recette.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Recettes (IDProduit, ListeDesEtapes) VALUES (@IDProduit, @Etapes)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDProduit", produitID);
                    command.Parameters.AddWithValue("@Etapes", etapes);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Recette ajoutée avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            Close();
        }
    }
}
