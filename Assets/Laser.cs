using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Renderer _quad;
    Material _material;

    [SerializeField] LaserProfile _profile;

    void Awake()
    {
        _material = _quad.material;
    }

    void Update()
    {
        _material.SetFloat("_Intensity", _profile.Intensity);
    }

    void OnDestroy()
    {
        if (_material != null)
        {
            Destroy(_material);
            _material = null;
        }
    }
}
