using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.12.16</para>
    /// <para>내    용 : 자식의 개수에 따라 크기를 설정하는 클래스</para>
    /// </summary>
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

        RectTransform rect;

        private void Awake()
        {
            rect = GetComponent<RectTransform>();            
        }

        // Start is called before the first frame update
        void OnEnable()
        {
            Func_SetRect();     // 크기 설정
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.12.16</para>
        /// <para>내    용 : 자식의 개수에 따라 크기를 설정하는 기능</para>
        /// </summary>
        public void Func_SetRect()
        {
            int _ChildNum = transform.childCount;

            if (_ChildNum <= viewMaxNum)
            {
                rect.sizeDelta = new Vector2(0, originalView);
            }
            else
            {
                addSize = (_ChildNum - viewMaxNum + (viewWidthNum - 1)) / viewWidthNum * slotSize;
                rect.sizeDelta = new Vector2(0, originalView + addSize);
            }
        }
    }
}