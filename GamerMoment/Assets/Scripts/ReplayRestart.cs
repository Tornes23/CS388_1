using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReplayRestart : MonoBehaviour
{
    public Text player_win;
    public Button rematch;
    public Button main_menu;
    public InputManagerLogic input;
    // Start is called before the first frame update
    void Start()
    {
        ShowUI(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI(bool set)
    {
        //win screen
        player_win.enabled = set;
        rematch.enabled = set;
        rematch.GetComponentInChildren<Text>().enabled = set;
        rematch.GetComponentInChildren<Image>().enabled = set;
        main_menu.enabled = set;
        main_menu.GetComponentInChildren<Text>().enabled = set;
        main_menu.GetComponentInChildren<Image>().enabled = set;
        input.EndGame(set);
    }

    public void OpenMainMenu() { SceneManager.LoadScene("Main Menu"); }
    public void Restart() { SceneManager.LoadScene("PlayerVsPlayer"); }
}
