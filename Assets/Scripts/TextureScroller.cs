using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to handle scrolling of textures
/// This is used for moving background to create a parallax effect
/// This technique offsets the texture offset of the main texture on the qued
/// rather than moving the actual quad
/// </summary>
public class TextureScroller : MonoBehaviour
{
		//The speed for scrolling
		public float scrollSpeed;

		//the start texture offset
		private Vector2 savedOffset;

		//The material which texture will be offset
		private Material material;

		/*
		 * Saves the current texture offset of the main texture 
			*/
		void Start()
		{
				material = GetComponent<Image>().material;
				savedOffset = material.GetTextureOffset("_MainTex");
		}

		/*
		 * Offsets the texture offset of the main texture to create a background scrolling effect
			* This works when the texture setting is set to repeat
			*/
		void Update()
		{
				float x = Mathf.Repeat(Time.time * scrollSpeed, 1.0f);
				Vector2 offset = new Vector2(x, savedOffset.y);
				material.SetTextureOffset("_MainTex", offset);
		}

		/*
		 * Reset the texture offset to what it originally was when the game object is being disabled
			*/
		void OnDisable()
		{
				//cannot use the private member material here, must get the component
				GetComponent<Image>().material.SetTextureOffset("_MainTex", savedOffset);
		}
}
