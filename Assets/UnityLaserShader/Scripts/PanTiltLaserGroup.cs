using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class LaserColor
{
    [ColorUsage(showAlpha: false, hdr: true)][SerializeField] public Color color;
    [ColorUsage(showAlpha: false, hdr: true)][SerializeField] public Color fogColor;
}
public class PanTiltLaserGroup : MonoBehaviour
{
    public List<PanTiltLaser> panTiltLasers = new();
    public List<LaserColor> laserColors = new List<LaserColor>();
    public float panStep = 0f;
    public float tiltStep = 0f;
    public float rotationStep = 0f;
    private LaserProps laserProps = new LaserProps();
    public void SetLaserProps(LaserProps laserProps, List<LaserColor> laserColors)
    {
        this.laserProps = laserProps;
        this.laserColors = laserColors;
        
    }

    public void ApplyValues()
    {
        var i = 0;
        var count = 0;
        foreach (var ptl in panTiltLasers)
        {
            i = (i + 1) % laserColors.Count;
            var laserColor = laserColors[i];
            var p = new LaserProps(laserProps);
            
            p.rotation += rotationStep * count;
            p.color = laserColor.color;
            p.fogColor = laserColor.fogColor;
            
            ptl.SetLaserProps(p);

            count++;
        }
    }
    
    

    public void SetPan(float pan)
    {
        var i = 0;
        foreach (var panTiltLaser in panTiltLasers)
        {
            panTiltLaser.SetPan(pan+i*panStep);
            i++;
        }
    }

    public void SetTilt(float tilt)
    {
        var i = 0;
        foreach (var panTiltLaser in panTiltLasers)
        {
            panTiltLaser.SetTilt(tilt+i*tiltStep);
            i++;
        }
    }
}
