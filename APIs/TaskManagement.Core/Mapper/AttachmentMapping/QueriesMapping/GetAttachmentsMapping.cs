using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Attachments.Queries;

namespace TaskManagement.Core.Mapper.AttachmentMapping
{
    public partial class AttachmentMappingProfile
    {
        public void GetAttachmentsMapping()
        {
            CreateMap<Attachment, GetAttachmentsResponse>()
                .ForPath(dst => dst.UserName, opt => opt.MapFrom(src => src.User!.UserName));
        }
    }
}
