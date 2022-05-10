using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LaserLineArrayBehaviour : PlayableBehaviour
{
    
    [Header("--- Base Settings ---")]
    public LaserTransform laserTransform = new LaserTransform();
    public LaserBasicProps laserBasicProps = new LaserBasicProps();
    public LaserLineArrayProps laserLinArrayProps = new LaserLineArrayProps();

    [Header("--- Stagger Settings ---")]
    [ColorUsage(showAlpha: false, hdr: true)]public List<Color> lineColors = new List<Color>(){Color.white};
    [ColorUsage(showAlpha: true, hdr: true)]public List<Color> fogColors = new List<Color>(){Color.white};

    public LaserTransform staggerLaserTransform = new LaserTransform(){pan = 0f,tilt=0f,size = Vector2.zero};
    public LaserBasicProps staggerLaserBasicProps = new LaserBasicProps(true);
    public LaserLineArrayProps staggerLaserLinArrayProps = new LaserLineArrayProps(true);

    public override void OnPlayableCreate (Playable playable)
    {
        
    }
    
    public void SetBasicValues()
    {
        laserBasicProps.InitializeBasicValues();
        laserBasicProps.InitializeBasicValues();
        laserLinArrayProps.InitializeBasicValues();
        laserLinArrayProps.InitializeBasicValues();
        laserTransform.SetBasicValues();
    }
}
