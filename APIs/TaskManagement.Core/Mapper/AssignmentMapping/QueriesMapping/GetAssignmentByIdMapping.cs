﻿using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Assignments.Queries;

namespace TaskManagement.Core.Mapper.AssignmentMapping
{
    public partial class AssignmentMappingProfile
    {
        public void GetAssignmentByIdMapping()
        {
            CreateMap<Assignment, GetAssignmentByIdResponse>()
                .ForMember(dst => dst.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForPath(dst => dst.Username, opt => opt.MapFrom(src => src.User!.UserName))
                .ForPath(dst => dst.ProjectName, opt => opt.MapFrom(src => src.Project!.Name));
        }
    }
}