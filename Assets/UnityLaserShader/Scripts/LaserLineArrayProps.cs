using System;
using UnityEngine;

[Serializable]
public class LaserLineArrayProps:LaserPropElement
{
    
    [Header("--- Array ---")]
    [SerializeField, Range(0, 60)] public int arrayCount = 0;
    [SerializeField, Range(-10, 10)] public float arrayMoveSpeed = 0f;
    [SerializeField, Range(0, 1)] public float arrayMoveTimeOffset = 0f;
    [SerializeField, Range(0, 1)] public float arrayMoveAttack = 0f;
    [SerializeField, Range(0, 1)] public float arrayMoveHold = 0f;
    [SerializeField, Range(0, 1)] public float arrayMoveRelease = 0f;
    [SerializeField, Range(0, 1)] public float arrayRandomness = 0f;
    
    

    public LaserLineArrayProps(LaserLineArrayProps laserLineArrayProps)
    {
       
        
        // array
        arrayCount = laserLineArrayProps.arrayCount;
        arrayMoveSpeed = laserLineArrayProps.arrayMoveSpeed;
        arrayMoveTimeOffset = laserLineArrayProps.arrayMoveTimeOffset;
        arrayMoveAttack = laserLineArrayProps.arrayMoveAttack;
        arrayMoveHold = laserLineArrayProps.arrayMoveHold;
        arrayMoveRelease = laserLineArrayProps.arrayMoveRelease;
        arrayRandomness = laserLineArrayProps.arrayRandomness;
        
       
    }
    
    public static LaserLineArrayProps operator+ (LaserLineArrayProps a, LaserLineArrayProps b)
    {
        LaserLineArrayProps result = new LaserLineArrayProps(a);
        // result.useManualTime += b.useManualTime;
   
        result.arrayCount += b.arrayCount;
        result.arrayMoveSpeed += b.arrayMoveSpeed;
        result.arrayMoveTimeOffset += b.arrayMoveTimeOffset;
        result.arrayMoveAttack += b.arrayMoveAttack;
        result.arrayMoveHold += b.arrayMoveHold;
        result.arrayMoveRelease += b.arrayMoveRelease;
        result.arrayRandomness += b.arrayRandomness;
        return result;
    }
    
    public static LaserLineArrayProps operator- (LaserLineArrayProps a, LaserLineArrayProps b)
    {
        LaserLineArrayProps result = new LaserLineArrayProps(a);
        result.arrayCount -= b.arrayCount;
        result.arrayMoveSpeed -= b.arrayMoveSpeed;
        result.arrayMoveTimeOffset -= b.arrayMoveTimeOffset;
        result.arrayMoveAttack -= b.arrayMoveAttack;
        result.arrayMoveHold -= b.arrayMoveHold;
        result.arrayMoveRelease -= b.arrayMoveRelease;
        result.arrayRandomness -= b.arrayRandomness;
        return result;
    }
    
    
    public static LaserLineArrayProps operator* (LaserLineArrayProps a, LaserLineArrayProps b)
    {
        LaserLineArrayProps result = new LaserLineArrayProps(a);
        result.arrayCount *= b.arrayCount;
        result.arrayMoveSpeed *= b.arrayMoveSpeed;
        result.arrayMoveTimeOffset *= b.arrayMoveTimeOffset;
        result.arrayMoveAttack *= b.arrayMoveAttack;
        result.arrayMoveHold *= b.arrayMoveHold;
        result.arrayMoveRelease *= b.arrayMoveRelease;
        result.arrayRandomness *= b.arrayRandomness;
        return result;
    }
    
    public static LaserLineArrayProps operator* (LaserLineArrayProps a, float b)
    {
        LaserLineArrayProps result = new LaserLineArrayProps(a);
        result.arrayCount = (int)(result.arrayCount*b);
        result.arrayMoveSpeed *= b;
        result.arrayMoveTimeOffset *= b;
        result.arrayMoveAttack *= b;
        result.arrayMoveHold *= b;
        result.arrayMoveRelease *= b;
        result.arrayRandomness *= b;
        return result;
    }


    public override void InitializeAllWithZero()
    {

        // array
        arrayCount = 0;
        arrayMoveSpeed = 0f;
        arrayMoveTimeOffset = 0f;
        arrayMoveAttack = 0f;
        arrayMoveHold = 0f;
        arrayMoveRelease = 0f;
        arrayRandomness = 0f;
        
    }

    public LaserLineArrayProps(bool initializeAllWithZero = false)
    {
        InitializeAllWithZero();
        if(!initializeAllWithZero)InitializeBasicValues();
        
    }

    public override void InitializeBasicValues()
    {
        arrayCount = 6;
        arrayMoveSpeed = 1f;
        arrayMoveHold = 0.5f;
    
    }

    // public void InitProperty()
    // {
    //     
    // }
}
