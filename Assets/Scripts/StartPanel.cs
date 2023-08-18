using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _startPanel;

    private void Start()
    {
        Time.timeScale = 0; // Pause a game
        _startPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1; // Unpause a game
            _startPanel.SetActive(false);
            this.enabled = false;
        }
    }

    private void Reset()
    {
        _startPanel = GameObject.Find("Start Panel");
    }
}
