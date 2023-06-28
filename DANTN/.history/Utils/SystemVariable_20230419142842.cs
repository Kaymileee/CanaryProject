namespace DANTN.Utils;

public static class SystemVariable
{
  public static string GetRanDomCodeInt(int length)
  {
    Random random = new Random();
    const string chars = "1234567890";

    IEnumerable<string> string_Enumerable = Enumerable.Repeat(chars, length);
    char[] arr = string_Enumerable.Select(s => s[random.Next(s.Length)]).ToArray();

    return new string(arr);
  }

  public static string NonUnicode(this string text)
  {
    var arr1 = new[] { " " };
    var arr2 = new[] { "_" };
    for (var i = 0; i < arr1.Length; i++)
    {
      text = text.Replace(arr1[i], arr2[i]);
      text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
    }

    return text;
  }

  public static string RemoveUnicode(string text)
  {
    string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
    string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
    for (int i = 0; i < arr1.Length; i++)
    {
      text = text.Replace(arr1[i], arr2[i]);
      text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
    }
    return text;
  }
}