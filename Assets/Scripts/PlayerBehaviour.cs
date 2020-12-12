using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        Vector2 movementVector;
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        

        gameObject.GetComponent<Rigidbody2D>().velocity = movementVector.normalized * speed;

        // attack
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        
    }

    void Attack()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}