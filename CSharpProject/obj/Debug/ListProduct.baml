   M S B A M L   `   `   `  ����H  DCSharpProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CSharpProjectCSharpProject  5   	       CSharpProject.ListProduct   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CSharpProject     5   	     � Title$  ListProduct��5   	   $	��450��6   $	��800��6*   .��5	      � $	��525��6   
�������$��134,34,134,37q�6+   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5         AutoGenerateColumns .  
�������   
IsReadOnly .    CanUserResizeColumns .     CanUserReorderColumns .  $��5q�5      $   HorizontalScrollBarVisibility$ Visible=�5      "   VerticalScrollBarVisibility$ Hidden=�5         SelectionMode$ Extended=�5      	   GridLinesVisibility$		 All=�5      
�������
   RowBackground

 �����   AlternatingRowBackground
 �  ��   HeadersVisibility$	 All=�5   N   $	��276��5      $	��500��6    $
��Left=�6,   $��	12,55,0,0q�6G   $	��Top=�5   '      	RowHeight$ 30Q�6?      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6N      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *title+6P     5      $ Category��6%    67   �� *
category+6V     5      $ Price��6%    64   �� *price+6P     5      $ Description��6%    6:   �� *description+6\   5      �� 5   
   $��Title��6   $
��Left=�6    $��	32,14,0,0q�6;   $	��Top=�6N   �� 5   
   -   5         ��Name$ textBoxTitle��5      $
��Left=�6(   $��23��6C   $��
101,17,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5        $��Search��5      $
��Left=�6"   $��
271,20,0,0q�6=   $	��Top=�6Q   $��75��6i   6t   5!      5"      