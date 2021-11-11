using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour
{
    public Plot plot;
    public Transform prefab;
    public float spawnSpeed = 3f;
    float spawnTimer = 0;
    private void Update()
    {
        if (!plot.plotStarted)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnSpeed)
            {
                spawnTimer = 0;
                Instantiate(prefab, new Vector3(Random.Range(-2.0f, 2.0f), 5.5f, 0), Quaternion.Euler(0, 0, Random.Range(0, 360)), transform);
            }
            
        }

    }   
        
        
}
