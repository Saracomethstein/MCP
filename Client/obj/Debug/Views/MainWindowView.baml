   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Client.ViewModelClient.ViewModel  5   	       Client.MainWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Client.ViewModel     5   	   $	��430��5   	   $	��800��5	   	     � WindowStartupLocation$  CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � WindowState$ Normal=�5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      *  $Client.ViewModel.MainWindowViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��350 �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�5      .+�5      �� -   5        $��0,0,0,0q�5      $	��MCP��5      $
��Left=�5      $��Center=�5       $	��740��5!      ���	#FFDDDDDD5#      �� 5%      -   5         ��Name$ MiniBT��5&      $��_��5%      $��	Helvetica)�5'      $��30��5(      $��Center=�5)      $��Center=�5*         
MiniButton#���   5,      ��5+      �� *GetMinimizedCommand+5,      �� 5.      -   5        $ ExitBT��51      $��X��5.      $��30��5/      $��	Helvetica)�50      $��Center=�52      $��Center=�53        
ExitButton#���  55      ��54      �� *GetCloseAppCommand+55      57      &   System.Windows.Controls.DataGrid  59   
   -   5          Name$ mainDG��5=        DataGridStyle#���  59      $��1��5:      $��
10,10,10,0q�5;      	 � Language$	 ru�5<      $��	Helvetica)�5>      
   
IsReadOnly
 .    AutoGenerateColumns .     CanUserAddRows .     GridLinesVisibility$ 
Horizontal=�5C      $��Hidden=�5D      ��5B      ��  �� Path$ 
TableInfos�   Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ Number��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 5H   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5I   %   �� $ Counter�  5K      $
 Date��6%   $	 150 5L   %    5M   %   �� $
 Date�  5O      $ 	Operation��6%   $	 200 5P   %    5Q   %   �� $ Event�  5S      $ Coordinates��6%   $
 Auto 5T   %    5U   %   �� $ Coordinates�5X      �� 5Z   
   $��2��6   $ 
Horizontal=�5[      $��	0,10,10,0q�5\      .+�5^      �� -   5        $ StartStopBT��5^      $��	Helvetica)�5b      $	��100��5c      $��30��5d      $��	10,0,0,10q�5e      
�������  MainButtonStyle#���  5h      ��5_      �� $ StartStopButton� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5g      �� *GetSatartCommand+5h      �� 5j      $��X:��6   $��16(�5k      $��	Helvetica)�5l      $��30��5m      $��30��5n      $��	20,0,0,10q�5o      �� 5q      -   5         ��Name$
 XCor��5s        TextBoxStyle#���  5q      {�.  $��18(�5u      $��	Helvetica)�5v      $��Center=�5w      $��Center=�5x      $��50��5y      $��30��5z      $��	10,0,0,10q�5{      ��5r      �� $
 XCor�5{      �� 5}      $��Y:��6   $��16(�5~      $��30��5      $��	Helvetica)�5�      $��30��5�      $��	20,0,0,10q�5�      �� 5�      -   5        $
 YCor��5�      #���  5�      {�.  $��18(�5�      $��	Helvetica)�5�      $��Center=�5�      $��Center=�5�      $��50��5�      $��30��5�      $��	10,0,0,10q�5�      ��5�      �� *YCor+5�      �� 5�      -   5        $ ClearBT��5�      $��Clear��5�      $	��140��5�      $��30��5�      $��	Helvetica)�5�      $��
160,0,0,10q�5�      
�������#���  5�      ��5�      �� *GetClearDataGridCommand+5�      �� 5�      -	   5        $ ChangeUserTB��5�      $��Change user��5�      $	��150��5�      $��30��5�      $��	10,0,0,10q�5�      $��	Helvetica)�5�      
�������#���  5�      ��5�      �� *GetChoseUserCommand+5�      5�      5�      5�      