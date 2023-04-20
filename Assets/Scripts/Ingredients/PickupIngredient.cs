using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIngredient : MonoBehaviour
{
    [SerializeField] GameObject inventoryManager;
    [SerializeField] GameObject poof;
    [SerializeField] LayerMask pickupLayer;
    [SerializeField] AudioSource pickupAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, pickupLayer);
            if (hit && hit.transform.name.Contains("Toad"))
            {
                print("you found a Toad!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Toad");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);
            }
            else if (hit && hit.transform.name.Contains("Toxic Butterfly"))
            {
                print("you found a Toxic Butterfly!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Toxic Butterfly");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);

            }
            else if (hit && hit.transform.name.Contains("Beetle"))
            {
                print("you found a Beetle!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Beetle");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);
            }
            else if (hit && hit.transform.name.Contains("Blueberry"))
            {
                print("you found a Blueberry!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Blueberry");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);

            }
            else if (hit && hit.transform.name.Contains("Carnelian"))
            {
                print("you found a Carnelian!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Carnelian");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);
            }
            else if (hit && hit.transform.name.Contains("Mandrake"))
            {
                print("you found a Mandrake!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Mandrake");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);

            }
            else if (hit && hit.transform.name.Contains("Mushy"))
            {
                print("you found a Mushy!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Mushy");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);
            }
            else if (hit && hit.transform.name.Contains("Rose Quartz"))
            {
                print("you found a Rose Quartz!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Rose Quartz");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);

            }
            else if (hit && hit.transform.name.Contains("Skull"))
            {
                print("you found a Skull!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Skull");
                pickupAudioSource.Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), Quaternion.identity);
                Destroy(hit.transform.gameObject);
            }

        }

    }
}
