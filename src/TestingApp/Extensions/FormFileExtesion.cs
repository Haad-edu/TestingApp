using TestingApp.Service.DTOs.Attachments;

namespace TestingApp.Extensions;

public static class FormFileExtesion
{
    public static AttachmentForCreation ToAttachmentOrDefault(this IFormFile formFile)
    {

        if (formFile?.Length > 0)
        {
            using var ms = new MemoryStream();
            formFile.CopyTo(ms);
            var fileBytes = ms.ToArray();

            return new AttachmentForCreation()
            {
                Path = formFile.FileName,
                Stream = new MemoryStream(fileBytes)
            };
        }

        return null;
    }
}
