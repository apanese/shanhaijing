using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody2D>() != null)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.gameObject.name+":OnCollisionEnter");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject.name + ":OnTriggerEnter");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(this.gameObject.name + ":OnCollisionEnter");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.gameObject.name + ":OnTriggerEnter");
    }
}
