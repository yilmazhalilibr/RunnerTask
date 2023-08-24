using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunnerTask.Managers
{
    public static class LevelManager
    {

        public static void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public static void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
        public static void ExitGame()
        {
            Application.Quit();
        }


    }
}

