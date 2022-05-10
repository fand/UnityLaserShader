using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.7116158f, 0.5226415f, 1f)]
[TrackClipType(typeof(LaserLineClip))]
[TrackBindingType(typeof(StylizedLaser))]
public class LaserLineTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var playableDirector = go.GetComponent<PlayableDirector>();
        var playable= ScriptPlayable<LaserLineMixerBehaviour>.Create (graph, inputCount);
        var playableBehaviour = playable.GetBehaviour();
        playableBehaviour.director = playableDirector;
        return playable;
    }
}
