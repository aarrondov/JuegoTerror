Shader "Custom/SecurityCameraEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PixelSize ("Pixel Size", Range(1, 20)) = 10
        _Brightness ("Brightness", Range(0, 2)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _PixelSize;
            float _Brightness;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Aplicar efecto de pixelado
                float2 pixelUV = i.uv * _PixelSize;
                pixelUV = floor(pixelUV) / _PixelSize;
                fixed4 color = tex2D(_MainTex, pixelUV);

                // Ajustar brillo
                color.rgb *= _Brightness;

                return color;
            }
            ENDCG
        }
    }
}
