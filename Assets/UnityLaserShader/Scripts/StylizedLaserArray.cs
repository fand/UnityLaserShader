using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class StylizedLaserArray : LaserElement
{
    [SerializeField] private List<StylizedLaser> laserArray = new List<StylizedLaser>();
    [SerializeField] private List<LaserTransform> _staggerLaserTransformArray = new List<LaserTransform>();
    public override void Init(LaserType laserType)
    {
        InitType(laserType);
        _staggerLaserTransformArray.Clear();
        foreach (var laser in laserArray)
        {
            laser.Init(this.laserType);
            _staggerLaserTransformArray.Add(new LaserTransform());
        }
    }


    [MenuItem("InitType")]
    public override void InitType(LaserType laserType)
    {
        this.laserType = laserType;
       

    }


    // Update is called once per frame
    void Update()
    {



        if (_staggerLaserTransformArray.Count != laserArray.Count) Init(laserType);
        foreach (var laser in laserArray)
        {
            laser.SetLaserTransform(laserTransform + _staggerLaserTransformArray[laserArray.IndexOf(laser)]);
            laser.SetBasicProps(laserBasicProps);
            laser.SetFanProps(laserFanProps);
            laser.SetLineArrayProps(laserLineArrayProps);
        }
    }
}
