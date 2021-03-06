using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTextScript : MonoBehaviour
{

    public Text interactionText;


    // Start is called before the first frame update
    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Interact") )
        {
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Interact"))
        {
            interactionText.gameObject.SetActive(false);
        }   
    }
}
