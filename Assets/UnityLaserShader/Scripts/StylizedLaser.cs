using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class StylizedLaser : LaserElement
{
    [SerializeField] private Transform pan;
    [SerializeField] private Transform tilt;
    [SerializeField] private  Laser laser;
   
    private float _manualTime = 0f;
    [SerializeField] List<StylizedLaser> synchronizedStylizedLasers = new List<StylizedLaser>();


 

    public float manualTime
    {
        get => _manualTime;
        set
        {
            _manualTime = value;
            if(laser != null)
            {
                laser.manualTime = value;
            }
        }
    }

    public LaserType laserType { 
        get { return _laserType; } 
        set

    {
        _laserType = value;
     
    }
}
    
    [ContextMenu("Init")]
    public void Init()
    {
        
        // InitProps();
        laser.Init(this.laserType);

    }
    
    [ContextMenu("SetBasicProps")]
    public override void SetBasicValues()
    {
        InitProps();
        laserBasicProps.SetBasicValues();
        
        laser.SetBasicProps(laserBasicProps);

        
        switch (laserType)
        {
            case LaserType.LaserLineArray:
                laserLineArrayProps.SetBasicValues();
                laser.SetLineArrayProps(laserLineArrayProps);
                break;
            default:
                break;
        }
       
        
        
        
    }
    
    
    void Start()
    {
        
    }
    
    public void SetLaserProps(LaserBasicProps laserBasicProps, LaserLineArrayProps laserLineArrayProps)
    {
        SetBasicProps(laserBasicProps);
        SetLineArrayProps(laserLineArrayProps);

        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaser ptl in synchronizedStylizedLasers)
            {
                ptl.SetBasicProps(laserBasicProps);
                ptl.SetLineArrayProps(laserLineArrayProps);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(laser == null) return;
        if (laser.laserType != laserType)
        {
            Init();     
        }
        
        laser.SetBasicProps(laserBasicProps);

        laser.laserTransform = laserTransform;
        
        if(laserType == LaserType.LaserLineArray)
        {
            laser.SetLineArrayProps(laserLineArrayProps);
        }
        
        if (pan != null)
        {
            pan.localEulerAngles = Vector3.up * laserTransform.pan;
        }
        
        if (tilt != null)
        {
            tilt.localEulerAngles = Vector3.left * laserTransform.tilt;
        }
    }
}
