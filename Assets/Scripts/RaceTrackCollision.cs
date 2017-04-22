using UnityEngine;

public class RaceTrackCollision : MonoBehaviour
{
		void OnCollisionEnter2D(Collision2D coll)
		{
				Debug.Log("Collision Enter");
				Rigidbody2D carRB = coll.gameObject.GetComponent<Rigidbody2D>();
				carRB.AddForce(coll.relativeVelocity, ForceMode2D.Impulse);
		}
		void OnCollisionStay2D(Collision2D coll)
		{
				Debug.Log("Collision Stay");
				Rigidbody2D carRB = coll.gameObject.GetComponent<Rigidbody2D>();
				carRB.AddForce(coll.relativeVelocity);
		}
}
