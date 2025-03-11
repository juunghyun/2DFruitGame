using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject panelInGame;
    [SerializeField] private TextMeshProUGUI textInGameScore;

    private int currentScore = 0;

    private AudioSource audioSource;
    public bool IsGameStart { private set; get;} = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GameStart()
    {
        IsGameStart = true;

        panelMainMenu.SetActive(false);
        panelInGame.SetActive(true);
        audioSource.Play();
    }

    public void IncreaseScore(int addScore)
    {
        currentScore += addScore;
        textInGameScore.text = currentScore.ToString();
    }
}
