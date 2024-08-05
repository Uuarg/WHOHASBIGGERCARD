using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StartAnimObj : MonoBehaviour
{
    public Vector3 worldVectorPosition;
    public float timeDuration = 0.5f;
    private void Awake()
    {
        worldVectorPosition = transform.position;
    }
    void OnEnable()
    {
        transform.position = Vector3.zero;
        transform.localScale = Vector3.zero;
        transform.DOMove(worldVectorPosition, timeDuration);
        transform.DOScale(Vector3.one, timeDuration).SetEase(Ease.OutBack);
    }
}
