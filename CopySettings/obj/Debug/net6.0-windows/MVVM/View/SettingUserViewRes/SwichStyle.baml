   M S B A M L   `   `   `  ����M  ISetting Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CopySettings.HellpCopySettings.Hellp  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a%    CopySettings.Hellp.RoundConvert   RoundCV"   CopySettings.Hellp.WidthHalf  widthHalfCV$   CopySettings.Hellp.SwichConten  SwichContenCV#   CopySettings.Hellp.AgentsName  AgentsNameCV  SliderThumbStyle  �� 
TargetType �� Property �� Value �� 
TargetType  Tap �� Triggers P� Property P� Value  Spa N� EnterActions �� TargetProperty	 W� From	
 W� To g� Duration N� ExitActions  switchStype � DataContext �� 	Converter � ColumnDefinitions �� Path �� Orientation �� ElementName �� 	Converter �� Triggers �� 
TargetName�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      'Cv clr-namespace:CopySettings.Hellp  5      %�
  &	        &	      &	 &     &	 9     &	 L     &	 �    &	     &	 �    7  7  7     5      6     5      6     5	      6     5
      6   �� 5      "  n�6%   .�5   
   ��  �@J�SnapsToDevicePixels$
 true��60   �� 5   
    �@�OverridesDefaultStyle$ false��62   �� 5   
    � ��$ 18��6#   �� 5   
    � ��$ 18��6"   �� 5   
    � �� 5      �� 5      " n�6"   .R�5      A� $��Ellipse��6X   
���   �$��1��6-   $��10��6A   $��10��6M   
�������6g   5      5      5      �� 5      "  	�6   .�5   
   ��  � �� 5      �� 5      " 	�6"   .R�5      � #��z��6   #��z��6E   ��6g   �� *Width+.+�5       �� #��z��6$   $��Center=�6E   $��Center=�6b   
�������$��15(�6�   �� 5!      $��1��6!   #��z��6,   $��Bottom=�6W   5"      5$      5'       5(   
   P� 5)       �@d�	IsChecked$
 TrueY�6+   . �5*      ��  � ��
 � d �60   5+      P� 5,       �@d�	IsChecked$ FalseY�6+   . �5-      ��  � ��
 �  ��60   5.      51      �� 53      "  ��6    54   
   P� 55       � {�$
 True��6+    56      �� 57      .��58      �� .��59      W� $ Width�6.   	 1255:   .   
 05;   .   $ 0:0:0.05D�65   5<      5=       5?      �� 5@      .��5A      �� .��5B      W� $ Width�6.   
 1255C   .   	 05D   .   $ 0:0:0.05D�67   5E      5F      5H      5J      �� 5L      "  ��6   .�5M   
   ��  � �� 5N      �� 5O      " ��6"   .R�5P      � $��colu1��6e   #��z��6   #��z��6E    5Q      �� *	Content+8    5S      �� 5T      �� 5U      .+�5X      �� ���	#33FFFFFF
������ $��3q�6R   ._�5Y      �� $��Center=�6B   $��Center=�6_   ��6(   �� $	 [0]�6_   5Z      �� 5\      ���	#33FFFFFF$��1��68   
������ $��3q�6b   ._�5]      �� $��Center=�6B   $��Center=�6_   ��6(   �� $	 [1]�6_   5^      �� 5`      $ 
Horizontal=�6%   $��2��6>   .+�5a      �� $	��spa��6%   8�� $	��125��6M   �� 5b      $
��Left=�6%   
����������	#33000000$��3q�6o   ��6�   �� $ colu1��8  ._�5c   "   �� $��BorderL��6~   $��Center=�6F   $��Center=�6c   ��6,   �� $	 [0]�6~   5d      5e      5f       5i      P� 5j       �@d�	IsChecked$ FalseY�67   . �5k      �� $	 spa��6G    � {�$
 True��6:   6G   �� 5l      $ BorderL��65    6J   �� $	 [0]� � ��5m      P� 5o       �@d�	IsChecked$ FalseY�67   . �5p      �� $	 spa��6H    � {�$ False��6:   6H   �� 5q      $ BorderL��65    6J   �� $	 [1]� � ��5s      5v      5x      5y      5{      