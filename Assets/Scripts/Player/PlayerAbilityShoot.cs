using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
	//public List<UIGunUpdater> uIGunUpdaters;

	public GunBase gunBase;
	public Transform gunPosition;
	private GunBase _currentGun;
	public FlashColor _flashcolor;

	/*
	public GunBase gunBase1;
	private GunBase _currentGun1;
	public Transform gunPosition1; */


	protected override void Init()
	{
		base.Init();


		CreateGun();
		//CreateGun1();

		//inputs.CharacterControls.Shoot.performed += ctx => StartShoot();
		//inputs.CharacterControls.Shoot.canceled += ctx => CancelShoot();
	}


	private void CreateGun()
	{
		_currentGun = Instantiate(gunBase, gunPosition);

		_currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;

		inputs.CharacterControls.Shoot.performed += ctx => StartShoot();
		inputs.CharacterControls.Shoot.canceled += ctx => CancelShoot();
		//inputs.CharacterControls.Gun1.performed += ctx => StartShoot();
	//	inputs.CharacterControls.Gun1.canceled += ctx => CancelShoot();
	}


	private void StartShoot()
	{
		_currentGun.StartShoot();
		_flashcolor?.Flash();
		//Debug.Log("Start Shoot");
	}


	private void CancelShoot()
	{
		//Debug.Log("Cancel Shoot");
		_currentGun.StopShoot();
	}

	
	/* 
	private void CreateGun1()
	{
		_currentGun1 = Instantiate(gunBase1, gunPosition1);

		_currentGun1.transform.localPosition = _currentGun1.transform.localEulerAngles = Vector3.zero;

		inputs.CharacterControls.Gun2.performed += ctx => StartShoot1();
		inputs.CharacterControls.Gun2.canceled += ctx => CancelShoot1();
	}

	private void StartShoot1()
	{
		_currentGun1.StartShoot();
	}

	private void CancelShoot1()
    {
		_currentGun1.StopShoot();
	} */

}
