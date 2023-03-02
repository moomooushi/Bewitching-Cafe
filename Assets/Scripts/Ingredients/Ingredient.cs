using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.U2D.Path;
using UnityEngine;
using ScriptableObjects.Ingredients;
using DG.Tweening;
using Events;
using Interfaces;
using Object = UnityEngine.Object;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour, IDestroyable
    {
        // Start is called before the first frame update
        // [field: SerializeField] public IngredientData Data { get; private set; }
        [SerializeField] private IngredientData ingredientData;

        [Header("Sprite Settings")] [ReadOnly] 
        public SpriteRenderer spriteRenderer;

        public PolygonCollider2D polyCollider;
        [SerializeField] private GameObject particleOnDestroy;
        [field:SerializeField] float animationFadeOutTime { get; set; }

        public IngredientData IngredientData
        {
            get => ingredientData;
            set => ingredientData = value;
        }

        private void Awake()
        {
            UpdateValues();
            // THIS DESTROY IS VERY TEMPORARY. REMOVE FOR NEXT TEST
            Destroy(this.gameObject, 7f);
        }

        private void OnValidate()
        {
            UpdateValues();
        }

        // private void Update() 
        // {
        //     if (gameObject.transform.position.y < -3) 
        //     {
        //         Destroy(gameObject);
        //     }
        // }

        void UpdateValues()
        {
            UpdateColliders();
            UpdateSpriteRenderer(ingredientData);
        }

        private void UpdateColliders()
        {
            polyCollider = GetComponent<PolygonCollider2D>();

            if (polyCollider = null) // If there is no poly collider, attach it onto the prefab
            {
                _ = gameObject.AddComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;
                Debug.Log("Added polygon collider");
            }
        }

        private void UpdateSpriteRenderer(IngredientData data)
        {
            if (GetComponent<SpriteRenderer>()) 
                spriteRenderer = GetComponent<SpriteRenderer>();
            else // if not spriterenderer add one
            {
                spriteRenderer = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            }

            if (spriteRenderer != null) // If no sprite, add a sprite from the ingredient data
                spriteRenderer.sprite = data.sprite;
        }

        public IEnumerator DoDelayedDestroy() // overrides the enumerator in IDestroyable so this plays
        {
            yield return new WaitForSeconds(0.5f); // nothing for .5s
            // Instantiate a particle on the same position as the prefab
            var particle = Instantiate(particleOnDestroy, this.transform.position, Quaternion.identity);
            Debug.Log("Particle instantiated");
            this.transform.DOScale(Vector3.zero, animationFadeOutTime); // Vector3 for where particle will spawn
            spriteRenderer.DOFade(0, animationFadeOutTime); // fade after sometime
            Destroy(particle, 2f); // destroy the particle after 2s
            Destroy(this.gameObject);
        }



        public void DoDestroy() // Overrides the function in IDestroyable so this plays
        {
            StartCoroutine(DoDelayedDestroy());
        }

        // private void OnDestroy() // Calls the IngredientDestroyEvent 
        // {
        //     GameEvents.OnIngredientDestroyedEvent?.Invoke();
        // }
    }
}
