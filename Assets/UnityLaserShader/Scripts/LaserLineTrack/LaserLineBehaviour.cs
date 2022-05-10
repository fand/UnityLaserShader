using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LaserLineBehaviour : PlayableBehaviour
{

    // public Vector2 v;
    [SerializeField]public LaserTransform laserTransform = new LaserTransform();
    public LaserBasicProps laserBasicProps = new LaserBasicProps();
    public LaserLineArrayProps laserLineArrayProps = new LaserLineArrayProps();
    
    public override void OnPlayableCreate (Playable playable)
    {

        // SetBasicValues();
        // laserLineArrayProps
    }

    public void SetBasicValues()
    {
        laserBasicProps.InitializeBasicValues();
        
        laserLineArrayProps.InitializeBasicValues();
        
        laserTransform.SetBasicValues();
    }
}
