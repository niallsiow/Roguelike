using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public float health;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageValue)
    {
        health = health - damageValue;
        if(health <= 0)
        {
            if(gameObject.tag == "Enemy")
            {
                for(int i = 0; i < References.enemies.Count; i++)
                {
                    if(References.enemies[i].transform.position == transform.position)
                    {
                        References.enemies.RemoveAt(i);
                    }
                }
            }

            
            Destroy(gameObject);
        }
    }
}
