using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PanTiltLaserGroupTimelineMixerBehaviour : PlayableBehaviour
{
    private PlayableDirector _Director;

    public IEnumerable<TimelineClip> clips;
    public PlayableDirector playableDirector
    {
        get => _Director;
        set { _Director = value; }
    }

    private PanTiltLaserGroup trackBinding;
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        trackBinding = playerData as PanTiltLaserGroup;
        if (!trackBinding)
        {
            return;
        }

        var pan = 0f;
        var tilt = 0f;
        var panStep = 0f;
        var tiltStep = 0f;
        var rotationStep = 0f;
        var laserProps = new LaserProps();
        var offsetChild = new List<OffsetPTLChildProp>();
        for (int j = 0; j < trackBinding.LaserCount; j++)
        {
            var lc = new OffsetPTLChildProp( 0,0,0,new Color(0, 0, 0, 0), new Color(0, 0, 0, 0));
            offsetChild.Add(lc);
        }
        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<PanTiltLaserTimelineBehaviour> inputPlayable = (ScriptPlayable<PanTiltLaserTimelineBehaviour>)playable.GetInput(i);
            PanTiltLaserTimelineBehaviour input = inputPlayable.GetBehaviour();
            
            if (inputWeight > 0)
            {

                
                trackBinding.ForceEnableLasers();
                
                 // trackBinding.UpdateLaser(input.laserProps);
                pan += input.pan * inputWeight;
                tilt += input.tilt * inputWeight;
                panStep += input.panStep * inputWeight;
                tiltStep += input.tiltStep * inputWeight;
                rotationStep += input.rotationStep * inputWeight;
                

                laserProps.size += input.size * inputWeight;
                
                laserProps.rotation += input.rotation * inputWeight;
                laserProps.offsetCenter += input.offsetCenter * inputWeight;

                var colorIndex= 0;

                CheckColorList(input);
                foreach (var c in offsetChild)
                {
                    c.pan += input.OffsetPTLChildPropList[colorIndex].pan * inputWeight;
                    c.tilt += input.OffsetPTLChildPropList[colorIndex].tilt * inputWeight;
                    c.rotation += input.OffsetPTLChildPropList[colorIndex].rotation * inputWeight;
                    
                    c.color += input.OffsetPTLChildPropList[colorIndex].color * inputWeight;
                    c.color.a = 1;
                    c.fogColor += input.OffsetPTLChildPropList[colorIndex].fogColor * inputWeight;
                    colorIndex++;
                }

                laserProps.useManualTime = true;
                if (playableDirector != null) laserProps.manualTime = (float)playableDirector.time;
                
                
                
                laserProps.angle += input.angle * inputWeight;
                laserProps.flickering += input.flickering * inputWeight;
                laserProps.width += input.width * inputWeight;
                laserProps.sharpness += input.sharpness * inputWeight;
                laserProps.xBlur += input.xBlur * inputWeight;
                laserProps.splitWidth += input.splitWidth * inputWeight;
                laserProps.splitMix += input.splitMix * inputWeight;
                laserProps.fog += input.fog * inputWeight;
                laserProps.centerBloom += input.centerBloom * inputWeight;
                laserProps.centerBloomSize += input.centerBloomSize * inputWeight;
                laserProps.distanceFade += input.distanceFade * inputWeight;
                
            
                laserProps.rapidFire += input.rapidFire * inputWeight;
                laserProps.rapidFireCount += input.rapidFireCount * inputWeight;
                laserProps.rapidFireSpeed += input.rapidFireSpeed * inputWeight;
                laserProps.rapidFireTimeOffset += input.rapidFireTimeOffset * inputWeight;
                laserProps.rapidFireAttack += input.rapidFireAttack * inputWeight;
                laserProps.rapidFireHold += input.rapidFireHold * inputWeight;
                laserProps.rapidFireRelease += input.rapidFireRelease * inputWeight;
                laserProps.rapidFireRandomness += input.rapidFireRandomness * inputWeight;
               
                laserProps.seed += input.seed * inputWeight;
                laserProps.noiseIntensity += input.noiseIntensity * inputWeight;
                laserProps.noiseScale += input.noiseScale * inputWeight;
                laserProps.noiseSpeed += input.noiseSpeed * inputWeight;
               
                laserProps.strobeSpeed += input.strobeSpeed * inputWeight;
                laserProps.strobePWM += input.strobePWM * inputWeight;
                laserProps.strobeTimeOffset += input.strobeTimeOffset * inputWeight;
                break;
            }
            else
            {
                // trackBinding.gameObject.SetActive(false);
                trackBinding.ForceDisableLasers();
            }
        }

        
        
       
        trackBinding.panStep = panStep;
        trackBinding.tiltStep = tiltStep;
        trackBinding.rotationStep = rotationStep;
        trackBinding.SetLaserProps(laserProps,offsetChild);
        trackBinding.ApplyValues();
        trackBinding.SetPanTilt(pan,tilt);
        
    }

    private void CheckColorList(PanTiltLaserTimelineBehaviour input)
    {
        // if (input.colors == null) input.colors = new List<Color>();
        // if (input.fogColors == null) input.fogColors = new List<Color>();

        var diff = input.OffsetPTLChildPropList.Count - trackBinding.LaserCount;
        var range = Math.Abs(diff);
        if (diff>0)
        {
            
            input.OffsetPTLChildPropList.RemoveRange(input.OffsetPTLChildPropList.Count-range-1,range);
            input.OffsetPTLChildPropList.RemoveRange(input.OffsetPTLChildPropList.Count-range-1,range);
            
        }

        if (diff < 0)
        {
            input.OffsetPTLChildPropList.AddRange(new OffsetPTLChildProp[range]);
            input.OffsetPTLChildPropList.AddRange(new OffsetPTLChildProp[range]);
        }
    }
}
