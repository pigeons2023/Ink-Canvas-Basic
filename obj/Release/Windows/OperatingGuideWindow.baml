   M S B A M L   `   `   `  ���� K  GInk Canvas Basic, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ink_Canvas
Ink_Canvas  %    Ink_Canvas.OperatingGuideWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     T PiNKORE.UI.WPF, Version=1.2.8.0, Culture=neutral, PublicKeyToken=cd19e634b9706635.ikw$http://schemas.inkore.net/lib/ui/wpf  $localclr-namespace:Ink_Canvas  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  \ XiNKORE.UI.WPF.Modern, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b9706635e	 aiNKORE.UI.WPF.Modern.Controls, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b97066356ui+http://schemas.inkore.net/lib/ui/wpf/modern  	   � Title$#  Ink Canvas Basic 使用指南��$	��700��$	��600��$	��500��'  !iNKORE.UI.WPF.Modern.ThemeManager   RequestedTheme$ Light=�8  2iNKORE.UI.WPF.Modern.Controls.Helpers.WindowHelper   SystemBackdropType$
 Mica=�   UseModernWindowStyle$
 True�� � Topmost$
 True�� � WindowStartupLocation$ CenterScreen=�.���� $��10q� �� Padding$ 	20,20,0,0q�   PopupWindowBackground#���     PopupWindowBorderBrush#���  $��1q� �� CornerRadius$ 10��._�� .+��� -   $��64��$��15��$��0,0,0,5q�$��Center=�$��Bottom=�#���   #���  $��1q�$ 8��$y�Visible=�� .+��� -   $��0,0,0,30q�$ Light=� �� PanningMode$ VerticalFirst=�$
��Auto=�.��-  'iNKORE.UI.WPF.Controls.SimpleStackPanel  .+�  $��
20,20,20,0q�$
��Left=�	   Orientation$	 
Horizontal=�.+�,  &iNKORE.UI.WPF.Modern.Controls.FontIcon  $��40��$��40��$	��6,0q�  FluentIconFontFamily
   
FontFamily#
 [    FontSize$ 24(�  PopupWindowForeground/  )iNKORE.UI.WPF.Modern.Controls.IconElement   
Foreground# �     Glyph$	 ���� $��Center=�$��22(�#���  $��软件快捷键��$
��Wrap=�(� $	��500��$
��Left=�.��  .+�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��4,0q�$��Center=�$��Center=�$��10(�#���  $
��Ctrl��$
��Wrap=��� $��Center=�$��10(�#���  $�� + Z ��$
��Wrap=��� $��Center=�$��10(�#���  $�� ——  撤销��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��4,0q�$��Center=�$��Center=�$��10(�#���  $
��Ctrl��$
��Wrap=��� $��Center=�$��10(�#���  $�� + Y ��$
��Wrap=��� $��Center=�$��10(�#���  $�� ——  重做��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��4,0q�$��Center=�$��Center=�$��10(�#���  $
��Ctrl��$
��Wrap=��� $��Center=�$��10(�#���  $�� + E ��$
��Wrap=��� $��18��$	��2,0q�$	 6,0q� ' #PopupWindowDarkBlueBorderBackground#���  $ 3��._��� $��Center=�$��10(� ' #PopupWindowDarkBlueBorderForeground#���  $��全局快捷键���� $��Center=�$��10(�#���  $�� ——  清屏��$
��Wrap=�  $��20��$��
20,10,20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��6,0q�$��Center=�$��Center=�$��10(�#���  $	��Alt��$
��Wrap=��� $��Center=�$��10(�#���  $�� + C ��$
��Wrap=��� $��18��$	��2,0q�$	 6,0q�#���  $ 3��._��� $��Center=�$��10(�#���  $��全局快捷键���� $��Center=�$��10(�#���  $"�� ——  截屏（Capture）��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��6,0q�$��Center=�$��Center=�$��10(�#���  $	��Alt��$
��Wrap=��� $��Center=�$��10(�#���  $�� + V ��$
��Wrap=��� $��18��$	��2,0q�$	 6,0q�#���  $ 3��._��� $��Center=�$��10(�#���  $��全局快捷键���� $��Center=�$��10(�#���  $B��< ——  显示/隐藏 笑脸右侧工具栏（Visibility）��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��6,0q�$��Center=�$��Center=�$��10(�#���  $	��Alt��$
��Wrap=��� $��Center=�$��10(�#���  $�� + D ��$
��Wrap=��� $��18��$	��2,0q�$	 6,0q�#���  $ 3��._��� $��Center=�$��10(�#���  $��全局快捷键���� $��Center=�$��10(�#���  $I��C ——  切换至批注模式 / 显示或关闭调色板（Draw）��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��6,0q�$��Center=�$��Center=�$��10(�#���  $	��Alt��$
��Wrap=��� $��Center=�$��10(�#���  $�� + Q ��$
��Wrap=��� $��18��$	��2,0q�$	 6,0q�#���  $ 3��._��� $��Center=�$��10(�#���  $��全局快捷键���� $��Center=�$��10(�#���  $+��% ——  退出批注模式（Quit）��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��6,0q�$��Center=�$��Center=�$��10(�#���  $	��Alt��$
��Wrap=��� $��Center=�$��10(�#���  $�� + B ��$
��Wrap=��� $��18��$	��2,0q�$	 6,0q�#���  $ 3��._��� $��Center=�$��10(�#���  $��全局快捷键���� $��Center=�$��10(�#���  $.��( ——  进入/退出 画板（Board）��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��6,0q�$��Center=�$��Center=�$��10(�#���  $	��Alt��$
��Wrap=��� $��Center=�$��10(�#���  $�� + S ��$
��Wrap=��� $��Center=�$��10(�#���  $0��* ——  切换至选择模式（Select）��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��6,0q�$��Center=�$��Center=�$��10(�#���  $	��Alt��$
��Wrap=��� $��Center=�$��10(�#���  $�� + E ��$
��Wrap=��� $��Center=�$��10(�#���  $=��7 ——  切换至面积擦/墨迹擦功能（Eraser）��$
��Wrap=�  $��20��$
��20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��6,0q�$��Center=�$��Center=�$��10(�#���  $	��Alt��$
��Wrap=��� $��Center=�$��10(�#���  $�� + L ��$
��Wrap=��� $��Center=�$��10(�#���  $:��4 ——  切换至单次直线绘制功能（Line）��$
��Wrap=�  $��20��$��
20,10,20,2q�$
��Left=�$	 
Horizontal=�.+��� $��30��#���  $��1q�$ 3��._��� $	��2,0q�$��Center=�$��Center=�$��10(�#���  $��Shift��$
��Wrap=��� $��Center=�$��10(�#���  $�� + Esc ��$
��Wrap=��� $��18��$	��2,0q�$	 6,0q�#���  $ 3��._��� $��Center=�$��10(�#���  $��全局快捷键���� $��Center=�$��10(�#���  $ �� ——  退出 PPT 放映��$
��Wrap=�  $��5q�$��Right=�$��Bottom=�.+��� -    ��Name$ BtnClose��$��50��$��50��$��5q�$��Right=�$��Bottom=����#E32A34#���  $	��0.5q�$	 100�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 3Q�   	Direction$ 0Q�   Opacity$	 0.1Q�   ShadowDepth$ 0Q�._�(� .��  $��10q�$��Center=�#
 [ 
 �����$	 ��