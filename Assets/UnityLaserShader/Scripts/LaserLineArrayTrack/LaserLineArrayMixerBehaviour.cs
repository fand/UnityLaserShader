using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class LaserLineArrayMixerBehaviour : PlayableBehaviour
{
    
    private PlayableDirector _director;
    public PlayableDirector director
    {
        get { return _director; }
        set { _director = value; }
    }
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        StylizedLaser trackBinding = playerData as StylizedLaser;

        if (!trackBinding)
            return;

        trackBinding.laserType = LaserType.LaserLineArray;
        trackBinding.manualTime = (float)director.time;
        int inputCount = playable.GetInputCount ();

        // bool hasClip = false;
        LaserBasicProps laserBasicProps = new LaserBasicProps();
        LaserLineArrayProps laserLineArrayProps = new LaserLineArrayProps();
        LaserTransform laserTransform = new LaserTransform();
        
        laserBasicProps.Init();
        laserLineArrayProps.Init();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<LaserLineArrayBehaviour> inputPlayable = (ScriptPlayable<LaserLineArrayBehaviour>)playable.GetInput(i);
            LaserLineArrayBehaviour input = inputPlayable.GetBehaviour ();


          
            if (inputWeight > 0.0f)
            {
                Debug.Log(i);
                laserBasicProps += input.laserBasicProps * inputWeight;
                laserLineArrayProps += input.laserLineArrayProps * inputWeight;
                laserTransform += input.laserTransform * inputWeight;
                // hasClip = true;
            }
            
           
            // trackBinding.SetLineArrayProps(laserLineArrayProps);
            // Use the above variables to process each frame of this playable.
            
        }
        
        // if (hasClip)
        // {
            laserBasicProps.useManualTime = true;
            Debug.Log(laserBasicProps.color);
            trackBinding.laserTransform = laserTransform;
            trackBinding.SetLaserProps(laserBasicProps,laserLineArrayProps);
            // }
    }
}
