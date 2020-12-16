using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "MiniDoodles/InventoryItem", order = int.MaxValue)]
    public class MD_Inventory_Setting : MD_BaseScriptableObject
    {
        [Header("- 인벤토리의 슬롯 프리팹")]
        public GameObject prefab_InventorySlot;

        [Header("- 슬롯의 아이템이 비어있을 때 이미지")]
        public Sprite sprite_VoidItem;
        
        [Header("- 슬롯 아이템 이미지 배열")]
        public Sprite[] sprite_ItemArr;
    }
}