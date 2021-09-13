using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderController : MonoBehaviour
{

    public int totalWeaponCount = 2;
    public GameObject weaponHolder;
    public GameObject[] weapons;

    private int currentWeaponIndex;
    private int currentWeaponCount;
    private GameObject equippedWeapon;
    private Vector3 playerScale;


    // Start is called before the first frame update
    void Start()
    {
        weapons = new GameObject[totalWeaponCount];
        currentWeaponIndex = 0;
        currentWeaponCount = 0;
        playerScale = GetComponentInParent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
            ChangeWeapon();       
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
            ChangeWeapon();
        }        
    }


    private void ChangeWeapon()
    {
        equippedWeapon = weapons[currentWeaponIndex];
        DeactivateOtherWeapons();

        if(weapons[currentWeaponIndex] != null)
            weapons[currentWeaponIndex].SetActive(true);
    }


    private void DeactivateOtherWeapons()
    {
        for(int i = 0; i  < totalWeaponCount; i++)
        {
            if( i != currentWeaponIndex)
            {
                if(weapons[i] != null)
                {
                    weapons[i].SetActive(false);
                }
                
            }
        }
    }


    public bool PickUpWeapon(GameObject weaponPrefab)
    {
        if (currentWeaponCount < totalWeaponCount)
        {
            for (int i = 0; i < totalWeaponCount; i++)
            {
                if (weapons[i] == null)
                {
                    GameObject weapon = Instantiate(weaponPrefab, weaponHolder.transform.position, weaponHolder.transform.rotation);
                    weapons[i] = weapon;
                    currentWeaponCount++;

                    weapon.transform.SetParent(weaponHolder.transform);
                    weapon.transform.localScale = playerScale;                 

                    weapon.SetActive(false);
                    return true;
                }
            }
        }
        else{
            
        }

        return false;
    }
}
