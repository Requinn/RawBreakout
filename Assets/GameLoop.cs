using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private Physics _physicsObj;

    [SerializeField]
    private GameObject _endGameScreen;
    [SerializeField]
    private GameObject _winText, _loseText;

    // Start is called before the first frame update
    void Start()
    {
        _physicsObj.GameOver += HandleGameOver;
    }

    private void HandleGameOver(bool didWin) {
        if (didWin)
            _winText.SetActive(true);
        else
            _loseText.SetActive(true);

        _endGameScreen.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
