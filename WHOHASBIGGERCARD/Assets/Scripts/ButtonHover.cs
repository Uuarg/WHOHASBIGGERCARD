using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isCard = false;
    [SerializeField] private Vector3 beforeScale = Vector3.one;
    [SerializeField] private Vector3 afterScale = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] private Vector3 clickedScale = new Vector3(1.1f, 1.1f, 1.1f);
    [SerializeField] private Tween mouseHoverTween;
    [SerializeField] private float timeDuration = 0.5f;
    public bool isMouseHover = false;
    private int siblingIndex = -1;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseHover)
        {
            if (mouseHoverTween != null && mouseHoverTween.active)
            {
                mouseHoverTween.Kill();
            }
            mouseHoverTween = transform.DOScale(clickedScale, timeDuration);
        }
        if (Input.GetMouseButtonUp(0) && isMouseHover)
        {
            if (mouseHoverTween != null && mouseHoverTween.active)
            {
                mouseHoverTween.Kill();
            }
            mouseHoverTween = transform.DOScale(afterScale, timeDuration);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseHover = true;
        if (mouseHoverTween != null && mouseHoverTween.active)
        {
            mouseHoverTween.Kill();
        }
        mouseHoverTween = transform.DOScale(afterScale, timeDuration);
        if (isCard)
        {
            siblingIndex = transform.GetSiblingIndex();
            transform.SetAsLastSibling();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseHover = false;
        if (mouseHoverTween != null && mouseHoverTween.active)
        {
            mouseHoverTween.Kill();
        }
        mouseHoverTween = transform.DOScale(beforeScale, timeDuration);
        if (isCard)
        {
            transform.SetSiblingIndex(siblingIndex);
        }
    }

    private void OnEnable()
    {
        isMouseHover = false;
    }
}
