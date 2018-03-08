using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    protected float speed;
    protected Vector2 direction;
    private Rigidbody2D myRigidbody;
    protected Animator myAnimator;
    protected bool isAttacking;
    protected Coroutine attackRoutine;
    // Use this for initialization

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    protected virtual void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

   

    //// Update is called once per frame
    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    } 

    public void HandleLayers()
    {
        if (IsMoving)
        {
            
            ActivateLayer("WalkLayer");
            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
            StopAttack();
        }
        else if (isAttacking)
        {
            ActivateLayer("AttackLayer");
        }
        else
        {
            ActivateLayer("IdleLayer");
        }
    }

    public void Move()
    {
        myRigidbody.velocity = direction.normalized * speed;
        AnimateMovement(direction);
    }
    public void AnimateMovement(Vector2 direction)
    {
        myAnimator.SetLayerWeight(1, 1);
        myAnimator.SetFloat("x", direction.x);
        myAnimator.SetFloat("y", direction.y);
    } 

    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }
        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
   
    }
    public void StopAttack()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isAttacking = false;
            myAnimator.SetBool("attack", isAttacking);
        }
    }

}
 
