using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    public Rigidbody2D projectile;
    public Transform gunPosition;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)){
            Rigidbody2D bulletInstance = Instantiate(projectile, gunPosition.position, Quaternion.identity) as Rigidbody2D;
            bulletInstance.velocity = gunPosition.TransformDirection(Vector2.up * 20);
        }
    }
}
