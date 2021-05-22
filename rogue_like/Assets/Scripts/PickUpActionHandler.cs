using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpActionHandler : MonoBehaviour
{
    public GameObject weaponPrefab;

    [SerializeField]
    private Text pickUpText;
    private WeaponHolderController weaponHolderController;
    private bool pickUpAllowed;


    void Start()
    {
        weaponHolderController = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponHolderController>();
        pickUpText.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;

            if (weaponHolderController.AddWeapon(weaponPrefab))
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
}
