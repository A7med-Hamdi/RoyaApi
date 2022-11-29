namespace Roya.helper
{
    public class DocumentSitting
    {
        public static string addFile(IFormFile file, string folderName)
        {
            var pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            

            var fileName = $"{file.FileName}";
            var filePath = Path.Combine(pathFolder, fileName);

            using var fs = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fs);
            return $"http://royaiti-001-site1.gtempurl.com/Files/Images/{fileName}";
            //return $"https://localhost:7272/Files/Images/{fileName}"; 
        }

        public static void deleteFile(string folderName ,string fileNmae)
        {

            string[] words = fileNmae.Split("http://royaiti-001-site1.gtempurl.com/Files/Images/");
            fileNmae = words[1];
            var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName,fileNmae);
            if (File.Exists(pathFile))
            {
                File.Delete(pathFile);
            } 
        }
    }
}
