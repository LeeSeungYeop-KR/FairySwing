using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{

    public class MD_ScrollView : MonoBehaviour
    {
        [Header("- 슬롯 크기")]
        [SerializeField] private float slotSize = 370f;

        [Header("- 화면의 기본 크기")]
        [SerializeField] private float originalView = 1120f;

        [Header("- 슬롯의 가로 개수")]
        [SerializeField] private int viewWidthNum = 3;

        [Header("- 화면에 보여야 할 슬롯의 개수")]
        [SerializeField] private int viewMaxNum = 9;

        [Header("- 증가 할 값")]
        [SerializeField] private float addSize;
        
        // Start is called before the first frame update
        void OnEnable()
        {
            RectTransform _rect = GetComponent<RectTransform>();
            int _ChildNum = transform.childCount;

            if (_ChildNum <= viewMaxNum)
            {
                _rect.sizeDelta = new Vector2(0, originalView);
            }
            else
            {
                addSize = (_ChildNum - viewMaxNum + (viewWidthNum - 1)) / viewWidthNum * slotSize;
                _rect.sizeDelta = new Vector2(0, originalView + addSize);
            }
        }
    }
}