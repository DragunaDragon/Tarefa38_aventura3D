using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace Items
{
    public class ItemCollactableBase : MonoBehaviour
    {

        public ItemType itemType;

        public string compareTag = "Player";
        public ParticleSystem particleSystemCoin;
        public float timeToHide = 3;
        public GameObject graphicItem;

        public Collider _collider;


        [Header("Sounds")]
        public AudioSource audioSource;


        private void Awake()
        {
            //if (particleSystemCoin != null) particleSystemCoin.transform.SetParent(null);
        }



        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }


        protected virtual void Collect()
        {
            if (_collider != null) _collider.enabled = false;

            if (graphicItem != null) graphicItem.SetActive(false);
            Invoke("HideObject", timeToHide);
            OnCollect();

        }


        public void HideObject()
        {
            gameObject.SetActive(false);
        }


        protected virtual void OnCollect()
        {
            if (particleSystemCoin != null) particleSystemCoin.Play();
             if (audioSource != null) audioSource.Play();
             ItemManager.Instance.AddByType(itemType);
            

        }



      

      

        
    }




}
