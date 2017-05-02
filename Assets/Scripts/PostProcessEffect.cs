using UnityEngine;

/// <summary>
/// Post process script for the camera gameobject
/// </summary>
[ExecuteInEditMode]
public class PostProcessEffect : MonoBehaviour
{
		[Range(0.0f, 1.0f)]
		public float m_intensity;
		private Material m_material;
		void Awake()
		{
				m_material = new Material(Shader.Find("VCustom/PostProcessEff"));
		}

		void OnRenderImage(RenderTexture _source, RenderTexture _destination)
		{
				if (m_intensity == 0)
				{
						Graphics.Blit(_source, _destination);
						return;
				}

				m_material.SetFloat("_bwBlend", m_intensity);
				Graphics.Blit(_source, _destination, m_material);
		}
}
