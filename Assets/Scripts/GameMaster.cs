using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
		public AIController[] m_AICars;
		public PlayerController m_playerCar;
		public Sprite[] m_lightsSprites;
		public Animator m_endAnim;
		public Text m_elapsedTime;

		public float m_lightsDelay = 0.5f;
		private float m_counter = 0.0f;
		private int m_spriteIndex = 0;
		private SpriteRenderer m_sr;
		private bool m_start = false;

		void Awake()
		{
				foreach (AIController aiCar in m_AICars)
				{
						aiCar.enabled = false;
				}
				m_playerCar.enabled = false;

				m_sr = GetComponent<SpriteRenderer>();
		}

		void Update()
		{
				if (!m_start)
				{
						if (m_spriteIndex == m_lightsSprites.Length)
						{
								m_start = true;

								foreach (AIController aiCar in m_AICars)
								{
										aiCar.enabled = true;
								}
								m_playerCar.enabled = true;

								m_sr.enabled = false;
						}
						else
						{
								m_counter += Time.deltaTime;

								if (m_counter >= m_lightsDelay)
								{
										m_counter = 0.0f;
										m_sr.sprite = m_lightsSprites[m_spriteIndex++];
								}
						}
				}
				else
				{
						m_counter += Time.deltaTime;
						if (m_playerCar.enabled == false)
						{
								OnPlayerFinished();
						}
				}
		}

	 void OnPlayerFinished()
		{
				m_elapsedTime.text = m_counter.ToString();
				m_endAnim.SetTrigger("Finished");

				bool isPlayerFirst = true;
				foreach (AIController aiCar in m_AICars)
				{
						if (aiCar.enabled == false)
						{
								isPlayerFirst = false;
						}
				}
				if (isPlayerFirst)
				{
						switch (SceneManager.GetActiveScene().name)
						{
								case "Level1":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 2)
										{
										GlobalControl.m_instance.m_savedData.unlockedLevels = 2;
										}
										break;
								case "Level2":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 3)
										{
												GlobalControl.m_instance.m_savedData.unlockedLevels = 3;
										}
										break;
								case "Level3":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 4)
										{
												GlobalControl.m_instance.m_savedData.unlockedLevels = 4;
										}
										break;
								case "Level4":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 5)
										{
												GlobalControl.m_instance.m_savedData.unlockedLevels = 5;
										}
										break;
								case "Level5":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 6)
										{
												GlobalControl.m_instance.m_savedData.unlockedLevels = 6;
										}
										break;
								case "Level6":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 7)
										{
												GlobalControl.m_instance.m_savedData.unlockedLevels = 7;
										}
										break;
								case "Level7":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 8)
										{
												GlobalControl.m_instance.m_savedData.unlockedLevels = 8;
										}
										break;
								case "Level8":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 9)
										{
												GlobalControl.m_instance.m_savedData.unlockedLevels = 9;
										}
										break;
								case "Level9":
										if (GlobalControl.m_instance.m_savedData.unlockedLevels < 10)
										{
												GlobalControl.m_instance.m_savedData.unlockedLevels = 10;
										}
										break;
								default: break;
						}
				}
				GlobalControl.m_instance.SaveData();
				gameObject.SetActive(false);
		}
}
