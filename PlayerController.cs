using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character {

    [SerializeField]
    private Stat health;
    [SerializeField]
    private Stat mana;
    private float initHealth = 100;
    private float initMana = 50;
    [SerializeField]
    private GameObject[] SpellPrefab;
    [SerializeField]
    private Block[] blocks;     
    [SerializeField]
    private Transform[] exitPoints;
    private int exitIndex;
    public Transform MyTarget { get; set; }


    protected override void Start()
    {
        health.Initialize(initHealth, initHealth);
        mana.Initialize(initMana, initMana);

        base.Start();
    }
 
	
	// Update is called once per frame
	protected override void Update () {
        GetInput();
        base.Update();
	}
    

    private void GetInput()
    {

        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            exitIndex = 0;
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            exitIndex = 3;
            direction += Vector2.left;

        } 
        if (Input.GetKey(KeyCode.S))
        {
            exitIndex = 2;
            direction += Vector2.down;

        }
        if (Input.GetKey(KeyCode.D))
        {
            exitIndex = 1;
            direction += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Block();
            if (isAttacking && !IsMoving && InLineOfSight())    
            {
                attackRoutine = StartCoroutine(Attack());
            }
           
        }
    }
    private IEnumerator Attack()
    {

        isAttacking = true;
        myAnimator.SetBool("attack", isAttacking);
        yield return new WaitForSeconds(3);
        StopAttack();
    }
    public void CastSpell()
    {
        Instantiate(SpellPrefab[0], exitPoints[exitIndex].position, Quaternion.identity);
    }

    private bool InLineOfSight()
    {
        Vector3 targetDirection = (MyTarget.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Vector2.Distance(transform.position, MyTarget.transform.position),256);
        if (hit.collider == null)
        {
            return true;
        }
        return false;
    }

    private void Block()
    {
        foreach (Block b in blocks)
        {
            b.Deactivate();
        }

        blocks[exitIndex].Activate();
    }
}

    