using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D body;
    public float bulletSpeed;
    public float lifeTime = 5f;

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * bulletSpeed * Time.fixedDeltaTime);
    }

    public void SetVelocity(Vector2 q)
    {
        velocity = q;
    }
}
