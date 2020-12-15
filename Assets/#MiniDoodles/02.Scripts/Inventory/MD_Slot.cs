using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.12.15 </para>
    /// <para> 내    용 : 인벤토리 클래스 </para>
    /// </summary>
    public class MD_Slot : MonoBehaviour
    {
        [Header("- 슬롯의 아이템 개수 Text")]
        [SerializeField] private Text text_ItemNum;

        [Header("- 슬롯의 아이템")]
        [SerializeField] private MD_Item slotItem;

        [Header("- 슬롯의 아이템 개수")]
        [SerializeField] private int itemNum;
    }
}