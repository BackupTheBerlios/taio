
ÿ/ *   G Bo w n a   k l a s a   a p l k a c j i ( e n g i n ) ,   t u t a j   b e d i e   c a l a   f u n k c i o a n l n o s c   * / 
 
 u s i n g   S y s t e m ; 
 
 u s i n g   S y s t e m . C o l l e c t i o n s . G e n e r i c ; 
 
 u s i n g   S y s t e m . T e x t ; 
 
 
 
 n a m e s p a c e   t a i o 
 
 { 
 
         c l a s s   m a i n 
 
         { 
 
                 p r i v a t e   D a t a . D a t a L o a d e r   d a t a L o a d e r ;   / /   o b i e k t   w c z y t u j a c y   i   t r z y m a j a c y   d a n e   z   p l i k u 
 
 
                 p r i v a t e   L i s t < D a t a . R e c t a n g l e >   r e c t a n g l e s ;   / / p r o s t o k a t y   n a   k t o r y c h   d z i a l a j a   a l g o r y t m y ,   m o z e   t o   b y c   i n n y   z b i o r   n i z   w c z y t a n y   z   p l i k u   n p   z e d y t o w a n y 
 
                 p r i v a t e   L i s t < D a t a . S o l u t i o n >   s o l u t i o n s ; 
 
 
 
                 i n t e r n a l   L i s t < D a t a . S o l u t i o n >   S o l u t i o n s 
 
                 { 
 
                         g e t   {   r e t u r n   s o l u t i o n s ;   } 
 
                         s e t   {   s o l u t i o n s   =   v a l u e ;   } 
 
                 } 
 
                 p u b l i c   D a t a . S o l u t i o n   g e t S o l u t i o n ( i n t   i n d e x ) 
 
                 {   
 
                         r e t u r n   t h i s . S o l u t i o n s [ i n d e x ] ; 
 
                 } 
 
 
 
                 p u b l i c   L i s t < D a t a . R e c t a n g l e >   R e c t a n g l e s 
 
                 { 
 
                         g e t   {   r e t u r n   r e c t a n g l e s ;   } 
 
                         s e t   {   r e c t a n g l e s   =   v a l u e ;   } 
 
                 } 
 
 
 
                 p u b l i c   m a i n ( t a i o . M a i n F r m   m a i n F r m ) 
 
                 { 
 
                         t h i s . d a t a L o a d e r   =   n e w   t a i o . D a t a . D a t a L o a d e r ( t h i s ) ; 
 
                         t h i s . s o l u t i o n s   =   n e w   L i s t < t a i o . D a t a . S o l u t i o n > ( ) ; 
 
                         t h i s . r e c t a n g l e s   =   n e w   L i s t < t a i o . D a t a . R e c t a n g l e > ( ) ; 
 
                 } 
 
 
 
 
 
 
 
                 / /   w c z y t u j e   d a n e   w   o b i e k c i e   d a t a L o a d e r 
 
                 p u b l i c   v o i d   l o a d D a t a ( S t r i n g   p a t h ) 
 
                 { 
 
                         t h i s . d a t a L o a d e r . l o a d D a t a ( p a t h ) ; 
 
                 } 
 
         } 
 
 } 
 