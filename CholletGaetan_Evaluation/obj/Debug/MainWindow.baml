   M S B A M L   `   `   `  ����  CholletGaetan_Evaluation)    #CholletGaetan_Evaluation.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5         RoundedButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding  	RedButton �� BasedOn  ProduitsBackground	 �� 
StartPoint
 �� EndPoint � Color � Offset  RecettesBackground  CommandesBackground��%J  &	        &	 �    7   &	 L    &	 �    &	 |    �� 5   
   " ��6&   .�5      ��  � �� �#007ACC6+   �� 5	       � ��
 �����6+   �� 5
       � ��$
 10,5q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 10��5   !   # z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      �� 5   
   " ��6"   8   .�5      ��  � ��
 �  ��6+   5      �� 5"   
   $		 0,0&�69   $	
 1,1&�6J   .��5#      � $ #FFD700��6   $	 0.0Q�6+   � 5$      $ #FF8C00��6   $	 1.0Q�6+   5%      �� 5&   
   $		 0,0&�69   $	
 1,1&�6J   .��5'      � $ #4CAF50��6   $	 0.0Q�6+   � 5(      $ #8BC34A��6   $	 1.0Q�6+   5)      �� 5*   
   $		 0,0&�6:   $	
 1,1&�6K   .��5+      � $ #00BCD4��6   $	 0.0Q�6+   � 5,      $ #2196F3��6   $	 1.0Q�6+   5-      5.      .��5/      � .+�50   
   �� .@�51      �� $��Produits��6   ��52      �� 53       �� ResourceKey$ ProduitsBackground��6%   .��55      �� .+�56      �� -   5        $��Ajouter un Produit��56      #��[  6]   &   System.Windows.Controls.DataGrid  57      -   5        $��ProduitsDataGrid��57         AutoGenerateColumns .  $��15q�6S      HeadersVisibility$ Column=�6_      CanUserAddRows .     Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Nom+  5:      $ Liste des Aliments��61    6M   �� *ListeDesAliments+  5;      $
 Type��61    6?   �� *TypeProduit+4  .System.Windows.Controls.DataGridComboBoxColumn  5<      $ Statut��65      SelectedItemBinding 6E   �� *Statut+   ElementStyle 5=   "   �� 5>   &   " ��6,   .�5?   *   ��  � �� 6H   �� *DataContext.Statuts+ �� RelativeSource ��  �� AncestorType$ WindowL�5@   '      EditingElementStyle 5B   "   �� 5C   &   " ��6,   .�5D   *   ��  � �� 6H   �� *DataContext.Statuts+ �� $ WindowL�5E   '   5G      4  .System.Windows.Controls.DataGridTemplateColumn  5H      $ 	Supprimer��65      CellTemplate 5I   "   �� 5J   &   .R�5K   *   �� -   5        $��	Supprimer��5K   1   #��[ 6j   5L   '   5N      5P      5Q      5R      �� 5S      $��Recettes��6   ��5T      �� 5U      $ RecettesBackground��6%   .��5W      �� .+�5X      �� -   5        $��Ajouter une Recette��5X      #��[  6^     5Y      -   5        $��RecettesDataGrid��5Y       .  $��15q�6S   $ Column=�6_    .   5Z        5[      $ 
ID Produit��61    6E   �� *	IDProduit+  5\      $ Nom du Produit��61    6I   �� *
NomProduit+  5]      $ Liste des Étapes��61    6K   �� *ListeDesEtapes+  5^      $ 	Supprimer��65    5_   "   �� 5`   &   .R�5a   *   �� -   5        $��	Supprimer��5a   1   #��[ 6j   5b   '   5d      5f      5g      5h      �� 5i      $��	Commandes��6   ��5j      �� 5k      $ CommandesBackground��6%   .��5m      �� .+�5n      �� -   5        $��Ajouter une Commande��5n      #��[  6`     5o      -   5        $��CommandesDataGrid��5o       .  $��15q�6T   $ Column=�6`    .   5p        5q      $ Numéro de Commande��61    6M   �� *NumeroCommande+  5r      $ Produit��61    6B   �� *
NomProduit+  5s      $ État de la Commande��65    5t   "   �� 5u   &   .R�5v   *   �� ��64   �� *EtatCommande+5w   '      CellEditingTemplate 5y   "   �� 5z   &   .R�5{   *   �� ��63   �� *DataContext.EtatsCommande+ �� $ WindowL� �� SelectedItem 5|   3   �� *EtatCommande+5}   '   5        5�      $ 	Supprimer��65    5�   "   �� 5�   &   .R�5�   *   �� -	   5        $��	Supprimer��5�   1   #��[ 6k   5�   '   5�      5�      5�      5�      5�      � 5�   
   $��Right=�6   $��Bottom=�6+   $��59��6F   $	��170��6R   $��10q�6^    � ColumnDefinitions 5�      �� 5�      $��* �6#   �� 5�      $
��Auto �6#   .+�5�      �� -
   5        $��0��5�      $
��Save��6%   
��� � �$��5q�6G   #��[  6k   5�      5�      5�      