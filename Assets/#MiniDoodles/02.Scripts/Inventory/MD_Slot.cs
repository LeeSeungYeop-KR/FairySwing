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
        [Header("- 슬롯의 아이템")]
        [SerializeField] private MD_Item slotItem;
        
        public void Func_SetSlotData(MD_ItemData _itemData, MD_Drag_ItemImage _dragImage, MD_Inventory_Information _Information)
        {
            slotItem.Func_SetItemData(_itemData);
            slotItem.Func_SetItemInformationOBJ(_Information);
            slotItem.GetComponent<MD_ItemDrag>()?.Func_SetDragImage(_dragImage);
        }        
    }
}