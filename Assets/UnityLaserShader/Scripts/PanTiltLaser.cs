using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanTiltLaser : MonoBehaviour
{
    [SerializeField] private Transform pan;
    [SerializeField] private Transform tilt;
    [SerializeField] private LaserQuad laser;

    public void SetLaserProps(LaserProps laserProps)
    {
        laser.laserProps = laserProps;
    }

    public LaserQuad laserQuad => laser;

    public void SetPan(float pan)
    {
        this.pan.localEulerAngles = Vector3.up * pan;
    }

    public void SetTilt(float tilt)
    {
        this.tilt.localEulerAngles = Vector3.left * tilt;
    }
}
