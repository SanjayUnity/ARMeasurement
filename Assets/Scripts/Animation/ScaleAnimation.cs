using UnityEngine;
using UnityEngine.Events;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float animationTime = 0.5f;
    private UnityAction OnIncreaseScale;
    private UnityAction OnDecreaseScale;

    private void OnEnable()
    {
        OnDecreaseScale += DisableObject;
        IncreaseScale();
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

    private void IncreaseScale()
    {
        transform.localScale = Vector3.zero;
        PlayScaleAnimation(Vector3.one, OnIncreaseScale);
    }

    [ContextMenu(nameof(DecreaseScale))]
    public void DecreaseScale()
    {
        transform.localScale = Vector3.one;
        PlayScaleAnimation(Vector3.zero, OnDecreaseScale);
    }

    private void PlayScaleAnimation(Vector3 scaleVal, UnityAction animationAction)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, scaleVal, animationTime).setOnComplete(() => { animationAction?.Invoke(); });
    }
}