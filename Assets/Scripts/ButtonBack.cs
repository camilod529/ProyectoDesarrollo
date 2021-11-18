using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBack : MonoBehaviour
{
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        Button backBtn = btn.GetComponent<Button>();
        backBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
