using UnityEngine;

/// <summary>
/// Class for the checkpoints on the tracks
/// which upon being reached call the callback functions of the cars
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class TrackCheckpoint : MonoBehaviour
{
		public TrackCheckpoint m_next;

		void OnTriggerEnter2D(Collider2D _other)
		{
				CarLapCounter clc = _other.GetComponent<CarLapCounter>();
				if (clc)
				{
						clc.OnReachCheckpoint(this);
				}
		}
}
