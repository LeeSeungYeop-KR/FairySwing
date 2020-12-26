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

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.26 </para>
        /// <para> 내    용 : 아이템의 아이디에 따라 그에 맞는 이미지를 불러오는 기능 </para>
        /// </summary>
        /// <param name="_id">아이템의 아이디 값</param>
        /// <returns>아이디에 맞는 이미지, 없으면 null</returns>
        public Sprite Func_GetIDImage(int _id)
        {
            for (int i = 0; i < sprite_ItemArr.Length; i++)
            {
                if (string.Equals(sprite_ItemArr[i].name, _id.ToString()))
                {
                    return sprite_ItemArr[i];
                }
            }

            return null;
        }
    }
}