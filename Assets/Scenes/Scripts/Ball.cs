using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    
    public float pushPower = 5f;

    public string targetLayerName = "Ball_Result";
    private int targetLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetLayer = LayerMask.NameToLayer(targetLayerName);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            float dir = Random.value < 0.5f ? -1f : 1f;

            Vector2 v = rb.linearVelocity;
            v.x = dir * pushPower;
            v.y = Mathf.Min(v.y, -1f);
            rb.linearVelocity = v;
        }
    }

    void Update()
    {
        if (gameObject.layer != targetLayer && transform.position.y < -1)
        {
            gameObject.layer = targetLayer;
        }
    }
}
