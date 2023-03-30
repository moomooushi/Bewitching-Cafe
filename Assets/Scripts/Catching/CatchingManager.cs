using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingManager : MonoBehaviour
{
        [SerializeField] GameObject poof;

        [SerializeField] GameObject inventoryManager;

        [SerializeField] LayerMask catchingLayers;

        [SerializeField] AudioSource[] catchingAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, catchingLayers);
            if (hit && hit.transform.name.Contains("Toad"))
            {
                print("you found a Toad!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Toad");
                catchingAudioSource[1].Play();
                Destroy(hit.transform.gameObject);
            }
            else if (hit && hit.transform.name.Contains("Toxic Butterfly"))
            {
                print("you found a Toxic Butterfly!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Toxic Butterfly");
                catchingAudioSource[1].Play();
                Destroy(hit.transform.gameObject);

            }
            else if (hit && hit.transform.name.Contains("Beetle"))
            {
                print("you found a Beetle!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Beetle");
                catchingAudioSource[1].Play();
                Destroy(hit.transform.gameObject);
            }
        }

    }
}
