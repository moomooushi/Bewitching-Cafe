using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Critters;

public class CritterSpawn : MonoBehaviour
{
    [SerializeField] GameObject critterPrefab;
    [SerializeField] Vector2 spawnPos = new Vector2(9.57f, -4.58f);
    [SerializeField] float critterSpeed;

    [SerializeField] private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCritters", 1, 200);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCritters() {
        critterSpeed = Random.Range(5, 10);
        float step = critterSpeed * Time.deltaTime;
        Instantiate(critterPrefab, spawnPos, Quaternion.identity);
        critterPrefab.transform.position = Vector2.MoveTowards(critterPrefab.transform.position, target.transform.position, step);
    }
}
