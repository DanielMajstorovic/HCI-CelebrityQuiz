   M S B A M L   `   `   `  ����H  DCelebrityQuiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CelebrityQuizCelebrityQuiz  5   	   C&clr-namespace:CelebrityQuiz.ConvertersCelebrityQuiz.Converters  5   	   #    CelebrityQuiz.View.QuizWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CelebrityQuiz     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3local1&clr-namespace:CelebrityQuiz.Converters  5   	     � Title$  Celebrity Quiz��5
   	   $	��700��6    $
��1000��6-    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $��Regular"�5   	   $��13(�5   	    � 
ResizeMode$ CanMinimize=�5   	    � Icon$* $pack://application:,,,/Res/oscar.png��5   	   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources 5      %   CelebrityQuiz.ImageUrlConverter  ImageUrlConverter:   4CelebrityQuiz.Converters.BooleanToThemeIconConverter  BooleanToThemeIconConverter  
QuizButton �� 
TargetType  MaterialDesignRaisedButton �� BasedOn �� Property �� Value+  %MaterialDesignThemes.Wpf.ButtonAssist.  (MaterialDesignThemes.Wpf.ElevationAssist	 �� Triggers
 �� Binding �� RelativeSource �� Path �� Value  ScoreNumberStyle  PrimaryHueMidBrush  TimerTextStyle�� 5   
   %!  &	       &	      &	 &     7  &	 j    &	 "      5      6&     5      61   �� 5      " ��6'   8   .�5      ��  � ��$ 8q�6+   �� 5       � ��$ 42��6+   �� 5       � ��$ 16(�6-   �� 5       �@ CornerRadius$ 8��6M   �� 5       �@ 	Elevation$	 Dp2=�6M   	 5      �� 5       
 6"   ��  �� *Self+$	 Tag� Correct6e   .a�5!      ��  � ��
 �"�"�67   �� 5"       � ��
 �"�"�68   5#      �� 5$      
 6"   ��  �� *Self+$	 Tag� 	Incorrect6e   .a�5%      ��  � ��
 �<��67   �� 5&       � ��
 �<��68   5'      5)      �� 5+      " ��6-   .�5,      ��  � ��$ 48(�6-   �� 5-       � ��$
 Bold"�6/   �� 5.       � ��# �  6/   �� 5/       � ��$ Center=�68   50      �� 52      " ��6+   .�53      ��  � ��$ 64(�6-   �� 54       � ��$
 Bold"�6/   �� 55       � ��$ Center=�68   	 56      �� 57      
 6"   �� *RemainingSeconds+ 56G   .a�58      ��  � ��
 � ���67   59      �� 5:      
 6"   �� *RemainingSeconds+ 46G   .a�5;      ��  � ��
 � ���67   5<      �� 5=      
 6"   �� *RemainingSeconds+ 36G   .a�5>      ��  � ��
 � E��67   5?      �� 5@      
 6"   �� *RemainingSeconds+ 26G   .a�5A      ��  � ��
 �  ��67   5B      �� 5C      
 6"   �� *RemainingSeconds+ 16G   .a�5D      ��  � ��
 �  ��67   5E      5G      5H      .��5K      )  #MaterialDesignThemes.Wpf.DialogHost  .��5L   
   )  #MaterialDesignThemes.Wpf.DrawerHost  .��5M      �  � RowDefinitions 5N      �� 5O      $
��Auto �6$   �� 5P      $��* �6$   .+�5T      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryDark=�6+   $��16q�6>      	Elevation$	 Dp4=�6K   .��5U      ]� .+�5V      ��  �� Orientation$ 
Horizontal=�6%   $��Right=�6>   .+�5W      d�  $	  MaterialDesignSwitchToggleButton#��[	 6+    � ToolTip$ Toggle theme��5X   +   ��5Y   +   �� *ToggleThemeCommand+��5Z   "   '	  !MaterialDesignThemes.Wpf.PackIcon	  5[   &    	  Kind 6>   �� *IsDarkTheme+ �� 	Converter# [ 5]      5^      �� 5`      $ 
Horizontal=�6%   $��Center=�6>   .+�5a      	  $ 	MovieStar=�66   $��32��6G   $��32��6R   $��Center=�5b   6   $��0,0,8,0q�6Q   �� 5c      $��Celebrity Quiz��6(   $��28(�6>   $
��Bold"�6L   $��Center=�5d   (   5e      5f      5g      � 5j      $��1��6   $��16q�6$    � ColumnDefinitions 5k      �� 5l      $��* �6+   �� 5m      $
��Auto �6+   .+�5q      #
  MaterialDesignThemes.Wpf.Card
  $��32q�6*   $��0 0 16 0q�67   $	 Dp3=�5r   *    
 MaterialDesignBackground#��� 
 5s   *   .��5t      �  5u      �� 5v   "   $
��Auto �60   �� 5w   "   $��* �60   �� 5x   "   $
��Auto �60   .+�5|      �� $��0��6%   #���  5}   %    �� CornerRadius$ 8��5~   %   $��0,0,0,24q�5   %   ._�5�   "   �� $��Choose the correct actor!��6,   $��22(�5�   ,   $
��Bold"�5�   ,      PrimaryHueMidForegroundBrush#���  5�   ,   $��Center=�5�   ,    �� Padding$ 8q�5�   ,   5�      �� 5�      $��1��6%   $	��200��5�   %   $	��300��5�   %   $��Center=�5�   %   $ 12��5�   %   $
}�True��5�   %   $��4q�5�   %   #���  5�   %   ��5�   "   �� 5�   &    j� Stretch$
 Fill=�61    �� ImageSource 6@   �� *CurrentActor.ImageUrl+# [ 5�      A� 5�      $��2��6*    A� Columns$ 2��67    A� Rows$ 2��6C   $��0 16 0 0q�6L   .+�5�   "   �� #��[ 5�   )   ��5�   )   �� *PossibleAnswers[0].Name+��5�   )   �� *CheckAnswerCommand+��5�   )   �� *PossibleAnswers[0]+
 � Tag 5�   )   �� *AnswerStates[0]+{�5�   )   �� *IsAnsweringEnabled+�� 5�   "   #��[ 5�   )   ��5�   )   �� *PossibleAnswers[1].Name+��5�   )   �� *CheckAnswerCommand+��5�   )   �� *PossibleAnswers[1]+ 5�   )   �� *AnswerStates[1]+{�5�   )   �� *IsAnsweringEnabled+�� 5�   "   #��[ 5�   )   ��5�   )   �� *PossibleAnswers[2].Name+��5�   )   �� *CheckAnswerCommand+��5�   )   �� *PossibleAnswers[2]+ 5�   )   �� *AnswerStates[2]+{�5�   )   �� *IsAnsweringEnabled+�� 5�   "   #��[ 5�   )   ��5�   )   �� *PossibleAnswers[3].Name+��5�   )   �� *CheckAnswerCommand+��5�   )   �� *PossibleAnswers[3]+ 5�   )   �� *AnswerStates[3]+{�5�   )   �� *IsAnsweringEnabled+5�      5�      5�      �� 5�      $��1��6!   $	��280��61   .+�5�      
  $��24q�6.   $��0 0 0 16q�6;   $	 Dp2=�5�   .   #��� 
 5�   .   .��5�      �� .+�5�   "   �� $ 
Horizontal=�6-   $��Center=�6F   $��0,0,0,8q�6c   .+�5�   &   	  $ Trophy=�6>   $��24��6L   $��24��6W   #���  5�   >   $��Center=�5�   >   $��0,0,8,0q�6Y   �� 5�   &   $��Score��60   $��24(�6=   $
��Bold"�6K   $��Center=�5�   0   5�   #   �� 5�   "   #��[ 6C   ��6,   �� *Score+6C   5�      5�      
  5�      $��24q�6.   $��0 0 0 16q�6;   $	 Dp2=�5�   .   #��� 
 5�   .   .��5�      �� .+�5�   "   �� $ 
Horizontal=�6-   $��Center=�6F   $��0,0,0,8q�6c   .+�5�   &   	  $ Timer=�6>   $��24��6K   $��24��6V   #���  5�   >   $��Center=�5�   >   $��0,0,8,0q�6Y   �� 5�   &   $��	Time Left��60   $��24(�6A   $
��Bold"�6O   $��Center=�5�   0   5�   #   �� 5�   "   #��[ 5�   ,   ��5�   ,   �� *RemainingSeconds+5�   ,   � 5�   "    � Maximum$ 30Q�6Q   $��4��5�   .   $��0,8,0,0q�69    � Value 5�   .   �� *RemainingSeconds+5�   9   5�      5�      �� 5�      $��Restart Quiz��6!      CornerRadius$ 8��5�   !   $��50��5�   !   $��18(�5�   !      MaterialDesignOutlinedButton#��[ 5�   !   ��5�   !   �� *InnerRestartQuizCommand+5�   !   5�      5�      5�      5�      5�      5�      