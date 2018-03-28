using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {


    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" )
        {
            col.GetComponentInParent<Character>().TakeDamage(GetComponentInParent<Enemy>().Damage);
        }else if (col.tag == "Enemy")
            col.GetComponentInParent<Character>().TakeDamage(GetComponentInParent<PlayerController>().Damage);
        }
    }

