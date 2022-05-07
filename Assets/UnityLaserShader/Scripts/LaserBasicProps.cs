using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LaserBasicProps
{
    
    [Header("--- Transform ----")]
    [SerializeField] public float rotation = 0f;
    [SerializeField] public Vector2 offsetCenter = new Vector2(0.5f, 0f);

    [Header("--- Color ---")]
    [ColorUsage(showAlpha: false, hdr: true)][SerializeField] public Color color = Color.green;
    [SerializeField, Range(0, 1)] public float opacity = 1f;
    [SerializeField, Range(0,1)] public float distanceFade;

    [Header("--- Update Mode ---")]
    [SerializeField] public bool useManualTime = false;
    [SerializeField] public float manualTime = 0f;
    
    [Header("--- Basic Style ---")]
    [SerializeField, Range(0, 90)] public float angle = 15f;
    [SerializeField, Range(0, 1)] public float flickering = 0f;
    [SerializeField, Range(0, 1)] public float width = 0.5f;
    [SerializeField, Range(0, 10)] public float sharpness = 0.1f;
    [SerializeField, Range(0, 1)] public float xBlur = 0.01f;
    [SerializeField, Range(0, 1)] public float splitWidth = 0f;
    [SerializeField, Range(0, 1)] public float splitMix = 0f;
    [SerializeField, Range(-360, 360)] public float arcMaskStart = -45f;
    [SerializeField, Range(-360, 360)] public float arcMaskEnd = 45f;
  
    [Header("--- Noise ---")]
    [SerializeField, Range(0, 100)] public float noiseSeed = 0f;
    [SerializeField, Range(0, 1)] public float noiseIntensity = 0f;
    [SerializeField, Range(0, 1000)] public float noiseScale = 1f;
    [SerializeField, Range(0, 1)] public float noiseSpeed = 0f;
    
    [Header("--- Strobe ---")]
    [SerializeField, Range(0, 60)] public float strobeSpeed = 0f;
    [SerializeField, Range(0, 1)] public float strobePWM = 0.5f;
    [SerializeField, Range(0, 1)] public float strobeTimeOffset = 0f;

    public LaserBasicProps()
    {
        Init();
        SetBasicValues();
    }

    public LaserBasicProps(LaserBasicProps laserBasicProps)
    {
        // transform
        rotation = laserBasicProps.rotation;
        offsetCenter = laserBasicProps.offsetCenter;
        
        // color
        color = laserBasicProps.color;
        opacity = laserBasicProps.opacity;
        distanceFade = laserBasicProps.distanceFade;
        
        // update mode
        useManualTime = laserBasicProps.useManualTime;
        manualTime = laserBasicProps.manualTime;
        
        // basic style
        angle = laserBasicProps.angle;
        flickering = laserBasicProps.flickering;
        width = laserBasicProps.width;
        sharpness = laserBasicProps.sharpness;
        xBlur = laserBasicProps.xBlur;
        splitWidth = laserBasicProps.splitWidth;
        splitMix = laserBasicProps.splitMix;
        arcMaskStart = laserBasicProps.arcMaskStart;
        arcMaskEnd = laserBasicProps.arcMaskEnd;
        
        // noise
        noiseSeed = laserBasicProps.noiseSeed;
        noiseIntensity = laserBasicProps.noiseIntensity;
        noiseScale = laserBasicProps.noiseScale;
        noiseSpeed = laserBasicProps.noiseSpeed;
        
        // strobe
        strobeSpeed = laserBasicProps.strobeSpeed;
        strobePWM =laserBasicProps.strobePWM;
        strobeTimeOffset = laserBasicProps.strobeTimeOffset;
    }
    
     public static LaserBasicProps operator +(LaserBasicProps a, LaserBasicProps b)
    {
        LaserBasicProps result = new LaserBasicProps(a);
        result.rotation += b.rotation;
        result.offsetCenter += b.offsetCenter;
        result.color += b.color;
        result.opacity += b.opacity;
        result.distanceFade += b.distanceFade;
        // result.useManualTime += b.useManualTime;
        result.manualTime += b.manualTime;
        result.angle += b.angle;
        result.flickering += b.flickering;
        result.width += b.width;
        result.sharpness += b.sharpness;
        result.xBlur += b.xBlur;
        result.splitWidth += b.splitWidth;
        result.splitMix += b.splitMix;
        result.arcMaskStart += b.arcMaskStart;
        result.arcMaskEnd +=b.arcMaskEnd;
        result.noiseSeed += b.noiseSeed;
        result.noiseIntensity += b.noiseIntensity;
        result.noiseScale += b.noiseScale;
        result.noiseSpeed += b.noiseSpeed;
        result.strobeSpeed += b.strobeSpeed;
        result.strobePWM += b.strobePWM;
        result.strobeTimeOffset += b.strobeTimeOffset;
        return result;
    }
    
    public static LaserBasicProps operator -(LaserBasicProps a, LaserBasicProps b)
    {
        LaserBasicProps result = new LaserBasicProps(a);
        result.rotation -= b.rotation;
        result.offsetCenter -= b.offsetCenter;
        result.color -= b.color;
        result.opacity -= b.opacity;
        result.distanceFade -= b.distanceFade;
        // result.useManualTime -= b.useManualTime;
        result.manualTime -= b.manualTime;
        result.angle -= b.angle;
        result.flickering -= b.flickering;
        result.width -= b.width;
        result.sharpness -= b.sharpness;
        result.xBlur -= b.xBlur;
        result.splitWidth -= b.splitWidth;
        result.splitMix -= b.splitMix;
        result.arcMaskStart -= b.arcMaskStart;
        result.arcMaskEnd -=b.arcMaskEnd;
        result.noiseSeed -= b.noiseSeed;
        result.noiseIntensity -= b.noiseIntensity;
        result.noiseScale -= b.noiseScale;
        result.noiseSpeed -= b.noiseSpeed;
        result.strobeSpeed -= b.strobeSpeed;
        result.strobePWM -= b.strobePWM;
        result.strobeTimeOffset -= b.strobeTimeOffset;
        return result;
    }
    
    
    public static LaserBasicProps operator *(LaserBasicProps a, LaserBasicProps b)
    {
        LaserBasicProps result = new LaserBasicProps(a);
        result.rotation *= b.rotation;
        result.offsetCenter *= b.offsetCenter;
        result.color *= b.color;
        result.opacity *= b.opacity;
        result.distanceFade *= b.distanceFade;
        // result.useManualTime *= b.useManualTime;
        result.manualTime *= b.manualTime;
        result.angle *= b.angle;
        result.flickering *= b.flickering;
        result.width *= b.width;
        result.sharpness *= b.sharpness;
        result.xBlur *= b.xBlur;
        result.splitWidth *= b.splitWidth;
        result.splitMix *= b.splitMix;
        result.arcMaskStart *= b.arcMaskStart;
        result.arcMaskEnd *=b.arcMaskEnd;
        result.noiseSeed *= b.noiseSeed;
        result.noiseIntensity *= b.noiseIntensity;
        result.noiseScale *= b.noiseScale;
        result.noiseSpeed *= b.noiseSpeed;
        result.strobeSpeed *= b.strobeSpeed;
        result.strobePWM *= b.strobePWM;
        result.strobeTimeOffset *= b.strobeTimeOffset;
        return result;
    }
    
    public static LaserBasicProps operator *(LaserBasicProps a, float b)
    {
        LaserBasicProps result = new LaserBasicProps(a);
        result.rotation *= b;
        result.offsetCenter *= b;
        result.color *= b;
        result.opacity *= b;
        result.distanceFade *= b;
        // result.useManualTime *= b.useManualTime;
        result.manualTime *= b;
        result.angle *= b;
        result.flickering *= b;
        result.width *= b;
        result.sharpness *= b;
        result.xBlur *= b;
        result.splitWidth *= b;
        result.splitMix *= b;
        result.arcMaskStart *= b;
        result.arcMaskEnd *=b;
        result.noiseSeed *= b;
        result.noiseIntensity *= b;
        result.noiseScale *= b;
        result.noiseSpeed *= b;
        result.strobeSpeed *= b;
        result.strobePWM *= b;
        result.strobeTimeOffset *= b;
        return result;
    }
    
    public void Init()
    {
        // transform
        rotation = 0f;
        offsetCenter = new Vector2(0f, 0);
        
        // color
        color = new Color(0, 0, 0, 0);
        opacity = 0f;
        distanceFade = 0f;
        
        // update mode
        useManualTime = false;
        manualTime = 0f;
        
        // basic style
        angle = 0f;
        flickering = 0f;
        width = 0f;
        sharpness = 0f;
        xBlur = 0f;
        splitWidth = 0f;
        splitMix = 0f;
        arcMaskStart = 0f;
        arcMaskEnd = 0f;
        
        
        // noise
        noiseSeed = 0f;
        noiseIntensity = 0f;
        noiseScale = 0;
        noiseSpeed = 0f;
        
        // strobe
        strobeSpeed = 0f;
        strobePWM = 0f;
        strobeTimeOffset = 0f;
    }

    public void SetBasicValues()
    {
        offsetCenter = new Vector2(0.5f, 0f);
        opacity = 1f;
        color = Color.red;
        distanceFade = 0.9f;
        angle = 45f;
        width = 0.1f;
        xBlur = 0.3f;
        sharpness = 3f;
        arcMaskStart = -45f;
        arcMaskEnd = 45f;
    }

}
