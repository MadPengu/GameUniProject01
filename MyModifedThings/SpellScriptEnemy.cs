using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScriptEnemy : MonoBehaviour
{

    private int damage;

    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponentInParent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
