   M S B A M L   `   `   `  ����F  BfilmLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:filmLibraryfilmLibrary  5   	       filmLibrary.SearchWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:filmLibrary     5   	     � Title$  SEARCH��5   	   $	��450��6   $	��800��6%   ���	#FF483D8B � Icon$" C:\workspace\searchIcon1.ico��6H   .��5	      �  � ShowGridLines .   � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��300px �6   6/   �� 5      6!   �� 5      $��50 �6   6,   .+�5   
   �� -   5        $��0��5      $��0��6   $��Search by title��6.   ���	#FF483D8B
�������$��18(�6�   $��Center=�6�   $��Verdana)�6�   $��DemiBold"�6�   $��Center=�6�   $��3q�6
  
������6  �� 5   
   -   5        $��1��5      $��0��6   $��Search by company��6.   ���	#FF483D8B
�������$��18(�6�   $��Center=�6�   $��Verdana)�6�   $��DemiBold"�6�   $��Center=�6�   $��3q�6  
������6   �� 5   
   -   5        $��2��5      $��0��6   $��Search by year��6.   ���	#FF483D8B
�������$��18(�6�   $��Center=�6�   $��Verdana)�6�   $��DemiBold"�6�   $��Center=�6�   $��3q�6	  
������6  �� 5   
   -   5        $��3��5      $��0��6   $��Search by duration��6.   ���	#FF483D8B
�������$��18(�6�   $��Center=�6�   $��Verdana)�6�   $��DemiBold"�6�   $��Center=�6�   $��3q�6  
������6!  �� 5   
   -   5        $��4��5      $��0��6   $��Search by format��6.   ���	#FF483D8B
�������$��18(�6�   $��Center=�6�   $��Verdana)�6�   $��DemiBold"�6�   $��Center=�6�   $��3q�6  
������6  �� 5   
   -   5        $��5��5      $��0��6   $��Search by quality��6.   ���	#FF483D8B
�������$��18(�6�   $��Center=�6�   $��Verdana)�6�   $��DemiBold"�6�   $��Center=�6�   $��3q�6  
������6   �� 5   
   -   5         ��Name$ searchByTitleTextBox��5      $��0��60   $��1��6=   ���	#FF483D8B���	#FFDDA0DD
�������$��18(�6�   $��Verdana)�6�   $��Center=�6�   �� 5   
   -   5        $ searchByCompanyTextBox��5      $��1��62   $��1��6?   ���	#FF483D8B���	#FFDDA0DD
�������$��18(�6�   $��Verdana)�6�   $��Center=�6�   �� 5    
   -	   5        $ searchByYearTextBox��5       $��2��6/   $��1��6<   ���	#FF483D8B���	#FFDDA0DD
�������$��18(�6�   $��Verdana)�6�   $��Center=�6�   �� 5!   
   -
   5        $ searchByDurationTextBox��5!      $��3��63   $��1��6@   ���	#FF483D8B���	#FFDDA0DD
�������$��18(�6�   $��Verdana)�6�   $��Center=�6�   �� 5"   
   -   5        $ searchByFormatTextBox��5"      $��4��61   $��1��6>   ���	#FF483D8B���	#FFDDA0DD
�������$��18(�6�   $��Verdana)�6�   $��Center=�6�   �� 5#   
   -   5        $ searchByQualityTextBox��5#      $��5��62   $��1��6?   ���	#FF483D8B���	#FFDDA0DD
�������$��18(�6�   $��Verdana)�6�   $��Center=�6�   5$      5%      