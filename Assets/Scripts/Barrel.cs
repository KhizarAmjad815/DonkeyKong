using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D barrelRB;

    // Start is called before the first frame update
    void Start()
    {
        barrelRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            barrelRB.AddForce(collision.transform.right * speed, ForceMode2D.Impulse);
        }
    }
}
