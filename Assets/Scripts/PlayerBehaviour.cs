using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    Animator animator;


    public Transform attackPoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}