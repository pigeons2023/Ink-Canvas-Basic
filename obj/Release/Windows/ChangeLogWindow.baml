   M S B A M L   `   `   `  ���� K  GInk Canvas Basic, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ink_Canvas
Ink_Canvas       Ink_Canvas.ChangeLogWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     T PiNKORE.UI.WPF, Version=1.2.8.0, Culture=neutral, PublicKeyToken=cd19e634b9706635.ikw$http://schemas.inkore.net/lib/ui/wpf  $localclr-namespace:Ink_Canvas  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  \ XiNKORE.UI.WPF.Modern, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b9706635e	 aiNKORE.UI.WPF.Modern.Controls, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b97066356ui+http://schemas.inkore.net/lib/ui/wpf/modern  	 -     � Title$%  版本更新 - Ink Canvas Basic��$	��600��$	��390��'  !iNKORE.UI.WPF.Modern.ThemeManager   RequestedTheme$ Light=�8  2iNKORE.UI.WPF.Modern.Controls.Helpers.WindowHelper   SystemBackdropType$
 Mica=�   UseModernWindowStyle$
 True�� � 
ResizeMode$ NoResize=� � ShowInTaskbar$ False�� � Topmost$
 True�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $��50 ��� $	��130 ��� �� $��60 �.+��� $
��20,0q�$&�� Ink Canvas 画板功能更新！��$��26(��� $��1��$y�	Collapsed=�.+��� -   $��TextBlockChangeLogTitle��$��
35,10,35,0q�$��18(�$
��Bold"�$��更新日志���� -   $��TextBlockChangeLog��$
��55,5q�$��14(�$��修复一堆 Bug。��$
��Wrap=��� -   $��TextBlockChangeLog1��$
��55,5q�$��14(�$9��3修复墨迹识别功能中部分误识别问题。��$
��Wrap=�$y�	Collapsed=��� -   $��TextBlockSuggestionTitle��$��
35,10,35,0q�$��18(�$
��Bold"�$��建议���� -   $��TextBlockSuggestion��$
��55,5q�$��14(�$q��k建议配置屏幕为：3840×2160 (缩放: 250%)，或1920×1080 (缩放: 125%)，以获得最佳体验。��$
��Wrap=�� $��1��$��	50,0,50,0q�$y�Visible=�	 � ColumnDefinitions	 �� �� �� -  'iNKORE.UI.WPF.Controls.SimpleStackPanel  $��2��$
��50,0q�$��Bottom=�.+��� $��0,10,0,0q�$��18(�$
��Bold"�$��更新日志���� $��25,5,0,0q�$��14(�$"��1. 支持多步撤销/重做��$
��Wrap=��� $��25,5,0,0q�$��14(�$'��!2. 添加 PowerPoint 相关功能��$
��Wrap=��� $��25,5,0,0q�$��14(�$��3. 提供白板选项��$
��Wrap=��� $��25,5,0,0q�$��14(�$'��!4. 增加双曲线渐近线选项��$
��Wrap=��� -   $��LabelVersion��$��3��$
��20,0q�$��Center=�$��12(��� -   $��3��$	��100��$��10q�$��Right=�$��确定��