   M S B A M L   `   `   `  ����  CholletGaetan_Evaluation4    .CholletGaetan_Evaluation.AjouterCommandeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Ajouter une Recette��5   	   $	��450��6%   $	��500��62   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Ajouter une Commande��6   $��10q�60   $��18(�6<   $
��Bold"�6J   �� 5   
   $��1��6   $��10q�6"   .+�5      ��    TextBlockStyle#��[  6   $��Produit:��6@   �� 5      -   5        $��ProduitComboBox��5      $	��200��6.    �� DisplayMemberPath$	 Nom��6:    �� SelectedValuePath$ 	IDProduit��6R   5      �� 5   
   $��2��6   $��10q�6"   .+�5      �� #��[  6   $��Numéro de Commande:��6@   �� 5      -   5        $��NumeroCommandeTextBox��5      $	��200��63   5      �� 5   
   $��3��6   $��10q�6"   .+�5      �� #��[  6   $��État de la Commande:��6@   �� 5      -   5        $��EtatCommandeComboBox��5      $	��200��63   .@�5      �� $��Passée��6   �� 5      $��En cours de fabrication��6   �� 5      $��	Terminée��6   �� 5       $��Distribuée��6   5!      5"      �� 5$   
   -   5        $��4��5$      $��Ajouter��6   $��	0,0,10,20q�6L   $��Right=�6_     RoundedButton#��[ 6{   5%      5&      