using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.U2D.Path;
using UnityEngine;
using ScriptableObjects.Ingredients;
using DG.Tweening;
using Events;

namespace Ingredients
{
    public class Ingredient : Destroyable
    {
        // Start is called before the first frame update
        // [field: SerializeField] public IngredientData Data { get; private set; }
        [SerializeField] private IngredientData ingredientData;

        [Header("Sprite Settings")] [ReadOnly] 
        public SpriteRenderer spriteRenderer;

        public PolygonCollider2D polyCollider;

        public IngredientData IngredientData
        {
            get => ingredientData;
            set => ingredientData = value;
        }

        private void Awake()
        {
            UpdateValues();
        }

        private void OnValidate()
        {
            UpdateValues();
        }

        void UpdateValues()
        {
            UpdateColliders();
            UpdateSpriteRenderer(ingredientData);
        }

        private void UpdateColliders()
        {
            polyCollider = GetComponent<PolygonCollider2D>();

            if (polyCollider = null)
            {
                _ = gameObject.AddComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;
                Debug.Log("Added polygon collider");
            }
        }

        private void UpdateSpriteRenderer(IngredientData data)
        {
            if (GetComponent<SpriteRenderer>())
                spriteRenderer = GetComponent<SpriteRenderer>();
            else
            {
                spriteRenderer = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            }

            if (spriteRenderer != null)
                spriteRenderer.sprite = data.sprite;
        }

        public override IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(0.5f);
            var particle = Instantiate((particleOnDestroy, this.transform.position, Quaternion.identity));
            Debug.Log("Particle instantiated");
            this.transform.DOScale(Vector3.zero, animationFadeOutTime);
            spriteRenderer.DOFade(0, animationFadeOutTime);
            Destroy(particle, 2f);
        }

        public override void DoDestroy()
        {
            StartCoroutine(DelayedDestroy());
        }

        private void OnDestroy()
        {
            GameEvents.OnIngredientDestroyedEvent?.Invoke();
        }
    }
}
