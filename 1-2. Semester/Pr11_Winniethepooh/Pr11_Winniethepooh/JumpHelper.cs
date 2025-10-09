namespace Pr11_Winniethepooh;

public static class JumpHelper
{
    public static string CalculateMeetingPoint(int TigerX, int TigerSpd, int PoohX, int PoohSpd)
    {
        string meetingPoint = null;
        do
        {
            TigerX += TigerSpd;
            PoohX += PoohSpd;

            if (TigerX == PoohX)
            {
                meetingPoint = $"{TigerX},{PoohX}";
                return meetingPoint;
            }
            if (TigerX != PoohX)
            {
                meetingPoint = "NO";
            }
            
        } while (TigerX < 10000 && PoohX < 10000);
        return meetingPoint;
    }
}