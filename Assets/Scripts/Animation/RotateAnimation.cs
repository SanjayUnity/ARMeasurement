using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 rotateAmount = new Vector3(0, 0, 180);
    [SerializeField] private float animationTime = 0.5f;
    [SerializeField] private Vector3 oldRotateVal;

    private void Awake()
    {
        oldRotateVal = transform.localEulerAngles;
    }

    [ContextMenu(nameof(Rotate))]
    public void Rotate()
    {
        PlayRotateAnimation(rotateAmount);
    }

    [ContextMenu(nameof(ResetRotate))]
    public void ResetRotate()
    {
        PlayRotateAnimation(oldRotateVal);
    }

    private void PlayRotateAnimation(Vector3 rotationAmount)
    {
        LeanTween.cancel(gameObject);
        LeanTween.rotate(gameObject, rotationAmount, animationTime);
    }
}