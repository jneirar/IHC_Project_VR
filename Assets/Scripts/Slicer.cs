using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{
    public Material materialAfterSlice;
    public LayerMask sliceMask;
    public bool isTouched;
    public GameObject handController;

    public ScoreManagerTrain scoreManagerTrain;
    public ScoreManagerLevelOne scoreManagerLevelOne;

    public GameObject score10;
    public GameObject score15;
    public GameObject score20;
    public float scaleScore = 0.5f;

    public AudioSource audioSource;
    public AudioSource audioSource2;

    private void Update()
    {
        if (isTouched == true)
        {
            isTouched = false;

            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                if(objectToBeSliced.gameObject == null)
                    continue;

                double vol = objectToBeSliced.GetComponent<MeshFilter>().mesh.bounds.size.x * objectToBeSliced.GetComponent<MeshFilter>().mesh.bounds.size.y * objectToBeSliced.GetComponent<MeshFilter>().mesh.bounds.size.z;
                Vector3 posObjectToBeSliced = objectToBeSliced.transform.position;

                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);

                if (slicedObject == null)
                    continue;

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                // Only one cut
                // upperHullGameobject.layer = LayerMask.NameToLayer("Sliceable");
                // lowerHullGameobject.layer = LayerMask.NameToLayer("Sliceable");

                Destroy(objectToBeSliced.gameObject);

                Destroy(upperHullGameobject, 2f);
                Destroy(lowerHullGameobject, 2f);

                // get volume of the upper
                double volU = upperHullGameobject.GetComponent<MeshFilter>().mesh.bounds.size.x * upperHullGameobject.GetComponent<MeshFilter>().mesh.bounds.size.y * upperHullGameobject.GetComponent<MeshFilter>().mesh.bounds.size.z;
                double volL = lowerHullGameobject.GetComponent<MeshFilter>().mesh.bounds.size.x * lowerHullGameobject.GetComponent<MeshFilter>().mesh.bounds.size.y * lowerHullGameobject.GetComponent<MeshFilter>().mesh.bounds.size.z;
                // absolute diff double
                double diff = System.Math.Abs(volU - volL);
                double porc = 1.0 - diff / vol;
                int score = 10;
                if(porc > 0.75)
                    score += 10;
                else if(porc > 0.5)
                    score += 5;

                if(scoreManagerTrain != null)
                    scoreManagerTrain.AddScore(score);
                
                if(scoreManagerLevelOne != null)
                    scoreManagerLevelOne.AddScore(score);

                if(score == 10)
                {
                    GameObject score10Instance = Instantiate(score10, posObjectToBeSliced, Quaternion.identity);
                    //GameObject score10Instance = Instantiate(score10, handController.transform.position, Quaternion.identity);
                    score10Instance.transform.localScale = new Vector3(scaleScore, scaleScore, scaleScore);
                    Destroy(score10Instance, 1f);
                }
                else if(score == 15)
                {
                    GameObject score15Instance = Instantiate(score15, posObjectToBeSliced, Quaternion.identity);
                    //GameObject score15Instance = Instantiate(score15, handController.transform.position, Quaternion.identity);
                    score15Instance.transform.localScale = new Vector3(scaleScore, scaleScore, scaleScore);
                    Destroy(score15Instance, 1f);
                }
                else if(score == 20)
                {
                    GameObject score20Instance = Instantiate(score20, posObjectToBeSliced, Quaternion.identity);
                    //GameObject score20Instance = Instantiate(score20, handController.transform.position, Quaternion.identity);
                    score20Instance.transform.localScale = new Vector3(scaleScore, scaleScore, scaleScore);
                    Destroy(score20Instance, 1f);
                }
                int random = Random.Range(0, 2);
                if(random == 0)
                    audioSource.Play();
                else
                    audioSource2.Play();
            }
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}
