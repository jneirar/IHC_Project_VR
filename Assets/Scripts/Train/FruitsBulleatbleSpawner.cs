using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsBulleatbleSpawner : MonoBehaviour
{
    public GameObject[] fruits;

    private GameObject[] fruitsSpawned;
    private int n_fruits = 0;
    private int n_respawned = 5;
    private Vector3 min;
    private Vector3 max;
    private float minScale = 1.5f;
    private float maxScale = 3f;
    
    void Start()
    {
        n_fruits = fruits.Length;
        fruitsSpawned = new GameObject[n_respawned];

        // get corners of the zone
        min = new Vector3(-6.152f, 5.73f, -30.56f);
        max = new Vector3(6.25f, 13.37f, -22.03f);

        // Instanciate 5 fruits in random position
        for(int i = 0; i < n_respawned; i++)
        {    
            // get random position inside the zone
            Vector3 randomPos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
            
            int fruitIndex = Random.Range(0, n_fruits);
            fruitsSpawned[i] = Instantiate(fruits[fruitIndex], randomPos, Quaternion.identity);
            fruitsSpawned[i].layer = LayerMask.NameToLayer("Bulleatble");
            fruitsSpawned[i].GetComponent<Rigidbody>().useGravity = false;
            Vector3 scale = fruitsSpawned[i].transform.localScale;
            float randomScale = Random.Range(minScale, maxScale);
            fruitsSpawned[i].transform.localScale = new Vector3(scale.x * randomScale, scale.y * randomScale, scale.z * randomScale);
        }
    }

    void Update()
    {
        // check if 5 fruits are still in the scene
        for(int i = 0; i < n_respawned; i++)
        {
            if(fruitsSpawned[i] == null)
            {
                Vector3 randomPos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
                int fruitIndex = Random.Range(0, n_fruits);
                fruitsSpawned[i] = Instantiate(fruits[fruitIndex], randomPos, Quaternion.identity);
                fruitsSpawned[i].layer = LayerMask.NameToLayer("Bulleatble");
                fruitsSpawned[i].GetComponent<Rigidbody>().useGravity = false;
                Vector3 scale = fruitsSpawned[i].transform.localScale;
                float randomScale = Random.Range(minScale, maxScale);
                fruitsSpawned[i].transform.localScale = new Vector3(scale.x * randomScale, scale.y * randomScale, scale.z * randomScale);
            }
        }
        
    }
}
