   M S B A M L   `   `   `  ���� K  GInk Canvas Basic, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ink_Canvas
Ink_Canvas      Ink_Canvas.RandWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     T PiNKORE.UI.WPF, Version=1.2.8.0, Culture=neutral, PublicKeyToken=cd19e634b9706635.ikw$http://schemas.inkore.net/lib/ui/wpf  $localclr-namespace:Ink_Canvas  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  \ XiNKORE.UI.WPF.Modern, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b9706635e	 aiNKORE.UI.WPF.Modern.Controls, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b97066356ui+http://schemas.inkore.net/lib/ui/wpf/modern  	 -     � Title$  抽奖 - Ink Canvas Basic��$	��900��$	��500��'  !iNKORE.UI.WPF.Modern.ThemeManager   RequestedTheme$ Light=�8  2iNKORE.UI.WPF.Modern.Controls.Helpers.WindowHelper   SystemBackdropType$
 Mica=�   UseModernWindowStyle$
 True�� � Topmost$
 True�� � WindowStartupLocation$ CenterScreen=�.���� $��10q�   PopupWindowBackground#���     PopupWindowBorderBrush#���  $��1q� �� CornerRadius$ 10��._��  � ColumnDefinitions �� $
��1.8* ��� $��1* �.+�(� $
��20,0q�$��Center=�.��-  'iNKORE.UI.WPF.Controls.SimpleStackPanel  $	��470��   Orientation$ 
Horizontal=�	   Spacing$	 50Q�.+��� -   $��LabelOutput��$��Center=�$��Center=�
 �� TextAlignment$
 Center=�$�� ��$��70(�  PopupWindowForeground#���  �� -   $��LabelOutput2��$��Center=�$��Center=�$
 Center=�$�� ��$��70(�#���  $y�	Collapsed=��� -   $��LabelOutput3��$��Center=�$��Center=�$
 Center=�$�� ��$��70(�#���  $y�	Collapsed=�  $��1��$
��Left=�$��Center=�$	 40Q�.+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ BorderBtnMinus��$��70��$��70��#���   #���  $��1q�$	 100�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 3Q�   	Direction$ 0Q�   Opacity$
 0.15Q�   ShadowDepth$ 0Q�._�(� .��,  &iNKORE.UI.WPF.Modern.Controls.FontIcon  $��80��$��80��  FluentIconFontFamily   
FontFamily# [    FontSize$ 36(�/  )iNKORE.UI.WPF.Modern.Controls.IconElement   
Foreground# �     Glyph$	 ���� -   $��LabelNumberCount��$��80��$��30q�$��55(�#���  $��1�� �� TextAlignment$ Center=��� -   $ BorderBtnAdd��$��70��$��70��#���   #���  $��1q�$	 100��   $ 3Q�$ 0Q�$
 0.15Q�$ 0Q�._�(� .��  $��80��$��80��# [ $ 36(�# �  $	 ��� .+��� -   $ BorderBtnRand��$	��200��$��70�����#0066BF$ 10��._�  $	��3,0q�$��Center=�$ 
Horizontal=�$	 10Q�.+�  $��40��$��40��# [ $ 30(�
 �����$	 ���� $��	-1,-1,4,0q�$��Center=�$��35(�
�������$��抽奖���� -	   $ BorderBtnRandCover��$	��200��$��70�����#BFBFBF$ 10��$y�	Collapsed=�._�  $	��3,0q�$��Center=�$ 
Horizontal=�$	 10Q�.+�  $��40��$��40��# [ $ 30(�
 �����$	 ���� $��	-1,-1,4,0q�$��Center=�$��35(�
�������$��抽奖���� $?��9为保证随机，最大抽取人数为总人数的一半��$��Center=�$	��Top=�$��38��$	��270��$
��Bold"� J� RenderTransformOrigin$ 0.638,0.862&��� -
   $ BorderBtnHelp��$��1��$��40��$��10,10,60,10q�$��Right=�$��Bottom=�#���   #���  $��1q�$ 20��   $ 3Q�$ 0Q�$
 0.15Q�$ 0Q�._�  $��Center=�$ 
Horizontal=�.+�(� $��15,10,10,10q�.��  $��20��$��20��# [ $ 18(�# �  $	 ���� -   $��TextBlockPeopleCount��$��-5,12,15,12q�$��Center=�$��Center=�$��16(�#���  $!��点击此处以导入名单���� -   $ BtnClose��$��1��$��40��$��40��$��10q�$��Right=����#E32A34$	 100������  �� ElementName$ BorderBtnHelp�� �� Path$ VerticalAlignment�   $ 3Q�$ 0Q�$	 0.1Q�$ 0Q�._�(� .��  $��80��$��80��# [ $ 36(�
 �����$	 ��