   M S B A M L   `   `   `  ���� H  DCelebrityQuiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CelebrityQuizCelebrityQuiz  %    CelebrityQuiz.View.ActorsWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  'localclr-namespace:CelebrityQuiz    � Title$  Celebrities��$	��700��$	��800�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � Icon$* $pack://application:,,,/Res/oscar.png������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #E8F5E9�� � Offset$ 0Q�� $ #C8E6C9��$ 1Q� � 	Resources %   CelebrityQuiz.ImageUrlConverter   ImageUrlConverter�� %   &	          .��� $��20q�	 � RowDefinitions	 �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Celebrities��$��24(�$
��Bold"�$��Center=�$��0,0,0,20q��� $��1��$��25 0 0 0q����� *CurrentPageActors+���� .R�� ���� .R��� $	��120��$	��240��$��10q�
�������  PrimaryHueMidBrush#���  $��1q�
 �� CornerRadius$
 8��._�� 	 �� $��* ��� $
��Auto �.+��� $	��200��$
 8,8,0,0��$
}�True������  j� Stretch$ UniformToFill=� �� ImageSource �� *
ImageUrl+ �� 	Converter# [  �� $��1��$��16(� �� Padding$ 10q�$
��Wrap=� �� TextAlignment$ Center=����� *Name+�� $��2�� �� Orientation$ 
Horizontal=�$��Center=�$��0,20,0,0q�.+���   MaterialDesignFlatButton#��[ $	��5,0q����� *PreviousPageCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChevronLeft=��� $��Center=�$
��10,0q����� *CurrentPage+ �� StringFormat$ Page {0}���� $��of��$��Center=�$	��5,0q��� $��Center=�$	��5,0q����� *
TotalPages+�� #��[ $	��5,0q����� *NextPageCommand+.��  $ ChevronRight=�