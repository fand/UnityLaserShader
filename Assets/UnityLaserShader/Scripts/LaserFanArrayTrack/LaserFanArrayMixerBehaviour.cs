using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class LaserFanArrayMixerBehaviour : PlayableBehaviour
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
        
        
        StylizedLaserArray trackBinding = playerData as StylizedLaserArray;

        if (!trackBinding)
            return;
        
        trackBinding.laserType = LaserType.Fan;
      
        int inputCount = playable.GetInputCount ();
        
        var laserBasicProps = new LaserBasicProps();
        var laserFanProps = new LaserFanProps();
        var laserTransform = new LaserTransform();
        
        laserBasicProps.InitializeAllWithZero();
        laserFanProps.InitializeAllWithZero();
        var currentInputs = new List<LaserFanArrayBehaviour>();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<LaserFanArrayBehaviour> inputPlayable = (ScriptPlayable<LaserFanArrayBehaviour>)playable.GetInput(i);
            LaserFanArrayBehaviour input = inputPlayable.GetBehaviour ();


          
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
