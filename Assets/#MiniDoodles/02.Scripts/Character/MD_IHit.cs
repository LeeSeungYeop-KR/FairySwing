namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.28 </para>
    /// <para> 내    용 : 맞는 메서드를 담당하는 인터페이스 </para>
    /// </summary>
    public interface MD_IHit
    {
        void Func_Hit(int _attackPower);        // 공격을 맞았을때 호출되는 메서드
    }
}