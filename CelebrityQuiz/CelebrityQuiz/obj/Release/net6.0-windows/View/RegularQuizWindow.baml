   M S B A M L   `   `   `  ���� H  DCelebrityQuiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CelebrityQuizCelebrityQuiz  C&clr-namespace:CelebrityQuiz.ConvertersCelebrityQuiz.Converters  *    $CelebrityQuiz.View.RegularQuizWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:CelebrityQuiz     _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  3local1&clr-namespace:CelebrityQuiz.Converters    � Title$  Celebrity Quiz��$	��700��$
��1000�� � WindowStartupLocation$ CenterScreen=�   MaterialDesignBody#���     MaterialDesignPaper#���  $��Regular"�$��13(� � 
ResizeMode$ CanMinimize=� � Icon$* $pack://application:,,,/Res/oscar.png����:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources %   CelebrityQuiz.ImageUrlConverter  ImageUrlConverter:   4CelebrityQuiz.Converters.BooleanToThemeIconConverter  BooleanToThemeIconConverter  
QuizButton �� 
TargetType  MaterialDesignRaisedButton �� BasedOn �� Property �� Value+  %MaterialDesignThemes.Wpf.ButtonAssist.  (MaterialDesignThemes.Wpf.ElevationAssist	 �� Triggers
 �� Binding �� RelativeSource �� Path �� Value  ScoreNumberStyle  PrimaryHueMidBrush  ResultsTextStyle�� %p  &	       &	      &	 
     7  &	 x    &	 �        �� " ��8   .���  � ��$ 8q���  � ��$ 42����  � ��$ 16(���  �@ CornerRadius$ 8����  �@ 	Elevation$	 Dp2=�	 �� 
 ��  �� *Self+$	 Tag� Correct.a���  � ��
 �"�"���  � ��
 �"�"��� 
 ��  �� *Self+$	 Tag� 	Incorrect.a���  � ��
 �<����  � ��
 �<���� " ��.���  � ��$ 48(���  � ��$
 Bold"���  � ��# �  ��  � ��$ Center=��� " ��.���  � ��$ 24(���  � ��$ Center=���  � ��$ 0,0,0,20q�.��)  #MaterialDesignThemes.Wpf.DialogHost  .��)  #MaterialDesignThemes.Wpf.DrawerHost  .���  � RowDefinitions �� $
��Auto ��� $��* �.+�(  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryDark=�$��16q�   	Elevation$	 Dp4=�.��]� .+���  �� Orientation$ 
Horizontal=�$��Right=�.+�d�  $	  MaterialDesignSwitchToggleButton#��[	  � ToolTip$ Toggle theme������ *ToggleThemeCommand+��'	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind �� *IsDarkTheme+ �� 	Converter# [ �� $ 
Horizontal=�$��Center=�.+�	  $ 	MovieStar=�$��32��$��32��$��Center=�$��0,0,8,0q��� $��Celebrity Quiz��$��28(�$
��Bold"�$��Center=�� $��1��$��16q� � ColumnDefinitions �� $��* ��� $
��Auto �.+�#
  MaterialDesignThemes.Wpf.Card
  $��32q�$��0 0 16 0q�$	 Dp3=� 
 MaterialDesignBackground#��� 
 .���  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��#���   �� CornerRadius$ 8��$��0,0,0,24q�._��� $��Choose the correct actor!��$��22(�$
��Bold"�   PrimaryHueMidForegroundBrush#���  $��Center=� �� Padding$ 8q��� $��1��$	��200��$	��300��$��Center=�$ 12��$
}�True��$��4q�#���  ����  j� Stretch$
 Fill=� �� ImageSource �� *CurrentActor.ImageUrl+# [ A� $��2�� A� Columns$ 2�� A� Rows$ 2��$��0 16 0 0q�.+��� #��[ ���� *PossibleAnswers[0].Name+���� *CheckAnswerCommand+���� *PossibleAnswers[0]+
 � Tag �� *AnswerStates[0]+{��� *IsAnsweringEnabled+�� #��[ ���� *PossibleAnswers[1].Name+���� *CheckAnswerCommand+���� *PossibleAnswers[1]+ �� *AnswerStates[1]+{��� *IsAnsweringEnabled+�� #��[ ���� *PossibleAnswers[2].Name+���� *CheckAnswerCommand+���� *PossibleAnswers[2]+ �� *AnswerStates[2]+{��� *IsAnsweringEnabled+�� #��[ ���� *PossibleAnswers[3].Name+���� *CheckAnswerCommand+���� *PossibleAnswers[3]+ �� *AnswerStates[3]+{��� *IsAnsweringEnabled+�� $��1��$	��280��.+�
  $��24q�$��0 0 0 16q�$	 Dp2=�#��� 
 .���� .+��� $ 
Horizontal=�$��Center=�$��0,0,0,8q�.+�	  $ Trophy=�$��24��$��24��#���  $��Center=�$��0,0,8,0q��� $��Score��$��24(�$
��Bold"�$��Center=��� #��[ ���� *Score+
  $��24q�$��0 0 0 16q�$	 Dp2=�#��� 
 .���� .+��� $ 
Horizontal=�$��Center=�$��0,0,0,8q�.+�	  $ Counter=�$��24��$��24��#���  $��Center=�$��0,0,8,0q��� $��Questions Left��$��24(�$
��Bold"�$��Center=��� #��[ ���� *RemainingQuestions+�  � Maximum$ 10Q�$��4��$��0,8,0,0q� � Value �� *QuestionsAnswered+�� $��Restart Quiz��   CornerRadius$ 8��$��50��$��18(�   MaterialDesignOutlinedButton#��[ ���� *InnerRestartQuizCommand+