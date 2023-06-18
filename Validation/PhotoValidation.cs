using System.ComponentModel.DataAnnotations;

namespace SeniorCapstoneProject.Validation
{
    public class PhotoValidation: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //cast it to what we were expecting
            IFormFile file = value as IFormFile;
            //set max size of file
            int maxLength = 1024 * 1024 * 2;
            //valid files accepted
            string[] validFileExtensions = { ".jpg", ".gif", ".png", "jpeg" };
            //check if file is null
            if (file == null)
            {
                ErrorMessage = "Please upload a file";
                return false;
            }
            if (!validFileExtensions.Contains(Path.GetExtension(file.FileName)))
            {
                ErrorMessage = $"Not an Image File. Please upload {string.Join(", ", validFileExtensions)}";
                return false;
            }
            if (file.Length > maxLength)
            {
                ErrorMessage = $"File is too large, max size is {maxLength / 1024}kb";
                return false;
            }
            return true;
        }
    }
}
