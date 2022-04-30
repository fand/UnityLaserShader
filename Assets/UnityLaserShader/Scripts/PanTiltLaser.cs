using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanTiltLaser : MonoBehaviour
{
    [SerializeField] private Transform pan;
    [SerializeField] private Transform tilt;
    [SerializeField] private LaserQuad laser;

    [SerializeField] private List<PanTiltLaser> child;
    public void SetLaserProps(LaserProps laserProps)
    {
        if (laser != null)
        {
            laser.laserProps = laserProps;     
        }

        if (child != null)
        {
            foreach (PanTiltLaser ptl in child)
            {
                ptl.SetLaserProps(laserProps);
            }
        }

    }

    [ContextMenu("Search Child")]
    private void SearchChild()
    {
        if (child == null) child = new List<PanTiltLaser>();
        child.Clear();
        foreach (Transform t in transform)
        {
            var ptl = t.gameObject.GetComponent<PanTiltLaser>();
            if (ptl != null)
            {
                child.Add(ptl);
            }
        }
    }

    public LaserQuad laserQuad => laser;

    public void SetPan(float pan)
    {
        if (this.pan != null)
        {
            this.pan.localEulerAngles = Vector3.up * pan;
        }

        if (child != null)
        {
            foreach (PanTiltLaser ptl in child)
            {
                ptl.SetPan(pan);
            }
        }
    }

    public void SetTilt(float tilt)
    {
        if (this.tilt != null)
        {
            this.tilt.localEulerAngles = Vector3.left * tilt;
        }
        
        if(child != null)
        {
            foreach (PanTiltLaser ptl in child)
            {
                ptl.SetTilt(tilt);
            }
        }
    }
}
