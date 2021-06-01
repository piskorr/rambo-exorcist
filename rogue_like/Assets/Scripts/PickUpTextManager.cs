using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpTextManager : MonoBehaviour
{

    public Text pickUpWeaponText;
    public Text shopText;

    // Start is called before the first frame update
    void Start()
    {
        pickUpWeaponText.gameObject.SetActive(false);
        shopText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Weapon") || collision.tag.Equals("Grenade"))
        {
            pickUpWeaponText.gameObject.SetActive(true);
        }
        else if (collision.tag.Equals("Shop"))
        {
            pickUpWeaponText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Weapon") || collision.tag.Equals("Grenade"))
        {
            pickUpWeaponText.gameObject.SetActive(false);
        }
        else if (collision.tag.Equals("Shop"))
        {
            pickUpWeaponText.gameObject.SetActive(true);
        }
    }
}
