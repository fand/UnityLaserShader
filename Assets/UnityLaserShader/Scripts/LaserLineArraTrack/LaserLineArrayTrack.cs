using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.3339622f, 1f, 0.8672137f)]
[TrackClipType(typeof(LaserLineArrayClip))]
[TrackBindingType(typeof(StylizedLaserArray))]
public class LaserLineArrayTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
      
        var playableDirector = go.GetComponent<PlayableDirector>();
        var playable= ScriptPlayable<LaserLineArrayMixerBehaviour>.Create (graph, inputCount);
        var playableBehaviour = playable.GetBehaviour();
        playableBehaviour.director = playableDirector;
        return playable;
    }
}
