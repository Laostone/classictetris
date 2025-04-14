using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverMask : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image hoverMask; // ���� HoverMask ����

    void Start()
    {
        hoverMask.enabled = false; // ȷ����ʼ����
    }

    void OnEnable()
    {
        hoverMask.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverMask.enabled = true; // �����ͣʱ��ʾ����
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverMask.enabled = false; // ����뿪ʱ��������
    }
}