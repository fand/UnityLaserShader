using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LaserType
{
    LaserLine,
    LaserLineArray
}

[ExecuteAlways]
public class Laser :LaserElement
{

    [SerializeField] private MeshRenderer meshRenderer;
    private MaterialPropertyBlock _materialPropertyBlock;
    private float _manualTime;
    [ContextMenu("Init")]
    public void Init(LaserType laserType)
    {
        this.laserType = laserType;
        _materialPropertyBlock = new();
        InitType(laserType);
        meshRenderer = GetComponent<MeshRenderer>();
    }

    
    public float manualTime
    {
        get => _manualTime;
        set
        {
            _manualTime = value;
        }
    }


    public override void InitType(LaserType laserType)
    {
        switch (laserType)
        {
            case LaserType.LaserLine:
                meshRenderer.sharedMaterial = Resources.Load<Material>("Materials/LaserLine");
                // InitLine();
                break;
            case LaserType.LaserLineArray:
                meshRenderer.sharedMaterial = Resources.Load<Material>("Materials/LaserLineArray");
                break;
            default:
                break;

        }
    }

    private void Start()
    {
        // Init(LaserType.LaserLineArray);
    }

  

    // Update is called once per frame
    void Update()
    {
        
        if (meshRenderer == null) { return; }

        if (_materialPropertyBlock == null)
        {
            _materialPropertyBlock = new();
        }

        transform.localScale = laserTransform.size;
        transform.localPosition = Vector3.up * laserTransform.size.y / 2f;
        
        _materialPropertyBlock.SetColor("_Color", laserBasicProps.color);
        _materialPropertyBlock.SetFloat("_DistanceFade", laserBasicProps.distanceFade);
        _materialPropertyBlock.SetFloat("_Opacity", laserBasicProps.opacity);
        _materialPropertyBlock.SetFloat("_Flickering", laserBasicProps.flickering);
     
        _materialPropertyBlock.SetVector("_OffsetCenter",laserBasicProps.offsetCenter);
        _materialPropertyBlock.SetFloat("_Rotation", laserBasicProps.rotation);
        _materialPropertyBlock.SetInt("_UseManualTime", laserBasicProps.useManualTime ? 1 : 0);
        _materialPropertyBlock.SetFloat("_ManualTime", laserBasicProps.manualTime);
        _materialPropertyBlock.SetFloat("_Angle", laserBasicProps.angle);
        _materialPropertyBlock.SetFloat("_Width", laserBasicProps.width);
        _materialPropertyBlock.SetFloat("_Sharpness", laserBasicProps.sharpness);
        _materialPropertyBlock.SetFloat("_XBlur", laserBasicProps.xBlur);
        _materialPropertyBlock.SetFloat("_SplitWidth", laserBasicProps.splitWidth);
        _materialPropertyBlock.SetFloat("_SplitMix", laserBasicProps.splitMix);

        _materialPropertyBlock.SetFloat("_ArrayNoiseIntensity", laserBasicProps.noiseIntensity);
        _materialPropertyBlock.SetFloat("_ArrayNoiseScale", laserBasicProps.noiseScale);
        _materialPropertyBlock.SetFloat("_ArrayNoiseSpeed", laserBasicProps.noiseSpeed);
        _materialPropertyBlock.SetFloat("_ArrayNoiseSeed", laserBasicProps.noiseSeed);
        
        _materialPropertyBlock.SetFloat("_StrobeSpeed", laserBasicProps.strobeSpeed);
        _materialPropertyBlock.SetFloat("_StrobePWM", laserBasicProps.strobePWM);
        _materialPropertyBlock.SetFloat("_StrobeTimeOffset", laserBasicProps.strobeTimeOffset);
        _materialPropertyBlock.SetFloat("_ManualTime", this.manualTime);
        _materialPropertyBlock.SetVector("_AngleMaskStartEnd",new Vector2(laserBasicProps.arcMaskStart,laserBasicProps.arcMaskEnd));
        
        if (laserType == LaserType.LaserLineArray)
        {
            // set array props
            _materialPropertyBlock.SetFloat("_ArrayCount", laserLineArrayProps.arrayCount);
            _materialPropertyBlock.SetFloat("_ArrayMoveSpeed", laserLineArrayProps.arrayMoveSpeed);
            _materialPropertyBlock.SetFloat("_ArrayMoveTimeOffset", laserLineArrayProps.arrayMoveTimeOffset);
            _materialPropertyBlock.SetFloat("_ArrayMoveAttack", laserLineArrayProps.arrayMoveAttack);
            _materialPropertyBlock.SetFloat("_ArrayMoveHold", laserLineArrayProps.arrayMoveHold);
            _materialPropertyBlock.SetFloat("_ArrayMoveRelease", laserLineArrayProps.arrayMoveRelease);
            _materialPropertyBlock.SetFloat("_ArrayRandomness", laserLineArrayProps.arrayRandomness);  
        }
      
        
        meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        
      
        
        
    }
}
