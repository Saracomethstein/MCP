   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Client.ViewModelClient.ViewModel  5   	   "    Client.Views.LoginWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Client.ViewModel     5   	     � Title$  LoginWindowView��5   	   $	��400��5	   	   $	��450��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      +  %Client.ViewModel.LoginWindowViewModel  5   
   .��5      � $��0,0,0,0q�6   .+�5   
   �� -   5         ��Name$ ExitBT��5      $��X��5      $��30��5      $��30��5      $��	Helvetica)�5      $��420,0,0,370q�5         
ExitButton#���   5      ��5      �� *GetCloseAppCommand+5      �� 5   
   -   5        $ MiniBT��5      $��30��5      $��30��5       $��_��5!      $��	Helvetica)�5"      $��390,0,30,370q�5#        
MiniButton#���  5%      ��5$      �� *GetMinimizedCommand+5%      �� 5'   
   -   5        $	��390��5'      $��30��5(      $��
0,0,60,370q�5)      $	��MCP��5*      $
��Left=�5+      $��Center=�5,      ���	#FFDDDDDD5.      �� 50   
   $��Welcome!��6   $��Center=�51      $��22(�52      $
��Bold"�53      $��46��54      $��0,82,0,0q�55      $	��Top=�56      $	��250��57      $��	Helvetica)�58      $��Center=�59      $��Center=�5:      �� 5<   
   $��Center=�5=      $	��Top=�5>      $��20(�5?      $��	Helvetica)�5@      $��Center=�5A      $��43��5B      $��	0,158,0,0q�5C       �� TextWrapping$
 Wrap=�5D      $��Center=�5E      $	��232��5F      ��5<      �� *Login+5F      �� 5H   
   $��Center=�5I      $	��Top=�5J      $��20(�5K      $��Center=�5L      $��43��5M      $��	0,217,0,0q�5N      $��Center=�5O      $	��232��5P      ��5H      �� *
Password+5P      �� 5R   
     MainButtonStyle#���  6   $��Sign in��5S      $��20(�5T      $��	Helvetica)�5U      $��Center=�5V      $	��Top=�5W      $��40��5X      $��	0,294,0,0q�5Y      $	��134��5Z      
���������5\      �� *LoginUsersCommand+5^      5_      