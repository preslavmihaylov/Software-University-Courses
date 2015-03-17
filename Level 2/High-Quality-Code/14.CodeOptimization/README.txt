The problem in the task was the Method EarthRotation. 
It came from a meaningless for loop from 0 to 360 with incrementation of 0.00005 on each step.
I just removed the loop and refactored the formula to just take 360 as a hardcalled value and proceed.