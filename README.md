## 3D FPS Movement

**Description**

This is a simple 3D movement system for Unity using mouse input for rotation and keyboard input for movement, jumping, and dashing.

**Features**

* Mouse-controlled rotation using the `Mouse X` and `Mouse Y` axes
* Keyboard-controlled movement using the `Horizontal` and `Vertical` axes
* Jumping with the `Space` key
* Dashing with the `Left Shift` key
* Adjusting player height with the `Left Control` key (for crouching)

**Instructions**

1. Attach the `MouseRotation` script to the player's GameObject.
2. Attach the `Move` script to the player's GameObject.
3. Create a Collider and a Rigidbody components for the player's GameObject.
4. Assign the Collider and the Rigidbody components in the `Move` script.
5. Create a GameObject with a tag of "Ground" to represent the ground surface.

**Controls**

* A and D keys: `Horizontal Axis`
* W and S keys: `Vertical Axis`
* Jump: `Space` key
* Dash: `Left Shift` key
* Crouch: `Left Control` key

**Known Issues**

* Dashing may cause the player to slide along the ground.

**TODO**

* Improve collision detection for dashing.
* Add more advanced movement mechanics, such as wall jumping and sliding.
