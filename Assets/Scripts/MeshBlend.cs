using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBlend : MonoBehaviour
{
    [SerializeField]
    private int _fpsNeeded;

    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private Mesh _skinnedMesh;
    private int _blendShapeCount;

    private int _playIndex;

    void Start()
    {
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        _skinnedMesh = _skinnedMeshRenderer.sharedMesh;
        _blendShapeCount = _skinnedMesh.blendShapeCount;
        StartCoroutine(AnimFrame());
    }

    // Update is called once per frame
    void Update()
    {
       /* if (_playIndex > 0)
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(_playIndex - 1, 0);
        }
        
        if (_playIndex == 0)
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(_blendShapeCount - 1, 0);
        }

        _skinnedMeshRenderer.SetBlendShapeWeight(_playIndex, 100);
        _playIndex++;

        if (_playIndex > _blendShapeCount - 1)
        {
            _playIndex = 0;
        }*/
    }

    private IEnumerator AnimFrame()
    {
        for(int i = 0; i < _blendShapeCount; i++)
        {
            if (_playIndex > 0)
            {
                _skinnedMeshRenderer.SetBlendShapeWeight(_playIndex - 1, 0);
            }

            if (_playIndex == 0)
            {
                _skinnedMeshRenderer.SetBlendShapeWeight(_blendShapeCount - 1, 0);
            }

            _skinnedMeshRenderer.SetBlendShapeWeight(_playIndex, 100);
            _playIndex++;

            if (_playIndex > _blendShapeCount - 1)
            {
                _playIndex = 0;
            }
            yield return new WaitForSeconds(1 / _fpsNeeded);
        }

        StartCoroutine(AnimFrame());
    }
}
