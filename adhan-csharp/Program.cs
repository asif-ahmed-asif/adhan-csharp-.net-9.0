﻿using Adhan.Internal;
using Adhan;
using System.Runtime.InteropServices;

namespace adhan_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates coordinates = new Coordinates(40.7128, -74.0060);
            DateComponents dateComponents = DateComponents.From(DateTime.Now);
            CalculationParameters parameters = CalculationMethod.EGYPTIAN.GetParameters();

            string timeZone = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                "Eastern Standard Time" : "America/New_York";

            TimeZoneInfo easternTime = TimeZoneInfo.FindSystemTimeZoneById(timeZone);

            PrayerTimes prayerTimes = new PrayerTimes(coordinates, dateComponents, parameters);
            Console.WriteLine("Fajr   : " + TimeZoneInfo.ConvertTimeFromUtc(prayerTimes.Fajr, easternTime));
            Console.WriteLine("Sunrise: " + TimeZoneInfo.ConvertTimeFromUtc(prayerTimes.Sunrise, easternTime));
            Console.WriteLine("Dhuhr  : " + TimeZoneInfo.ConvertTimeFromUtc(prayerTimes.Dhuhr, easternTime));
            Console.WriteLine("Asr    : " + TimeZoneInfo.ConvertTimeFromUtc(prayerTimes.Asr, easternTime));
            Console.WriteLine("Maghrib: " + TimeZoneInfo.ConvertTimeFromUtc(prayerTimes.Maghrib, easternTime));
            Console.WriteLine("Isha   : " + TimeZoneInfo.ConvertTimeFromUtc(prayerTimes.Isha, easternTime));
        }
    }
}
