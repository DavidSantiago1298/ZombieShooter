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
    
private GetWeapon _getWeapon;
    public void Shoot ()
    {
        if(_currentBulletNumber == 0)
        {
            if(_totalBulletNumber == 0)
            {
                RemoveWeapon();    
            }
            return;
        }

        _weaponAnimator.Play("Shoot", -1, 0f);
        Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);  
        _currentBulletNumber --;
        UpdateBulletText();
    }

    private void RemoveWeapon()
    {
        _getWeapon.RemoveWeapon();
        _getWeapon = null;
    }

    public void PickUpWeapon(GetWeapon getWeapon)
    {
        _getWeapon = getWeapon;
        _totalBulletNumber =_maxBulletNumber;
        Reload();
        _weaponAnimator.Play("GetWeapon");
        UpdateBulletText();  
    }

    public void Reload()
    {
        if(_currentBulletNumber == _CartidgeBulletsNumber || _totalBulletNumber == 0)
        {
            return;
        }
        int bulletNeeded = _CartidgeBulletsNumber - _currentBulletNumber;
        if(_totalBulletNumber >= _CartidgeBulletsNumber)
        {
            _currentBulletNumber = bulletNeeded;
        }
        else if(_totalBulletNumber > 0)
        {
            _currentBulletNumber = _totalBulletNumber;
        }
        _totalBulletNumber -= _currentBulletNumber;
        UpdateBulletText();
        _weaponAnimator.Play("Reload");
    }

    private void UpdateBulletText()
    {
        if (_bulletText == null)
        {
            _bulletText = _getWeapon.GetComponent<  UIcontroller>().BulletsText;
        }
         _bulletText.text = _currentBulletNumber + "/" + _totalBulletNumber;
    }
}