   M S B A M L   `   `   `  ����Q  MHaui_TimeKeepingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Haui_TimeKeepingSystemHaui_TimeKeepingSystem  5   	   *    $Haui_TimeKeepingSystem.wdAddEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Haui_TimeKeepingSystem     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.    � Title$ Thêm nhân viên��5   	   $	��680��6    $	��510��6-   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��2* �6   �� 5      $
��0.2* �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $	��20* �6#   �� 5      $��1* �6#   .+�5      � $��1��6   .+�5      �� .+�5       �� $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Tên nhân viên (*)��5!   4   $
��Left=�6M   $
��Bold"�6h   �� 5#      -   5         ��Name$ txtEmployeeName��5#       * &MaterialDesignOutlinedTextFieldTextBox#��[ 67   $	��Top=�5$   3   $��40��6L   $	��450��6X    �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�5%   H   $��Right=�6\   "
 �� VerticalScrollBarVisibility$

 Auto=�5&   2   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên nhân viên��6U   {�5'   2   ��  �� Path$ 	IsChecked� �� ElementName$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5)      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Mã nhân viên (*)��5*   4   $
��Left=�6L   $
��Bold"�6g   �� 5,      -   5        $ txtEmployeeCode��5,      #��[ 67   $	��Top=�5-   3   $��40��6K   $	��450��6W    . $
	 Wrap=�5.   H   $��Right=�6\   $

 Auto=�5/   2   $ Mã nhân viên��6U   {�50   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 52      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Bộ phận (*)��53   4   $
��Left=�6G   $
��Bold"�6b   �� 55      -   5        $ txtDepartMent��55      #��[ 65   $	��Top=�56   3   $��40��6K   $	��450��6W    . $
	 Wrap=�57   H   $��Right=�6\   $

 Auto=�58   2   $ Bộ phận��6U   {�59   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5;      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $ ��Vị trí công việc (*)��5<   4   $
��Left=�6P   $
��Bold"�6k   �� 5>      -   5        $ txtJob��5>      #��[ 6.   $	��Top=�5?   3   $��40��6L   $	��450��6X    . $
	 Wrap=�5@   H   $��Right=�6\   $

 Auto=�5A   2   $ Vị trí công việc��6U   {�5B   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5D      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Hình ảnh (*)��5E   4   $
��Left=�6H   $
��Bold"�6c   �� 5G      -   5        $ txtPicturePath��5G      #��[ 66   $	��Top=�5H   3   $��40��6K   $	��415��6W   $��./Resources/NVA.png��6c    . $
	 Wrap=�5I   H   $
��Left=�6\   $

 Auto=�5J   2   $ Hình ảnh nhân viên��6U   {�5K   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��'  !MaterialDesignThemes.Wpf.PackIcon  5M      -   5          Name$ btnOpenFile��5M   "      Kind$ MenuOpen=�67   $��35��6G   $��30��6R   $��Center=�6^   $��420,-40,0,0q�5N   *   6?   �� 5P      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Mã số vân tay (*)��5Q   4   $
��Left=�6M   $
��Bold"�6h   �� 5S      -   5        $ txtFingerID��5S      #��[ 63   $	��Top=�5T   3   $��40��6L   $	��450��6X    . $
	 Wrap=�5U   H   $��Right=�6\   $

 Auto=�5V   2   $ Mã số vân tay��6U   {�.  6x   5Y      5Z      5[      � 5\   
   $��2��6    5]      �� 5^      $��1* �6#   �� 5_      $��1* �6#   �� 5`      $��1* �6#   �� 5a      $��1* �6#   .+�5c      � $��2��6   .+�5d      �� -	   5         ��Name$ btnSave��5d      $
��Lưu��6*   $��Center=�68   $	��100��5e      6%   5g      � 5h      $��3��6   .+�5i      �� -
   5        $ 	btnCancel��5i      $��Hủy��6,   $��Center=�6:   $	��100��5j      6%   5k      5m      5n      5o      