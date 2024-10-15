using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CircleMove : MonoBehaviour
{
    public Image Cherry;
    public TextMeshProUGUI Title;
    public float radius = 400f;
    public float speed = 2f;

    private Vector2 titlePosition;

    private void Start()
    {
        titlePosition = Title.rectTransform.anchoredPosition;
    }

    private void Update()
    {
        float angle = Time.time * speed;

        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;

        Cherry.rectTransform.anchoredPosition = new Vector2(x, y) + titlePosition;
    }
}
