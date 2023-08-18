using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField]
    private TMP_Text _scoreText;

    private int _score = 0;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        _score = 0;
    }
    

    public void AddScorePoint()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    public int GetScorePoints()
    {
        return _score;
    }

    public void GameOver()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
        SceneManager.LoadScene(0);
    }

    private void Reset()
    {
        _scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
    }
}
