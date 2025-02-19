using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    public int pointcount = 0;
    public int playerhealth = 3;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody yi kullanarak fiziksel bir hareket sa�l�yoruz
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //farkl� y�nlere hareketi sa�lamak i�in input al�yoruz

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 1);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Puan Kazand�!");
            playerhealth -= 1; //oyuncu sa�l���n� azalt
            Destroy(other.gameObject); // Nesneyi yok et
        }
        if (other.CompareTag("Point"))
        {
            Debug.Log("Puan Kazand�!");
            pointcount += 1; // Puan� art�r
            Destroy(other.gameObject); // Nesneyi yok et
        }
    }


}
