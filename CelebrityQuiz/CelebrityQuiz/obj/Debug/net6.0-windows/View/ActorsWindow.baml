   M S B A M L   `   `   `  ����H  DCelebrityQuiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CelebrityQuizCelebrityQuiz  5   R   %    CelebrityQuiz.View.ActorsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:CelebrityQuiz  6R     � Title$  Celebrities��5   	   $	��780��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ CanMinimize=�5	   	    � Icon$* $pack://application:,,,/Res/oscar.png��5
   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #E8F5E9��6    � Offset$ 0Q�6+   � 5      $ #C8E6C9��6   $ 1Q�6+   5       � 	Resources 5      %   CelebrityQuiz.ImageUrlConverter   ImageUrlConverter   BooleanToVisibilityConverter�� 5   
   %:   &	        &	        5      6&   �� 5      6+   5      .��5      � $��20q�6   	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5#   
   �� $��0��6   $��Celebrities��5$      $��24(�5%      $
��Bold"�5&      $��Center=�5'      $��0,0,0,20q�5(      �� 5+   
   $��1��6   
����������#AAAAAA$��1q�5.      
 �� CornerRadius$
 8��5/       �� Padding$
 10,0q�50      $��40��51      $	��300��52      $
��Left=�53      $��0,0,0,20q�54      ._�55      �  � ColumnDefinitions 56      �� 57      $
��Auto �6'   �� 58      $��* �6'   .+�5:      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6*   $��20��5;   (   $��20��5<   (   $��Center=�5=   (   $��5,0,10,0q�5>   (   �� 5?      -   5         ��Name$ 	SearchBox��5?      $��1��5@      
������ $��0q�5B      $��Center=�5C      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search celebrities...��5E      ��5D      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5E      5F      5G      �� 5J   
   $��2��6   $��25 0 0 0q�5L      ��5K      �� *CurrentPageActors+y�5M      �� *	HasActors+ �� 	Converter# [ ��5N      �� 5O      .R�5P      � 5Q      ��5T      �� 5U      .R�5V      �� $	��120��6   $	��240��5W      $��10q�5X      
�������  PrimaryHueMidBrush#���  5Z      $��1q�5[      $
 8��5\      ._�5]      � 	 5^      �� 5_   "   $��* �60   �� 5`   "   $
��Auto �60   .+�5d      �� $	��200��6%   $
 8,8,0,0��5e   %   $
}�True��5f   %   ��5g   "   �� 5h   &    j� Stretch$ UniformToFill=�61    �� ImageSource 5i   /   �� *
ImageUrl+# [  5k      �� 5n      $��1��6(   $��16(�5p   (    �� Padding$ 10q�5q   (   $
��Wrap=�5r   (    �� TextAlignment$ Center=�5s   (   ��5o   (   �� *Name+5s   (   5t      5u      5v      5x      �� 5{   
   $��2��6   $4��.No actors found matching your search criteria.��5|      $��18(�5}      $��Center=�5~      $��Center=�5      y�5�      �� *HasNoActors+# [ �� 5�   
   $��3��6    �� Orientation$ 
Horizontal=�5�      $��Center=�5�      $��0,20,0,0q�5�      y�5�      �� *	HasActors+# [ .+�5�      ��   MaterialDesignFlatButton#��[ 5�      $	��5,0q�5�      ��5�      �� *PreviousPageCommand+.��5�        $ ChevronLeft=�6*   5�      �� 5�      $��Center=�5�      $
��10,0q�5�      ��5�      �� *CurrentPage+ �� StringFormat$ Page {0}��5�      �� 5�      $��of��6   $��Center=�5�      $	��5,0q�5�      �� 5�      $��Center=�5�      $	��5,0q�5�      ��5�      �� *
TotalPages+5�      �� 5�      #��[ 5�      $	��5,0q�5�      ��5�      �� *NextPageCommand+.��5�        $ ChevronRight=�6*   5�      5�      5�      5�      