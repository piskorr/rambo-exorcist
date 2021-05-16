using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPointController : MonoBehaviour
{
    public Camera gameCamera;
    public Transform weaponHandlerTransform;
    [SerializeField] public float angleOffset = 0f;    
    Vector3 mousePosition;
    


    void Update()
    {
        mousePosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);
    }


    void FixedUpdate()
    {
        Vector3 pointDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(pointDirection.y, pointDirection.x)*Mathf.Rad2Deg - angleOffset;
        weaponHandlerTransform.eulerAngles = new Vector3(0, 0, angle);
        

        Vector3 localScale = Vector3.one;
        if ((angle > 90.0f ||  angle < -90.0f))
		{
				localScale.y = -1f;
		}
		else 
		{
				localScale.y = +1f;
		}
        weaponHandlerTransform.localScale = localScale;
    }


    
}
