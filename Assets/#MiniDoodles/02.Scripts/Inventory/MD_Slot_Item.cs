using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.12.15 </para>
    /// <para> 내    용 : 인벤토리 슬롯의 아이템 클래스 </para>
    /// </summary>
    public class MD_Slot_Item : MonoBehaviour
    {
        [Header("- 아이템의 이미지")]
        [SerializeField] private Image image_Item;
        
        [Header("- 아이템의 데이터")]
        [SerializeField] private MD_ItemData itemData;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.15 </para>
        /// <para> 내    용 : 인벤토리 슬롯의 아이템 데이터를 설정하는 기능</para>
        /// </summary>
        public void Func_SetItemData(MD_ItemData _data)
        {
            itemData = _data;
        }
    }
}