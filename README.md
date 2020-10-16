Stacy Shang 62961990  
Lab 2 Part 1  
**Question 1:**    
 #Threads=4
 |array size        |single-thread (s)      |multi-thread (s)|
 |------------------|-----------------------|----------------|
 |10                |   0.0000027           |  0.0028478     |
 |100               |   0.0000559           |  0.0037507     |
 |1000              |   0.0005347           |  0.0044462     |
 |10000             |   0.0036808           |  0.0095578     |
 |100000            |   0.0409366           |  0.0516668     |
 |1000000           |   0.3812969           |  0.2691253     |
 |10000000          |   4.2140990           |  2.8845874     |
 
 **Question 2:**  
 my laptop has 4 cores, i'm expecting speed-up factor of 4.    
 
 **Question 3:**  
 |array size      |  single-thread (s)    |  multi-thread (s)  |  speed-up factor|
 |----------------|-----------------------|--------------------|-----------------|
 |1000000         |      0.4249128        |     0.2524563      |     1.68x       |
 |1000000         |      0.3812969        |     0.2691253      |     1.41x       |
 |1000000         |      0.3980016        |     0.2042004      |     1.95x       |  
 
 for array size of 1 million, the speed up factor= (1.68+1.41+1.95)/3 = 1.68x
 
 **Question 4:**  
 array size=1000000  
 
 |#threads     |   single-thread (s)    |  multi-thread (s) |   speed-up factor|
 |-------------|-----------------------|--------------------|-------------------|
 |10            |     0.3847501         |    0.3055320      |      1.26|
 |20            |     0.3719396         |    0.3544189      |       1.04|
 |30            |     0.3690568         |    0.4494049      |       0.82|
 |40            |     0.3708897         |    0.5630559      |       0.66|
 |70            |     0.4006481         |    1.0248229      |       0.39|
 |100           |     0.3828021         |    1.2806604      |       0.30|
 |200           |     0.3813904         |    2.4955226      |       0.15|    
 
 *y = -0.358ln(x) + 2.0031*  
 in conclusion, as the number of threads increases, for array size of 1 million, the speed factor will decrease.  
 
 **Part2**   
 **Question 1**  
 - Multi-Threading doesn't always have short processing time.
 - the speed-up factor is largest when the number of threading equals to the number of cores  
 **question 2**  
 - We want to have numbers of multi-thread as same as numbers of core to producing the most efficient programs.
 **Qeustion 3**
 
