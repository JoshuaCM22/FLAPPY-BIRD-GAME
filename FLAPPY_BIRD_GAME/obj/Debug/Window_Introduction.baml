   M S B A M L   `   `   `  ����K  GFLAPPY_BIRD_GAME, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FLAPPY_BIRD_GAMEFLAPPY_BIRD_GAME  5   	   *    $FLAPPY_BIRD_GAME.Window_Introduction   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FLAPPY_BIRD_GAME     5   	   -   5          � Title$  FLAPPY BIRD GAME��5	   	   $	��560��6#   $	��525��60    � 
ResizeMode$ CanMinimize=�6<   .��5
      �� -   5        $��MyCanvas��5
      |�. 
����ح�.+�5   
   �� -   5        $��lblTitle��5      $��40(�6   $��FLAPPY BIRD GAME��6.   
���   �$��	ExtraBold"�6\   
 �� Top$ 19��6s    �� Left$ 53��6�   �� 5   
   $��/Images/flappyBird.png��6   $	��100��60   $��80��6<   $	 193��6H   $ 99��6Z   �� 5   
   -   5        $��lblInstructions��5      $��20(�6   $o��iInstructions: Avoid to overfly and fallen down. 
Also avoid to collide in any tunnels as long as
you can.��65   
���   �$��Normal"�6�   $	 201��6�   $ 53��6�   $	��112��6�   �� 5   
   -   5        $��lblControls��5      $��20(�6   $5��/Control: Use the space bar to control the bird.��61   
���   �$��Normal"�6~   $	 299��6�   $ 53��6�   $	��112��6�   �� 5   
   -   5        $��btnPlay��5      $
��PLAY��6    $��16(�6/   $
��Bold"�6=   $	 156��6f   $	 375��6x   $��48��6�   $	��193��6�    � Cursor$
 Hand��6�   �� 5   
   -   5        $��btnAudio��5      $��50��6!   $��50��6,   
������ $
 Hand��6h   $	 460��6v   $	 470��6�   .��5      �� $/��)pack://application:,,,/Images/unmuted.png��6   5      �� 5   
   -   5        $��btnHighScores��5      $��HIGH SCORES��6&   $��16(�6X   $
��Bold"�6f   $	 156��6y   $	 437��6�   $��48��6�   $	��193��6�   $
 Hand��6�   5      5      