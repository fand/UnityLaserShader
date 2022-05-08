using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LaserFanArrayClip : PlayableAsset, ITimelineClipAsset
{
    public LaserFanArrayBehaviour template = new LaserFanArrayBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Looping | ClipCaps.Blending | ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<LaserFanArrayBehaviour>.Create (graph, template);
        LaserFanArrayBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
