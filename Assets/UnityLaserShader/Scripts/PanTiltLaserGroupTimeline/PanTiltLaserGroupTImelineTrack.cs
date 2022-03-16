using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.24377f, 0.9339623f, 0.5197048f)]
[TrackClipType(typeof(PanTiltLaserTimelineClip))]
[TrackBindingType(typeof(PanTiltLaserGroup))]
public class PanTiltLaserGroupTimelineTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var playableDirector = go.GetComponent<PlayableDirector>();
        var mixer = ScriptPlayable<PanTiltLaserGroupTimelineMixerBehaviour>.Create(graph, inputCount);

        var playableBehaviour = mixer.GetBehaviour();
        playableBehaviour.playableDirector = playableDirector;
        playableBehaviour.clips = GetClips();

        return mixer;
    }
}
