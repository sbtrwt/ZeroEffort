using UnityEngine;
using UnityEngine.SceneManagement;
namespace cowsins
{
    public class DeathRestart : MonoBehaviour
    {
        private void Update()
        {
            if (InputManager.reloading) {  
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}