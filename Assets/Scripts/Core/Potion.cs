using System;
using System.Collections;
using System.ComponentModel;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

namespace Core
{
    public class Potion : MonoBehaviour, IDestroyable
    {
        [SerializeField] private PotionData potionType;
        private Rigidbody2D rb;

        private SpriteRenderer sr;
        private Vector3 originalScale;
        
        [SerializeField] private GameObject particleOnDestroy;
        [field:SerializeField] float animationFadeOutTime { get; set; }

        public PotionData PotionType
        {
            get => potionType;
            set
            {
                potionType = value;
            }
        }

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            originalScale = transform.localScale;
        }

        private void OnEnable()
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.DOScale(originalScale, .5f).SetEase(Ease.OutBounce);
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        public IEnumerator DoDelayedDestroy()
        {
            yield return new WaitForSeconds(.5f);
            var particle = Instantiate(particleOnDestroy, this.transform.position, Quaternion.identity);
            Debug.Log("Particle instantiated (Potion)");
            this.transform.DOScale(Vector3.zero, animationFadeOutTime);
            sr.DOFade(0, animationFadeOutTime);
            Destroy(particle, 2f);
            Destroy(this.gameObject, 2.1f);
        }

        public void DoDestroy()
        {
            StartCoroutine(DoDelayedDestroy());
        }
    }
}
