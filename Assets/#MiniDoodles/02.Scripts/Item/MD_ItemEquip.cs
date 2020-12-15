using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.12.15</para>
    /// <para>내    용 : 장비 아이템의 데이터 구조체 </para>
    /// </summary>
    [System.Serializable]
    public struct MD_ItemEquipmentData
    {
        /// <summary>
        /// 아이템 공격력
        /// </summary>
        public int data_Attack;

        /// <summary>
        /// 아이템 이름
        /// </summary>
        public string data_Name;

        /// <summary>
        /// 아이템 설명
        /// </summary>
        public string data_Description;

        /// <summary>
        /// 아이템 타입
        /// </summary>
        public int data_Type;
    }

    public class MD_ItemEquip : MD_Item
    {
        [Header("- 장비 아이템 데이터")]
        [SerializeField] private int attack;
        [SerializeField] private int magic;
        [SerializeField] private int attackDefence;
        [SerializeField] private int magicDefence;

    }
}