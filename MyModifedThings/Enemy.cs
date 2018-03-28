using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{


    private IState currentState;
    public float MyAttackRange { get; set; }
    public float MyAttackTime { get; set; }
    public Vector3 MyStartPosition { get; set; }
    [SerializeField]
    private float initAggroRange;
    [SerializeField]
    public Collider2D attackTrigger;
    public float MyAggroRange { get; set; }
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject EnemySpellPrefab;
    [SerializeField]
    private bool mage;






    public bool InRange
    {
        get
        {
            return Vector2.Distance(transform.position, MyTarget.position) < MyAggroRange;
        }
    }

    public int Damage
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

    public bool Mage
    {
        get
        {
            return mage;
        }

        set
        {
            mage = value;
        }
    }

    protected void Awake()
    { 
        MyStartPosition = transform.position;
        MyAggroRange = initAggroRange;
        if (mage == false)
        {
            MyAttackRange = 0.44f;
        } else if (mage == true) {
            MyAttackRange = 10;
        }
        ChangeState(new IdleState());
    }

 

    protected override void Update()
    {
        

            if (!IsAttacking)
            {
                MyAttackTime += Time.deltaTime;
            }

            currentState.Update();

        base.Update();

    }




    public void ChangeState(IState newState)
    {
        if (currentState != null) 
        {
            currentState.Exit();
        }

      
        currentState = newState;

     
        currentState.Enter(this);
    }

    public void SetTarget(Transform target)
    {
        if (MyTarget == null && !(currentState is EvadeState))
        {
            float distance = Vector2.Distance(transform.position, target.position);
            MyAggroRange = initAggroRange;
            MyAggroRange += distance;
            MyTarget = target;
        }
    }

    public void AttackSpell()
    {
          
          Vector2 direction =  (MyTarget.transform.position - transform.position).normalized;
          SpellScriptEnemy s = Instantiate(EnemySpellPrefab, transform.position, Quaternion.identity).GetComponent<SpellScriptEnemy>();
          s.Initialize(damage);
          s.GetComponent<Rigidbody2D>().AddForce(direction * 50);

    }
    public void Reset()
    {
        this.MyTarget = null;
        this.MyAggroRange = initAggroRange;
        this.MyHealth.MyCurrentValue = this.MyHealth.MyMaxValue;
    }
}
