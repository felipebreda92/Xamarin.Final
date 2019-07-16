using System;

namespace XF.BlocoNotas.Droid
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path,fileName);
        }
    }
}