using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMovement : MonoBehaviour
{
    public float speed = 10f; // Tốc độ di chuyển của enemy
    private bool isSlowed = false;
    void Update()
    {
        // Lấy input từ các phím mũi tên
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Tính toán vector di chuyển
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * speed * Time.deltaTime;

        // Cập nhật vị trí của object
        transform.Translate(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            // Lấy Component SlowBullet từ viên đạn va chạm
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            Debug.Log(bullet.BulletDame);
            try
            {
                AutoBullet autoBullet = collision.gameObject.GetComponent<AutoBullet>();
                if (autoBullet != null)
                {
                    // Nếu enemy chưa bị giảm tốc độ, thực hiện giảm tốc độ và gán trạng thái isSlowed thành true
                    if (!isSlowed)
                    {
                        isSlowed = true;
                        speed -= autoBullet.slow;
                    }

                    // Tiến hành hủy đạn sau khi va chạm
                    Destroy(collision.gameObject);
                }
            }
            catch (System.Exception)
            {
            }        }
    }
}
