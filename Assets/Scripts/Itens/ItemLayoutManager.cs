using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Items
{

	public class ItemLayoutManager : MonoBehaviour
	{
		public ItemLayout prefabLayout;
		public Transform container;

		public List<ItemLayout> itemLayouts;

		public void Start()
		{
			CreateItens();
		}

		private void CreateItens()
		{
			foreach (var setup in ItemManager.Instance.itemSetups)
			{
				var item = Instantiate(prefabLayout, container);
				item.Load(setup);
				itemLayouts.Add(item);
			}
		}

	}


}

