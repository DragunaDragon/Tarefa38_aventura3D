using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



namespace Items
{


	public class ItemLayout : MonoBehaviour
	{
		public ItemSetup _currSetups;
		public Image uiIcon;
		public TextMeshProUGUI uiValue;



		public void Load(ItemSetup setup)
		{
			_currSetups = setup;
			UpdateUI();
		}

		private void UpdateUI()
		{
			uiIcon.sprite = _currSetups.icon;
		}

		private void Update()
		{
			uiValue.text = _currSetups.soInt.value.ToString();
			
		}

	}

}


