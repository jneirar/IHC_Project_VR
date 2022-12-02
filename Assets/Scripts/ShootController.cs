using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    public Hand hand;

    //private AudioSource audioSource;
        
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            if(hand == Hand.Left)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
                {
                    simpleShoot.StartShoot();
                    //audioSource.Play();
                }
            }
            else if(hand == Hand.Right)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
                {
                    simpleShoot.StartShoot();
                    //audioSource.Play();
                }
            }
        }
    }
}

public enum Hand{
    Left,
    Right
}