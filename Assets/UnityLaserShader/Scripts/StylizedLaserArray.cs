using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class StylizedLaserArray : LaserElement
{
    [SerializeField] private List<StylizedLaser> laserArray = new List<StylizedLaser>();
    [ColorUsage(showAlpha: false, hdr: true)]public List<Color> lineColors = new List<Color>(){Color.white};
    [ColorUsage(showAlpha: true, hdr: true)]public List<Color> fogColors = new List<Color>(){Color.white};
     public LaserTransform staggerLaserTransform = new LaserTransform();
     public LaserBasicProps staggerLaserProps = new LaserBasicProps();
     public LaserFanProps staggerLaserFanProps = new LaserFanProps();
     
     public List<StylizedLaserArray> synchronizedStylizedLasers = new List<StylizedLaserArray>();
    // [SerializeField] private List<LaserTransform> _staggerLaserTransformArray = new List<LaserTransform>();
    public override void Init(LaserType laserType)
    {
        InitType(laserType);
        // _staggerLaserTransformArray.Clear();
        foreach (var laser in laserArray)
        {
            laser.Init(this.laserType);
            // _staggerLaserTransformArray.Add(new LaserTransform());
        }
    }


    [MenuItem("InitType")]
    public override void InitType(LaserType laserType)
    {
        this.laserType = laserType;
       

    }
    
    public override void SetBasicProps(LaserBasicProps laserBasicProps)
    {
        // this.laserTransform = laserTransform;
        this.laserBasicProps = laserBasicProps;
        
        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaserArray ptl in synchronizedStylizedLasers)
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
            foreach (StylizedLaserArray ptl in synchronizedStylizedLasers)
            {
                ptl.SetLineArrayProps(laserLineArrayProps);
            }
        }
        
    }
    public override void SetFanProps(LaserFanProps laserFanProps)       {
        this.laserFanProps = laserFanProps;
        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaserArray ptl in synchronizedStylizedLasers)
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
            foreach (StylizedLaserArray ptl in synchronizedStylizedLasers)
            {
                ptl.SetLaserTransform(laserTransform);
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if(laserArray == null) return;

        // if (_staggerLaserTransformArray.Count != laserArray.Count) Init(laserType);
        foreach (var laser in laserArray)
        {
            laser.laserType = LaserType.Fan;
            var index = laserArray.IndexOf(laser);
            var copyLaserTransform = laserTransform + staggerLaserTransform*index;   //_staggerLaserTransformArray[index];
            var copyBasicProps = laserBasicProps + staggerLaserProps*index;
            var copyFanProps = laserFanProps + staggerLaserFanProps*index;
            
            copyBasicProps.color = lineColors[index%lineColors.Count];
            copyFanProps.fogColor = fogColors[index%fogColors.Count];

            laser.SetLaserTransform(copyLaserTransform);
            laser.SetBasicProps(copyBasicProps);
            laser.SetFanProps(copyFanProps);
            // laser.SetLineArrayProps(copyLineArrayProps);
        }

        foreach (var synchronizedStylizedLaser in synchronizedStylizedLasers)
        {
            synchronizedStylizedLaser.staggerLaserProps = staggerLaserProps;
            synchronizedStylizedLaser.staggerLaserTransform = staggerLaserTransform;
            synchronizedStylizedLaser.staggerLaserFanProps = staggerLaserFanProps;
            
            synchronizedStylizedLaser.SetBasicProps(laserBasicProps);
            synchronizedStylizedLaser.SetLineArrayProps(laserLineArrayProps);
            synchronizedStylizedLaser.SetFanProps(laserFanProps);
            
            synchronizedStylizedLaser.fogColors = fogColors;
            synchronizedStylizedLaser.lineColors = lineColors;
        }
        
    }
}
