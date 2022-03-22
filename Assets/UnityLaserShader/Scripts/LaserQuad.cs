using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(MeshRenderer))]
public class LaserQuad : MonoBehaviour
{
    public LaserProps laserProps = new();
    [SerializeField] private MeshRenderer meshRenderer;
    private MaterialPropertyBlock materialPropertyBlock;

    public void Init()
    {
        materialPropertyBlock = new();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Init();
    }

    public void SetProps(LaserProps laserProps)
    {
        this.laserProps = laserProps;
    }

    void Update()
    {
        if (meshRenderer == null) { return; }

        if (materialPropertyBlock == null)
        {
            Init();
        }

        materialPropertyBlock.SetColor("_Color", laserProps.color);
        materialPropertyBlock.SetFloat("_Intensity", laserProps.intensity);
        materialPropertyBlock.SetFloat("_Flickering", laserProps.flickering);
        materialPropertyBlock.SetFloat("_Seed", laserProps.seed);
        materialPropertyBlock.SetInt("_UseManualTime", laserProps.useManualTime ? 1 : 0);
        materialPropertyBlock.SetFloat("_ManualTime", laserProps.manualTime);
        materialPropertyBlock.SetFloat("_Angle", laserProps.angle);
        materialPropertyBlock.SetFloat("_Width", laserProps.width);
        materialPropertyBlock.SetFloat("_Sharpness", laserProps.sharpness);
        materialPropertyBlock.SetFloat("_XBlur", laserProps.xBlur);
        materialPropertyBlock.SetFloat("_SplitWidth", laserProps.splitWidth);
        materialPropertyBlock.SetFloat("_SplitMix", laserProps.splitMix);
        materialPropertyBlock.SetFloat("_Rapidfiire", laserProps.rapidFire);
        materialPropertyBlock.SetFloat("_RapidFireCount", laserProps.rapidFireCount);
        materialPropertyBlock.SetFloat("_RapidFireSpeed", laserProps.rapidFireSpeed);
        materialPropertyBlock.SetFloat("_RapidFireTimeOffset", laserProps.rapidFireTimeOffset);
        materialPropertyBlock.SetFloat("_RapidFireAttack", laserProps.rapidFireAttack);
        materialPropertyBlock.SetFloat("_RapidFireHold", laserProps.rapidFireHold);
        materialPropertyBlock.SetFloat("_RapidFireRelease", laserProps.rapidFireRelease);
        materialPropertyBlock.SetFloat("_RapidFireRandomness", laserProps.rapidFireRandomness);
        materialPropertyBlock.SetFloat("_NoiseIntensity", laserProps.noiseIntensity);
        materialPropertyBlock.SetFloat("_NoiseScale", laserProps.noiseScale);
        materialPropertyBlock.SetFloat("_NoiseSpeed", laserProps.noiseSpeed);
        materialPropertyBlock.SetFloat("_Fog", laserProps.fog);
        materialPropertyBlock.SetFloat("_CenterBloom", laserProps.centerBloom);
        materialPropertyBlock.SetFloat("_CenterBloomSize", laserProps.centerBloomSize);
        materialPropertyBlock.SetFloat("_StrobeSpeed", laserProps.strobeSpeed);
        materialPropertyBlock.SetFloat("_StrobePWM", laserProps.strobePWM);
        materialPropertyBlock.SetFloat("_StrobeTimeOffset", laserProps.strobeTimeOffset);

        meshRenderer.SetPropertyBlock(materialPropertyBlock);
    }
}
