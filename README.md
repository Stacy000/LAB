Stacy Shang 62961990
Lab 2 Part 1
Question 1:   
 #Threads=4
 array size        single-thread (s)      multi-thread (s)
 10                   0.0000027             0.0028478
 100                  0.0000559             0.0037507
 1000                 0.0005347             0.0044462
 10000                0.0036808             0.0095578
 100000               0.0409366             0.0516668
 1000000              0.3812969             0.2691253
 10000000             4.2140990             2.8845874
 
 Question 2:
 my laptop has 4 cores.
 
 Question 3:
 for array size of 1 million, the speed up factor=0.3812969/0.2691263=1.41x
 
 Question 4:
 array size=1000000
 
 #threads        single-thread (s)      multi-thread (s)    speed-up factor
 10                 0.3847501             0.3055320             1.26
 20                 0.3719396             0.3544189             1.04
 30                 0.3690568             0.4494049             0.82
 40                 0.3708897             0.5630559             0.66
 70                 0.4006481             1.0248229             0.39
 100                0.3828021             1.2806604             0.30
 200                0.3813904             2.4955226             0.15
 y=1.1972e^(-0.011x)
 in conclusion, as the number of threads increases, for array size of 1 million, the speed factor will decrease.
