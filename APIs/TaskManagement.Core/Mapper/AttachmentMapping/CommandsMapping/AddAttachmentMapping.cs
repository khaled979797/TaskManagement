using TaskManagement.Core.Features.Attachments.Commands.Models;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Mapper.AttachmentMapping
{
    public partial class AttachmentMappingProfile
    {
        public void AddAttachmentMapping()
        {
            CreateMap<AddAttachmentCommand, Attachment>();
        }
    }
}
