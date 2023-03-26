using System;
using System.Runtime.InteropServices;


[ComVisible(true)]
[ComImport, Guid("97F46DEA-56F5-4183-BDE2-C44429BCE3E7")]
public class Car
{
}

// {A9A6751E-4EE5-41F6-828F-7152CD3B274B}
//DEFINE_GUID(IID_ICreateCar,
//0xa9a6751e, 0x4ee5, 0x41f6, 0x82, 0x8f, 0x71, 0x52, 0xcd, 0x3b, 0x27, 0x4b);
[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A9A6751E-4EE5-41F6-828F-7152CD3B274B")]
public interface ICreateCar
{
    void SetPetName(string petName);
    void SetMaxSpeed(int maxSp);
}

// {18DED56F-3FF3-4180-A87B-273CD251E123}
//DEFINE_GUID(IID_IStats,
//0x18ded56f, 0x3ff3, 0x4180, 0xa8, 0x7b, 0x27, 0x3c, 0xd2, 0x51, 0xe1, 0x23);
[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("18DED56F-3FF3-4180-A87B-273CD251E123")]
public interface IStats
{
    void DisplayStats();
    void GetPetName(ref string petName);
}
// {E5975DD2-28BB-4447-87EB-25BD3BC0F545}
//DEFINE_GUID(IID_IEngine,
//0xe5975dd2, 0x28bb, 0x4447, 0x87, 0xeb, 0x25, 0xbd, 0x3b, 0xc0, 0xf5, 0x45);
[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("E5975DD2-28BB-4447-87EB-25BD3BC0F545")]
public interface IEngine
{
    void SpeedUp();
    void GetMaxSpeed(ref int curSpeed);
    void GetCurSpeed(ref int maxSpeed);
}

class Program
{
    static void Main()
    {
        Car myCar = new();
        ICreateCar iCrCar = (ICreateCar)myCar;
        Console.WriteLine("Напишите имя: ");
        iCrCar.SetPetName(Console.ReadLine());

    }
}