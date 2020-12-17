﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiniDoodles
{  
    /// <summary>
   /// <para>작 성 자 : 이승엽</para>
   /// <para>작 성 일 : 2020.12.15</para>
   /// <para>내    용 : 장비 아이템의 클래스 </para>
   /// </summary>
    public class MD_ItemEquip : MD_Item
    {
        [Header("- 장비 아이템 데이터")]
        [SerializeField] private MD_ItemEquipmentData equipment_data;
        

    }
}