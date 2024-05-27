-- Création de la base de données BreadyToomysDB3
CREATE DATABASE BreadyToomysDB3;
GO

-- Utilisation de la base de données BreadyToomysDB3
USE BreadyToomysDB3;
GO

-- Création de la table Produits
CREATE TABLE Produits (
    IDProduit INT PRIMARY KEY IDENTITY,
    Nom NVARCHAR(100) NOT NULL,
    ListeDesAliments NVARCHAR(MAX),
    TypeProduit NVARCHAR(50),
    Statut NVARCHAR(20) NOT NULL
);
GO

-- Création de la table Recettes
CREATE TABLE Recettes (
    IDRecette INT PRIMARY KEY IDENTITY,
    IDProduit INT FOREIGN KEY REFERENCES Produits(IDProduit),
    ListeDesEtapes NVARCHAR(MAX)
);
GO

-- Création de la table Commandes
CREATE TABLE Commandes (
    IDCommande INT PRIMARY KEY IDENTITY,
    IDProduit INT FOREIGN KEY REFERENCES Produits(IDProduit),
    NumeroCommande NVARCHAR(50) NOT NULL,
    EtatCommande NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Utilisateur (
    UtilisateurID INT PRIMARY KEY IDENTITY(1,1),
    Pseudo NVARCHAR(100) NOT NULL,
    MotDePasse NVARCHAR(100) NOT NULL
);
GO

-- Ajout d'un utilisateur d'exemple
INSERT INTO Utilisateur (Pseudo, MotDePasse) VALUES ('admin', 'password');
GO