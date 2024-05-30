using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public void Die(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
