using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class LaserFanMixerBehaviour : PlayableBehaviour
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
        
        trackBinding.laserType = LaserType.Fan;
      
        int inputCount = playable.GetInputCount ();
        
        var laserBasicProps = new LaserBasicProps();
        var laserFanProps = new LaserFanProps();
        var laserTransform = new LaserTransform();
        
        laserBasicProps.InitializeAllWithZero();
        laserFanProps.InitializeAllWithZero();
        var currentInputs = new List<LaserFanBehaviour>();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<LaserFanBehaviour> inputPlayable = (ScriptPlayable<LaserFanBehaviour>)playable.GetInput(i);
            LaserFanBehaviour input = inputPlayable.GetBehaviour ();


          
            if (inputWeight > 0.0f)
            {
                // Debug.Log(i);
                // Debug.Log(input.laserFanProps.fogColor);
                laserBasicProps += input.laserBasicProps * inputWeight;
                laserFanProps += input.laserFanProps * inputWeight;
                laserTransform += input.laserTransform * inputWeight;
                currentInputs.Add(input);
                // hasClip = true;
            }
            
           
            // trackBinding.SetLineArrayProps(laserFanProps);
            // Use the above variables to process each frame of this playable.
            
        }

        
        laserBasicProps.useManualTime = true;
        laserBasicProps.manualTime = (float)director.time;
        trackBinding.SetLaserTransform(laserTransform);
        trackBinding.SetBasicProps(laserBasicProps);
        trackBinding.SetFanProps(laserFanProps);

    }
}
