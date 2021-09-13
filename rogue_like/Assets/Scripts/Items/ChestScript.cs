using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    
    public GameObject itemPrefab;

    public bool isEmpty = false;
    public bool interactionAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (interactionAllowed && Input.GetKeyDown(KeyCode.F) && !isEmpty )
            SpawnItem();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            interactionAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            interactionAllowed = false;
        }
    }

    private void SpawnItem()
    {
        GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        item.transform.localScale = transform.localScale;
        GetComponent<Animator>()?.SetBool("IsOpen", true);
        isEmpty = true;
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

}
