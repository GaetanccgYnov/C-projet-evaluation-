using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace CholletGaetan_Evaluation
{
    public partial class MainWindow : Window
    {
        public string connectionString = "Server=.\\SQLEXPRESS01;Database=BreadyToomysDB3;Trusted_Connection=True;";

        public List<string> Statuts { get; set; } = new List<string> { "Active", "Archive" };
        public List<string> EtatsCommande { get; set; } = new List<string> { "Passée", "En cours...", "Terminée", "Distribuée" };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadProduits();
            LoadRecettes();
            LoadCommandes();
        }


        private void LoadProduits()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT IDProduit, Nom, ListeDesAliments, TypeProduit, Statut FROM Produits";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                ProduitsDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void LoadRecettes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT r.IDRecette, r.IDProduit, r.ListeDesEtapes, p.Nom AS NomProduit FROM Recettes r INNER JOIN Produits p ON r.IDProduit = p.IDProduit";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                RecettesDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }


        private void LoadCommandes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                SELECT c.IDCommande, c.NumeroCommande, p.Nom as NomProduit, c.EtatCommande
                FROM Commandes c
                JOIN Produits p ON c.IDProduit = p.IDProduit";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                CommandesDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }

        private void AjouterProduitButton_Click(object sender, RoutedEventArgs e)
        {
            AjouterProduitWindow ajouterProduitWindow = new AjouterProduitWindow();
            if (ajouterProduitWindow.ShowDialog() == true)
            {
                LoadProduits();
            }
        }

        private void AjouterRecetteButton_Click(object sender, RoutedEventArgs e)
        {
            AjouterRecetteWindow ajouterRecetteWindow = new AjouterRecetteWindow();
            if (ajouterRecetteWindow.ShowDialog() == true)
            {
                LoadRecettes();
            }
        }

        private void AjouterCommandeButton_Click(object sender, RoutedEventArgs e)
        {
            AjouterCommandeWindow ajouterCommandeWindow = new AjouterCommandeWindow();
            if (ajouterCommandeWindow.ShowDialog() == true)
            {
                LoadCommandes();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in ProduitsDataGrid.Items)
            {
                if (item is DataRowView rowView && rowView.Row.RowState == DataRowState.Modified)
                {
                    string nom = rowView["Nom"] as string;
                    string listeDesAliments = rowView["ListeDesAliments"] as string;
                    string statut = rowView["Statut"] as string;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Produits SET Nom = @Nom, ListeDesAliments = @ListeDesAliments, Statut = @Statut WHERE IDProduit = @IDProduit";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Nom", nom);
                            command.Parameters.AddWithValue("@ListeDesAliments", listeDesAliments);
                            command.Parameters.AddWithValue("@Statut", statut);
                            command.Parameters.AddWithValue("@IDProduit", rowView["IDProduit"]);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            foreach (var item in CommandesDataGrid.Items)
            {
                if (item is DataRowView rowView && rowView.Row.RowState == DataRowState.Modified)
                {
                    string etatCommande = rowView["EtatCommande"] as string;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Commandes SET EtatCommande = @EtatCommande WHERE IDCommande = @IDCommande";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EtatCommande", etatCommande);
                            command.Parameters.AddWithValue("@IDCommande", rowView["IDCommande"]);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Modifications sauvegardées avec succès", "Sauvegarde", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SupprimerProduitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProduitsDataGrid.SelectedItem is DataRowView rowView)
            {
                int idProduit = (int)rowView["IDProduit"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Produits WHERE IDProduit = @IDProduit";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDProduit", idProduit);
                        command.ExecuteNonQuery();
                    }
                }
                LoadProduits();
            }
        }

        private void SupprimerRecetteButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecettesDataGrid.SelectedItem is DataRowView rowView)
            {
                int idRecette = (int)rowView["IDRecette"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Recettes WHERE IDRecette = @IDRecette";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDRecette", idRecette);
                        command.ExecuteNonQuery();
                    }
                }
                LoadRecettes();
            }
        }

        private void SupprimerCommandeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CommandesDataGrid.SelectedItem is DataRowView rowView)
            {
                int idCommande = (int)rowView["IDCommande"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Commandes WHERE IDCommande = @IDCommande";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDCommande", idCommande);
                        command.ExecuteNonQuery();
                    }
                }
                LoadCommandes();
            }
        }
    }
}
