using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    // Each vehicle implementation specifies its own movement speed
    public float BulletSpeed = 0f;
    public float BulletDame = 0f;
    public enum BulletType
    {
        AutoBullet,
        MiniBullet
    }
    public abstract BulletType GetBulletType();
    void Update()
    {
        transform.Translate(Vector3.right * (BulletSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            Debug.Log(BulletDame);
            Destroy(gameObject);
        }

    }
}
