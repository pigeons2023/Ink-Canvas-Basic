   M S B A M L   `   `   `  ���� K  GInk Canvas Basic, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ink_Canvas
Ink_Canvas  ?$clr-namespace:Ink_Canvas.ProcessBarsInk_Canvas.ProcessBars  %    Ink_Canvas.CountdownTimerWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     T PiNKORE.UI.WPF, Version=1.2.8.0, Culture=neutral, PublicKeyToken=cd19e634b9706635.ikw$http://schemas.inkore.net/lib/ui/wpf  $localclr-namespace:Ink_Canvas  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6processbars$clr-namespace:Ink_Canvas.ProcessBars  \ XiNKORE.UI.WPF.Modern, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b9706635e	 aiNKORE.UI.WPF.Modern.Controls, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b97066356ui+http://schemas.inkore.net/lib/ui/wpf/modern  	 -     � Title$"  计时器 - Ink Canvas Basic��$
��1100��$	��700��$	��300��$	��200��'  !iNKORE.UI.WPF.Modern.ThemeManager   RequestedTheme$ Light=�8  2iNKORE.UI.WPF.Modern.Controls.Helpers.WindowHelper   SystemBackdropType$
 Mica=�   UseModernWindowStyle$
 True�� � Topmost$
 True�� � WindowStartupLocation$ CenterScreen=�.���� $��20q�   PopupWindowBackground#���     PopupWindowBorderBrush#���  $��1q� �� CornerRadius$ 10��._�� .+��� -    ��Name$ TbCurrentTime��$��Center=�$��Center=�$��56(�$��Black"�  PopupWindowForeground#���  $y�	Collapsed=��� -   $��64��$��15��$��0,0,0,5q�$��Center=�$��Bottom=�
�������$ 8��y���  �� ElementName$ TbCurrentTime��	 �� Path$	 
Visibility�(� -   
 (�Name$
 BigViewController��$��20,20,20,20q�.��� $	��200��$	��180��.+�,   &Ink_Canvas.ProcessBars.CycleProcessBar  -     Name$ ProcessBarTime��$	��150��$	��Top=�   CurrentValue$ 0Q�-  'iNKORE.UI.WPF.Controls.SimpleStackPanel  -   $
��28.5��$��0,0,0,25q�$��Center=�$��Center=�   Orientation$ 
Horizontal=�.+��� -   $��TextBlockHour��$��Segeo UI)�$��26(�#���   J� Opacity$	 0.9Q�$��00��$y�	Collapsed=��� -   $��TextControlHour������ $ TextBlockHour��$
	 Text����� .R���  �� Orientation$ 
Horizontal=����� .R�� $��14��.+��� $��Center=�$��SemiBold"����� $ TextBlockHour��$	 
FontFamily����� $ TextBlockHour��$	 FontSize����� $ TextBlockHour��$	 
Foreground����� � -	   $��GridAdjustHour��$��29��$��-29,-30,0,-30q�$y�Visible=�.+�     Spacing$ 2Q�.+��� -
   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��+5���� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��+1��  $��Bottom=�$ 2Q�.+��� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��-1���� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��-5���� $��
0,-2.5,0,0q�$��Center=�$	��Top=�$��DemiBold"�$��:������ $ TextBlockHour��$	 
FontFamily����� $ TextBlockHour��$	 FontSize����� $ TextBlockHour��$	 
Foreground��� -   $��TextBlockMinute��$��26(�$��01��$y�	Collapsed=����� $ TextBlockHour��$	 
FontFamily����� $ TextBlockHour��$	 
Foreground��� -   $��TextControlMinute������ $ TextBlockMinute��$
	 Text����� .R��� $ 
Horizontal=����� .R�� $��14��.+��� $��Center=�$��SemiBold"����� $ TextBlockMinute��$	 
FontFamily����� $ TextBlockMinute��$	 FontSize����� $ TextBlockMinute��$	 
Foreground����� � $��29��$��-29,-30,0,-30q�y��� $ GridAdjustHour��$	 
Visibility�.+�  $ 2Q�.+��� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��+5���� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��+1��  $��Bottom=�$ 2Q�.+��� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��-1���� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��-5���� -    ��Name$ BtnTimeSetOkay��$��20��$��20��$��	0,0,0,-35q�$��Bottom=����#0066BF$	 100�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 3Q�   	Direction$ 0Q�   Opacity$	 0.1Q�   ShadowDepth$ 0Q�._�(� .��,  &iNKORE.UI.WPF.Modern.Controls.FontIcon  $��5q�  FluentIconFontFamily   
FontFamily# [    FontSize$ 10(�/  )iNKORE.UI.WPF.Modern.Controls.IconElement   
Foreground
 �����   Glyph$	 ���� $��
0,-2.5,0,0q�$��Center=�$	��Top=�$��DemiBold"�$��:������ $ TextBlockHour��$	 
FontFamily����� $ TextBlockHour��$	 FontSize����� $ TextBlockHour��$	 
Foreground��� -   $��TextBlockSecond��$��26(�$��00��$y�	Collapsed=����� $ TextBlockHour��$	 
FontFamily����� $ TextBlockHour��$	 
Foreground��� -   $��TextControlSecond������ $ TextBlockSecond��$
	 Text����� .R��� $ 
Horizontal=����� .R�� $��14��.+��� $��Center=�$��SemiBold"����� $ TextBlockSecond��$	 
FontFamily����� $ TextBlockSecond��$	 FontSize����� $ TextBlockSecond��$	 
Foreground����� � -   $
��96.8��$��-96.8,0,0,0q�
������ � $��29��$��-29,-30,0,-30q�y��� $ GridAdjustHour��$	 
Visibility�.+�  $ 2Q�.+��� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�$��+5���� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�$��+1��  $��Bottom=�$ 2Q�.+��� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��-1���� -   $��13������ $ GridAdjustHour��$	 ActualWidth�.���� $	��-10q�$��Center=�$��Center=�$��8(�#���  $��-5���� -   $ BorderStopTime��$��18��$��0,23,0,0q�$��Center=�$��Center=�#���   #���  $	��0.5q�$ 9��._�  $	��6,0q�$��Center=�$ 
Horizontal=�$ 0Q�.+�  $��10��$��10��$��0,1,1,0q�# [ $ 10(�# �  $	 ���� -   $��TextBlockStopTime��$��Center=�$��9(�#���  $��12:30 PM��  $��30��$��Center=�$��Bottom=�$ 
Horizontal=�$ 10Q�y��� $ ProcessBarTime��$	 
Visibility�.+�� .+��� -   $ BtnStart��$��20��$��20�����#0066BF$	 100��._�(� .��  -     Name$ SymbolIconStart��$��5q�$��Center=�# [ 
 �����$	 ���� -    $ BtnStartCover��$��20��$��20�����#BFBFBF$	 100��$y�	Collapsed=�._�(� .��  -!   $ SymbolIconStartCover��$��5q�$��Center=�# [ 
 �����$	 ��� .+��� -"   $ BtnReset��$��20��$��20��#���   #���  $	��0.5q�$	 100��   $ 3Q�$ 0Q�$
 0.15Q�$ 0Q�._�(� .��  $��10q�$��Center=�# [ # �  $	 ���� -#   $ BtnResetCover��$��20��$��20��#���   #���  $	��0.5q�$	 100��._�(� .��  $��10q�$��Center=�# [ # �  $	 ��(� $��20,20,20,20q�$��Right=�y��� $ BigViewController��$	 
Visibility�.��  $	��180��$ 
Horizontal=�.+��� -$   $ 
BtnMinimal��$��20��$��20��$��5q�$��Right=�$��Bottom=�#���   #���  $	��0.5q�$	 100��y��� $ BorderStopTime��$	 
Visibility�   $ 3Q�$ 0Q�$	 0.1Q�$ 0Q�._�(� .��  $��10q�$��Center=�# [ # �  $	 ���� -%   $ BtnFullscreen��$��20��$��20��$��5q�$��Right=�$��Bottom=�#���   #���  $	��0.5q�$	 100��   $ 3Q�$ 0Q�$	 0.1Q�$ 0Q�._�(� .��  -&   $ SymbolIconFullscreen��$��10q�$��Center=�# [ # �  $	 ���� -'   $ BtnClose��$��20��$��20��$��5q�$��Right=�$��Bottom=����#E32A34$	 100��   $ 3Q�$ 0Q�$	 0.1Q�$ 0Q�._�(� .��  $��10q�$��Center=�# [ 
 �����$	 ��r� $	��100��$	��100��$
��Left=�$	��Top=�$y�	Collapsed=�