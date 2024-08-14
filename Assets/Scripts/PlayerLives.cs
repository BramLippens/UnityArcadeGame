using UnityEngine;
using UnityEngine.UI;


public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUi;

    public PointManager pointManager;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Fighter") || collision.collider.gameObject.CompareTag("Scout"))
        {
            Destroy(collision.collider.gameObject);
            lives -= 1;
            for (int i = 0; i < livesUi.Length; i++){
                if(i < lives)
                {
                    livesUi[i].enabled = true;
                }
                else
                {
                    livesUi[i].enabled = false;
                }
            }
            if(lives <= 0)
            {
                Destroy(gameObject);
                pointManager.HighScoreUpdate();
                gameManager.GameOver();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Bomb"))
        {
            Destroy(collision.gameObject);
            lives -= 1;
            for (int i = 0; i < livesUi.Length; i++)
            {
                if (i < lives)
                {
                    livesUi[i].enabled = true;
                }
                else
                {
                    livesUi[i].enabled = false;
                }
            }
            if (lives <= 0)
            {
                Destroy(gameObject);
                pointManager.HighScoreUpdate();
                gameManager.GameOver();
            }
        }
    }
}
