using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using TaskManagement.Data.Models;

namespace TaskManagement.Service.Interfaces
{
    public interface IAttachmentRepository : IGenericRepository<Attachment>
    {
        Task<ImageUploadResult> AddAttachment(IFormFile file);
        Task<DeletionResult> DeleteAttachmentById(int id);
        Task<List<Attachment>> GetAllAttachments(int assignmentId);
        Task<Attachment> GetAttachmentById(int id);
    }
}
