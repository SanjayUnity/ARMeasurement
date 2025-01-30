using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomColorPicker : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private MeasureManager measureManager;
    [SerializeField] private Image colorImage;
    [SerializeField] private Color selectedColor;
    private RectTransform rectTransform;
    private Vector2 pointerPosition;
    private Texture2D colorTexture;

    void Start()
    {
        rectTransform = colorImage.GetComponent<RectTransform>();
        colorTexture = colorImage.sprite.texture;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateHandlePosition(eventData);
    }

    private void UpdateHandlePosition(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position,
            eventData.pressEventCamera, out pointerPosition))
        {
            pointerPosition.x = Mathf.Clamp(pointerPosition.x, rectTransform.rect.xMin, rectTransform.rect.xMax);
            pointerPosition.y = Mathf.Clamp(pointerPosition.y, rectTransform.rect.yMin, rectTransform.rect.yMax);
            Vector2 normalizedPosition = new Vector2(
                (pointerPosition.x - rectTransform.rect.xMin) / rectTransform.rect.width,
                (pointerPosition.y - rectTransform.rect.yMin) / rectTransform.rect.height);
            measureManager.SelectedColor =
                selectedColor = colorTexture.GetPixelBilinear(normalizedPosition.x, normalizedPosition.y);
        }
    }
}