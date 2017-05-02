using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
		//Array of audio clips to play/switch through
		public AudioClip[] m_clips;
		//The audio source in this game object
		private AudioSource m_source;


		void Start()
		{
				// Set the volume of the audio listener to the saved volume data
				//AudioListener.volume = GlobalControl.m_instance.m_savedData.volume;

				//Get the audio source
				m_source = GetComponent<AudioSource>();

				//Set the audio clip
				m_source.clip = m_clips[Random.Range(0, m_clips.Length)];

				//Play the music
				m_source.Play();
		}
}
