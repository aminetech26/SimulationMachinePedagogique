   M S B A M L   `   `   `  ����A  =projet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:projet.Pagesprojet.Pages  5      b ^PresentationFramework.Aero2, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5
          projet.Pages.PageQuiz2   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:projet.Pages     5      ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5
        N� Title$  	PageQuiz2��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��50 �6   6+   �� 5      $��* �6   6*   �� 5      $��60 �6   6+   �� 5      $��60 �6   6+   �� 5      $	��100 �6   6,   .+�5   
   �� $��50��6   $��30��6   $��0q�6(   $
��Left=�6<   $��Bottom=�5      $��25,0,0,0q�65   ��5      �� 5        �� 
TargetType" ��6"   .R�5!      � .+�5"      �� $��/Pages/retour.png��6    $��Uniform=�6;   5#      5$      5&      �� 5*   
   $��1��6   .+�5,      �� $��Quiz N° 2 :��6   $��	Open Sans)�6+   $��35(�6B   $��SemiBold"�6P   $��	75 25 0 0q�5-      �� 5/      $��Choisir la bonne réponse��6   $��
Montserrat)�68   $��22(�6P   $
��Thin"�50      $��75 3 0 0q�6&   $��Italic$�68   �� 52      $3��-Que fait l’instruction suivante : MOV AX,BX��6   $��
Montserrat)�6K   $��23(�6c   $��Medium"�53      $��	75 35 0 0q�6(   $��Normal$�6;    �� TextAlignment$
 Left=�6N   �� 55         ComboBoxStyle1#���   6    �� SelectedIndex$ 0��6@   $
��20 5q�6R   $��75 20q�6a   $��40��6p   $	��400��6|   $
��Left=�6�   .@�56      �� .��6   
Option 16)   �� 57      .��6   
Option 26)   �� 58      .��6   
Option 36)   �� 59      .��6   
Option 46)   5:      �� 5<      $��43��6   $	��125��6!     RoundedButtonStyle#��[ 5=      ���#81C784
����������#81C784$
��Left=�5A      $
��75 0q�5B      .��5D      �� $��Validez��6   $��
Montserrat)�6+   $��23(�6C   $��Normal"�6Q   6h   5F      5H      �� 5J   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   $��58 0 0 0q�6V   .+�5L      �� $��/Pages/checkmark.png��6   $��40��62   $��40��6=   �� 5M      $G��AC'est exactement ça ! Félicitations pour votre réponse juste !��6   $
��Auto��5N      $	��600��6&   $
��Wrap=�62    �� Padding$	 8 0q�6F   $��
Montserrat)�6T   $��21(�5O      $��Normal"�6&   ���#81C784$
 Left=�6O   $��Center=�5P      5S      �� 5V   
   $��3��6   $ 
Horizontal=�6"   $
��Left=�6;   $��60 0 0 0q�6V   .+�5X      �� $��/Pages/false.png��6   $��30��6.   $��30��69   �� 5Y      $b��\Vous êtes proche de la bonne réponse, mais ce n'est pas tout à fait ça. Essayez encore !��6   $
��Auto��5Z      $	��600��6&   $
��Wrap=�62   $
 12 0q�6F   $��
Montserrat)�6U   $��21(�5[      $��Normal"�6&   ���#FFB347$
 Left=�6O   $��Center=�5\      5_      �� 5a   
   $��4��6   $ 
Horizontal=�6"   $��Right=�6;   $��	361,0,0,0q�6W   .+�5c      �� -   5        #��[ 5c      $��55��6A   $	��155��6M   ���#E0E0E0
���   ����#E0E0E0$��0 5 20 0q�5g      .��5j      �� $ 
Horizontal=�6   $��Center=�66   .+�5k      �� $��/Pages/precedent.png��6   $��15��6:   $
��Auto��6F   $��Center=�6S   �� 5l      $��	Precedent��6    $ Center=�61   $ 7q�6H   $��
Montserrat)�5m       $��22(�5n       $��Normal"�6.   5p      5q      �� 5s      #��[ 6   $��55��6A   $	��155��6M   ���#81C784
����������#81C784$��0 5 50 0q�5w      .��5z      �� $ 
Horizontal=�6   $��Center=�66   .+�5{      �� $��Suivant��6    $ Center=�6/   $ 7q�6F   $��
Montserrat)�5|       $��22(�5}       $��Normal"�6.   �� 5      $��/Pages/suivant.png��6   $��15��68   $
��Auto��6D   $��Center=�6Q   5�      5�      5�      5�      5�      