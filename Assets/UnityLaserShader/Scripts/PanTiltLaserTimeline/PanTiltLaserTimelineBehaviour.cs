using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class PanTiltLaserTimelineBehaviour : PlayableBehaviour
{
    public float pan = 0f;
    public float tilt = 0f;
    [SerializeField, ColorUsage(true, true)] public Color color = Color.green;
    [SerializeField] public float intensity = 1f;
    [SerializeField, Range(0, 1)] public float flickering = 0f;
    [SerializeField, Range(0, 100)] public float seed = 0f;
    // [SerializeField] public bool useManualTime =false;
    [SerializeField, Range(0, 1)] public float manualTime = 0f;
    [SerializeField, Range(0, 90)] public float angle = 15f;
    [SerializeField, Range(0, 1)] public float width = 0.5f;
    [SerializeField, Range(0, 10)] public float sharpness = 0.1f;
    [SerializeField, Range(0, 1)] public float xBlur = 0.01f;
    [SerializeField, Range(0, 1)] public float splitWidth = 0f;
    [SerializeField, Range(0, 1)] public float splitMix = 0f;
    [SerializeField, Range(0, 1)] public float rapidFire = 0f;
    [SerializeField, Range(0, 60)] public float rapidFireCount = 0f;
    [SerializeField, Range(-10, 10)] public float rapidFireSpeed = 0f;
    [SerializeField] public float rapidFireTimeOffset = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireAttack = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireHold = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireRelease = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireRandomness = 0f;
    [SerializeField, Range(0, 1)] public float noiseIntensity = 0f;
    [SerializeField, Range(0, 1000)] public float noiseScale = 1f;
    [SerializeField, Range(0, 1)] public float noiseSpeed = 0f;
    [SerializeField, Range(0, 1)] public float fog = 0f;
    [SerializeField, Range(0, 10)] public float centerBloom = 0f;
    [SerializeField, Range(0, 1)] public float centerBloomSize = 0f;
    [SerializeField, Range(0, 60)] public float strobeSpeed = 0f;
    [SerializeField, Range(0, 1)] public float strobePWM = 0.5f;
    [SerializeField, Range(0, 1)] public float strobeTimeOffset = 0f;
}
