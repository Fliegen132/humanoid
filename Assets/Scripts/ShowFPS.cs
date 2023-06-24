using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    public TextMeshProUGUI TextFPS;
    private float _FPS;
    private void Update () {

        _FPS += (Time.deltaTime - _FPS) * 0.1f;
        float fps = 1.0f / _FPS;
        TextFPS.text = Mathf.Ceil (fps).ToString();

        if (fps < 20) {
            TextFPS.color = Color.red;
        }

        if (fps > 60) {
            TextFPS.color = Color.green;
        }

    }
}
