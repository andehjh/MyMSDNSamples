namespace Windows8.DateTimeFormatSample
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Windows.Globalization.DateTimeFormatting;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Cultures the info current culture date time format click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.RoutedEventArgs" /> instance containing the event data.</param>
        private void CultureInfoCurrentCultureDateTimeFormatClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            lbxDateTime.Items.Clear();
            this.ShowDateTimeUsingCultureInfoCurrentCultureDateTimeFormat();
        }

        /// <summary>
        /// The date time formatter click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DateTimeFormatterClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            lbxDateTime.Items.Clear();
            this.ShowDateUsingDateTimeFormatter();
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>the list converted in string value.</returns>
        private string GetString(IEnumerable<string> values)
        {
            return values.Aggregate(string.Empty, (current, value) => current + (value + " "));
        }

        /// <summary>
        /// Shows the date time click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.RoutedEventArgs" /> instance containing the event data.</param>
        private void ShowDateTimeClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            lbxDateTime.Items.Clear();
            this.ShowDateTimeUsingToString();
        }

        /// <summary>
        /// Shows the date time using culture info current culture date time format.
        /// </summary>
        private void ShowDateTimeUsingCultureInfoCurrentCultureDateTimeFormat()
        {
            var currentDateTime = DateTime.Now;
            var dateTimeFormatter = CultureInfo.CurrentCulture.DateTimeFormat;
            lbxDateTime.Items.Add(string.Concat(dateTimeFormatter.FullDateTimePattern, " -> ", currentDateTime.ToString(dateTimeFormatter.FullDateTimePattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.LongDatePattern,
                    " -> ",
                    currentDateTime.ToString(dateTimeFormatter.LongDatePattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.LongTimePattern,
                    " -> ",
                    currentDateTime.ToString(dateTimeFormatter.LongTimePattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.MonthDayPattern,
                    " -> ",
                    currentDateTime.ToString(dateTimeFormatter.MonthDayPattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.RFC1123Pattern, " -> ", currentDateTime.ToString(dateTimeFormatter.RFC1123Pattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.ShortDatePattern,
                    " -> ",
                    currentDateTime.ToString(dateTimeFormatter.ShortDatePattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.ShortTimePattern,
                    " -> ",
                    currentDateTime.ToString(dateTimeFormatter.ShortTimePattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.SortableDateTimePattern,
                    " -> ",
                    currentDateTime.ToString(dateTimeFormatter.SortableDateTimePattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.UniversalSortableDateTimePattern,
                    " -> ",
                    currentDateTime.ToString(dateTimeFormatter.UniversalSortableDateTimePattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    dateTimeFormatter.YearMonthPattern,
                    " -> ",
                    currentDateTime.ToString(dateTimeFormatter.YearMonthPattern)));

            lbxDateTime.Items.Add(
                string.Concat(
                    "AbbreviatedDayNames -> ",
                    this.GetString(dateTimeFormatter.AbbreviatedDayNames)));
            lbxDateTime.Items.Add(
                "AbbreviatedMonthGenitiveNames -> " +
                   this.GetString(dateTimeFormatter.AbbreviatedMonthGenitiveNames));
            lbxDateTime.Items.Add(
                "AbbreviatedMonthNames -> " +
                  this.GetString(dateTimeFormatter.AbbreviatedMonthNames));

            lbxDateTime.Items.Add(
                string.Concat("CalendarWeekRule", " -> ", dateTimeFormatter.CalendarWeekRule));
            lbxDateTime.Items.Add(
                string.Concat("DayNames", " -> ", this.GetString(dateTimeFormatter.DayNames)));

            lbxDateTime.Items.Add(
              string.Concat("FirstDayOfWeek", " -> ", dateTimeFormatter.FirstDayOfWeek.ToString()));

            lbxDateTime.Items.Add(
            string.Concat("GetAbbreviatedDayName(DayOfWeek.Monday)", " -> ", dateTimeFormatter.GetAbbreviatedDayName(DayOfWeek.Monday)));

            lbxDateTime.Items.Add(
            string.Concat("GetAbbreviatedMonthName(2)", " -> ", dateTimeFormatter.GetAbbreviatedMonthName(2)));

            lbxDateTime.Items.Add(
            string.Concat("GetDayName(DayOfWeek.Sunday)", " -> ", dateTimeFormatter.GetDayName(DayOfWeek.Sunday)));

            lbxDateTime.Items.Add(
             string.Concat("GetMonthName(3)", " -> ", dateTimeFormatter.GetMonthName(3)));

            lbxDateTime.Items.Add(
                string.Concat(
                    "ShortestDayNames -> ", this.GetString(dateTimeFormatter.ShortestDayNames)));
        }

        /// <summary>
        /// The show date time.
        /// </summary>
        private void ShowDateTimeUsingToString()
        {
            var currentDateTime = DateTime.Now;
            string[] formats =
                {
                    "d", "D", "f", "F", "g", "G", "m", "r", "s", "t", "T", "u", "U", "y",
                    "dddd, MMMM dd yyyy", "ddd, MMM d \"'\"yy", "dddd, MMMM dd", "M/yy", "dd-MM-yy"
                };

            foreach (string format in formats)
            {
                this.lbxDateTime.Items.Add(
                    string.Concat(
                        " dateTime.ToString( ",
                        format,
                        " )  ->  ",
                        currentDateTime.ToString(format)));
            }
        }

        /// <summary>
        /// The show date time with invariant info.
        /// </summary>
        private void ShowDateTimeWithInvariantInfo()
        {
            var currentDateTime = DateTime.Now;
            string[] formats =
                {
                    "d", "D", "f", "F", "g", "G", "m", "r", "s", "t", "T", "u", "U", "y",
                    "dddd, MMMM dd yyyy", "ddd, MMM d \"'\"yy", "dddd, MMMM dd", "M/yy", "dd-MM-yy"
                };

            foreach (var format in formats)
            {
                this.lbxDateTime.Items.Add(
                    string.Concat(
                        " dateTime.ToString( ",
                        format,
                        " )  ->  ",
                        currentDateTime.ToString(format, DateTimeFormatInfo.InvariantInfo)));
            }
        }

        /// <summary>
        /// Shows the date time with invariant info click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Windows.UI.Xaml.RoutedEventArgs" /> instance containing the event data.</param>
        private void ShowDateTimeWithInvariantInfoClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            lbxDateTime.Items.Clear();
            this.ShowDateTimeWithInvariantInfo();
        }

        /// <summary>
        /// Shows the date using date time formatter.
        /// </summary>
        private void ShowDateUsingDateTimeFormatter()
        {
            var currentDateTime = DateTime.Now;

            // first case
            var languages = new List<string>
                {
                    CultureInfo.CurrentCulture.ToString()
                };

            lbxDateTime.Items.Add(new DateTimeFormatter("month day dayofweek year").Format(currentDateTime));
;
            lbxDateTime.Items.Add(new DateTimeFormatter(YearFormat.Default, MonthFormat.Default, DayFormat.Default, DayOfWeekFormat.Default, HourFormat.None, MinuteFormat.None, SecondFormat.None, languages).Format(currentDateTime));

            lbxDateTime.Items.Add(new DateTimeFormatter(YearFormat.None, MonthFormat.None, DayFormat.None, DayOfWeekFormat.None, HourFormat.Default, MinuteFormat.Default, SecondFormat.Default, languages).Format(currentDateTime));
         
            lbxDateTime.Items.Add(new DateTimeFormatter(YearFormat.Abbreviated, MonthFormat.Numeric, DayFormat.Default, DayOfWeekFormat.None, HourFormat.None, MinuteFormat.None, SecondFormat.None, languages).Format(currentDateTime));


            lbxDateTime.Items.Add("YearFormat.Default ->" + new DateTimeFormatter(YearFormat.Default, MonthFormat.None, DayFormat.None, DayOfWeekFormat.None, HourFormat.None, MinuteFormat.None, SecondFormat.None, languages).Format(currentDateTime));

            lbxDateTime.Items.Add("MonthFormat.Default ->" + new DateTimeFormatter(YearFormat.None, MonthFormat.Default, DayFormat.None, DayOfWeekFormat.None, HourFormat.None, MinuteFormat.None, SecondFormat.None, languages).Format(currentDateTime));

            lbxDateTime.Items.Add("DayFormat.Default ->" + new DateTimeFormatter(YearFormat.None, MonthFormat.None, DayFormat.Default, DayOfWeekFormat.None, HourFormat.None, MinuteFormat.None, SecondFormat.None, languages).Format(currentDateTime));

            lbxDateTime.Items.Add("DayOfWeekFormat.Default ->" + new DateTimeFormatter(YearFormat.None, MonthFormat.None, DayFormat.None, DayOfWeekFormat.Default, HourFormat.None, MinuteFormat.None, SecondFormat.None, languages).Format(currentDateTime));

            lbxDateTime.Items.Add("HourFormat.Default ->" + new DateTimeFormatter(YearFormat.None, MonthFormat.None, DayFormat.None, DayOfWeekFormat.None, HourFormat.Default, MinuteFormat.None, SecondFormat.None, languages).Format(currentDateTime));

            lbxDateTime.Items.Add("HourFormat.Default and  MinuteFormat.Default ->" + new DateTimeFormatter(YearFormat.None, MonthFormat.None, DayFormat.None, DayOfWeekFormat.None, HourFormat.Default, MinuteFormat.Default, SecondFormat.None, languages).Format(currentDateTime));

            lbxDateTime.Items.Add("HourFormat.Default and  MinuteFormat.Default and SecondFormat.Default ->" + new DateTimeFormatter(YearFormat.None, MonthFormat.None, DayFormat.None, DayOfWeekFormat.None, HourFormat.Default, MinuteFormat.Default, SecondFormat.Default, languages).Format(currentDateTime));
      
        }
    }
}