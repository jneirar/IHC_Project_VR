using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{   
    public Vector3 from = new Vector3(0f, 30f, 0f);
    public Vector3 to   = new Vector3(0f, -30f, 0f);
    public float speed = 1.0f; 

    void Update()
    {
        GetComponent<Animation>().Play();
        float t = Mathf.PingPong(Time.time * speed * 2.0f, 0.5f);
        transform.eulerAngles = Vector3.Lerp (from, to, t);
    }
}
