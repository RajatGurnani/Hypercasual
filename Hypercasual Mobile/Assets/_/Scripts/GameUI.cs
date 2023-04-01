using DG.Tweening;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public RectTransform startPanel;

    public Vector2 screenDimension;

    private void Awake()
    {
        screenDimension = new Vector2(Screen.width, Screen.height);
    }

    public void StartButton()
    {
        startPanel.DOMoveY(screenDimension.y * 2, 1f);
    }
}
