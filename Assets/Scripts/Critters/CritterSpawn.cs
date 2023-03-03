using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterSpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnArea;
    [SerializeField] private GameObject spiderPrefab;

    private Vector2 spawnCoords = new Vector2(); // change ALL of this to scriptable objects






    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCritters", 1, 20);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCritters() {

        Instantiate(spiderPrefab, spawnArea);
    }
}
