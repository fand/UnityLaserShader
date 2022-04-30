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
    // public List<PanTiltLaserGroup> panTiltLaserGroups = new();
    public List<OffsetPTLChildProp> OffsetPtlChildProps = new List<OffsetPTLChildProp>();
    public float panStep = 0f;
    public float tiltStep = 0f;
    public float rotationStep = 0f;
    private LaserProps laserProps = new LaserProps();

    public List<PanTiltLaserGroup> synchronizationGroups = new();
    public void SetLaserProps(LaserProps laserProps, List<OffsetPTLChildProp> OffsetPtlChildProps)
    {
        this.laserProps = laserProps;
        this.OffsetPtlChildProps = OffsetPtlChildProps;
        
    }
    
    [ContextMenu("Search Child")]
    private void SearchChild()
    {
        if (panTiltLasers == null) panTiltLasers = new List<PanTiltLaser>();
        panTiltLasers.Clear();
        foreach (Transform t in transform)
        {
            var ptl = t.gameObject.GetComponent<PanTiltLaser>();
            if (ptl != null)
            {
                panTiltLasers.Add(ptl);
            }
        }
    }

    public int LaserCount
    {
        get
        {
            return panTiltLasers.Count;
        }
    }

    public void ForceDisableLasers()
    {
        foreach (var laser in panTiltLasers)
        {
           laser.gameObject.SetActive(false);
        }
    }
    
    public void ForceEnableLasers()
    {
        foreach (var laser in panTiltLasers)
        {
            laser.gameObject.SetActive(true);
        }
    }

    public void ApplyValues()
    {
        // var i = 0;
        var count = 0;
        foreach (var ptl in panTiltLasers)
        {
            // i = (i + 1) % OffsetPtlChildProps.Count;
            var offset = OffsetPtlChildProps[count];
            var p = new LaserProps(laserProps);
            p.rotation += (rotationStep * count+offset.rotation);
            p.color = offset.color;
            p.fogColor = offset.fogColor;
         
            
            ptl.SetLaserProps(p);

            count++;
        }

        foreach (var group in synchronizationGroups)
        {
            count = 0;
            foreach (var ptl in group.panTiltLasers)
            {
                // i = (i + 1) % OffsetPtlChildProps.Count;
                var offset = OffsetPtlChildProps[count];
                var p = new LaserProps(laserProps);
                p.rotation += (rotationStep * count+offset.rotation);
                p.color = offset.color;
                p.fogColor = offset.fogColor;
         
            
                ptl.SetLaserProps(p);

                count++;
            }
        }

        // foreach (var ptlGroup in panTiltLaserGroups)
        // {
        //     count = 0;
        //     foreach (var ptl in ptlGroup.panTiltLasers)
        //     {
        //         // i = (i + 1) % OffsetPtlChildProps.Count;
        //         var offset = OffsetPtlChildProps[count];
        //         var p = new LaserProps(laserProps);
        //         p.rotation += (rotationStep * count+offset.rotation);
        //         p.color = offset.color;
        //         p.fogColor = offset.fogColor;
        //  
        //     
        //         ptl.SetLaserProps(p);
        //
        //         count++;
        //     }
        // }
    }
    
    

    public void SetPanTilt(float pan,float tilt)
    {
        var i = 0;
        foreach (var panTiltLaser in panTiltLasers)
        {
            panTiltLaser.SetTilt(tilt+i*tiltStep+OffsetPtlChildProps[i].tilt);
            panTiltLaser.SetPan(pan+i*panStep+OffsetPtlChildProps[i].pan);
            i++;
        }

        foreach (var group in synchronizationGroups)
        {
            i = 0;
            foreach (var panTiltLaser in group.panTiltLasers)
            {
                panTiltLaser.SetTilt(tilt+i*tiltStep+OffsetPtlChildProps[i].tilt);
                panTiltLaser.SetPan(pan+i*panStep+OffsetPtlChildProps[i].pan);
                i++;
            }
        }
    }

    // public void SetTilt(float tilt)
    // {
    //     var i = 0;
    //     foreach (var panTiltLaser in panTiltLasers)
    //     {
    //         panTiltLaser.SetTilt(tilt+i*tiltStep);
    //         i++;
    //     }
    // }
}
