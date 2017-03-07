Shader "Custom/Blink" {
  Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Blink ( "Blink", Float ) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float _Blink;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex );
			if( _Blink == 1.0f ) 
				c *=  ( 0.5f + abs( sin( _Time.w ) ) );
			o.Albedo	= c.rgb;
			o.Alpha		= c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}