using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class LaserElement: MonoBehaviour
{

    [SerializeField]internal LaserType _laserType;
    [SerializeField]internal LaserBasicProps laserBasicProps;
    [SerializeField]internal LaserLineArrayProps laserLineArrayProps;
    [SerializeField]internal LaserFanProps laserFanProps;    
    [SerializeField] internal LaserTransform laserTransform = new LaserTransform();


    public LaserType laserType { get { return _laserType; } set { _laserType = value; } }

    public void InitProps()
    {
        laserBasicProps = new LaserBasicProps();
        laserLineArrayProps = new LaserLineArrayProps();
    }
    public virtual void SetBasicProps(LaserBasicProps laserBasicProps)
    {
        this.laserBasicProps = laserBasicProps;
    }
    
    public virtual void SetLineArrayProps(LaserLineArrayProps laserLineArrayProps)
    {
        this.laserLineArrayProps = laserLineArrayProps;
    }
    
    public virtual void SetFanProps(LaserFanProps laserFanProps)
    {
        this.laserFanProps = laserFanProps;
    }
    
    public virtual void InitType(LaserType laserType)
    {
        _laserType = laserType;

    }
    
    public virtual void SetLaserTransform(LaserTransform laserTransform)
    {
        this.laserTransform = laserTransform;
    }

    // public LaserTransform laserTransform
    // {
    //     get => _laserTransform;
    //     // set => _laserTransform = value;
    // }
    
    public virtual void SetBasicValues()
    {
        
    }
    
    public Material GetMaterialSource(LaserType laserType)
    {
        Material material = null;
        switch (this.laserType)
        {
            case LaserType.Line:
                material = (Material)AssetDatabase.LoadAssetAtPath($"Packages/{StylizedLaserConstans.PACAGE_NAME}/Resources/LaserMaterials/LaserLineMat.mat", typeof(Material));
                // InitLine();
                break;
            case LaserType.LineArray:
                material = (Material)AssetDatabase.LoadAssetAtPath($"Packages/{StylizedLaserConstans.PACAGE_NAME}/Resources/LaserMaterials/LaserLineArrayMat.mat", typeof(Material));
                break;
            case LaserType.Fan:
                material = (Material)AssetDatabase.LoadAssetAtPath($"Packages/{StylizedLaserConstans.PACAGE_NAME}/Resources/LaserMaterials/LaserFanMat.mat", typeof(Material));
                break;
            case LaserType.FanArray:
                material = (Material)AssetDatabase.LoadAssetAtPath($"Packages/{StylizedLaserConstans.PACAGE_NAME}/Resources/LaserMaterials/LaserFanArrayMat.mat", typeof(Material));
                break;
            default:
                break;

        }
            

        return  material;
    }

    public void ApplyMaterialPropertyWithCurrentProp(MaterialPropertyBlock materialPropertyBlock, MeshRenderer meshRenderer)
    {
        // set basic property;
        materialPropertyBlock.SetColor("_Color", laserBasicProps.color);
        materialPropertyBlock.SetFloat("_DistanceFade", laserBasicProps.distanceFade);
        materialPropertyBlock.SetFloat("_Opacity", laserBasicProps.opacity);
        materialPropertyBlock.SetFloat("_Flickering", laserBasicProps.flickering);
        materialPropertyBlock.SetFloat("_ManualTime", laserBasicProps.manualTime);
        
        materialPropertyBlock.SetVector("_OffsetCenter",laserBasicProps.offsetCenter);
        materialPropertyBlock.SetFloat("_Rotation", laserBasicProps.rotation);
        materialPropertyBlock.SetInt("_UseManualTime", laserBasicProps.useManualTime ? 1 : 0);
        materialPropertyBlock.SetFloat("_ManualTime", laserBasicProps.manualTime);
        materialPropertyBlock.SetFloat("_Angle", laserBasicProps.angle);
        materialPropertyBlock.SetFloat("_Width", laserBasicProps.width);
        materialPropertyBlock.SetFloat("_Sharpness", laserBasicProps.sharpness);
        materialPropertyBlock.SetFloat("_XBlur", laserBasicProps.xBlur);
        materialPropertyBlock.SetFloat("_SplitWidth", laserBasicProps.splitWidth);
        materialPropertyBlock.SetFloat("_SplitMix", laserBasicProps.splitMix);

        materialPropertyBlock.SetFloat("_ArrayNoiseIntensity", laserBasicProps.noiseIntensity);
        materialPropertyBlock.SetFloat("_ArrayNoiseScale", laserBasicProps.noiseScale);
        materialPropertyBlock.SetFloat("_ArrayNoiseSpeed", laserBasicProps.noiseSpeed);
        materialPropertyBlock.SetFloat("_ArrayNoiseSeed", laserBasicProps.noiseSeed);
        
        materialPropertyBlock.SetFloat("_StrobeSpeed", laserBasicProps.strobeSpeed);
        materialPropertyBlock.SetFloat("_StrobePWM", laserBasicProps.strobePWM);
        materialPropertyBlock.SetFloat("_StrobeTimeOffset", laserBasicProps.strobeTimeOffset);
        materialPropertyBlock.SetVector("_AngleMaskStartEnd",new Vector2(laserBasicProps.arcMaskStart,laserBasicProps.arcMaskEnd));
        
        if (laserType == LaserType.LineArray)
        {
            // set array props
            materialPropertyBlock.SetFloat("_ArrayCount", laserLineArrayProps.arrayCount);
            materialPropertyBlock.SetFloat("_ArrayMoveSpeed", laserLineArrayProps.arrayMoveSpeed);
            materialPropertyBlock.SetFloat("_ArrayMoveTimeOffset", laserLineArrayProps.arrayMoveTimeOffset);
            materialPropertyBlock.SetFloat("_ArrayMoveAttack", laserLineArrayProps.arrayMoveAttack);
            materialPropertyBlock.SetFloat("_ArrayMoveHold", laserLineArrayProps.arrayMoveHold);
            materialPropertyBlock.SetFloat("_ArrayMoveRelease", laserLineArrayProps.arrayMoveRelease);
            materialPropertyBlock.SetFloat("_ArrayRandomness", laserLineArrayProps.arrayRandomness);  
        }

        if (laserType == LaserType.Fan)
        {
            // set fan props   
            materialPropertyBlock.SetColor("_FogColor", laserFanProps.fogColor);
            materialPropertyBlock.SetFloat("_CenterBloom", laserFanProps.centerBloom);
            materialPropertyBlock.SetFloat("_CenterBloomSize", laserFanProps.centerBloomSize);
            materialPropertyBlock.SetVector("_FogNoiseScale", laserFanProps.fogNoiseScale);
            materialPropertyBlock.SetVector("_FogNoiseSpeed", laserFanProps.fogNoiseSpeed);

        }

        meshRenderer.SetPropertyBlock(materialPropertyBlock);
    }
    
    public virtual void Init(LaserType laserType)
    {
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
