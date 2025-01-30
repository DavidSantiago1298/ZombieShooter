using UnityEngine;

public class FireInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            gameObject.GetComponent<GetWeppon>().Weapon?.Shoot();
        }
    }
}