using System;
using System.Globalization;
using System.Linq;
using System.Text;

public class LedgerEntry
{
   public LedgerEntry(DateTime date, string desc, float chg)
   {
       Date = date;
       Desc = desc;
       Chg = chg;
   }

   public DateTime Date { get; }
   public string Desc { get; }
   public float Chg { get; }
}

public static class Ledger
{
    private const string LocaleUS = "en-US";
    private const string LocaleNLD = "nl-NL";

    #region Methods - Public

    public static LedgerEntry CreateEntry(string date, string desc, int chg)
    {
        return new LedgerEntry(ParseDate(date), desc, ParseChange(chg));
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        StringBuilder formatted = new StringBuilder(GetLedgerHead(locale));

        if (entries.Length > 0)
        {
            CultureInfo culture = GetCultureInfo(currency, locale);

            foreach (LedgerEntry entry in entries.OrderBy(e => e.Chg))
            {
                formatted.Append($"\n{FormatEntry(culture, entry)}");
            }
        }

        return formatted.ToString();
    }

    #endregion Methods - Public

    #region Methods - Private

    private static DateTime ParseDate(string date) => DateTime.Parse(date, CultureInfo.InvariantCulture);

    private static float ParseChange(int chg) => chg / 100.0f;

    private static string GetLedgerHead(string locale)
    {
        switch (locale)
        {
            case LocaleUS: return "Date       | Description               | Change       ";
            case LocaleNLD: return "Datum      | Omschrijving              | Verandering  ";
            default: throw new ArgumentException("Invalid locale");
        }
    }

    private static CultureInfo GetCultureInfo(string currency, string locale)
    {
        CultureInfo culture = new CultureInfo(locale);
        culture.NumberFormat.CurrencySymbol = GetCurrencySymbol(currency);
        culture.DateTimeFormat.ShortDatePattern = GetShortDatePattern(locale);
        return culture;
    }

    private static string GetCurrencySymbol(string currency)
    {
        switch (currency)
        {
            case "USD": return "$";
            case "EUR": return "€";
            default: throw new ArgumentException("Invalid currency");
        }
    }

    private static string GetShortDatePattern(string locale)
    {
        switch (locale)
        {
            case LocaleUS: return "MM/dd/yyyy";
            case LocaleNLD: return "dd/MM/yyyy";
            default: throw new ArgumentException("Invalid locale");
        }
    }

    private static string FormatEntry(IFormatProvider culture, LedgerEntry entry) =>
        $"{FormatDate(culture, entry.Date)} | {(entry.Desc.Length > 25 ? FormatDescription(entry.Desc) : entry.Desc),-25} | {FormatChange(culture, entry.Chg),13}";

    private static string FormatDate(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string FormatDescription(string desc) => $"{desc.Substring(0, 22)}...";

    private static string FormatChange(IFormatProvider culture, float chg) => chg.ToString("C", culture) + (chg < 0.0 ? "" : " ");

    #endregion Methods - Private
}
