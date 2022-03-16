using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanTiltLaserGroup : MonoBehaviour
{
    public List<PanTiltLaser> panTiltLasers = new();

    public void SetLaserProps(LaserProps laserProps)
    {
        foreach (var ptl in panTiltLasers)
        {
            ptl.SetLaserProps(laserProps);
        }
    }

    public void SetPan(float pan)
    {
        foreach (var panTiltLaser in panTiltLasers)
        {
            panTiltLaser.SetPan(pan);
        }
    }

    public void SetTilt(float tilt)
    {
        foreach (var panTiltLaser in panTiltLasers)
        {
            panTiltLaser.SetTilt(tilt);
        }
    }
}
