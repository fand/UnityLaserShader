using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LaserFanClip : PlayableAsset, ITimelineClipAsset
{
    public LaserFanBehaviour template = new LaserFanBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Looping | ClipCaps.Blending | ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<LaserFanBehaviour>.Create (graph, template);
        LaserFanBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
