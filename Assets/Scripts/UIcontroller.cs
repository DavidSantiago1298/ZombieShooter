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
    
    public void ShowBulletsUI(bool show)
    {
        _bulletUI.SetActive(show);
    }
}
