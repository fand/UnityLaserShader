using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]
public class RandomFlashStatus
{
    public float time = 0f;
    public float offsetTime = 0f;
    // public float duration = 0.5f;
    // public AnimationCurve animationCurve;
    public StylizedLaser stylizedLaser;
    public void  Update()
    {


        time += Time.deltaTime;
        // return animationCurve.Evaluate(time);
    }
    
    // public
}
[ExecuteAlways]
public class StylizedLaserRandomFlash : LaserElement
{

    public float time = 0f;
    public float prevTime = 0f;
    public Vector2 randomOffsetRange = new Vector2(0f, 1f);
    public float duration = 0.5f;
    public AnimationCurve animationCurve;
    [SerializeField] private List<StylizedLaser> laserArray = new List<StylizedLaser>();
    [ColorUsage(showAlpha: false, hdr: true)]public List<Color> lineColors = new List<Color>(){Color.white};
    [ColorUsage(showAlpha: true, hdr: true)]public List<Color> fogColors = new List<Color>(){Color.white};
     public LaserTransform staggerLaserTransform = new LaserTransform();
     public LaserBasicProps staggerLaserProps = new LaserBasicProps();
     public LaserFanProps staggerLaserFanProps = new LaserFanProps();
     public LaserLineArrayProps staggerLaserLineArrayProps = new LaserLineArrayProps();
     public List<StylizedLaserRandomFlash> synchronizedStylizedLasers = new List<StylizedLaserRandomFlash>();
     
     [SerializeField]private List<RandomFlashStatus> randomQue = new List<RandomFlashStatus>();
     
    // [SerializeField] private List<LaserTransform> _staggerLaserTransformArray = new List<LaserTransform>();
    public override void Init(LaserType laserType)
    {
        InitType(laserType);
        // _staggerLaserTransformArray.Clear();
        
        
        randomQue.Clear();
        var randomSort  = laserArray.OrderBy(a => Guid.NewGuid()).ToList();

        var i = 0;
        foreach (var stylizedLaser in randomSort)
        {
            var newStatus = new RandomFlashStatus();
            newStatus.offsetTime = i*Random.Range(randomOffsetRange.x, randomOffsetRange.y);
            // newStatus.offsetTime = 0f;
            // newStatus.animationCurve = animationCurve;
            // newStatus.duration = duration;
            newStatus.stylizedLaser = stylizedLaser;
            randomQue.Add(newStatus);
            i++;
        }

        foreach (var laser in laserArray)
        {
            laser.Init(this.laserType);
            // _staggerLaserTransformArray.Add(new LaserTransform());
        }

        foreach (var synchronizedStylizedLaser in synchronizedStylizedLasers)
        {
            synchronizedStylizedLaser.Init(laserType);
        }
    }


    private void Start()
    {
        Init(this.laserType);
    }

    [ContextMenu("Init Type")]
    public void InitForce()
    {
        Init(laserType);
    }
    public override void InitType(LaserType laserType)
    {
        this.laserType = laserType;
        
       
    }
    
    public override void SetBasicProps(LaserBasicProps laserBasicProps)
    {
        // this.laserTransform = laserTransform;
        this.laserBasicProps = laserBasicProps;
        
       

    }
    
    public  override void SetLineArrayProps(LaserLineArrayProps laserLineArrayProps)
    {
        this.laserLineArrayProps = laserLineArrayProps;
        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaserRandomFlash ptl in synchronizedStylizedLasers)
            {
                ptl.SetLineArrayProps(laserLineArrayProps);
            }
        }
        
    }
    public override void SetFanProps(LaserFanProps laserFanProps)       {
        this.laserFanProps = laserFanProps;
        if (synchronizedStylizedLasers != null)
        {
            foreach (StylizedLaserRandomFlash ptl in synchronizedStylizedLasers)
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
            foreach (StylizedLaserRandomFlash ptl in synchronizedStylizedLasers)
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
        foreach (var randomFlashStatus  in randomQue)
        {
            var laser = randomFlashStatus.stylizedLaser;
            
            if(laser == null) return;
            laser.laserType = laserType;
            var index = laserArray.IndexOf(laser);
            var copyLaserTransform = laserTransform + staggerLaserTransform*index;   //_staggerLaserTransformArray[index];
            var copyBasicProps = laserBasicProps + staggerLaserProps*index;
            var copyFanProps = laserFanProps + staggerLaserFanProps*index;
            var copyLineArrayProps = laserLineArrayProps + staggerLaserLineArrayProps*index;
            copyBasicProps.color = lineColors[index%lineColors.Count];
            copyFanProps.fogColor = fogColors[index%fogColors.Count];
            copyBasicProps.color = lineColors[index%lineColors.Count];
            // copyLineArrayProps.fogColor = fogColors[index%fogColors.Count];

            if(time > prevTime)            randomFlashStatus.Update();

            // randomFlashStatus.globalTime=time;
            var t = Math.Max(randomFlashStatus.time - randomFlashStatus.offsetTime, 0);
            copyBasicProps.angle = laserBasicProps.angle * animationCurve.Evaluate(t / duration);

            if (t > duration) randomFlashStatus.time = 0f;

            copyBasicProps.opacity = copyBasicProps.angle <= 0 ? 0 :1;
            laser.SetLaserTransform(copyLaserTransform);
            laser.SetBasicProps(copyBasicProps);
            laser.SetFanProps(copyFanProps);
            laser.SetLineArrayProps(copyLineArrayProps);
            // laser.SetLineArrayProps(copyLineArrayProps);
        }

        foreach (var synchronizedStylizedLaser in synchronizedStylizedLasers)
        {
            synchronizedStylizedLaser.time = time;
            synchronizedStylizedLaser.duration = duration;
            synchronizedStylizedLaser.animationCurve = animationCurve;
            synchronizedStylizedLaser.randomOffsetRange = randomOffsetRange;
            synchronizedStylizedLaser.staggerLaserProps = staggerLaserProps;
            synchronizedStylizedLaser.staggerLaserTransform = staggerLaserTransform;
            synchronizedStylizedLaser.staggerLaserFanProps = staggerLaserFanProps;
            
            synchronizedStylizedLaser.SetBasicProps(laserBasicProps);
            synchronizedStylizedLaser.SetLineArrayProps(laserLineArrayProps);
            synchronizedStylizedLaser.SetFanProps(laserFanProps);
            
            synchronizedStylizedLaser.fogColors = fogColors;
            synchronizedStylizedLaser.lineColors = lineColors;
        }

        prevTime = time;
    }
}
