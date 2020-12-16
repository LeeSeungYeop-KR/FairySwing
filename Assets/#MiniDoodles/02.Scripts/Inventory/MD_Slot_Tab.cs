using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{

    public class MD_Slot_Tab : MonoBehaviour
    {
        [Space(10)]
        [Header("- Test")]
        [Header("- 기본 컬러")]
        [SerializeField] private Color nomalColor;

        [Header("- 클릭 시 컬러")]
        [SerializeField] private Color clickColor;

        [Header("- 탭 이미지 배열")]
        [SerializeField] private Image[] tabImageArr;

        public void Button_ClickTab(int _clickNum)
        {
            for (int i = 0; i < tabImageArr.Length; i++)
            {
                tabImageArr[i].color = nomalColor;
            }

            tabImageArr[_clickNum].color = clickColor;
        }
    }
}