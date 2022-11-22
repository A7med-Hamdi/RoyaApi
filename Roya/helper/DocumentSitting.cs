namespace Roya.helper
{
    public class DocumentSitting
    {
        public static string addFile(IFormFile file, string folderName)
        {
            var pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            var fileName = $"{Guid.NewGuid()}{file.FileName}";
            var filePath = Path.Combine(pathFolder, fileName);

            using var fs = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fs);

            return fileName;


        }

        public static void deleteFile(string folderName ,string fileNmae)
        {
            
            var pathFile = Path.Combine(Directory.GetCurrentDirectory(), folderName,fileNmae);
            if (File.Exists(pathFile))
            {
                File.Delete(pathFile);
            } 

        }
    }
}
