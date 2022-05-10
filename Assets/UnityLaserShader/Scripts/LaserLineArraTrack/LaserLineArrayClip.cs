using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LaserLineArrayClip : PlayableAsset, ITimelineClipAsset
{
    public LaserLineArrayBehaviour template = new LaserLineArrayBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Looping | ClipCaps.Blending | ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<LaserLineArrayBehaviour>.Create (graph, template);
        LaserLineArrayBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
