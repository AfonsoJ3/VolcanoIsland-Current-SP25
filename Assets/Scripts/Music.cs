using UnityEngine;

public class Music : MonoBehaviour
{
    //singleton stuff
    private static Music _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        
        DontDestroyOnLoad(this.gameObject);
    }

    public static Music instance()
    {
        return _instance;
    }
}
