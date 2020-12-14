namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.04.04</para>
    /// <para>내    용 : 패스 정의하는 구조체</para>
    /// </summary>
    public struct MD_PathDefine
    {
        #region CSV

        // ******************************************************************************************************
        // CSV
        // ******************************************************************************************************
        public const string CSV_ItemListPath = "CSV/Item/ItemList";
        public const string CSV_ItemEquipListPath = "CSV/Item/ItemEquipList";

        public const string CSV_CharacterCardListPath = "CSV/CharacterCard/CharacterCardList";


        #endregion

        #region XML

        // ******************************************************************************************************
        // XML
        // ******************************************************************************************************
        public const string XML_SavePath = "Assets/Resources/XML/";
        public const string XML_PlayerInformation = "Player";
        public const string XML_CharacterCardInformation = "CharacterCard";

        public const string XML_Node_Setting = "SettingInfo/Setting";

        #endregion

        #region Audio

        // ******************************************************************************************************
        // Audio Path
        // ******************************************************************************************************
        public const string Audio_BGMPath = "Audio/BGM";
        public const string Audio_EffectPath = "Audio/Effect";

        // ******************************************************************************************************
        // BGM
        // ******************************************************************************************************
        public const string Audio_BGM_Space = "PlayBGM";

        // ******************************************************************************************************
        // Effect
        // ******************************************************************************************************
        public const string Audio_EffectButtonClick = "ButtonClick";

        #endregion
    }
}