using UnityEngine;

/// <summary>
/// Let artificial intelligence control the car
/// </summary>
public class AIController : Car2DController
{
		void FixedUpdate()
		{
				Accelerate();

				transform.rotation = Quaternion.Slerp(transform.rotation, GetCurrentTarget().transform.rotation * Quaternion.Euler(0.0f, 0.0f, -5.0f), 0.5f);
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
