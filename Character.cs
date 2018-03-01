using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    private float speed;
    protected Vector2 direction;
    private Rigidbody2D myRigidbody;
    // Use this for initialization

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }
    
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	

	// Update is called once per frame
	protected virtual void Update () {

    }
     
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        myRigidbody.velocity = direction.normalized * speed;
    }
}

