using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class StylizedLaser : LaserElement
{
    [SerializeField] private Transform pan;
    [SerializeField] private Transform tilt;
    [SerializeField] private  Laser laser;
    [SerializeField] List<StylizedLaser> synchronizedStylizedLasers = new List<StylizedLaser>();
    

    
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
        laserBasicProps.InitializeBasicValues();
        
        laser.SetBasicProps(laserBasicProps);

        
        switch (laserType)
        {
            case LaserType.LineArray:
                laserLineArrayProps.InitializeBasicValues();
                laser.SetLineArrayProps(laserLineArrayProps);
                break;
            default:
                break;
        }

    }
    
    void Start()
    {
        
    }
    
    public override void SetBasicProps(LaserBasicProps laserBasicProps)
    {
        // this.laserTransform = laserTransform;
        this.laserBasicProps = laserBasicProps;
       
        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaser ptl in synchronizedStylizedLasers)
            {
                ptl.SetBasicProps(laserBasicProps);
            }
        }

    }
    
    public  override void SetLineArrayProps(LaserLineArrayProps laserLineArrayProps)
    {
        this.laserLineArrayProps = laserLineArrayProps;
        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaser ptl in synchronizedStylizedLasers)
            {
                ptl.SetLineArrayProps(laserLineArrayProps);
            }
        }

    }
    public override void SetFanProps(LaserFanProps laserFanProps)       {
        this.laserFanProps = laserFanProps;
        // Debug.Log($"set: {laserFanProps.fogColor}");
        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaser ptl in synchronizedStylizedLasers)
            {
                ptl.SetFanProps(laserFanProps);
            }
        }
    }


    public override void SetLaserTransform(LaserTransform laserTransform)
    {
        this.laserTransform = laserTransform;
        
        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaser ptl in synchronizedStylizedLasers)
            {
                ptl.SetLaserTransform(laserTransform);
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

        switch (laserType)
        {
                
           case LaserType.LineArray:
               laser.SetLineArrayProps(laserLineArrayProps);
               break;
                
           case LaserType.Fan:
               laser.SetFanProps(laserFanProps);
               break;
           
          default:  
              break;
        }

        foreach (var synchronizedStylizedLaser in synchronizedStylizedLasers)
        {
            synchronizedStylizedLaser.laserType = laserType;
            synchronizedStylizedLaser.SetLaserTransform(laserTransform);
            synchronizedStylizedLaser.SetBasicProps(laserBasicProps);
            switch (laserType)
            {
                case LaserType.LineArray:
                    
                    synchronizedStylizedLaser.SetLineArrayProps(laserLineArrayProps);
                    break;
                case LaserType.Fan:
                    synchronizedStylizedLaser.SetFanProps(laserFanProps);
                    break;  
                    
                default:
                    break;
            }
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
