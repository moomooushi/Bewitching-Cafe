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
        [SerializeField] private GameObject catching;
        

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
        if (Input.GetMouseButtonDown(0) && catching.activeSelf)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, catchingLayers);
            if (hit && hit.transform.name.Contains("Toad"))
            {
                print("you found a Toad!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Toad");
                catchingAudioSource[1].Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, -3), Quaternion.identity);
                StartCoroutine(CaughtCritter(.3f, hit.transform.gameObject, hit.transform.GetComponent<SpriteRenderer>()));
            }
            else if (hit && hit.transform.name.Contains("Toxic Butterfly"))
            {
                print("you found a Toxic Butterfly!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Toxic Butterfly");
                catchingAudioSource[1].Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, -3), Quaternion.identity);
                StartCoroutine(CaughtCritter(.3f, hit.transform.gameObject, hit.transform.GetComponent<SpriteRenderer>()));
            }
            else if (hit && hit.transform.name.Contains("Beetle"))
            {
                print("you found a Beetle!");
                inventoryManager.GetComponent<Inventory>().IncreaseIngredient("Beetle");
                catchingAudioSource[1].Play();
                Instantiate(poof, new Vector3(hit.transform.position.x, hit.transform.position.y, -3), Quaternion.identity);
                StartCoroutine(CaughtCritter(.3f, hit.transform.gameObject, hit.transform.GetComponent<SpriteRenderer>()));
            }
        }

    }
    
    IEnumerator CaughtCritter(float duration, GameObject critterGO, SpriteRenderer _sr)
    {
        float progress = 0;
        var color = _sr.color;
        while (progress < 1)
        {
            progress += Time.deltaTime / duration;
            var transparency = Color.Lerp(new Color(1,1,1,1), new Color(1,1,1,0), progress);
            _sr.color = transparency;
            Debug.Log(_sr.color.a);
            // critterGO.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        Destroy(critterGO);
    }
}
