   M S B A M L   `   `   `  ����Q  MHaui_TimeKeepingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Haui_TimeKeepingSystemHaui_TimeKeepingSystem  5   	   '    !Haui_TimeKeepingSystem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Haui_TimeKeepingSystem     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5        � Title$* $Hệ thống quản lý chấm công��5   	   $	��680��6,   $	��900��69   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6    5      �� 5      $
��0.2* �6#   �� 5      $��1* �6#   �� 5      $
��0.2* �6#   .+�5      � $��1��6    � RowDefinitions 5      �� 5      $
��0.5* �6$   �� 5       $��2* �6$   �� 5!      $
��0.3* �6$   �� 5"      $
��0.3* �6$   .+�5$      � $��0��6   .+�5%      �� $��HÌNH ẢNH NHÂN VIÊN��6    $
��Bold"�5&       $��Center=�5'       $��Center=�5(       $��22(�5)       5*      � 5+      $��1��6   .+�5,      �� -   5         ��Name$ 
img_People��5,      5.      � 5/      $��2��6   .+�50      �� -   5         ��Name$ txtName��50       $
��Bold"�51       $��Center=�52       $��Center=�53       $��22(�54       55      � 56      $��3��6   .+�57      �� -   5        $ txtCode��57       $
��Bold"�58       $��Center=�59       $	��Top=�5:       $��16(�5;       5<      5=      5?      � 5@   
   $��1��6    5A      �� 5B      $
��0.1* �6    �� 5C      $��2* �6    �� 5D      $
��0.2* �6    .+�5F      � $��1��6    5G      �� 5H      $��1* �6'   �� 5I      $	��20* �6'   �� 5J      $��1* �6'   .+�5L      � $��1��6   .+�5M      �� .+�5N      �� $	��200��6$   $��30��60   $��Bottom=�6<   $��0,20,0,0q�6W   $��Tên nhân viên (*)��5O   4   $
��Left=�6M   $
��Bold"�6h   �� 5Q      -   5         ��Name$ txtEmployeeName��5Q   "    * &MaterialDesignOutlinedTextFieldTextBox#��[ 6;   $	��Top=�5R   3   $��40��6L   $	��400��6X   	 �� AcceptsReturn	 . 
 �� TextWrapping$

 Wrap=�5S   H   $��Right=�6\   " �� VerticalScrollBarVisibility$
 Auto=�5T   2   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên nhân viên��6U   {�5U   2   ��  �� Path$ 	IsChecked� �� ElementName$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5W      $	��200��6$   $��30��60   $��Bottom=�6<   $��0,20,0,0q�6W   $��Mã nhân viên (*)��5X   4   $
��Left=�6L   $
��Bold"�6g   �� 5Z      -   5        $ txtEmployeeCode��5Z   "   #��[ 6;   $	��Top=�5[   3   $��40��6K   $	��400��6W   	 . $

 Wrap=�5\   H   $��Right=�6\   $
 Auto=�5]   2   $ Mã nhân viên��6U   {�5^   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5`      $	��200��6$   $��30��60   $��Bottom=�6<   $��0,20,0,0q�6W   $��Bộ phận (*)��5a   4   $
��Left=�6G   $
��Bold"�6b   �� 5c      -   5        $ txtDepartMent��5c   "   #��[ 69   $	��Top=�5d   3   $��40��6K   $	��400��6W   	 . $

 Wrap=�5e   H   $��Right=�6\   $
 Auto=�5f   2   $ Bộ phận��6U   {�5g   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5i      $	��200��6$   $��30��60   $��Bottom=�6<   $��0,20,0,0q�6W   $ ��Vị trí công việc (*)��5j   4   $
��Left=�6P   $
��Bold"�6k   �� 5l      -   5        $ txtJob��5l   "   #��[ 62   $	��Top=�5m   3   $��40��6L   $	��400��6X   	 . $

 Wrap=�5n   H   $��Right=�6\   $
 Auto=�5o   2   $ Vị trí công việc��6U   {�5p   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5r      $	��200��6$   $��30��60   $��Bottom=�6<   $��0,20,0,0q�6W   $��Giờ vào (*)��5s   4   $
��Left=�6G   $
��Bold"�6b   �� 5u      -	   5        $ txtInputTime��5u   "   #��[ 68   $	��Top=�5v   3   $��40��6K   $	��400��6W   	 . $

 Wrap=�5w   H   $��Right=�6\   $
 Auto=�5x   2   $ 
Giờ vào��6U   {�5y   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox���� 5{      $	��200��6$   $��30��60   $��Bottom=�6<   $��0,20,0,0q�6W   $��Giờ ra (*)��5|   4   $
��Left=�6F   $
��Bold"�6a   �� 5~      -
   5        $ txtOutputTime��5~   "   #��[ 69   $	��Top=�5   3   $��40��6K   $	��400��6W   	 . $

 Wrap=�5�   H   $��Right=�6\   $
 Auto=�5�   2   $ Giờ ra��6U   {�5�   2   �� $ 	IsChecked�$; 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��5�      5�      5�      � 5�      $��2��6    5�      �� 5�      $��1* �6'   �� 5�      $��12.5* �6'   �� 5�      $
��6.5* �6'   �� 5�      $��1* �6'   .+�5�      � $��2��6   .+�5�      �� -   5         ��Name$ btnAddEmployee��5�      $��Thêm nhân viên��65   $��Right=�6O   $	��130��5�      6%   5�      � 5�      $��1��6   .+�5�      �� -   5        $ 
btnHistory��5�      $��Lịch sử��61   $	��100��6C   $��Right=�6O   5�      5�      5�      5�      5�      5�      