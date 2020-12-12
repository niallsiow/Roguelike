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

        // rotate Player towards cursor position
        /*
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 diffPos = myPos - new Vector2(cursorPosition.x, cursorPosition.y);
        float rotation = Mathf.Atan2(diffPos.x, diffPos.y);
        transform.Rotate(0, 0, rotation);
        
        */
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diffPos = cursorPosition - transform.position;
        diffPos.z = 0f;
        transform.right = diffPos;

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
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.right = transform.right;
    }
}