   M S B A M L   `   `   `  ����M  ISetting Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CopySettings.MVVM.View.PopupCopySettings.MVVM.View.Popup  5      (    "CopySettings.MVVM.View.Popup.Login   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:CopySettings.MVVM.View.Popup     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          >�Name$  
LoginPopup��5      .��5
      � $	��200��6   $��Center=�6   $��Center=�64   .+�5   
   �� $��Center=�6   $��10q�60   .+�5      �� -   5         ��Name$
 User��5      $��30��5      $��10q�6"   
�������$��17(�6A   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ UserName��5      .��6;   5      G� 5      -   5         G�Name$ PasswordBox��5      $��30��5      $��
10,10,10,0q�6&   
�������$��17(�6M   $ Password��5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��5      5      �� 5      -   5         ��Name$ remember��5      $��30,3,0,3q�5      $��0q�6)   $��15(�65   
�������$��remember��5      �� 5      -   5         ��Name$	 err��5   B   $��0��6   $��15(�6#   $��0,0,0,5q�61   $��Center=�6O   
���  ��6l   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5       �� -   5        $��70��5       $��30��6$   $��	10,0,10,0q�60   $��0q�6C   .��6]   Cancel5"      �� 5#      -   5        $��70��5#      $��30��6$   $��	10,0,10,0q�60   .��6Q   Login5%      5&      5(      �� 5)   
   -   5         ��Name$ Loading��5)   <   ���	#77000000$y�Hidden=�6(   ._�5*      �� $��Center=�6   .+�5+      � 	 � IsIndeterminate$
	 True��5,      $��10q�6,   �� 5-      $��Login...��6   
�������$��Center=�6?   $��70��6Z   $��20(�6e   5.      5/      �� 51   
   -	   5        
������ 
������ $��Right=�51   R   $	��Top=�6n   $��0q�6�   ��52      �� 53      .R�54      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 CloseCircle=�6.   
���  �����#340D3E$��Right=�6k   $��4q�6�   55      57      58      59      