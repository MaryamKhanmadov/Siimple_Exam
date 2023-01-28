namespace Siimple_Template_Exam.Helpers
{
    public static class DeleteOldFile
    {
        public static void DeleteOld(this string filename , string rootpath , string foldername)
        {
            string path = Path.Combine(rootpath, foldername, filename);
            FileInfo fileInfo = new(path);
            if (fileInfo.Exists)
                fileInfo.Delete();
        }
    }
}
