using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.12.15</para>
    /// <para>내    용 : 무기 아이템의 클래스 </para>
    /// </summary>
    public class MD_ItemWeapon : MD_Item
    {
        [Header("- 무기 아이템 데이터")]
        [SerializeField] private MD_ItemWeaponData weapon_data;

    }
}