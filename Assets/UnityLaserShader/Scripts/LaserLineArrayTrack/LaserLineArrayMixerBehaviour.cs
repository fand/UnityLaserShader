using System;
using System.Collections.Generic;
using System.Linq;
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

        trackBinding.laserType = LaserType.LineArray;
        int inputCount = playable.GetInputCount ();

        // bool hasClip = false;
        LaserBasicProps laserBasicProps = new LaserBasicProps();
        LaserLineArrayProps laserLineArrayProps = new LaserLineArrayProps();
        LaserTransform laserTransform = new LaserTransform();
        
        laserBasicProps.InitializeAllWithZero();
        laserLineArrayProps.InitializeAllWithZero();
        var currentInputs = new List<LaserLineArrayBehaviour>();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<LaserLineArrayBehaviour> inputPlayable = (ScriptPlayable<LaserLineArrayBehaviour>)playable.GetInput(i);
            LaserLineArrayBehaviour input = inputPlayable.GetBehaviour ();


          
            if (inputWeight > 0.0f)
            {
                // Debug.Log(i);
                laserBasicProps += input.laserBasicProps * inputWeight;
                laserLineArrayProps += input.laserLineArrayProps * inputWeight;
                laserTransform += input.laserTransform * inputWeight;
                currentInputs.Add(input);
                // hasClip = true;
            }
            
           
            // trackBinding.SetLineArrayProps(laserLineArrayProps);
            // Use the above variables to process each frame of this playable.
            
        }

        if (currentInputs.Count == 2)
        {
            if (currentInputs.First().laserLineArrayProps.arrayCount ==
                currentInputs.Last().laserLineArrayProps.arrayCount)
            {
                laserLineArrayProps.arrayCount = currentInputs.First().laserLineArrayProps.arrayCount;
            }
        }
        laserBasicProps.useManualTime = true;
        laserBasicProps.manualTime = (float)director.time;
        trackBinding.SetLaserTransform(laserTransform);
        trackBinding.SetBasicProps(laserBasicProps);
        trackBinding.SetLineArrayProps(laserLineArrayProps);
           
    }
}
