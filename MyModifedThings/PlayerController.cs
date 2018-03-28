using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character {

    [SerializeField]
    private Stat mana;
    private float initMana = 50;
    

    [SerializeField]
    private Transform[] exitPoints;
    [SerializeField]
    private BoxCollider2D[] attackPoints;
    private int attackIndex;
    private int exitIndex;
    [SerializeField]
    private int spellSpeed;
    private int spellIndex;
    private SpellBook spellBook;
    private float spellCooldown = 0;
    private float attackCooldown = 0;
    private bool cast = false;
    private bool attack = true;
    private float manaCost = 5;
    private float managRegen;
    [SerializeField]
    private float damage;


    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    protected override void Start()
    {
        spellBook = GetComponent<SpellBook>();
        mana.Initialize(initMana, initMana);
        base.Start();
        exitIndex = 2;
        attackIndex = 2;
    }
 
	
	// Update is called once per frame
	protected override void Update () {
        managRegen += Time.deltaTime;
        if(Mathf.Round(managRegen)/5 == 0)
        {
            mana.MyCurrentValue += manaCost;
        }
        if (spellCooldown>0 && cast == true)
        {

            spellCooldown -= Time.deltaTime;
            if (spellCooldown <= 0)
            {
                cast = false;
            }
        }
        if (attackCooldown > 0 && attack == true)
        {

            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                attack = false;
            }
        }
        GetInput();
        base.Update();
	}
    

    private void GetInput()
    {

        Direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            exitIndex = 0;
            attackIndex = 0;
            Direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            exitIndex = 3;
            attackIndex = 3;
            Direction += Vector2.left;

        } 
        if (Input.GetKey(KeyCode.S))
        {
            exitIndex = 2;
            attackIndex = 2;
            Direction += Vector2.down;

        }
        if (Input.GetKey(KeyCode.D))
        {
            exitIndex = 1;
            attackIndex = 1;
            Direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Mathf.Round(attackCooldown) == 0)
            {
                StartCoroutine(AttackMelee(attackIndex));
            }
        }

    }

    private IEnumerator AttackMelee(int attackIndex)
    {

        
        IsAttacking = true;
        MyAnimator.SetBool("attack", true);

        yield return new WaitForSeconds(MyAnimator.GetCurrentAnimatorStateInfo(2).length); // waits for duration of animation to attack
        attackPoints[attackIndex].enabled = true;
        yield return new WaitForSeconds(0.2f);
        IsAttacking = false;
        attackPoints[attackIndex].enabled = false;
        StopCoroutine(AttackMelee(attackIndex));
        attackCooldown = 0.7f;
        attack = true;
    }

    public void FireProjectile(int spellIndex)
    {
        if (spellCooldown<0.1)
        {
            mana.MyCurrentValue -= manaCost;
            Spell newSpell = spellBook.CastSpell(spellIndex);
            SpellScript s = Instantiate(newSpell.MySpellPrefab, exitPoints[exitIndex].position, Quaternion.identity).GetComponent<SpellScript>();
            s.Initialize(newSpell.MyDamage);
            if (exitIndex == 1)
            {
                s.GetComponent<Rigidbody2D>().AddForce(Vector2.right * newSpell.MySpeed);
            }
            if (exitIndex == 0)
            {
                s.GetComponent<Rigidbody2D>().AddForce(Vector2.up * newSpell.MySpeed);
            }
            if (exitIndex == 2)
            {
                s.GetComponent<Rigidbody2D>().AddForce(Vector2.down * newSpell.MySpeed);
            }
            if (exitIndex == 3)
            {
                s.GetComponent<Rigidbody2D>().AddForce(Vector2.left * newSpell.MySpeed);
            }
         
          cast = true;
          spellCooldown = 2;
        }
       
    }



}

    