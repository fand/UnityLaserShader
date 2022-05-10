using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Graphs;
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

    private StylizedLaserArray trackBinding;
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        
        
        trackBinding = playerData as StylizedLaserArray;

        if (!trackBinding)
            return;
        
        trackBinding.laserType = LaserType.LineArray;
      
        int inputCount = playable.GetInputCount ();
        
        var laserBasicProps = new LaserBasicProps(true);
        var laserLineArrayProps = new LaserLineArrayProps(true);
        var laserTransform = new LaserTransform();
        
        var staggerLaserBasicProps = new LaserBasicProps(true);
        var staggerlaserLineArrayProps = new LaserLineArrayProps(true);
        var staggerLaserTransform = new LaserTransform();
        
        laserBasicProps.InitializeAllWithZero();
        laserLineArrayProps.InitializeAllWithZero();

        var lineColors = new List<Color>();
        var fogColors = new List<Color>();
        
        for (int li = 0; li < trackBinding.lineColors.Count; li++)
        {
            lineColors.Add(new Color(0,0,0,0));
        }
                
        for (int li = 0; li < trackBinding.lineColors.Count; li++)
        {
            fogColors.Add(new Color(0,0,0,0));
        }
        var currentInputs = new List<LaserLineArrayBehaviour>();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<LaserLineArrayBehaviour> inputPlayable = (ScriptPlayable<LaserLineArrayBehaviour>)playable.GetInput(i);
            LaserLineArrayBehaviour input = inputPlayable.GetBehaviour ();



            if (inputWeight > 0.0f)
            {
                CheckColorList(input);
                for (int li = 0; li < lineColors.Count; li++)
                {
                    lineColors[li] += input.lineColors[li] * inputWeight;
                }
                
                for (int fi = 0; fi < fogColors.Count; fi++)
                {
                    fogColors[fi] += input.fogColors[fi] * inputWeight;
                }
            

                laserBasicProps += input.laserBasicProps * inputWeight;
                laserLineArrayProps += input.laserLinArrayProps * inputWeight;
                laserTransform += input.laserTransform * inputWeight;
                
                staggerLaserBasicProps += input.staggerLaserBasicProps * inputWeight;
                staggerlaserLineArrayProps += input.staggerLaserLinArrayProps * inputWeight;
                staggerLaserTransform += input.staggerLaserTransform * inputWeight;
             
                currentInputs.Add(input);
                
            }
            
        }

        
        laserBasicProps.useManualTime = true;
        laserBasicProps.manualTime = (float)director.time;
        
        trackBinding.staggerLaserProps = staggerLaserBasicProps;
        trackBinding.staggerLaserLineArrayProps = staggerlaserLineArrayProps;
        trackBinding.staggerLaserTransform = staggerLaserTransform;
        
        trackBinding.lineColors = lineColors;
        trackBinding.fogColors = fogColors;
        
        trackBinding.SetLaserTransform(laserTransform);
        trackBinding.SetBasicProps(laserBasicProps);
        trackBinding.SetLineArrayProps(laserLineArrayProps);

    }
    
    private void CheckColorList(LaserLineArrayBehaviour input)
    {
        // if (input.colors == null) input.colors = new List<Color>();
        // if (input.fogColors == null) input.fogColors = new List<Color>();

        var diff = input.lineColors.Count - trackBinding.lineColors.Count;
        var range = Math.Abs(diff);
        if (diff>0)
        {
            
            input.lineColors.RemoveRange(input.lineColors.Count-range-1,range);

        }

        if (diff < 0)
        {
            input.lineColors.AddRange(new Color[range]);
        }
        
        
        diff = input.fogColors.Count - trackBinding.fogColors.Count;
        range = Math.Abs(diff);
        if (diff>0)
        {
            
            input.fogColors.RemoveRange(input.fogColors.Count-range-1,range);
            
        }

        if (diff < 0)
        {
            input.fogColors.AddRange(new Color[range]);
        }
    }
}
