using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class PanTiltLaserTimelineClip : PlayableAsset, ITimelineClipAsset
{
    public PanTiltLaserTimelineBehaviour laserProps = new();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Looping | ClipCaps.Blending | ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<PanTiltLaserTimelineBehaviour>.Create(graph, laserProps);
    }
}
