using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedGainSecond = 0.2f;
    [SerializeField] private float _turnSpeed = 200f;

    private int _steerValue;

    void Start()
    {
        
    }

    void Update()
    {
        _speed += _speedGainSecond * Time.deltaTime;

        transform.Rotate(0f, _steerValue * _turnSpeed, 0f * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle")) 
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Steer(int value)
    {
        _steerValue = value;
    }
}
