using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloudMovement : MonoBehaviour
{
    public float duration = 10f;  // Durasi loop pergerakan awan
    public float endPositionX = -10f;
    public float startPositionX = 10f;

    void Start()
    {
        StartLoopingMovement();
    }

    void StartLoopingMovement()
    {
        transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        transform.DOMoveX(endPositionX, duration)
            .SetEase(Ease.Linear)
            .OnComplete(StartLoopingMovement);  // Ulangi gerakan saat selesai
    }
}
