using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int size;
    public List<GameObject> parts;
    public int spawnRateMin;
    public int spawnRateMax;
    private float nextSpawn;
    public float y;
    public float minX;
    public float maxX;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawn -= Time.deltaTime;
        if(nextSpawn < 0)
        {
            spawn();
        }
    }

    private void spawn()
    {
        int spawnID = Random.Range(0, size - 1);
        float xPos = Random.Range(minX, maxX);
        Instantiate(parts[spawnID], new Vector3(xPos, y, 0), Quaternion.identity);
        nextSpawn = Random.Range(spawnRateMin, spawnRateMax);
    }


}
