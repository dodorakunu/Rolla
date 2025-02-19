using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    public int pointcount = 0;
    public int playerhealth = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody yi kullanarak fiziksel bir hareket saðlýyoruz
        UpdateScoreUI();//Baþlangýçtaki skoru yazýyoruz
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //farklý yönlere hareketi saðlamak için input alýyoruz

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 1);
        rb.AddForce(movement * speed);
        if (playerhealth < 1)
        {
            SceneManager.LoadScene("GameOver");
            PlayerPrefs.SetInt("FinalScore", pointcount);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("BOMBA!");
            playerhealth -= 1; //oyuncu saðlýðýný azalt
            UpdateScoreUI();
            Destroy(other.gameObject); // Nesneyi yok et

            if (playerhealth < 1)
            {
                SceneManager.LoadScene("GameOver");
                PlayerPrefs.SetInt("FinalScore", pointcount);
            }
        }
        if (other.CompareTag("Point"))
        {
            Debug.Log("Puan Kazandý!");
            pointcount += 1; // Puaný artýr
            UpdateScoreUI();
            Destroy(other.gameObject); // Nesneyi yok et
        }
    }
    void UpdateScoreUI()
    {   
        if(scoreText  != null)
        {
            scoreText.text = "Score = " + pointcount;
            healthText.text = "HP = " + playerhealth;
        }
        

    }


}
