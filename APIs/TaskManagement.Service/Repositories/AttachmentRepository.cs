using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Helpers.Meta;
using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
        private readonly Cloudinary cloudinary;
        public AttachmentRepository(AppDbContext context, CloudinarySettings cloudinarySettings) : base(context)
        {
            var account = new Account
            {
                Cloud = cloudinarySettings.CloudName,
                ApiKey = cloudinarySettings.ApiKey,
                ApiSecret = cloudinarySettings.ApiSecret
            };
            cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddAttachment(IFormFile file)
        {
            var uplaodResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };
                uplaodResult = await cloudinary.UploadAsync(uploadParams);
            }
            return uplaodResult;
        }

        public async Task<DeletionResult> DeleteAttachmentById(int id)
        {
            await BeginTransactionAsync();
            try
            {
                var attachment = await GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (attachment is null) return null!;

                var deleteParams = new DeletionParams(attachment.PublicId);
                var deleteResult = await cloudinary.DestroyAsync(deleteParams);
                if (deleteResult.Error is not null) return null!;

                await DeleteAsync(attachment);

                await SaveChangesAsync();
                await CommitAsync();
                return deleteResult;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<List<Attachment>> GetAllAttachments()
        {
            var attachments = await GetTableNoTracking().Include(x => x.User).ToListAsync();
            return attachments.Count() > 0 ? attachments : null!;
        }

        public async Task<Attachment> GetAttachmentById(int id)
        {
            return await GetTableNoTracking().Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        }
    }
}
