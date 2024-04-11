using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DestructableItemBase : MonoBehaviour
{
	public HealthBase healthBase;


	public float shakeDuration = .1f;
	public int shakeForce = 1;


	public int dropCoinsAmount = 10;
	public GameObject coinPrefab;
	public Transform dropPosition;


	private void OnValidate()
	{
		if (healthBase == null) healthBase = GetComponent<HealthBase>();
	}

	private void Awake()
	{
		OnValidate();
		healthBase.OnDamage += OnDamage;
	}

	private void OnDamage(HealthBase h)
	{
		Debug.Log("OnDamage");
		transform.DOShakeScale(shakeDuration, Vector3.up / 2, shakeForce);
		DropGroupCoins();
	}

	//ex drocoin

	[NaughtyAttributes.Button]
	private void DropCoins()
	{
		var i = Instantiate(coinPrefab);
		i.transform.position = dropPosition.position;
		i.transform.DOScale(0, .1f).SetEase(Ease.OutBack).From(); ;

	}


	private void DropGroupCoins()
	{
		StartCoroutine(DroupGroupCoinsCoroutine());
	}

	
	IEnumerator DroupGroupCoinsCoroutine()
	{
		for (int i = 0; i < dropCoinsAmount; i++)
		{
			DropCoins();
			yield return new WaitForSeconds(.1f);
		}
	} 

}
