using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class ShaderTest : MonoBehaviour
{
    private float dissolveAmount;
    private Material mat;
    public float speed = 1;

    private void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
        mat = null;
        mat = GetComponent<SpriteRenderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.isPressed)
        {
            DissolveIn();
        }
        if (Keyboard.current.tKey.isPressed)
        {
            DissolveOut();
        }

        mat.SetFloat("_NoiseAmount", dissolveAmount);
    }

    private void DissolveOut()
    {
        if (dissolveAmount < 1)
        {
            Debug.Log("wsdfs");
            dissolveAmount += Time.deltaTime * speed;
        }
    }

    private void DissolveIn()
    {
        if (dissolveAmount > 0)
        {
            Debug.Log("wsdfs");
            dissolveAmount -= Time.deltaTime * speed;
        }
    }
}
