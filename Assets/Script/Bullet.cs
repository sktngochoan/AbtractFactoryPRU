using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    // Each vehicle implementation specifies its own movement speed
    protected float BulletSpeed = 0f;
    protected float BulletDame = 0f;
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
