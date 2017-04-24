using UnityEngine;

/// <summary>
/// Let artificial intelligence control the car
/// </summary>
public class AIController : Car2DController
{
		void FixedUpdate()
		{
				Accelerate();

				TrackCheckpoint target = GetCurrentTarget();

				Debug.Log(target);

				Vector3 towardsNextCheckpoint = transform.position - target.transform.position;
				float angleBetweenCP = Vector2.Angle(Vector2.up, towardsNextCheckpoint.normalized) * Mathf.Sign(towardsNextCheckpoint.y);
				float rot = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, angleBetweenCP, 0.3f);
				transform.eulerAngles = new Vector3(0.0f, 0.0f, rot);
				//Steer(Mathf.Sign(angleBetweenCP));
		}

		private TrackCheckpoint GetCurrentTarget()
		{
				CarLapCounter clc = GetComponent<CarLapCounter>();
				if (clc)
				{
						return clc.GetNextCheckpoint();
				}
				return null;
		}
}
