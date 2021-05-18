using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerManager : MonoBehaviour
{

    public int offset = 0;
    private Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.sortingOrder = offset + (int) (renderer.transform.position.y * (-100));
    }
}
