using UnityEngine;

/// <summary>
/// Base class for the car controls
/// Derived classes should handle inputs and use the functions to move
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Car2DController : MonoBehaviour
{
		private float m_speed = 35.0f;
		private float m_driftFactorSticky = 0.9f;
		private float m_driftFactorSlippy = 1;
		private float m_maxStickyVelocity = 2.5f;
		private float m_minSlippyVelocity = 1.5f;

		private Rigidbody2D m_rb;
		private Transform m_frontLeftWheel;
		private Transform m_frontRightWheel;

		void Start()
		{
				m_frontLeftWheel = transform.Find("FrontLeftWheel");
				m_frontRightWheel = transform.Find("FrontRightWheel");
				if (m_frontLeftWheel == null || m_frontRightWheel == null)
				{
						Debug.Log("Cannot find the wheels!");
				}
				m_rb = GetComponent<Rigidbody2D>();
		}

		void FixedUpdate()
		{
				float driftFactor = m_driftFactorSticky;
				if (RightVelocity().magnitude > m_maxStickyVelocity)
				{
						driftFactor = m_driftFactorSlippy;
				}

				m_rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;
		}

		protected void Accelerate()
		{
				m_rb.AddForceAtPosition(m_frontLeftWheel.up  * m_speed, m_frontLeftWheel.position);
				m_rb.AddForceAtPosition(m_frontRightWheel.up * m_speed, m_frontRightWheel.position);
		}
		protected void Brake()
		{
				m_rb.AddForceAtPosition(m_frontLeftWheel.up  * -m_speed / 2f, m_frontLeftWheel.position);
				m_rb.AddForceAtPosition(m_frontRightWheel.up * -m_speed / 2f, m_frontRightWheel.position);
		}
		protected void Steer(float _amount)
		{
				float torqueForce = ForwardVelocity().magnitude / 10.0f;

				m_rb.AddForceAtPosition(m_frontLeftWheel.right  * torqueForce * _amount, m_frontLeftWheel.position);
				m_rb.AddForceAtPosition(m_frontRightWheel.right * torqueForce * _amount, m_frontRightWheel.position);
		}

		Vector2 ForwardVelocity()
		{
				return transform.up * Vector2.Dot(m_rb.velocity, transform.up);
		}

		Vector2 RightVelocity()
		{
				return transform.right * Vector2.Dot(m_rb.velocity, transform.right);
		}
}
