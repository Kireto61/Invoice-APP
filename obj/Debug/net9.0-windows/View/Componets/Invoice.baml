   M S B A M L   `   `   `  ����E  AInvoiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InvoiceApp.View.ComponetsInvoiceApp.View.Componets  5      G(clr-namespace:InvoiceApp.View.ConvertersInvoiceApp.View.Converters  5      ;"clr-namespace:InvoiceApp.ViewModelInvoiceApp.ViewModel  5      3clr-namespace:InvoiceApp.ModelInvoiceApp.Model  5      ;"clr-namespace:InvoiceApp.ResourcesInvoiceApp.Resources  5	      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
      3clr-namespace:InvoiceApp.ModelInvoiceApp.Model  5      '    !InvoiceApp.View.Componets.Invoice   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9local'clr-namespace:InvoiceApp.View.Componets     5      9conv(clr-namespace:InvoiceApp.View.Converters     5      8	viewmodel"clr-namespace:InvoiceApp.ViewModel     5      0modelclr-namespace:InvoiceApp.Model     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2res"clr-namespace:InvoiceApp.Resources     5	      6sys&clr-namespace:System;assembly=mscorlib     5
      .modclr-namespace:InvoiceApp.Model     5      $
��Auto��5      $
��Auto��6     � 	Resources  5      ;   5InvoiceApp.View.Converters.CurrencyToEnabledConverter   CurrencyToEnabledConverter��%   &	          5   
   6*   5      .��5      � $��10q�6   $	��305��6   $	��685��6$    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $��* �6   �� 5#      $
��Auto �6   �� 5$      $��* �6   .+�5(   
   �� $��Invoice Number:��6   $��0��6*   $��0��67   $��Center=�6G   �� 5)   
   $��0��5*      $��1��6   $��5q�6/   ��5)      �� *CurrentInvoice.InvoiceNumber+5*   /   �� 5-   
   $��Invoice Date:��6   $��1��6(   $��0��65   $��Center=�6E   (  "System.Windows.Controls.DatePicker  5.   
   $��1��5/      $��1��6"   $��5q�62      SelectedDate 5.      �� *CurrentInvoice.Date+5/   2   �� 52   
   $��	Customer:��6   $��1��6$   $��2��61   $��Center=�6A   �� 53   
    �� DisplayMemberPath$
 Name��55      $��1��56      $��3��6    $��5q�60   $	��150��6;   ��53      �� *	Customers+ �� SelectedItem 54      �� *CurrentInvoice.Customer+56   ;   &   System.Windows.Controls.DataGrid  59   
   $��3��5:      $��0��6    $��4��60      AutoGenerateColumns$ False��5;      $��5q�6/   ��59      �� *CurrentInvoice.Items+   Columns 5<      4  .System.Windows.Controls.DataGridTemplateColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$
 Type��6)   	   CellTemplate	 5@      �� 5A      .R�5B      �� ��6(   �� *
TypeString+5C      
   CellEditingTemplate
 5F      �� 5G      .R�5H      �� $	��120��5J   !    5H   '   �� *
TypeString+��5I   !   �� *DataContext.Types+ �� RelativeSource ��  �� AncestorType UserControl5J   !   5K      5M        5O      $ Currency��6)   	 5Q      �� 5R      .R�5S      �� ��6(   �� *CurrencyString+5T      
 5W      �� 5X      .R�5Y      �� $	��120��5[   !    5Y   '   �� *CurrencyString+��5Z   !   �� *DataContext.Currencies+ ��  UserControl5[   !   5\      5^        5`      $ Price��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 68   	 5a      �� 5b      .R�5c      �� ��6(   �� *Price+5d      
 5f      �� 5g      .R�5h      �� ��6&   �� *Price+ �� 
IsReadOnly 5i   &   �� *CurrencyString+ �� 	Converter# [  5j      5l      0  *System.Windows.Controls.DataGridTextColumn  5m      $ Quantity��6%   $
 Auto 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Quantity+6T     5n      $ Total��6%   $
 Auto 6N      
IsReadOnly$
 True��6[    64   �� *Total+6[   5p      �� 5s   
   $��4��6   $��0��6"   $��4��62    �� Orientation$ 
Horizontal=�6F   $
��Left=�5t      $��5q�60   .+�5u      �� $��Add Item��6   $��5q�6K   ��6(   �� *AddItemCommand+6K   �� 5v      $��	Calculate��6   $��5q�6N   ��6)   �� *CalculateCommand+6N   �� 5w      -   5        $��Display items��5w   +   $��5q�6C   5y      �� 5|   
   $��5��6   $��0��6"   $��4��62   $ 
Horizontal=�6F   $��Right=�5}      $��5q�61   .+�5~      �� $��Total (excl. VAT):��6   $��Center=�61   �� 5      $	��100��5�      $��Center=�6$    �� TextAlignment$ Right=�6?   $	��5,0q�6U   ��5      �� *TotalExclVat+ �� StringFormat$ N2��5�   U   �� 5�      $��Total (incl. VAT):��6   $��Center=�61   $��10,0,0,0q�6L   �� 5�      $	��100��5�      $��Center=�6$   $ Right=�6?   $	��5,0q�6U   ��5�      �� *TotalInclVat+$ N2��5�   U   5�      �� 5�   
   $��	Currency:��6   $��1��6$   $��Center=�64   $��3��6O   $��262,0,262,0q�6c   �� 5�   
   -   5        $��3��5�   !   $��	56,1,56,3q�61   $	��150��6D    5�      �� *CurrentInvoice.CurrencyString+��5�   !   �� *
Currencies+5�   P   5�      5�      