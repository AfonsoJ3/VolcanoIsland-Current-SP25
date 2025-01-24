using UnityEngine;

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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        player.reset();
    }
}
