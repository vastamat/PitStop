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
#if UNITY_EDITOR_WIN
				if (Input.GetButton("Accelerate"))
				{
						Accelerate();
				}
				if (Input.GetButton("Brakes"))
				{
						Brake();
				}
				Steer(Input.GetAxis("Horizontal"));

#elif UNITY_ANDROID
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

				//rotate the tilt as the phone will be horizonal rather than vertical
				//rotating the tilt by 90 on the z axis makes it correct when the phone is horizontal
				//tilt = Quaternion.Euler(0.0f, 0.0f, 90.0f) * tilt;

				Steer(tilt.x);
#endif
		}
}