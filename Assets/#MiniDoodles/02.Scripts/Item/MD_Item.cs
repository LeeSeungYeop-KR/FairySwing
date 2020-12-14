using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.05.16</para>
    /// <para>내    용 : 아이템의 스크립트</para>
    /// </summary>
    public class MD_Item
    {
        #region 열거형

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.05.16</para>
        /// <para>내    용 : 아이템의 타입</para>
        /// </summary>
        public enum ItemType
        {
            Use, Eqip, Quest, ETC
        }

        #endregion

        [Header("- Basic Value")]
        [SerializeField] private int item_ID;               // 아이템의 id값. 중복 불가
        [SerializeField] private string item_Name;          // 아이템의 이름 중복 가능
        [SerializeField] private string item_Description;   // 아이템의 설명
        [SerializeField] private int item_Count;            // 아이템의 개수
        [SerializeField] private Sprite item_Sprite;        // 아이템의 아이콘
        [SerializeField] private ItemType item_Type;        // 아이템의 타입

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.05.16</para>
        /// <para>내    용 : 아이템 생성자</para>
        /// </summary>
        //public MD_Item(int _id, string _name, string _des, ItemType _type, int _count = 1)
        //{
        //    item_ID = _id;
        //    item_Name = _name;
        //    item_Description = _des;
        //    item_Type = _type;
        //    item_Count = _count;
        //    item_Sprite = Resources.Load("ItemIcon/" + item_ID.ToString(), typeof(Sprite)) as Sprite;
        //}

    }
}