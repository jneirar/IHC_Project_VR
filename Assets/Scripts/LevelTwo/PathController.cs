using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public GameObject obj;
    public GameObject[] pathPoints;
    public float speed = 2.0f;

    private int numberOfPoints = 0;
    private Vector3 actualPosition;
    private int x;
    
    void Start()
    {
        numberOfPoints = pathPoints.Length;
        x = 0;
    }

    void Update()
    {
        actualPosition = obj.transform.position;
        obj.transform.position = Vector3.MoveTowards(actualPosition, pathPoints[x].transform.position, speed * Time.deltaTime);

        if(actualPosition == pathPoints[x].transform.position && x != numberOfPoints - 1)
        {
            // Modify the rotation of the object
            obj.transform.rotation = Quaternion.LookRotation(pathPoints[x + 1].transform.position - pathPoints[x].transform.position);
            x++;
        }
    }
}
