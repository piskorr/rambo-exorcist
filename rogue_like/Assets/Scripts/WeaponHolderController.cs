using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderController : MonoBehaviour
{

    public int totalWeaponCount = 2;
    public int maxGrenadeCount = 3;
    public GameObject grenadePrefab;
    public GameObject weaponHolder;
    public GameObject[] weapons;

    private int currentWeaponIndex;
    private int currentWeaponCount;
    private int currentGrenadeCount;
    private GameObject equippedWeapon;
    private Vector3 playerScale;


    // Start is called before the first frame update
    void Start()
    {
        weapons = new GameObject[totalWeaponCount];
        currentWeaponIndex = 0;
        currentWeaponCount = 0;
        currentGrenadeCount = 0;
        playerScale = GetComponentInParent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentGrenadeCount == 0)
        {
            if (grenadePrefab.active)
                    grenadePrefab.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.G) && currentGrenadeCount > 0)
        {
            EquipGrenade();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {  
            currentWeaponIndex = 0;
            ChangeWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
            ChangeWeapon();
        }
        
    }


    private void EquipGrenade()
    {
        DeactivateAllWeapons();
        if(currentGrenadeCount > 0)
            grenadePrefab.SetActive(true);
    }


    private void ChangeWeapon()
    {
        equippedWeapon = weapons[currentWeaponIndex];
        DeactivateOtherWeapons();

        if (grenadePrefab.active)
                    grenadePrefab.SetActive(false);


        if (weapons[currentWeaponIndex] != null)
            weapons[currentWeaponIndex].SetActive(true);
    }


    private void DeactivateOtherWeapons()
    {
        for (int i = 0; i < totalWeaponCount; i++)
        {
            if (i != currentWeaponIndex)
            {
                if (weapons[i] != null)
                {
                    weapons[i].SetActive(false);
                }

            }
        }
    }


    private void DeactivateAllWeapons()
    {
        for (int i = 0; i < totalWeaponCount; i++)
        {
            if (weapons[i] != null)
            {
                weapons[i].SetActive(false);
            }
        }
    }


    private void deleteCurrentWeapon()
    {
        Destroy(weapons[currentWeaponIndex]);
        weapons[currentWeaponIndex] = null;
    }


    public bool AddGrenade()
    {
        if(currentGrenadeCount < maxGrenadeCount)
        {
            currentGrenadeCount++;
            return true;
        }
        return false;
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
        else
        {

            GameObject pickableWeapon = weapons[currentWeaponIndex].GetComponent<ItemDropHandler>().getPickablePrefab();
            GameObject weaponPickable = Instantiate(pickableWeapon, weaponHolder.transform.position, Quaternion.identity);
            deleteCurrentWeapon();

            GameObject weapon = Instantiate(weaponPrefab, weaponHolder.transform.position, weaponHolder.transform.rotation);
            weapons[currentWeaponIndex] = weapon;
            currentWeaponCount++;

            weapon.transform.SetParent(weaponHolder.transform);
            weapon.transform.localScale = playerScale;

            weapon.SetActive(false);
            return true;

        }

        return false;
    }


    public void DecreaseGrenadeCount()
    {
        if(currentGrenadeCount > 0)
            currentGrenadeCount--;
    }


    public bool isGrenadeFull()
    {
        return currentGrenadeCount >= maxGrenadeCount;
    }
}
