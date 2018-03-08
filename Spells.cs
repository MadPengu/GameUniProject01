using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    [SerializeField]
    private float speed;
    private Transform target;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Target").transform;
	}
	
    
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;  // Temporary solution
        myRigidbody.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
