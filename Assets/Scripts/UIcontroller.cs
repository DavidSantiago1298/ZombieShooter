using System;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField]

    private GameObject _bulletUI;
    
    [SerializeField]
    private Text _bulletsText;
    public Text BulletsText
    {
        get{return _bulletsText;}
    }

    [SerializeField]

    private GameObject _gameOverUI;
    
    [SerializeField]

    private GameObject _winUI;

    private void Start()
    {
        ShowBulletsUI(false);
        ShowGameOverUI(false);
        ShowWinUI(false);
    }

    public void ShowBulletsUI(bool show)
    {
        _bulletUI.SetActive(show);
    }

    public void ShowGameOverUI (bool show)
    {
        _gameOverUI.SetActive(show);
    }

    public void ShowWinUI (bool show)
    {
        _winUI.SetActive(show);
    }
}
