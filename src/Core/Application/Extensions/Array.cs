namespace Smashup.Application.Extensions
{
  public static class ArrayExt
  {
    public static void Deconstruct<T>(this T[] items, out T first, out T second)
    {
      first = items.Length > 0 ? items[0] : default(T);
      second = items.Length > 1 ? items[1] : default(T);
    }
  }
}