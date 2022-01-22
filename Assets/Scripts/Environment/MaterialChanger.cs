using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialChanger : MonoBehaviour
{
    private MeshRenderer _renderer;
    private MaterialManager _materialManager;

    private Shader _initialShader;
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _materialManager = GameObject.Find("MaterialManager").GetComponent<MaterialManager>();
    }

    private void Start()
    {
        _initialShader = _renderer.material.shader;
    }

    public void SetHighlight(bool toggle)
    {
        if (toggle)
            _renderer.material.shader = _materialManager.HighlightShader;
        else
            _renderer.material.shader = _initialShader;
    }
    
    
}
