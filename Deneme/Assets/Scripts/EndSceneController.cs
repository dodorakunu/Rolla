using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{


    public TextMeshProUGUI ScoreText;
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); // Change "GameScene" to your main game scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        if(ScoreText != null)
        {
  
            int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // Get the saved score
            ScoreText.text = "Your Score: " + finalScore; // Display it

        }
    }
    


}
