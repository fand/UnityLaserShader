using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LaserFanBehaviour : PlayableBehaviour
{
    [SerializeField]public LaserTransform laserTransform = new LaserTransform();
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
