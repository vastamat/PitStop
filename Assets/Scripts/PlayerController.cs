using UnityEngine;

/// <summary>
/// Handle user input to control the player's car
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Car2DController
{
		void FixedUpdate()
		{
#if UNITY_ANDROID
				//Check if the screen has been touched
				if (Input.touchCount > 0)
				{
						//get only 1 touch (the first)
						Touch touch = Input.GetTouch(0);

						//calculate the middle position of the screen
						float middlePos = Screen.width / 2.0f;

						//check on which side of the screen was the touch (horizontally)
						if (touch.position.x < middlePos)
						{
								//left side = brake trigger
								Brake();
						}
						else
						{
								//right side = Accelerate trigger
								Accelerate();
						}
				}

				Vector3 tilt = Input.acceleration;
				//dead zone for steering
				if (tilt.x < -0.1f || tilt.x > 0.1f)
				{
						Steer(tilt.x);
				}

#else
				if (Input.GetKey(KeyCode.W))
				{
						Accelerate();
				}
				if (Input.GetKey(KeyCode.S))
				{
						Brake();
				}
				Steer(Input.GetAxis("Horizontal"));
#endif
		}
}