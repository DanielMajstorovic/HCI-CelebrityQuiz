   M S B A M L   `   `   `  ���� H  DCelebrityQuiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CelebrityQuiz.ConvertersCelebrityQuiz.Converters  (    "CelebrityQuiz.View.LeaderboardView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9local1&clr-namespace:CelebrityQuiz.Converters       � Title$  Leaderboard��$	��450��$	��600�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � Icon$* $pack://application:,,,/Res/oscar.png������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #E8F5E9�� � Offset$ 0Q�� $ #C8E6C9��$ 1Q� � 	Resources 7   1CelebrityQuiz.Converters.BoolToGoldBrushConverter   BoolToGoldBrushConverter>   8CelebrityQuiz.Converters.InverseBoolToGoldBrushConverter # InverseBoolToGoldBrushConverter?   9CelebrityQuiz.Converters.InverseBoolToVisibilityConverter $  InverseBoolToVisibilityConverter3  -System.Windows.Media.Effects.DropShadowEffect  SoftShadowEffect	   
BlurRadius
   ShadowDepth   	Direction   Color  TabButtonStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  LeaderboardItemStyle �� 
TargetType �� CornerRadius J� Effect �� Binding �� Value   Opacity�� %H  &	        &	      &	 
     &	      &	 ?     &	 �    7          $	 10Q�$
 1Q�$	 270Q�$ 	#20000000���� " ��.���  � ��$ 20,10q���  � ��$ 5q���  � ��
 ���� ��  � ��$ 0,0,0,2q���  � ��
 ���� ��  � ��$ Segoe UI Light)���  � ��$ 14(���  � �� �#2C3E50 P�  �@J�IsMouseOver$
 True��. ���  � �� �#4CAF50��  � �� �#E8F5E9��  � �� �#1B5E20�� " ��.���  � ��$ 15,12q���  � ��$	 0,4q���  � �� �� " ��.R��� #��z��$��0q�$ 8��8   ._���  P�  �@J�IsMouseOver$
 True��. ���  � �� �#E8F5E9��  �� *IsFirstPlace+ True.a���  � �� �#C8E6C9��  � ��$
 Bold"���  �@J�Effect   $ #4CAF50��$	 15Q�$
 0Q�$	 0.3Q�.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��2��.+�F� -����        � ��@x} ������ �����	���	#4CAF5020$��2�� �� Left$ 0��
 �� Top$ 20���� $��0��# [ ���� $	 0,0&�$	 1,0&�.��� $ #FFFFFF��$ 0Q�� $ #E8F5E9��$ 1Q�._�� .+��� $+��%pack://application:,,,/Res/trophy.png��$��80��$��80��$��Right=�$	��Top=�$��	0,10,10,0q� J� RenderTransformOrigin$ 0.5,0.5&�z���  �� Angle$	 -15Q��� .+��� $��Leaderboard��$��24(�$��Light"�$
��Left=�$��
20,20,0,10q����#2C3E50��  �� Orientation$ 
Horizontal=�$��Center=�$��0,0,0,20q�.+��� #��[ ���� *IsStandardSelected+ �� 	Converter# [  ���� *SelectStandardCommand+.���� $ 
Horizontal=�.+�F� �����@T� ��- �@T� @o@��ا @o@��ا ��- �@T� ��- �@KL ��- �@KL @o@���j @o@���j ��- �@KL ��- �@]� ��- �@]� @o@���� @o@���� ��- �@]� ��- ���!��- ���!@o@�@o@@o@�@o@��- ���!��- 	$��16��$��16��$��0,0,8,0q�����   �� RelativeSource  �� ! �� AncestorType
! Button" �� Path$" 
Foreground��� $��Standard Mode���� #��[ ���� *IsStandardSelected+# [ ���� *SelectTimedCommand+.���� $ 
Horizontal=�.+�F� ����� �  -1� -1 �   z  z � �  	=   z  z � 	=  �   z  z � �  -1  z  z � � �� ׀�O � ���� ��� � � ��O���� ��� �p�b ��O�� `��  � � � �� ���� ��� � �� ��j � �� �� �@f@�� Q��� fffff&0@��ا @]� ��ا ��j � �� ��j 	$��16��$��16��$��0,0,8,0q�����   �� 
! Button$" 
Foreground��� $��
Timed Mode��� $��1��$��20q�.+��� 
�������$ 12��# [ $
��0,10q�._�� .+��� $��32,16q�#��[ $
��Auto=�
������ $��0q����� *StandardLeaderboard+y��� *IsStandardSelected+   BooleanToVisibilityConverter# [ ���� .R�� # � ColumnDefinitions# �� $
��Auto ��� $��* ��� $
��Auto �.+��� $ 
Horizontal=�$��0��.+��� $ �� Padding$$ 4q�$��Center=�$��0,0,10,0q����� *Rank+F� j���� � @B ����  �� ���^`�� �`��� ���!��^� � ��!�@KL ��^Ѡ.c ��� �@B `�� � ��  �� � � @B 	���#FFD700$��16��$��16��% �� Stretch$% Uniform=�y��� *IsFirstPlace+# [ �� $$ 4q�$��1��$
��10,0q����� *
PlayerName+�� $$ 4q�$��2��$
��Bold"����� *Score+�� $��32,16q�#��[ $
��Auto=�
������ $��0q����� *TimedLeaderboard+y��� *IsStandardSelected+# [ ���� .R�� # �� $
��Auto ��� $��* ��� $
��Auto �.+��� $ 
Horizontal=�$��0��.+��� $$ 4q�$��Center=�$��0,0,10,0q����� *Rank+F� j���� � @B ����  �� ���^`�� �`��� ���!��^� � ��!�@KL ��^Ѡ.c ��� �@B `�� � ��  �� � � @B 	���#FFD700$��16��$��16��$% Uniform=�y��� *IsFirstPlace+# [ �� $��1��$$ 4q�$
��10,0q����� *
PlayerName+�� $��2��$$ 4q�$
��Bold"����� *Score+