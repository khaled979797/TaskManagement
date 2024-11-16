using AutoMapper;

namespace TaskManagement.Core.Mapper.AttachmentMapping
{
    public partial class AttachmentMappingProfile : Profile
    {
        public AttachmentMappingProfile()
        {
            #region Commands
            AddAttachmentMapping();
            #endregion

            #region Queries
            GetAttachmentsMapping();
            GetAttachmentByIdMapping();
            #endregion
        }
    }
}
