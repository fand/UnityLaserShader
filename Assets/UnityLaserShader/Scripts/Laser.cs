using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum LaserType
{
    Line,
    LineArray,
    Fan,
    FanArray
}

[ExecuteAlways]
public class Laser :LaserElement
{

    [SerializeField] private MeshRenderer _meshRenderer;
    private MaterialPropertyBlock _materialPropertyBlock;
    
    
    public MaterialPropertyBlock materialPropertyBlock => _materialPropertyBlock;
    public MeshRenderer meshRenderer => _meshRenderer;
    
    [ContextMenu("Init")]
    public override void Init(LaserType laserType)
    {
        
        _materialPropertyBlock = new();
        _meshRenderer = GetComponent<MeshRenderer>();
        InitType(laserType);
       
    }


    [MenuItem("InitType")]
    public override void InitType(LaserType laserType)
    {
        this.laserType = laserType;
        if(meshRenderer == null) return;
        meshRenderer.sharedMaterial  = GetMaterialSource(this.laserType);
        
    }


    // Update is called once per frame
    void Update()
    {
        
        if (meshRenderer == null) { Init(laserType); }
        if(meshRenderer == null) return;
        
        if (_materialPropertyBlock == null) _materialPropertyBlock = new();
        

        transform.localScale = laserTransform.size;
        transform.localPosition = Vector3.up * laserTransform.size.y / 2f;
        
        
        ApplyMaterialPropertyWithCurrentProp(_materialPropertyBlock,meshRenderer);
      
        
        
    }
}
