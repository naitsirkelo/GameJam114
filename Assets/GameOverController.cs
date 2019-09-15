using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public GameObject endMenu;

    public Text score;

    public void GameOver(int gold) {

        endMenu.SetActive(true);
        Time.timeScale = 0f;
        score.text = "Total gold collected: " + gold;

    }

    public void QuitFromEnd() {

        Application.Quit();

    }

    public void RestartFromEnd() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
