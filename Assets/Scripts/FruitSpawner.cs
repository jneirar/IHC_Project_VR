using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits;
    bool isTimeOver = true;
    public int forceMin;
    public int forceMax;
    public bool laterals = false;

    void Update()
    {
        if(isTimeOver == true)
        {
            StartCoroutine("SpawnFruit");
        }
    
    }
    IEnumerator SpawnFruit()
    {
        isTimeOver = false;
        // Randomly select a fruit from the array
        int index = Random.Range(0, fruits.Length);
        
        // Instantiate the fruit and throw it to a random direction and velocity
        GameObject fruit = Instantiate(fruits[index], transform.position, Quaternion.identity);
        
        // throw
        if(laterals)
            fruit.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-30, 30), Random.Range(forceMin, forceMax), Random.Range(-200, -150)));
        else
            fruit.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(forceMin, forceMax));
        fruit.layer = LayerMask.NameToLayer("Sliceable");
        foreach (Transform child in fruit.transform)
            child.gameObject.layer = LayerMask.NameToLayer("Sliceable");
        Destroy(fruit, 5f);

        // Wait for random seconds
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        isTimeOver = true;
    }
}
