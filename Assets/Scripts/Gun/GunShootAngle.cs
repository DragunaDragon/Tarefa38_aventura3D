using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GunShootAngle : GunShootLimit

{

	public int amountPerShoot = 4;
	public float angle = 15f;

	public override void Shoot()
	{

		int mult = 0;

		for (int i = 0; i < amountPerShoot; i++)
		{
			float time = 0;
			if (i % 2 == 0)
			{
				mult++;
			}
			var projectile = Instantiate(prefabProjectile, positionToShoot);

			projectile.transform.localPosition = Vector3.zero;
			projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;

			projectile.speed = speed;
			projectile.transform.parent = null;
			uiGunUpdaters.ForEach(i => i.UpdateValue(time / timeToRecharge));
		}
	}

	

}
