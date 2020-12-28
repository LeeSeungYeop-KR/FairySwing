using System.Collections;
using System.Collections.Generic;

namespace MiniDoodles
{
    #region 열거형

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.05.16</para>
    /// <para>내    용 : 아이템의 타입</para>
    /// </summary>
    public enum TYPE_ITEM
    {
        Weapon, Helmet, Armor, Gloves, Shoes, ETC
    }

    #endregion

    #region 캐릭터 카드의 데이터

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.11.28</para>
    /// <para>내    용 : 캐릭터 카드의 데이터 구조체 </para>
    /// </summary>
    [System.Serializable]
    public struct MD_CharacterData
    {
        /// <summary>
        /// 캐릭터 아이디
        /// </summary>
        public int data_ID;

        /// <summary>
        /// 캐릭터 이름
        /// </summary>
        public string data_name;

        /// <summary>
        /// 캐릭터 레벨
        /// </summary>
        public int data_level;

        /// <summary>
        /// 캐릭터 별 개수
        /// </summary>
        public int data_StarNum;
    }

    #endregion

    #region 아이템의 데이터

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.12.15</para>
    /// <para>내    용 : 아이템의 데이터 구조체 </para>
    /// </summary>
    [System.Serializable]
    public struct MD_ItemData
    {
        /// <summary>
        /// 아이템 아이디
        /// </summary>
        public int data_ID;

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
        public TYPE_ITEM data_Type;

        /// <summary>
        /// 아이템 소지 개수
        /// </summary>
        public int data_Count;
    }

    #endregion

    #region 장비 아이템의 데이터

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
        /// 아이템 마력
        /// </summary>
        public int data_Magic;

        /// <summary>
        /// 아이템 물리방어력
        /// </summary>
        public int data_AttackDefence;

        /// <summary>
        /// 아이템 마법방어력
        /// </summary>
        public int data_MagicDefence;
    }

    #endregion
}