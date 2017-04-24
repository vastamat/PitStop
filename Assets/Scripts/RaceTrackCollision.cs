using UnityEngine;

/// <summary>
/// Collision handling  when a car hits the race track colliders
/// </summary>
public class RaceTrackCollision : MonoBehaviour
{
		void OnCollisionEnter2D(Collision2D coll)
		{
				Rigidbody2D carRB = coll.gameObject.GetComponent<Rigidbody2D>();
				carRB.AddForce(coll.relativeVelocity, ForceMode2D.Impulse);
		}
		void OnCollisionStay2D(Collision2D coll)
		{
				Rigidbody2D carRB = coll.gameObject.GetComponent<Rigidbody2D>();
				carRB.AddForce(coll.relativeVelocity);
		}
}
