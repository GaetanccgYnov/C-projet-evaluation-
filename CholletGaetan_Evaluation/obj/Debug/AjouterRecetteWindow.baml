   M S B A M L   `   `   `  ����  CholletGaetan_Evaluation3    -CholletGaetan_Evaluation.AjouterRecetteWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Ajouter une Recette��5   	   $	��450��6%   $	��500��62   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��Ajouter une Recette��6   $��10q�6/   $��18(�6;   $
��Bold"�6I   �� 5   
   $��1��6   $��10q�6"   .+�5      �� $��Produit:��6   $��14(�6(   $
��Bold"�66   �� 5      -   5        $��ProduitComboBox��5      $	��200��6.    �� DisplayMemberPath$	 Nom��6:    �� SelectedValuePath$ 	IDProduit��6R   5      �� 5   
   $��2��6   $��10q�6"   .+�5      �� $��Liste des Étapes:��6   $��14(�61   $
��Bold"�6?   �� 5      $
��Auto=�6   $��Disabled=�6>   $	��150��6g   .��5      �� -   5        $��EtapesTextBox��5      $	��200��6/    �� TextWrapping$
 Wrap=�6;    �� AcceptsReturn . 6O   5      5      �� 5   
   -   5        $��3��5      $��Ajouter��6   $��10q�6L   $��Right=�6X      RoundedButton#��[  6t   5      5      