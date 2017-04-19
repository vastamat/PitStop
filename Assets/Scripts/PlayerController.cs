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
				Android code
#endif
		}
}