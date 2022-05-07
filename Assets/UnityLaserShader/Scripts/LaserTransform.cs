using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LaserTransform
{
    // Start is called before the first frame update
    public float pan = 0f;
    public float tilt = 0f;
    public Vector2 size = Vector2.one;

    public LaserTransform(LaserTransform laserTransform)
    {
        // transform
        pan = laserTransform.pan;
        tilt = laserTransform.tilt;
        size = laserTransform.size;
    }
    public LaserTransform()
    {
        pan = 0f;
        tilt = 0f;
        size = Vector2.one;
        
    }

    public void SetBasicValues()
    {
        pan = 0f;
        tilt = 0f;
        size = Vector2.one;

    }

    public static LaserTransform operator +(LaserTransform a, LaserTransform b)
    {
        LaserTransform c = new LaserTransform(a);
        c.pan += b.pan;
        c.tilt += b.tilt;
        c.size += b.size;
        return c;
    }

    public static LaserTransform operator -(LaserTransform a, LaserTransform b)
    {
        LaserTransform c = new LaserTransform(a);
        c.pan -= b.pan;
        c.tilt -= b.tilt;
        c.size -= b.size;
        return c;
    }

    public static LaserTransform operator *(LaserTransform a, LaserTransform b)
    {
        LaserTransform c = new LaserTransform(a);
        c.pan *= b.pan;
        c.tilt *= b.tilt;
        c.size *= b.size;
        return c;
    }

    public static LaserTransform operator *(LaserTransform a, float b)
    {
        LaserTransform c = new LaserTransform(a);
        c.pan *= b;
        c.tilt *= b;
        c.size *= b;
        return c;
    }
    
    public static LaserTransform operator /(LaserTransform a, LaserTransform b)
    {
        LaserTransform c = new LaserTransform(a);
        c.pan /= b.pan;
        c.tilt /= b.tilt;
        c.size /= b.size;
        return c;
    }
    
    public static LaserTransform operator /(LaserTransform a, float b)
    {
        LaserTransform c = new LaserTransform(a);
        c.pan /= b;
        c.tilt /= b;
        c.size /= b;
        return c;
    }
    
    public static LaserTransform operator -(LaserTransform a)
    {
        LaserTransform c = new LaserTransform(a);
        c.pan = -c.pan;
        c.tilt = -c.tilt;
        c.size = -c.size;
        return c;
    }
    
    // public static LaserTransform operator +(LaserTransform a)
    // {
    //     LaserTransform c = new LaserTransform(a);
    //     c.pan = +c.pan;
    //     c.tilt = +c.tilt;
    //     c.size = +c.size;
    //     return c;
    // }

    public void InitEmptyValues()
    {
        pan = 0f;
        tilt = 0f;
        size = Vector2.one;
    }
}
