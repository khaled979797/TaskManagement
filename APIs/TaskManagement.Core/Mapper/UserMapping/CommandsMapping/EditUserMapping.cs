﻿using TaskManagement.Core.Features.Users.Commands.Models;
using TaskManagement.Data.Models;

namespace TaskManagement.Core.Mapper.UserMapping
{
    public partial class UserMappingProfile
    {
        public void AddEditUserMapping()
        {
            CreateMap<EditUserCommand, AppUser>();
        }
    }
}