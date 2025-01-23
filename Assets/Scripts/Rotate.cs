using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0F, _rotateSpeed * Time.deltaTime, 0F);
    }
}
