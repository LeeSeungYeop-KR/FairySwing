﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{    
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.05.16</para>
    /// <para>내    용 : 아이템의 스크립트</para>
    /// </summary>
    public class MD_Item : MonoBehaviour
    {
        [Header("- Basic Value")]
        [SerializeField] private Image image_item;        // 아이템의 이미지

        [Header("- 아이템 데이터")]
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