using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

    public void GamePressed()
    {
        Debug.Log("Game is pressed!");
        // переходим в новое меню (одиночная или многопользовательская)
        SceneManager.LoadScene("MenuChoiceGame");
    }

    public void SettingsPressed()
    {
        Debug.Log("Settings is pressed!");
        // тут всё понятно
        // допилить полноэкранный режим или нет
        // мэйби музычку
        // мэйби выбор разрешения
    }

    public void ExitPressed()
    {
        Debug.Log("Exit is pressed!");
        Application.Quit();
    }

    public void SinglePressed()
    {
        Debug.Log("Single is pressed!");
        // одиночная игра
    }

    public void MultiplayerPressed()
    {
        Debug.Log("Multiplayer is pressed!");
        // совместная игра
    }

    public void BackPressed()
    {
        Debug.Log("Back is pressed!");
        SceneManager.LoadScene("MainMenu");
    }
}
