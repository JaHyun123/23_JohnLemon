using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float degreePerSecond;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
       
      
        if (col.gameObject.name == "JohnLemon")
        {
            Score.coinAmount += 1;
            _audioSource.Play();
            Destroy(gameObject);
        }

    }
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * degreePerSecond);        
    }
}
