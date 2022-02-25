using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(menuName = "UnityLaserShader/Create LaserProfile")]
public class LaserProfile : ScriptableObject
{
    [Range(0, 1)] public float Intensity = 1f;
    // public float Color
}

