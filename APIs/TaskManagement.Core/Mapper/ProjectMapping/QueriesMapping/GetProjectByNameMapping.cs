﻿using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Projects.Queries;

namespace TaskManagement.Core.Mapper.ProjectMapping
{
    public partial class ProjectMappingProfile
    {
        public void AddGetProjectByNameMapping()
        {
            CreateMap<Project, GetProjectByNameResponse>();
        }
    }
}