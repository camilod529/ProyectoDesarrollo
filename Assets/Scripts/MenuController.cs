using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Button btn, btn1;
    // Start is called before the first frame update
    void Start()
    {
        Button inicio = btn.GetComponent<Button>();
        Button salir = btn1.GetComponent<Button>();
        inicio.onClick.AddListener(TaskOnClick);
        salir.onClick.AddListener(TaskOnClick1);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Juego");
    }

    void TaskOnClick1()
    {
        Debug.Log("Pajuera");
        Application.Quit();

    }
}
