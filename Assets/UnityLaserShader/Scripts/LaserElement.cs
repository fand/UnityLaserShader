using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserElement: MonoBehaviour
{

    [SerializeField]internal LaserType _laserType;
    [SerializeField]internal LaserBasicProps laserBasicProps;
    [SerializeField]internal LaserLineArrayProps laserLineArrayProps;
    [SerializeField] internal LaserTransform _laserTransform = new LaserTransform();


    public LaserType laserType { get { return _laserType; } set { _laserType = value; } }

    public void InitProps()
    {
        laserBasicProps = new LaserBasicProps();
        laserLineArrayProps = new LaserLineArrayProps();
    }
    public void SetBasicProps(LaserBasicProps laserBasicProps)
    {
        this.laserBasicProps = laserBasicProps;
    }
    
    public void SetLineArrayProps(LaserLineArrayProps laserLineArrayProps)
    {
        this.laserLineArrayProps = laserLineArrayProps;
    }
    
    public virtual void InitType(LaserType laserType)
    {
        _laserType = laserType;

    }

    public LaserTransform laserTransform
    {
        get => _laserTransform;
        set => _laserTransform = value;
    }
    
    public virtual void SetBasicValues()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
