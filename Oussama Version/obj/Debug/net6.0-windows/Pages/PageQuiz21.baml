   M S B A M L   `   `   `  ����A  =projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:projet.Pagesprojet.Pages  5      b ^PresentationFramework.Aero2, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5
          projet.Pages.PageQuiz21   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:projet.Pages     5      ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5
        N� Title$  
PageQuiz21��5	      .��5      � -   5        
������� � ColumnDefinitions 5   
   �� 5      $	��59* �6   �� 5      $
��741* �6    � RowDefinitions 5   
   �� 5      $��50 �6   6+   �� 5      $��* �6   6*   �� 5      $��60 �6   6+   �� 5      $	��100 �6   6,   �� 5      $	��100 �6   6,   .+�5!   
   �� -   5        $��50��5!      $��30��6   $��0q�6(   $
��Left=�6<   $��Bottom=�5"      $��25,0,0,0q�5#      $��2��6#   ��5$      �� 5%       �� 
TargetType" ��6"   .R�5&      � .+�5'      �� $��/Pages/images/retour.png��6    $��Uniform=�6B   5(      5)      5+      �� 5/   
   $��1��6   $��2��6"   .+�51      �� -   5         ��Name$ Text1��51      $��Quiz N° 21 :��6'   $��	Open Sans)�6;   $��35(�6R   $��SemiBold"�6`   $��	75 25 0 0q�52      �� 54      -   5        $ Text2��54      $��Choisir la bonne réponse��6'   $��
Montserrat)�6G   $��22(�6_   $
��Thin"�55      $��75 3 0 0q�6&   $��Italic$�68   �� 57      -   5        $ Text3��57      $'��!● Qu'est-ce que le processeur ?��6'   $��
Montserrat)�6N   $��23(�6f   $
��Wrap=�6u   $��Medium"�58      $��	75 35 0 0q�6(   $��Normal$�6;    �� TextAlignment$
 Left=�6N   �� 5:      -   5         ��Name$ Combo��5=         ComboBoxStyle1#���   5:       �� SelectedIndex$ 0��6@   $
��20 5q�5;      $��75 20q�6&   $��40��65   $	��400��6A   $
��Left=�5<      .@�5>      �� .��6   $"Une unité de stockage de données6A   �� 5?      .��6   Un périphérique d'affichage6<   �� 5@      .��6   )'Un périphérique de saisie de données6E   �� 5A      .��6   &$Une unité de calcul de l'ordinateur6D   5B      �� 5D      -   5         ��Name$ Button1��5D      $��43��6&   $	��125��62     RoundedButtonStyle#��[ 5E      ���#81C784
����������#81C784$
��Left=�5I      $
��75 0q�5J      .��5L      �� $��Validez��6   $��
Montserrat)�6+   $��23(�6C   $��Normal"�6Q   6h   5N      5P      �� 5R   
   $��2��6   	 �� Orientation$	 
Horizontal=�6"   $
��Left=�6;   $��1,0,0,0q�6V   $��1��6g   .+�5T      �� -   5        
 ��Name$
 Image1��5T      $!��/Pages/images/checkmark.png��6$   $��40��6I   $��40��6T   �� 5U      -	   5        $ Text4��5X   3   $G��AC'est exactement ça ! Félicitations pour votre réponse juste !��5U      $
��Auto��5V      $
��Auto��6&   $
��Wrap=�63    �� Padding$	 8 0q�6G   $��
Montserrat)�6U   $��20(�5W      $��Normal"�6&   ���#81C784$
 Left=�6O   $��Center=�5X      63   5[      � 5^   
   $��3��6   $��1��6   .+�5_      � -
   5         �Name$ 
myGridExpl��5_       5`      �� 5a      $��40 �6$   �� 5b      $��* �6$   .+�5d      � $��0��6   .+�5e      �� $	 
Horizontal=�6!   $��40��6:   $	��Top=�6F   .+�5f      �� -   5        $
 Image2��5f       $/��)/Pages/images/idee-removebg-preview 1.png��60   $��30��5g   "   $��30��6-   $
��Left=�69   $	��Top=�6T   �� 5h      $��Explication :��6$   $��23(�69   5i      5j      � 5k      $��1��6   $
��Auto��6$   .+�5m      �� -   5        $ Text5��5n   4   $��
Montserrat)�5m       $
��Wrap=�68   ���#E0E0E0$��18(�5n   $   $��0,0,10,0q�6E   $���� Une unité de calcul de l'ordinateur. Le processeur est une unité centrale de traitement (CPU) de l'ordinateur qui exécute les instructions et effectue les calculs.��5o   $   5r      5s      5t      �� 5v   
   $��4��6   $	 
Horizontal=�6"   $��Right=�6;   $��1��6W   .+�5x      �� -   5        $ Button2��5|   '   #��[ 5x      $��55��6A   $	��155��6M   ���#E0E0E0
���   ����#E0E0E0$��0 5 20 0q�5|      .��5�      �� $	 
Horizontal=�6   $��Center=�66   .+�5�      �� $!��/Pages/images/precedent.png��6   $��15��6A   $
��Auto��6M   $��Center=�6Z   �� 5�      $��	Precedent��6    $ Center=�61   $ 7q�6H   $��
Montserrat)�5�       $��22(�5�       $��Normal"�6.   5�      5�      �� 5�      -   5        $ Button3��5�   (   #��[ 5�      $��55��6A   $	��155��6M   ���#81C784
����������#81C784$��0 5 50 0q�5�      .��5�      �� $	 
Horizontal=�6   $��Center=�66   .+�5�      �� $��Suivant��6    $ Center=�6/   $ 7q�6F   $��
Montserrat)�5�       $��22(�5�       $��Normal"�6.   �� 5�      $��/Pages/images/suivant.png��6   $��15��6?   $
��Auto��6K   $��Center=�6X   5�      5�      5�      5�      5�      