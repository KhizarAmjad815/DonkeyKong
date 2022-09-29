using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Collider2D pCollider;

    public float speed = 3f;
    private Vector2 direction;
    public float jumpForce = 4f;

    private Collider2D[] results;
    public bool isGrounded;
    public bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        pCollider = GetComponent<Collider2D>();
        results = new Collider2D[4];
    }

    void CheckCollision()
    {
        isGrounded = isClimbing = false;
        Vector2 size = pCollider.bounds.size;
        size.y += 0.1f;
        size.x /= 2.0f;

        int times = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0f, results);

        for (int i = 0; i < times; i++)
        {
            GameObject hit = results[i].gameObject;

            if (hit.CompareTag("Ground"))
            {
                if ((transform.position.y - 0.5f) > hit.transform.position.y)
                {
                    isGrounded = true;
                    Debug.Log("You are grounded");
                }
                Physics2D.IgnoreCollision(pCollider, results[i], !isGrounded);
            }
            else if (hit.CompareTag("Ladder"))
            {
                isClimbing = true;
                Physics2D.IgnoreCollision(pCollider, results[i]);
                Debug.Log("Collided with Ladder");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();

        if (isClimbing)
        {
            float vInput = Input.GetAxis("Vertical");
            direction.y = vInput * speed;

            //transform.Translate(Vector3.up * vInput * speed * Time.deltaTime);
        }
        else if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector2.up * jumpForce;
        }
        else
        {
            direction += Physics2D.gravity * Time.deltaTime;
        }

        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        if (isGrounded)
        {
            direction.y = Mathf.Max(direction.y, -1f);
        }

        if (direction.x > 0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (direction.x < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //transform.Translate(Vector3.right * hInput * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + direction * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {

        }

        if (collision.gameObject.CompareTag("Objective"))
        {

        }
    }
}
