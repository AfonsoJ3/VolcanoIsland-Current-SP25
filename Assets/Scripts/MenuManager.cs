using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void onPlayClick()
    {
        SceneManager.LoadScene("MainGame");
    }
}
