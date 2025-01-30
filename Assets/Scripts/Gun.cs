using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _bulletPivot;
    [SerializeField]
    private Animator _weaponAnimator;
    private int _maxBulletNumber = 20;
    [SerializeField]
    private int _CartidgeBulletsNumber = 5;
    private int _totalBulletNumber = 0;
    private int _currentBulletNumber = 0;
    private Text _bulletText;
    
    public void Shoot ()
    {
        _weaponAnimator.Play("Shoot", -1, 0f);
        Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);  
        _currentBulletNumber --;
        UpdateBulletText();
    }

    public void PickUpWeapon()
    {
        _weaponAnimator.Play("GetWeapon");
        _totalBulletNumber = _maxBulletNumber;
        _currentBulletNumber = _CartidgeBulletsNumber;
        UpdateBulletText();
    }

    public void Reload()
    {
        if(_totalBulletNumber >= _CartidgeBulletsNumber)
        {
            _currentBulletNumber = _CartidgeBulletsNumber;
        }
        else if(_totalBulletNumber > 0)
        {
            _currentBulletNumber = _totalBulletNumber;
        }
        _totalBulletNumber -= _currentBulletNumber;
        UpdateBulletText();
    }

    private void UpdateBulletText()
    {
        if (_bulletText == null)
        {
            _bulletText = GameObject.Find("BulletText").GetComponent<Text>();
        }
        _bulletText.text = _currentBulletNumber + "/" + _totalBulletNumber;
    }
}