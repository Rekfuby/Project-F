using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D body;
    public float bulletSpeed;
    public float lifeTime = 5f;

    // Start is called before the first frame update
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * bulletSpeed * Time.fixedDeltaTime);
    }

    public void SetVelocity(Vector2 q)
    {
        velocity = q;
    }
}
