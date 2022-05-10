using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LaserLineClip : PlayableAsset, ITimelineClipAsset
{
    public LaserLineBehaviour template = new LaserLineBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Looping | ClipCaps.Blending | ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<LaserLineBehaviour>.Create (graph, template);
        LaserLineBehaviour clone = playable.GetBehaviour ();
        // template.SetBasicValues();
        return playable;
    }
}
