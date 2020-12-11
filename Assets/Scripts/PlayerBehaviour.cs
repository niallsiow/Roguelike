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
        Vector2 movementVector;
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        

        gameObject.GetComponent<Rigidbody2D>().velocity = movementVector.normalized * speed;

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        
    }

    void Attack()
    {
        // play attack animation
        animator.SetTrigger("Attack");

        // detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.GetComponent<HealthSystem>() != null)
            {
                enemy.gameObject.GetComponent<HealthSystem>().TakeDamage(1f);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
