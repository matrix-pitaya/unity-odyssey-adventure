Shader "Custom/StaticBlurCube" 
{
    Properties 
    {
        _BlurSize ("Blur Size", Range(0, 2)) = 0.1
        _BlurIntensity ("Blur Intensity", Range(0, 1)) = 0.5
    }
    SubShader 
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        
        Pass 
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target 
            {
                return fixed4(1,1,1,1);
            }
            ENDCG
        }

        Pass 
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata 
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f 
            {
                float4 pos : SV_POSITION;
                float3 localPos : TEXCOORD0;
            };

            float _BlurSize;
            float _BlurIntensity;

            v2f vert (appdata v) 
            {
                v2f o;
                float3 expanded = v.vertex.xyz + v.normal * _BlurSize;
                o.pos = UnityObjectToClipPos(float4(expanded, 1));
                o.localPos = v.vertex.xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target 
            {
                float3 absPos = abs(i.localPos);
                float3 edgeDist = float3(0.5, 0.5, 0.5) - absPos;
                float minEdge = min(min(edgeDist.x, edgeDist.y), edgeDist.z);
                
                float alpha = smoothstep(0, _BlurSize * 2, minEdge);
                alpha = lerp(1, alpha, _BlurIntensity);
                
                return fixed4(1, 1, 1, (1 - alpha) * 0.7);
            }
            ENDCG
        }
    }
}