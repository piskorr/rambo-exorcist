using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Vector2 roomSize;
    public GameObject roomType;
    public int special = 0;
    public int enemyMaxNumber;
    public int enemyMinNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void drawRoom()
    {
        roomType.GetComponent<RoomEnemySpawner>().enemyMaxNumber = enemyMaxNumber;
        roomType.GetComponent<RoomEnemySpawner>().enemyMinNumber = enemyMinNumber;

        roomType = Instantiate(roomType,gameObject.transform);
    }
}
