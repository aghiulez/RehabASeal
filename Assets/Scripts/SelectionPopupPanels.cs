using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionPopupPanels : MonoBehaviour
{
    public GameObject PopUpPanel;
    public bool PopUpActivate = false;
    //public Button StartButton;
    public GameObject SeperatePanel;
    public Button SeperatePanelButton;
    //public AudioSource sealAudioSource;

    void Start()
    {
        if (SeperatePanel == null) Debug.LogError("Need a SeparatePanel declaration on consolse");
        SeperatePanelButton = SeperatePanel.GetComponent<Button>();
        SeperatePanelButton.onClick.AddListener(delegate 
        { 
            SeperatePanel.SetActive(false);
            PopUpPanel.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        PopUpPanel.SetActive(true);
        SeperatePanel.SetActive(true);
        PopUpActivate = true;
    }


}
