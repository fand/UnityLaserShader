using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PanTiltLaserTimelineMixerBehaviour : PlayableBehaviour
{
    private PlayableDirector _Director;

    public IEnumerable<TimelineClip> clips;
    public PlayableDirector playableDirector
    {
        get => _Director;
        set { _Director = value; }
    }

    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        var trackBinding = playerData as PanTiltLaser;
        if (!trackBinding)
        {
            return;
        }

        var pan = 0f;
        var tilt = 0f;
        LaserProps laserProps = new LaserProps();

        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<PanTiltLaserTimelineBehaviour> inputPlayable = (ScriptPlayable<PanTiltLaserTimelineBehaviour>)playable.GetInput(i);
            PanTiltLaserTimelineBehaviour input = inputPlayable.GetBehaviour();

            if (inputWeight > 0)
            {
                // trackBinding.UpdateLaser(input.laserProps);
                pan += input.pan * inputWeight;
                tilt += input.tilt * inputWeight;
                laserProps.color += input.color * inputWeight;
                laserProps.intensity += input.intensity * inputWeight;
                laserProps.flickering += input.flickering * inputWeight;
                laserProps.seed += input.seed * inputWeight;
                laserProps.useManualTime = true;
                if (playableDirector != null) laserProps.manualTime = (float)playableDirector.time;
                laserProps.angle += input.angle * inputWeight;
                laserProps.width += input.width * inputWeight;
                laserProps.sharpness += input.sharpness * inputWeight;
                laserProps.xBlur += input.xBlur * inputWeight;
                laserProps.splitWidth += input.splitWidth * inputWeight;
                laserProps.splitMix += input.splitMix * inputWeight;
                laserProps.rapidFire += input.rapidFire * inputWeight;
                laserProps.rapidFireCount += input.rapidFireCount * inputWeight;
                laserProps.rapidFireSpeed += input.rapidFireSpeed * inputWeight;
                laserProps.rapidFireTimeOffset += input.rapidFireTimeOffset * inputWeight;
                laserProps.rapidFireAttack += input.rapidFireAttack * inputWeight;
                laserProps.rapidFireHold += input.rapidFireHold * inputWeight;
                laserProps.rapidFireRelease += input.rapidFireRelease * inputWeight;
                laserProps.rapidFireRandomness += input.rapidFireRandomness * inputWeight;
                laserProps.noiseIntensity += input.noiseIntensity * inputWeight;
                laserProps.noiseScale += input.noiseScale * inputWeight;
                laserProps.noiseSpeed += input.noiseSpeed * inputWeight;
                laserProps.fog += input.fog * inputWeight;
                laserProps.centerBloom += input.centerBloom * inputWeight;
                laserProps.centerBloomSize += input.centerBloomSize * inputWeight;
                laserProps.strobeSpeed += input.strobeSpeed * inputWeight;
                laserProps.strobePWM += input.strobePWM * inputWeight;
                laserProps.strobeTimeOffset += input.strobeTimeOffset * inputWeight;
            }
        }

        trackBinding.SetLaserProps(laserProps);
        trackBinding.SetPan(pan);
        trackBinding.SetTilt(tilt);
    }
}
