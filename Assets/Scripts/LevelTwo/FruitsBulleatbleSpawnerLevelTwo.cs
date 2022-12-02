using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsBulleatbleSpawnerLevelTwo : MonoBehaviour
{
    public GameObject[] fruits;

    private GameObject[] fruitsSpawned;
    private GameObject[] fruitsSpawned2;
    private int n_fruits = 0;
    private int n_respawned = 30;
    private Vector3 min;
    private Vector3 max;
    private Vector3 min2;
    private Vector3 max2;
    private float minScale = 1.5f;
    private float maxScale = 3f;
    
    void Start()
    {
        n_fruits = fruits.Length;
        fruitsSpawned = new GameObject[n_respawned];
        fruitsSpawned2 = new GameObject[n_respawned];

        // get corners of the zone
        min = new Vector3(256.665f, 9.55f, 381.41f);
        max = new Vector3(351.32f, 22.37f, 409.89f);
        
        min2 = new Vector3(262.168f, 9.504f, 407.717f);
        max2 = new Vector3(356.4f, 22.43f, 435.865f);

        // Instanciate n fruits in random position
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

        // Instanciate n fruits in random position
        for(int i = 0; i < n_respawned; i++)
        {    
            // get random position inside the zone
            Vector3 randomPos = new Vector3(Random.Range(min2.x, max2.x), Random.Range(min2.y, max2.y), Random.Range(min2.z, max2.z));
            
            int fruitIndex = Random.Range(0, n_fruits);
            fruitsSpawned2[i] = Instantiate(fruits[fruitIndex], randomPos, Quaternion.identity);
            fruitsSpawned2[i].layer = LayerMask.NameToLayer("Bulleatble");
            fruitsSpawned2[i].GetComponent<Rigidbody>().useGravity = false;
            Vector3 scale = fruitsSpawned2[i].transform.localScale;
            float randomScale = Random.Range(minScale, maxScale);
            fruitsSpawned2[i].transform.localScale = new Vector3(scale.x * randomScale, scale.y * randomScale, scale.z * randomScale);
        }
    }

    void Update()
    {
        // check if n fruits are still in the scene
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
        // check if n fruits are still in the scene
        for(int i = 0; i < n_respawned; i++)
        {
            if(fruitsSpawned2[i] == null)
            {
                Vector3 randomPos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
                int fruitIndex = Random.Range(0, n_fruits);
                fruitsSpawned2[i] = Instantiate(fruits[fruitIndex], randomPos, Quaternion.identity);
                fruitsSpawned2[i].layer = LayerMask.NameToLayer("Bulleatble");
                fruitsSpawned2[i].GetComponent<Rigidbody>().useGravity = false;
                Vector3 scale = fruitsSpawned2[i].transform.localScale;
                float randomScale = Random.Range(minScale, maxScale);
                fruitsSpawned2[i].transform.localScale = new Vector3(scale.x * randomScale, scale.y * randomScale, scale.z * randomScale);
            }
        }
    }
}
