using UnityEngine;

/// <summary>
/// Collision handling  when a car hits the race track colliders
/// </summary>
public class RaceTrackCollision : MonoBehaviour
{
		void OnCollisionEnter2D(Collision2D coll)
		{
				if (coll.gameObject.CompareTag("Player"))
				{
						Camera.main.GetComponent<PostProcessEffect>().m_intensity = Mathf.Lerp(0.0f, 1.0f, 0.2f * Time.deltaTime);
				}
				//Rigidbody2D carRB = coll.gameObject.GetComponent<Rigidbody2D>();
				//carRB.AddForce(coll.relativeVelocity, ForceMode2D.Impulse);
		}
		void OnCollisionStay2D(Collision2D coll)
		{
				if (coll.gameObject.CompareTag("Player"))
				{
						Camera.main.GetComponent<PostProcessEffect>().m_intensity = Mathf.Lerp(0.0f, 1.0f, 0.2f * Time.deltaTime);
				}
				//Rigidbody2D carRB = coll.gameObject.GetComponent<Rigidbody2D>();
				//carRB.AddForce(coll.relativeVelocity);
		}
		void OnCollisionExit2D(Collision2D coll)
		{
				if (coll.gameObject.CompareTag("Player"))
				{
						Camera.main.GetComponent<PostProcessEffect>().m_intensity = Mathf.Lerp(1.0f, 0.0f, 0.2f * Time.deltaTime);
				}
				//Rigidbody2D carRB = coll.gameObject.GetComponent<Rigidbody2D>();
				//carRB.AddForce(coll.relativeVelocity);
		}
}
