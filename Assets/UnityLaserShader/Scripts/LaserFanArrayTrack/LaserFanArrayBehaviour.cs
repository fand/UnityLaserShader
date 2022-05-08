using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LaserFanArrayBehaviour : PlayableBehaviour
{
    [SerializeField]public LaserTransform laserTransform = new LaserTransform();
    public float offsetPan = 0f;
    public float offsetTilt = 0f;
    public float offsetRotation = 0f;
    public LaserBasicProps laserBasicProps = new LaserBasicProps();
    public LaserFanProps laserFanProps = new LaserFanProps();

    public override void OnPlayableCreate (Playable playable)
    {
        
    }
    
    public void SetBasicValues()
    {
        laserBasicProps.InitializeBasicValues();
        laserBasicProps.InitializeBasicValues();
        laserFanProps.InitializeBasicValues();
        laserFanProps.InitializeBasicValues();
        laserTransform.SetBasicValues();
    }
}
