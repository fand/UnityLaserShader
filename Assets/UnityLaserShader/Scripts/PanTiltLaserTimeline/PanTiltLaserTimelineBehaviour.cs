using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class OffsetPTLChildProp
{
    public float pan;
    public float tilt;
    public float rotation;
    [ColorUsage(showAlpha: false, hdr: true)][SerializeField] public Color color = Color.green;
    [ColorUsage(showAlpha: true, hdr: true)][SerializeField] public Color fogColor = Color.green;
    
    
    public OffsetPTLChildProp(float pan = 0f, float tilt = 0f, float rotation = 0f, Color color=new Color(), Color fogColor = new Color())
    {
        this.pan = pan;
        this.tilt = tilt;
        this.rotation = rotation;
        this.color = color;
        this.fogColor = fogColor;
    }
}

[Serializable]
public class PanTiltLaserTimelineBehaviour : PlayableBehaviour
{
    [Header("--- Child steps ---")] 
    public float panStep = 0f;
    public float tiltStep = 0f;
    public float rotationStep = 0f;
    
    
    [Header("--- Transform ----")]
    [SerializeField] public Vector2 size = Vector2.one;
    
    public float pan = 0f;
    public float tilt = 0f;
    
    [SerializeField] public float rotation = 0f;
    [SerializeField] public Vector2 offsetCenter = new Vector2(0.5f, 0f);

    [Header("--- Offset Child ----")]
    
    public List<OffsetPTLChildProp> OffsetPTLChildPropList = new List<OffsetPTLChildProp>();
    
    // [ColorUsage(showAlpha: false, hdr: true)][SerializeField] public List<Color> colors = new List<Color>(){Color.green};
    // [ColorUsage(showAlpha: true, hdr: true)][SerializeField] public List<Color> fogColors = new List<Color>(){Color.green};
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
    [SerializeField, Range(0, 1)] public float distanceFade = 0.5f;
    
    [Header("--- Rapid ---")]
    [SerializeField, Range(0, 1)] public float rapidFire = 0f;
    [SerializeField, Range(0, 60)] public int rapidFireCount = 0;
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
