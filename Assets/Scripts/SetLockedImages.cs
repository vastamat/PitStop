using UnityEngine;
using UnityEngine.UI;

public class SetLockedImages : MonoBehaviour
{
		public Sprite m_lockImage;

		// The array of images of the levels
		private Image[] m_levelsImages;

		// Use this for initialization
		void Start()
		{
				// Get all the images
				m_levelsImages = GetComponentsInChildren<Image>();

				// Change all the unlocked levels to their unlocked sprite
				for (int i = GlobalControl.m_instance.m_savedData.unlockedLevels; i < m_levelsImages.Length; i++)
				{
						m_levelsImages[i].sprite = m_lockImage;
				}
		}
}
