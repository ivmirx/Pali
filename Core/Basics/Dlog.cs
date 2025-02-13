using System.Diagnostics;

namespace Core;

public static class Dlog
{
    public static void Info(Object obj)
    {
        if (obj == null)
            Debug.WriteLine("NULL");
        else
            Debug.WriteLine(obj);
    }

    public static void Warning(Object obj)
    {
        if (obj == null)
            Debug.WriteLine("🔸 NULL");
        else
            Debug.WriteLine("🔸 " + obj);
    }

    public static void Error(Object obj)
    {
        if (obj == null)
            Debug.WriteLine("🔻 NULL");
        else
            Debug.WriteLine("🔻 " + obj);
    }
}