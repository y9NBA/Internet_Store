   M S B A M L   `   `   `  ����I  EInternet_Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Internet_StoreInternet_Store  5   	   '    !Internet_Store.WindowEditingOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Internet_Store     5   	   -   5          � Title$!  Корзина-Заказы��5   	   $	��500��6    $	��800��6-    � Icon$ \Pictures\Store_Icon.ico��5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��5q�5      $��Center=�6    $	��Top=�6=    &  "MaterialDesignToolForegroundButton#��[  5      .��5      �� $%��\Pictures\Circle_Arrow_Back.png��6   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ Orders��5         
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$		 №��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *ID+  5      $	 Дата заказа��6)   
 6>   �� *
Date_Order+  5      $	 Статус��6)   
 69   �� *Status.Name_Status+  5      $	 Название��6)   
 6;   �� *	Good.Name+  5      $	 Количество��6)   
 6=   �� *Total_Amount+  5      $	 
Сумма��6)   
 68   �� *Total_Price+5      5      �� 5    
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   .+�5!      �� -   5         ��Name$ Information��5!      $(��"Подробнее о товаре��6*   $��Center=�5"      $��Center=�62   $��10q�5#      6!   5$      �� 5%   
   $��Right=�6   $��Bottom=�61   .+�5&      �� -   5        $ Excel��5&      $��Удалить��6$   $��Center=�5'      $��Center=�62   $��10q�5(      6!   5)      5*      5+      