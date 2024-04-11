using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class PlayerMagneticTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		ItemCollactableBase i = other.transform.GetComponent<ItemCollactableCoin>();
		if (i != null)
		{
			i.gameObject.AddComponent<Magnetic>();

		}

	}

}
