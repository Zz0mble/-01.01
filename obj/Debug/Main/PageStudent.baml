   M S B A M L   `   `   `  ����?  ;ESUN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ESUN.Main	ESUN.Main  5          ESUN.Main.PageStudent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ESUN.Main     5        N� Title$  PageStudent��5	       N� 
Background �	#FF364C90.��5      �  � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      $
��133* �6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $
��133* �6   �� 5      $��70 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��1��6K   .+�5      �� $��Поиск по ФИО: ��6   $��Center=�6.   
�������6I   �� 5      -   5        $
��txtB��5       �� TextWrapping$
 Wrap=�6"   $	��321��66   $
��0,15q�6B   6P   �� 5      $��20��6   $	��125��6$   $,��&Фильтрация по классу��60   $��10,0,0,0q�6L   
�������6^   �� 5      -   5        $��CmbGroup��5   @   $	��141��6   $��5,0,0,0q�6#   $��30��64   6P   5      �� 5   
   $��Center=�6   $
��Left=�60   $��0��6K   $��3��6[   .+�5      �� -   5        $��Journal��5   H   $��70��6   $��70��6    $��Журнал��6,   $��5q�6=   6W   �� 5      -   5        $��Theory��5   H   $��70��6   $��70��6    $��Теория��6,   $��5q�6=   6V   �� 5      -   5        $
��Test��5   G   $��70��6   $��70��6    $��
Тесты��6,   $��5q�6<   6S   �� 5      -   5        $
��Exit��5   G   $��70��6   $��70��6    $��
Выход��6,   $��5q�6<   6S   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dataGrid��5!         AutoGenerateColumns .     
IsReadOnly . "	   VerticalScrollBarVisibility$
	 Auto=�6S   $��1��6v   $��1��6�   $��5q�6�   
   Columns
 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *FIO+6J     5$      $ 
Класс��6%   $ * 6S    64   �� *
Class.Name+6S   5&      �� 5'   
   $ 
Horizontal=�6   $��2��6.   $��1��6;   $��Center=�6K   .+�5(      �� -   5        $��Import��5(   >   $��Импорт��6   $��10q�6&   $	��150��62   6L   �� 5)      -	   5        $��Ex��5)   =   $��Excel��6   $��10q�6%   $	��150��61   6G   �� 5*      -
   5        $	��Add��5*   @   $��Добавить��6   $��10q�6(   $	��150��64   6K   �� 5+      -   5        $
��Edit��5+   E   $ ��Редактировать��6   $��10q�6-   $	��150��69   6Q   �� 5,      -   5        $��Delete��5,   ?   $��Удалить��6   $��10q�6'   $	��150��63   6M   5-      5.      5/      