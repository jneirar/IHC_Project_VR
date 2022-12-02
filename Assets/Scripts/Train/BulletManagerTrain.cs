using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerTrain : MonoBehaviour
{   
    public GameObject score10;
    public GameObject score15;
    public GameObject score20;
    public float scale = 0.3f;

    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        // Layer name of other
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName == "Bulleatble")
        {
            Vector3 centerOther = other.bounds.center;
            Vector3 centerThis = GetComponent<Collider>().bounds.center;
            // maxDistance is the sum of the radius of the two objects
            float maxDistance = other.bounds.extents.magnitude + GetComponent<Collider>().bounds.extents.magnitude;
            // distance from the impact point to the center of the other object
            float distance = Vector3.Distance(centerOther, centerThis);
            int score = 10;
            if (distance < 0.5f * maxDistance)
            {
                score += 10;
                GameObject score10Instance = Instantiate(score10, other.transform.position, Quaternion.identity);
                score10Instance.transform.localScale = new Vector3(scale, scale, scale);
                Destroy(score10Instance, 1f);
            }
            else if (distance < 0.75f * maxDistance)
            {
                score += 5;
                GameObject score15Instance = Instantiate(score15, other.transform.position, Quaternion.identity);
                score15Instance.transform.localScale = new Vector3(scale, scale, scale);
                Destroy(score15Instance, 1f);
            }
            else
            {
                GameObject score20Instance = Instantiate(score20, other.transform.position, Quaternion.identity);
                score20Instance.transform.localScale = new Vector3(scale, scale, scale);
                Destroy(score20Instance, 1f);
            }
            audioSource.Play();
            ScoreTrainSingleton.Instance.addToScore(score);
            // change layer name
            other.gameObject.layer = LayerMask.NameToLayer("Default");
            Destroy(other.gameObject);
        }
    }
}
