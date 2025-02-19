using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    public int pointcount = 0;
    public int playerhealth = 3;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody yi kullanarak fiziksel bir hareket saðlýyoruz
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //farklý yönlere hareketi saðlamak için input alýyoruz

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 1);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Puan Kazandý!");
            playerhealth -= 1; //oyuncu saðlýðýný azalt
            Destroy(other.gameObject); // Nesneyi yok et
        }
        if (other.CompareTag("Point"))
        {
            Debug.Log("Puan Kazandý!");
            pointcount += 1; // Puaný artýr
            Destroy(other.gameObject); // Nesneyi yok et
        }
    }


}
