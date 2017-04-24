/// <summary>
/// Serializable class (for saving and loading) containing data to be saved before the game is turned off
/// </summary>
[System.Serializable]
public class SavedData
{
		/*
			* the unlocked levels (1 to 10)
			*/
		public byte unlockedLevels = 1;

		/*
			* music volume
			*/
		public float volume = 1.0f;
}
