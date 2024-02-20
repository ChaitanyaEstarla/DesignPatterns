using UnityEngine;

public class ObjectToSpawn : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    bool addForce = true;
    Vector2 spawnPosition;

    private void Start()
    {
        spawnPosition = new Vector2(Random.Range(-2, 4), Random.Range(3, 6));
    }

    private void FixedUpdate()
    {
        if (!addForce) return;

        rb.AddForce((Vector2)transform.up + spawnPosition * Random.Range(2,20));
        //rb.AddForce(transform.up * Random.Range(2,20));

        if(transform.position.y > 7)
        {
            addForce = false;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.gravityScale = 1;
        }
    }
}
