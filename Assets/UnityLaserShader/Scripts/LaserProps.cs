using System;
using UnityEngine;

[Serializable]
public class LaserProps
{
    [SerializeField] public Color color = Color.green;
    [SerializeField] public float intensity = 1f;
    [SerializeField, Range(0, 1)] public float flickering = 0f;
    [SerializeField, Range(0, 100)] public float seed = 0f;
    [SerializeField] public bool useManualTime = false;
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
    [SerializeField, Range(0, 1)] public float rapidFireTimeOffset = 0f;
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

    public LaserProps()
    {
        color = new Color(0, 0, 0, 0);
        intensity = 0f;
        flickering = 0f;
        seed = 0f;
        useManualTime = false;
        manualTime = 0f;
        angle = 0f;
        width = 0f;
        sharpness = 0f;
        xBlur = 0f;
        splitWidth = 0f;
        splitMix = 0f;
        rapidFire = 0f;
        rapidFireCount = 0f;
        rapidFireSpeed = 0f;
        rapidFireTimeOffset = 0f;
        rapidFireAttack = 0f;
        rapidFireHold = 0f;
        rapidFireRelease = 0f;
        rapidFireRandomness = 0f;
        noiseIntensity = 0f;
        noiseScale = 0;
        noiseSpeed = 0f;
        fog = 0f;
        centerBloom = 0f;
        centerBloomSize = 0f;
        strobeSpeed = 0f;
        strobePWM = 0f;
        strobeTimeOffset = 0f;
    }
}
