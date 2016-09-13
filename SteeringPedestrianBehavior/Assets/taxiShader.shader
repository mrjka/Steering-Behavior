Shader "Custom/taxi" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_CubeMap ("Taxt CubeMap", CUBE) = "" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		samplerCUBE _CubeMap;

		struct Input {
			float2 uv_MainTex;
			float3 worldRefl;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			float3 CubeColor = texCUBE(_CubeMap, IN.worldRefl);
			//float3 reflectVector = IN.worldRefl;
			
			float3 aC = c.rgb;
			float3 rC = float3(0.2,0.2,0.2);
			
			float total = aC.x + aC.y + aC.z;
			float refVal = 12.0;
			
			float percentVal = total/refVal;
			
			CubeColor.x = CubeColor.x*percentVal;
			CubeColor.y = CubeColor.y*percentVal;
			CubeColor.z = CubeColor.z*percentVal;
			
			o.Emission = CubeColor;
			
			o.Albedo = c.rgb*0.6;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
