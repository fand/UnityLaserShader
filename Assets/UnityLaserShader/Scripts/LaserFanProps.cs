using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LaserFanProps : LaserPropElement
{
   
    [Header("--- Fan ---")]
    [ColorUsage(showAlpha: true, hdr: true)][SerializeField] public Color fogColor = Color.green;
    [SerializeField, Range(0, 10)] public float centerBloom = 0f;
    [SerializeField, Range(0, 1)] public float centerBloomSize = 0f;
    [SerializeField] public Vector2 fogNoiseScale = Vector2.one;
    [SerializeField] public Vector2 fogNoiseSpeed = Vector2.one;
    

    public LaserFanProps(LaserFanProps laserFanProps)
    {
       
        fogColor = laserFanProps.fogColor;
        centerBloom = laserFanProps.centerBloom;
        centerBloomSize = laserFanProps.centerBloomSize;
        fogNoiseScale = laserFanProps.fogNoiseScale;
        fogNoiseSpeed = laserFanProps.fogNoiseSpeed;
    
        
       
    }
    
    public static LaserFanProps operator+ (LaserFanProps a, LaserFanProps b)
    {
        LaserFanProps result = new LaserFanProps(a);
        result.fogColor += b.fogColor;
        result.centerBloom += b.centerBloom;
        result.centerBloomSize += b.centerBloomSize;
        result.fogNoiseScale += b.fogNoiseScale;
        result.fogNoiseSpeed += b.fogNoiseSpeed;
        
        return result;
    }
    
    public static LaserFanProps operator- (LaserFanProps a, LaserFanProps b)
    {
        LaserFanProps result = new LaserFanProps(a);
        result.fogColor -= b.fogColor;
        result.centerBloom -= b.centerBloom;
        result.centerBloomSize -= b.centerBloomSize;
        result.fogNoiseScale -= b.fogNoiseScale;
        result.fogNoiseSpeed -= b.fogNoiseSpeed;
        
        return result;
    }


    public static LaserFanProps operator *(LaserFanProps a, LaserFanProps b)
    {
        LaserFanProps result = new LaserFanProps(a);
        result.fogColor *= b.fogColor;
        result.centerBloom *= b.centerBloom;
        result.centerBloomSize *= b.centerBloomSize;
        result.fogNoiseScale *= b.fogNoiseScale;
        result.fogNoiseSpeed *= b.fogNoiseSpeed;
        return result;
    }

    public static LaserFanProps operator* (LaserFanProps a, float b)
    {
        LaserFanProps result = new LaserFanProps(a);
        result.fogColor *= b;
        result.centerBloom *= b;
        result.centerBloomSize *= b;
        result.fogNoiseScale *= b;
        result.fogNoiseSpeed *= b;
        return result;
    }
    
    public override void InitializeAllWithZero()
    {
        fogColor = new Color(0,0,0,0); // default      
        centerBloom = 0f;
        centerBloomSize = 0f;
        fogNoiseScale = Vector2.zero;
        fogNoiseSpeed = Vector2.zero;
        
    }

    public LaserFanProps(bool allValueZero = false)
    {
        InitializeAllWithZero();
        if(!allValueZero)InitializeBasicValues();
        
    }

    public override void InitializeBasicValues()
    {
        fogColor = Color.green;   
        centerBloom = 0f;
        centerBloomSize = 1f;
        fogNoiseScale = Vector2.one;
        fogNoiseSpeed = Vector2.one;
    
    }

}
