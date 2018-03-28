using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{

    private Enemy parent;

    private float attackCooldown = 2;

    private float extraRange = .2f;

    public void Enter(Enemy parent)
    {
        this.parent = parent; 
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
  

        
        if (parent.MyAttackTime >= attackCooldown && !parent.IsAttacking)
        {
  
            parent.MyAttackTime = 0;


            if (parent.Mage == false)
            {
                parent.StartCoroutine(Attack()); // Enemy parent inherits MonoBehaviour that handles coroutines 
            } else if(parent.Mage == true){
                parent.StartCoroutine(SpellAttack());
            }
        }

        if (parent.MyTarget != null) 
        {
           
            float distance = Vector2.Distance(parent.MyTarget.position, parent.transform.position);

          
            if (distance >= parent.MyAttackRange+extraRange && !parent.IsAttacking)
            {
               
                parent.ChangeState(new FollowState());
            }
       

        }
        else
        {
            parent.ChangeState(new IdleState());
        }
    }


    public IEnumerator SpellAttack() //coroutine
    {

        parent.IsAttacking = true;

        parent.AttackSpell();
        yield return new WaitForSeconds(1.4f);
   
        parent.IsAttacking = false;
  
    }

    public IEnumerator Attack() //coroutine
    {
        parent.attackTrigger.enabled = false;
        parent.IsAttacking = true;
 
        parent.MyAnimator.SetBool("attack", true);

        yield return new WaitForSeconds((parent.MyAnimator.GetCurrentAnimatorStateInfo(2).length)/2); // waits for duration of animation to attack
        parent.attackTrigger.enabled = true;
        yield return new WaitForSeconds((parent.MyAnimator.GetCurrentAnimatorStateInfo(2).length) / 2);
        parent.IsAttacking = false;
        parent.attackTrigger.enabled = false;
    }
   
}
