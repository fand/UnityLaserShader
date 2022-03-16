using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class LaserPropsScriptableObject : ScriptableObject
{
    [SerializeField] private LaserProps laserProps = new();
}
