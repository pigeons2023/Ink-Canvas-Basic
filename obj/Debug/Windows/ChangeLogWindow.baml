   M S B A M L   `   `   `  ����K  GInk Canvas Basic, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ink_Canvas
Ink_Canvas  5           Ink_Canvas.ChangeLogWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T PiNKORE.UI.WPF, Version=1.2.8.0, Culture=neutral, PublicKeyToken=cd19e634b9706635.ikw$http://schemas.inkore.net/lib/ui/wpf  5      $localclr-namespace:Ink_Canvas  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      \ XiNKORE.UI.WPF.Modern, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b9706635e	 aiNKORE.UI.WPF.Modern.Controls, Version=0.9.30.0, Culture=neutral, PublicKeyToken=cd19e634b97066356ui+http://schemas.inkore.net/lib/ui/wpf/modern  	 5	      -   5          � Title$%  版本更新 - Ink Canvas Basic��5
      $	��600��5      $	��390��5      '  !iNKORE.UI.WPF.Modern.ThemeManager   RequestedTheme$ Light=�5      8  2iNKORE.UI.WPF.Modern.Controls.Helpers.WindowHelper   SystemBackdropType$
 Mica=�5         UseModernWindowStyle$
 True��5       � 
ResizeMode$ NoResize=�5       � ShowInTaskbar$ False��5       � Topmost$
 True��5       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��130 �6   �� 5      �� 5      $��60 �6   .+�5   
   �� $
��20,0q�6   $&�� Ink Canvas 画板功能更新！��6   $��26(�6;   �� 5   
   $��1��6   $y�	Collapsed=�6"   .+�5       �� -   5        $��TextBlockChangeLogTitle��5!      $��
35,10,35,0q�5"      $��18(�5#      $
��Bold"�5$      $��更新日志��5%      �� 5&      -   5        $��TextBlockChangeLog��5'      $
��55,5q�5(      $��14(�5)      $��修复一堆 Bug。��5*      $
��Wrap=�5+      �� 5,      -   5        $��TextBlockChangeLog1��5-      $
��55,5q�5.      $��14(�5/      $9��3修复墨迹识别功能中部分误识别问题。��50      $
��Wrap=�51      $y�	Collapsed=�52      �� 53      -   5        $��TextBlockSuggestionTitle��54      $��
35,10,35,0q�55      $��18(�56      $
��Bold"�57      $��建议��58      �� 59      -   5        $��TextBlockSuggestion��5:      $
��55,5q�5;      $��14(�5<      $q��k建议配置屏幕为：3840×2160 (缩放: 250%)，或1920×1080 (缩放: 125%)，以获得最佳体验。��5=      $
��Wrap=�5>      5?      � 5@   
   $��1��6   $��	50,0,50,0q�6   $y�Visible=�6/   	 � ColumnDefinitions	 5A      �� 5B      �� 5C      �� 5D      5F      -  'iNKORE.UI.WPF.Controls.SimpleStackPanel  5G   
   $��2��6   $
��50,0q�6,   $��Bottom=�6:   .+�5H      �� $��0,10,0,0q�6   $��18(�6*   $
��Bold"�68   $��更新日志��6J   �� 5I      $��25,5,0,0q�6   $��14(�6*   $"��1. 支持多步撤销/重做��68   $
��Wrap=�6L   �� 5J      $��25,5,0,0q�6   $��14(�6*   $'��!2. 添加 PowerPoint 相关功能��68   $
��Wrap=�6U   �� 5K      $��25,5,0,0q�6   $��14(�6*   $��3. 提供白板选项��68   $
��Wrap=�6I   �� 5L      $��25,5,0,0q�6   $��14(�6*   $'��!4. 增加双曲线渐近线选项��68   $
��Wrap=�6M   5O      �� 5P   
   -   5        $��LabelVersion��5Q      $��3��5P      $
��20,0q�5R      $��Center=�5S      $��12(�5T      �� 5U   
   -   5        $��3��5U      $	��100��5V      $��10q�5W      $��Right=�5X      $��确定��5Z      5[      5\      