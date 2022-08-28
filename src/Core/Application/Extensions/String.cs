using System.Text.RegularExpressions;
namespace Smashup.Application.Extensions
{
  public static class String
  {
    public static string OnlyNumbers(this string value)
    {
      var regex = new Regex(@"[^0-9]");
      return regex.Replace(value, "");
    }

    public static string RemoveWhiteSpaces(this string value)
    {
      var regex = new Regex(@"\s");
      return regex.Replace(value, "");
    }
  }
}