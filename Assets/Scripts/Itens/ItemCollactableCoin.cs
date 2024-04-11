using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class ItemCollactableCoin : ItemCollactableBase

{
    public Collider _collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;



    private void Start()
    {
       // CoinsAnimationManager.Instance.RegisterCoins(this);
    }


    protected override void OnCollect()
    {
        base.OnCollect();
        _collider.enabled = false;
        collect = true;
        //PlayerController.Instance.BounceItem();


        ItemManager.Instance.AddByType(ItemType.COIN);
    }

    protected override void Collect()
    {
        OnCollect();
    }
    private void Update()
    {
        if (collect)
        {
            /*transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                HideObject();
                Destroy(gameObject);
            } */
        }
    }
}


