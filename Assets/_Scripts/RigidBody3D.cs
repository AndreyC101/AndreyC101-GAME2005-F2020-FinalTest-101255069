using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    STATIC,
    DYNAMIC
}


[System.Serializable]
public class RigidBody3D : MonoBehaviour
{
    [Header("Gravity Simulation")]
    public float gravityScale;
    public float mass;
    public BodyType bodyType;
    public float timer;
    public bool isFalling;

    [Header("Attributes")]
    public Vector3 velocity;
    public Vector3 acceleration;
    private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        gravity = -0.001f;
        velocity = Vector3.zero;
        acceleration = new Vector3(0.0f, gravity * gravityScale, 0.0f);
        if (bodyType == BodyType.DYNAMIC)
        {
            isFalling = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyType == BodyType.DYNAMIC)
        {
            if (isFalling)
            {
                timer += Time.deltaTime;
                
                if (gravityScale < 0)
                {
                    gravityScale = 0;
                }

                if (gravityScale > 0)
                {
                    velocity[1] = velocity.y + acceleration.y * 0.5f * timer * timer;
                }
            }
            MoveXZ();
            Move();
        }
    }

    public void Stop()
    {
        timer = 0;
        isFalling = false;
    }

    public void MoveXZ()
    {
        velocity[0] = velocity.x + (acceleration.x * Time.deltaTime);
        velocity[2] = velocity.z + (acceleration.z * Time.deltaTime);
        acceleration.Set(0.0f, acceleration.y, 0.0f);
    }

    public void PushX(float force)
    {
        velocity[0] = velocity.x + force * 1.01f;
    }

    public void PushZ(float force)
    {
        velocity[2] = velocity.z + force * 1.01f;
    }

    public void Move()
    {
        if (!isFalling) velocity[1] = 0;
        transform.position += velocity;

        if (gameObject.GetComponent<CubeBehaviour>().isGrounded)
        {
            velocity[0] = velocity.x * 0.8f;
            velocity[2] = velocity.z * 0.8f;
        }
    }
}
