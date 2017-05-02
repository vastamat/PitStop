Shader "VCustom/PostProcessEff"
{
		Properties
		{
				_MainTex("Base (RGB)", 2D) = "white" {}
				_bwBlend("Black & White blend", Range(0, 1)) = 0
		}
				SubShader
		{
				// No culling or depth
				Cull Off ZWrite Off ZTest Always

				Pass
				{
					CGPROGRAM
					#pragma vertex vert
					#pragma fragment frag

					#include "UnityCG.cginc"

					struct appdata
					{
						float4 pos_modelSpace : POSITION;
						float2 uv : TEXCOORD0;
					};

					struct v2f
					{
						float2 uv : TEXCOORD0;
						float4 pos_clipSpace : SV_POSITION;
					};

					v2f vert(appdata _vertex)
					{
						v2f o;
						o.pos_clipSpace = mul(UNITY_MATRIX_MVP, _vertex.pos_modelSpace);
						o.uv = _vertex.uv;
						return o;
					}

					uniform sampler2D _MainTex;
					uniform float _bwBlend;

					float4 frag(v2f _input) : SV_Target
					{
							float4 col = tex2D(_MainTex, _input.uv);

							float lum = col.r * 0.3f + col.g * 0.59f + col.b * 0.11f;
							float3 bw = float3(lum, lum, lum);

							float4 result = col;
							result.rgb = lerp(col.rgb, bw, _bwBlend);
							return result;
				}
				ENDCG
			}
		}
}
