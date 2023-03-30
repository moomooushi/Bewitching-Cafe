using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingManager : MonoBehaviour
{
        [SerializeField] GameObject poof;

        [SerializeField] GameObject inventoryManager;

        [SerializeField] LayerMask catchingLayers;

        [SerializeField] AudioSource[] catchingAudioSource;

        [SerializeField] private GameObject butterflies;
        [SerializeField] private GameObject toads;
        [SerializeField] private GameObject beetles;

    // Start is called before the first frame update
    public void SpawnCatchables() {
        for (int i = 0; i < Random.Range(1, 5); i++) {
            Debug.Log("Spawned butterflies");
            Instantiate(butterflies, new Vector3(Random.Range(-8.88f, 8.5f), Random.Range(1.3f, 3.9f), 0), Quaternion.identity);
        }
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            Debug.Log("Spawned toads");
            Instantiate(toads, new Vector3(Random.Range(-8.19f, 8.33f), -4.24f, 0), Quaternion.identity);
        }
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            Debug.Log("Spawned beetles");
            Instantiate(beetles, new Vector3(Random.Range(-8.9f, 8.9f), -0.68f, 0), Quaternion.identity);
        }
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
