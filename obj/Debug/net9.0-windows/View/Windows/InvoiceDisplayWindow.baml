   M S B A M L   `   `   `  ����E  AInvoiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:InvoiceApp.ViewModelInvoiceApp.ViewModel  5   	   3clr-namespace:InvoiceApp.ModelInvoiceApp.Model  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   E'clr-namespace:InvoiceApp.View.ComponetsInvoiceApp.View.Componets  5   	   5    /InvoiceApp.View.Components.InvoiceDisplayWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1vm"clr-namespace:InvoiceApp.ViewModel     5   	   .modclr-namespace:InvoiceApp.Model     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   9local'clr-namespace:InvoiceApp.View.Componets     5   	     � Title$  Invoice Display��5   	   $	��450��6!   $	��800��6.    � 	Resources 5	      ��%    5
      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Invoice Number:��6   $��0��6*   $��0��67   $��Center=�6G   �� 5   
   $��0��6B   $��1��6O   $��5q�6_   ��6   �� *CurrentInvoice.InvoiceNumber+6_   �� 5    
   $��Invoice Date:��6   $��1��6(   $��0��65   $��Center=�6E   �� 5!   
   $��1��6I   $��1��6V   $��5q�6f   ��6   �� *CurrentInvoice.Date+ �� StringFormat$ d��6f   �� 5$   
   $��	Customer:��6   $��2��6$   $��0��61   $��Center=�6A   �� 5%   
   $��2��6B   $��1��6O   $��5q�6_   ��6   �� *CurrentInvoice.Customer.Name+6_   &   System.Windows.Controls.DataGrid  5(   
   $��3��5)      $��0��6    $��4��60      AutoGenerateColumns$ False��5*      $��5q�6/      
IsReadOnly$
 True��6:   ��5(      �� *CurrentInvoice.Items+   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$
 Type��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6L   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Type+6L     5-      $ Currency��6%   $
	 Auto 6T   
 67   �� *
Currency+6T     5.      $ Price��6%   $
	 Auto 6N   
 64   �� *Price+6N     5/      $ Quantity��6%   $
	 Auto 6T   
 67   �� *
Quantity+6T     50      $ Total��6%   $
	 Auto 6N   
 64   �� *Total+6N   52      �� 54   
   $��4��6   $��0��6   $��Total (excl. VAT):��6-   $��Center=�6J   �� 55   
   $��4��6   $��1��6!   $	��100��6`   $��Center=�56       �� TextAlignment$ Right=�60   $	��5,0q�6F   ��55   1   �� *TotalExclVat+$ N2��56   F   �� 57   
   $��4��6   $��2��6   $��Total (incl. VAT):��6-   $��Center=�6J   $��10,0,0,0q�6e   �� 58   
   $��4��6   $��3��6!   $	��100��6`   $��Center=�59      $ Right=�60   $	��5,0q�6F   ��58   1   �� *TotalInclVat+$ N2��59   F   �� 5:   
   -   5        $��22,3,564,13q�5:   '   $��5��6<   $��0��6I   $��4��6Y   .��6m   	Add items6x   5;      5<      