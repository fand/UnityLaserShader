using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class PanTiltLaserTimelineBehaviour : PlayableBehaviour
{
    [Header("--- Child steps ---")] 
    public float panStep = 0f;
    public float tiltStep = 0f;
    public float rotationStep = 0f;
    
    
    [Header("--- Transform ----")]
    public float pan = 0f;
    public float tilt = 0f;

    [SerializeField] public Vector2 size = Vector2.one;
    [SerializeField] public float rotation = 0f;
    [SerializeField] public Vector2 offsetCenter = new Vector2(0.5f, 0f);

    [Header("--- Color ---")]
    [ColorUsage(showAlpha: false, hdr: true)][SerializeField] public List<Color> colors = new List<Color>(){Color.green};
    [ColorUsage(showAlpha: false, hdr: true)][SerializeField] public List<Color> fogColors = new List<Color>(){Color.green};
    // [SerializeField, Range(0, 1)] public float intensity = 1f;

    // [Header("--- Update Mode ---")]
    // [SerializeField] public bool useManualTime = false;
    // [SerializeField] public float manualTime = 0f;
    
    [Header("--- Basic Style ---")]
    [SerializeField, Range(0, 90)] public float angle = 15f;
    [SerializeField, Range(0, 1)] public float flickering = 0f;
    [SerializeField, Range(0, 1)] public float width = 0.5f;
    [SerializeField, Range(0, 10)] public float sharpness = 0.1f;
    [SerializeField, Range(0, 1)] public float xBlur = 0.01f;
    [SerializeField, Range(0, 1)] public float splitWidth = 0f;
    [SerializeField, Range(0, 1)] public float splitMix = 0f;
    [SerializeField, Range(0, 1)] public float fog = 0f;
    [SerializeField, Range(0, 10)] public float centerBloom = 0f;
    [SerializeField, Range(0, 1)] public float centerBloomSize = 0f;
    
    [Header("--- Rapid ---")]
    [SerializeField, Range(0, 1)] public float rapidFire = 0f;
    [SerializeField, Range(0, 60)] public float rapidFireCount = 0f;
    [SerializeField, Range(-10, 10)] public float rapidFireSpeed = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireTimeOffset = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireAttack = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireHold = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireRelease = 0f;
    [SerializeField, Range(0, 1)] public float rapidFireRandomness = 0f;
    
    [Header("--- Noise ---")]
    [SerializeField, Range(0, 100)] public float seed = 0f;
    [SerializeField, Range(0, 1)] public float noiseIntensity = 0f;
    [SerializeField, Range(0, 1000)] public float noiseScale = 1f;
    [SerializeField, Range(0, 1)] public float noiseSpeed = 0f;
    
    [Header("--- Strobe ---")]
    [SerializeField, Range(0, 60)] public float strobeSpeed = 0f;
    [SerializeField, Range(0, 1)] public float strobePWM = 0.5f;
    [SerializeField, Range(0, 1)] public float strobeTimeOffset = 0f;

}
