using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    bool gameEnded = false;

    public float delay = 1f;

    public void GameOver() {

        if (!gameEnded) {

            gameEnded = true;
            Invoke("Restart", delay);

        }

    }

    void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
