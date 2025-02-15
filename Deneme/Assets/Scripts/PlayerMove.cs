using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody yi kullanarak fiziksel bir hareket sa�l�yoruz
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical"); //farkl� y�nlere hareketi sa�lamak i�in input al�yoruz

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
}
