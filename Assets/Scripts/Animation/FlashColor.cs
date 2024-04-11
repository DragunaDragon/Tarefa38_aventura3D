using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
	public MeshRenderer meshRenderer;
	public SkinnedMeshRenderer skinneMeshRenderer;


	[Header("Setup")]
	public Color color = Color.red;
	public float duration = .1f;


    private Tween _currTween;

	public string colorParameter = "_EmissionColor";
    
	private void OnValidate()
	{
		if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
		
		if (skinneMeshRenderer == null) skinneMeshRenderer = GetComponent<SkinnedMeshRenderer>();
		
	} 


    [NaughtyAttributes.Button]

	public void Flash()
	{
		if (meshRenderer !=null && !_currTween.IsActive())
		_currTween = meshRenderer.material.DOColor(color, colorParameter, duration).SetLoops(2, LoopType.Yoyo);


		if (skinneMeshRenderer != null && !_currTween.IsActive()) 
		_currTween = skinneMeshRenderer.material.DOColor(color, colorParameter, duration).SetLoops(2, LoopType.Yoyo);
	}

}
