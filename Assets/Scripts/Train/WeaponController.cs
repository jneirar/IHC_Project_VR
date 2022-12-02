using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Array of GameObjects
    public GameObject[] _weapons;
    public GameObject[] _selectors;
    public GameObject laserpointer;

    private int currentWeapon = 0;
    private int n_weapons = 0;

    void Awake()
    {
        n_weapons = _weapons.Length;
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.A))
        {
            SelectNextWeapon();
        }
        else if(OVRInput.GetDown(OVRInput.RawButton.B))
        {
            SelectPreviousWeapon();
        }
    }

    void SelectNextWeapon()
    {
        _weapons[currentWeapon].SetActive(false);
        if(_selectors.Length > 0)
            _selectors[currentWeapon].SetActive(false);
        
        currentWeapon = (currentWeapon + 1) % n_weapons;
        
        _weapons[currentWeapon].SetActive(true);
        if(_selectors.Length > 0)
            _selectors[currentWeapon].SetActive(true);
        
        laserPointerManager();
    }

    void SelectPreviousWeapon()
    {
        _weapons[currentWeapon].SetActive(false);
        if(_selectors.Length > 0)
            _selectors[currentWeapon].SetActive(false);
        
        currentWeapon = (currentWeapon - 1) % n_weapons;
        if(currentWeapon < 0)
            currentWeapon = n_weapons - 1;

        _weapons[currentWeapon].SetActive(true);
        if(_selectors.Length > 0)
            _selectors[currentWeapon].SetActive(true);
        
        laserPointerManager();
    }

    void laserPointerManager()
    {
        if(laserpointer != null)
        {
            if(currentWeapon == 0)
                laserpointer.SetActive(true);
            else
                laserpointer.SetActive(false);
        }
    }
}
