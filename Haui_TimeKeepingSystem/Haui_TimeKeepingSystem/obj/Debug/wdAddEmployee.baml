   M S B A M L   `   `   `  ����Q  MHaui_TimeKeepingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Haui_TimeKeepingSystemHaui_TimeKeepingSystem  5   	   *    $Haui_TimeKeepingSystem.wdAddEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Haui_TimeKeepingSystem     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.    � Title$ Thêm nhân viên��5   	   $	��710��6    $	��525��6-   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��2* �6   �� 5      $
��0.2* �6   .+�5   
   � $��0��6   .+�5      �� $)��#KHAI BÁO THÔNG TIN NGƯỜI DÙNG��6   $
��Bold"�6=   $��24(�6O   $��Center=�5      $��Center=�65   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $	��20* �6#   �� 5       $��1* �6#   .+�5"      � $��1��6   .+�5#      �� .+�5$      �� $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Họ và tên (*)��5%   4   $
��Left=�6I   $
��Bold"�6d   �� 5'      -   5         ��Name$ txtEmployeeName��5'       * &MaterialDesignOutlinedTextFieldTextBox#��[ 67   $	��Top=�5(   3   $��40��6L   $	��450��6X    �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�5)   H   $��Right=�6\   "
 �� VerticalScrollBarVisibility$

 Auto=�5*   2   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên người dùng��6U   {�5+   2   ��  �� Path$ 	IsChecked� �� ElementName$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5-      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Mã người dùng (*)��5.   4   $
��Left=�6M   $
��Bold"�6h   �� 50      -   5        $ txtEmployeeCode��50      #��[ 67   $	��Top=�51   3   $��40��6K   $	��450��6W    . $
	 Wrap=�52   H   $��Right=�6\   $

 Auto=�53   2   $ Mã người dùng��6U   {�54   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 56      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Số phòng (*)��57   4   $
��Left=�6H   $
��Bold"�6c   �� 59      -   5        $ txtDepartMent��59      #��[ 65   $	��Top=�5:   3   $��40��6K   $	��450��6W    . $
	 Wrap=�5;   H   $��Right=�6\   $

 Auto=�5<   2   $ Số phòng��6U   {�5=   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5?      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $$��Quan hệ với chủ nhà (*)��5@   4   $
��Left=�6S   $
��Bold"�6n   �� 5B      -   5        $ txtJob��5B      #��[ 6.   $	��Top=�5C   3   $��40��6L   $	��450��6X    . $
	 Wrap=�5D   H   $��Right=�6\   $

 Auto=�5E   2   $  Quan hệ với chủ nhà��6U   {�5F   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5H      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Hình ảnh (*)��5I   4   $
��Left=�6H   $
��Bold"�6c   �� 5K      -   5        $ txtPicturePath��5K      #��[ 66   $��15,0,0,0q�6v   $	��Top=�5L   3   $��40��6K   $	��415��6W   $��./Resources/NVA.png��6c    . $
	 Wrap=�5M   H   $
��Left=�6\   $

 Auto=�5N   2   $  Hình ảnh người dùng��6U   {�5O   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��'  !MaterialDesignThemes.Wpf.PackIcon  5Q      -   5          Name$ btnOpenFile��5Q   "      Kind$ MenuOpen=�67   $��35��6G   $��30��6R   $��Center=�6^   $��435,-40,0,0q�5R   *   6?   �� 5T      $	��200��6    $��30��6,   $��Bottom=�68   $��0,20,0,0q�6S   $��Mã số vân tay (*)��5U   4   $
��Left=�6M   $
��Bold"�6h   �� 5W      -   5        $ txtFingerID��5W      #��[ 63   $	��Top=�5X   3   $��40��6L   $	��450��6X    . $
	 Wrap=�5Y   H   $��Right=�6\   $

 Auto=�5Z   2   $ Mã số vân tay��6U   {�.  6x   5]      5^      5_      � 5`   
   $��2��6    5a      �� 5b      $��1* �6#   �� 5c      $��1* �6#   �� 5d      $��1* �6#   �� 5e      $��1* �6#   .+�5g      � $��2��6   .+�5h      �� -	   5         ��Name$ btnSave��5h      $
��Lưu��6*   $��Center=�68   $	��100��5i      6%   5k      � 5l      $��3��6   .+�5m      �� -
   5        $ 	btnCancel��5m      $��Hủy��6,   $��Center=�6:   $	��100��5n      6%   5o      5q      5r      5s      