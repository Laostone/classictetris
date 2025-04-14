using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverMask : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image hoverMask; // 拖入 HoverMask 物体

    void Start()
    {
        hoverMask.enabled = false; // 确保初始隐藏
    }

    void OnEnable()
    {
        hoverMask.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverMask.enabled = true; // 鼠标悬停时显示遮罩
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverMask.enabled = false; // 鼠标离开时隐藏遮罩
    }
}