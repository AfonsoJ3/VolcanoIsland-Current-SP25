using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //singleton stuff
    private static GameManager _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }

    public Player player;
    public GameObject deathCanvas;
    public TMP_Text healthText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.reset();
        deathCanvas.SetActive(false);
        
    }

    public void updateHealthText(int value)
    {
        healthText.text = "x"+value.ToString();
    }

    public void setDeathCanvas(bool value)
    {
        deathCanvas.SetActive(value);
    }

    public void onResetClick()
    {
        player.reset();
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
