﻿Shader "Custom/Glow"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Emission ("Emission", 2D) = "white" {}
        _EmissionColor ("Color", Color) = (0.000000,0.000000,0.000000,1.000000)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        //Cull Off
       // ZWrite On
       // Blend SrcAlpha OneMinusSrcAlpha

    
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _Emission;

        struct Input
        {
            float2 uv_MainTex;   
           // float2 uv_EmissionTex;         
            float3 viewDir;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb; 

            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));

            fixed4 e = tex2D (_Emission, IN.uv_MainTex) * _Color;

           // _Color *= e.rgba;
            o.Emission = e.rgb * _EmissionColor * pow(rim,0.1);

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;          
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
