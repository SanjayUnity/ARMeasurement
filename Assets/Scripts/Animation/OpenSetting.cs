using System.Collections.Generic;
using UnityEngine;

public class OpenSetting : MonoBehaviour
{
    [SerializeField] private RotateAnimation rotateAnimation;
    [SerializeField] private List<ScaleAnimation> scaleAnimations = new List<ScaleAnimation>();

    [ContextMenu(nameof(OpenCloseMenu))]
    public void OpenCloseMenu(bool isOpen)
    {
        if (!isOpen)
        {
            for (int i = 0; i < scaleAnimations.Count; i++)
            {
                scaleAnimations[i].gameObject.SetActive(true);
            }

            rotateAnimation.Rotate();
            isOpen = true;
        }
        else
        {
            for (int i = 0; i < scaleAnimations.Count; i++)
            {
                scaleAnimations[i].DecreaseScale();
            }

            rotateAnimation.ResetRotate();
            isOpen = false;
        }
    }
}