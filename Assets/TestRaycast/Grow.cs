using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float _speed = 3f;
    public float _maxSize = 4f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x < _maxSize)
        {
            float delta = Time.deltaTime * _speed;
            gameObject.transform.localScale += new Vector3(delta, delta, delta);
        }
    }
}
