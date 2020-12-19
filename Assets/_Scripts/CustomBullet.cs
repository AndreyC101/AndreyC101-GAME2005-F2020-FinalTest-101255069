using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBullet : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float range;
    public Vector3 size;
    public Vector3 max;
    public Vector3 min;
    public bool isColliding;
    public Vector3 collisionNormal;
    public float penetration;
    public List<Contact> contacts;
    public bool isGrounded;

    public BulletManager bulletManager;
    private MeshFilter meshFilter;
    public Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
        bulletManager = FindObjectOfType<BulletManager>();
        meshFilter = GetComponent<MeshFilter>();

        bounds = meshFilter.mesh.bounds;
        size = bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += direction * speed * Time.deltaTime;
        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;
    }

    private void _CheckBounds()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > range)
        {
            bulletManager.ReturnBullet(this.gameObject);
        }
    }
}
