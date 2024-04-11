using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GunShootLimit : GunBase
{
	public List<UIFillUpdate> uiGunUpdaters;

	public float maxShoot = 5f;
	public float timeToRecharge = 1f;

	private float _currentShoots;
	private bool _recharging = false;


	private void Awake()
	{
		GetALLUIs();
	}

	

	protected override IEnumerator ShootCoroutine()
	{

		float time = 0;
		if (_recharging) yield break;

		while (true)
		{
			if (_currentShoots < maxShoot)
			{
				Shoot();
				_currentShoots++;
				CheckRecharge();
				UpdateUI();
				uiGunUpdaters.ForEach(i => i.UpdateValue(time / timeToRecharge));
				yield return new WaitForSeconds(timeBetweenShoot);
			}
		}
	}



	private void CheckRecharge()
	{
		if (_currentShoots >= maxShoot)
		{
			StopShoot();
			StartRecharge();
		}
	}

	
	private void StartRecharge()
	{
		_recharging = true;
		StartCoroutine(RechargeCoroutine());
	}


	IEnumerator RechargeCoroutine()
	{
		float time = 0;
		while (time < timeToRecharge)
		{
			time += Time.deltaTime;
			Debug.Log("Rechargin:" + time);
			yield return new WaitForEndOfFrame();
		}

		_currentShoots = 0;
		_recharging = false;
	}


	private void UpdateUI()
	{
		uiGunUpdaters.ForEach(i => i.UpdateValue(maxShoot, _currentShoots));
	}

	private void GetALLUIs()
	{
		uiGunUpdaters = GameObject.FindObjectsOfType<UIFillUpdate>().ToList();
	} 

	

}
