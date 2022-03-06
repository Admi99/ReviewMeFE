using System.Globalization;

namespace ReviewMe.Components
{
    public static class Utilities
    {
        public static string ClassNames(params string[] classNames) => string.Join(" ", classNames);

        public static string GetShortestDayName(int dayNumber)
            => DateTimeFormatInfo.CurrentInfo.GetShortestDayName((DayOfWeek)dayNumber);

        public static int GetClosestDecade(int year) => (int)Math.Floor(year / 10.0) * 10;

        public static IReadOnlyCollection<DateTimeOffset> DaysInMonth(DateTimeOffset date)
            => Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month))
                .Select(day => new DateTimeOffset(date.Year, date.Month, day, 0, 0, 0, date.Offset))
                .ToList();

        public static IReadOnlyCollection<DateTimeOffset> MonthsInYear(DateTimeOffset date)
            => Enumerable.Range(1, 12)
                .Select(month =>
                    new DateTimeOffset(date.Year, month, date.Day, 0, 0, 0, date.Offset))
                .ToList();

        public static IReadOnlyCollection<DateTimeOffset> YearsInDecade(DateTimeOffset date)
            => Enumerable.Range(date.Year - (date.Year % 10), 11)
                .Select(year => new DateTimeOffset(year, date.Month, date.Day, 0, 0, 0, date.Offset))
                .ToList();

        public static int FirstDayOfWeek => (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
    }
}