using System.ComponentModel.DataAnnotations;
using SixLabors.ImageSharp;

namespace LpuApplicationForm.Models
{
    public class MaxFileSizeAndResolutionAttribute : ValidationAttribute
    {
        private const long MaxFileSize = 3 * 1024 * 1024; // 3 MB
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png" };
        private const int RequiredWidth = 500;
        private const int RequiredHeight = 500;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not IFormFile file)
                return ValidationResult.Success;

            // Check file size
            if (file.Length > MaxFileSize)
                return new ValidationResult("File size must not exceed 3 MB.");

            // Check file extension
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(extension))
                return new ValidationResult("Only .jpg, .jpeg, and .png files are allowed.");

            // Check resolution using SixLabors.ImageSharp
            try
            {
                using var stream = file.OpenReadStream();
                var imageInfo = Image.Identify(stream);
                if (imageInfo == null)
                    return new ValidationResult("Unable to read image. Please upload a valid image file.");

                if (imageInfo.Width != RequiredWidth || imageInfo.Height != RequiredHeight)
                    return new ValidationResult($"Image must be exactly {RequiredWidth}x{RequiredHeight} pixels. Uploaded image is {imageInfo.Width}x{imageInfo.Height}.");
            }
            catch
            {
                return new ValidationResult("Unable to process the image. Please upload a valid image file.");
            }

            return ValidationResult.Success;
        }
    }
}