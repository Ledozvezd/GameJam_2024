using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour{

    public Button button;

    private void Start()
    {
        button.onClick.AddListener(NewGame);
    }
    public void NewGame()
    { 
        SceneManager.LoadScene("Comix");
    }
}
