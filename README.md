# Positional control of the COMAU Rebel-S6-0.45 robot using the gradient descent method

The 3D model of the robot can be found on [the robot's official page](https://www.comau.com/en/our-offer/products-and-solutions/robot-team/rebel-s6-0-45/).

![FBX model](/img/2.jpg)

## Camera control
All camera control functions are implemented in the script `FlyCamera.cs`.

|  Command  |  action  |
| --------- |  ------  |
| W         |  Forward |
| A         |   Left   |
| S         | Backward |
| D         |   Right  |
| Space     |    Up    |
| LeftShift |   Down   |

## UI
The user fills in three fields with the coordinates of the point he wants to create and presses the **addTarget** button. If the user wants to delete a point, he must select the point in **targetList** and press the **deleteTarget** button to delete the point.

## Application of gradient descent to solve the inverse kinematics problem
Gradient descent is a method for finding a local minimum of a function. We will call the function to which the method will be applied $\text{GetDistance}$, and it will return the distance from the last link of the robot to the point. We will save the initial distance in the variable $\text{distance1}$ and move by a very small angle $\Delta \theta = 0.01$ and measure the distance again, saving the value in the variable $\text{distance2}$. Calculate the derivative by definition. We will calculate this value for each link and change the rotation angle of the link by $\phi$.

$$ \frac{d(\text{GetDistance})}{d \theta} = \frac{\text{distance2} - \text{distance1}}{\Delta \theta} $$

$$ \phi = - \alpha \cdot \frac{d(\text{GetDistance})}{d \theta} $$

where $\alpha$ is a number equal to the robot's speed, specified by the user. The algorithm continues to work until the $\text{GetDistance}$ function shows a value less than the value set by the **threshold** variable.
## Result | video

[![Watch the video](https://img.youtube.com/vi/6DnhueNAK40/0.jpg)](https://www.youtube.com/watch?v=6DnhueNAK40)

The compiled project is located in the `Build` folder.
