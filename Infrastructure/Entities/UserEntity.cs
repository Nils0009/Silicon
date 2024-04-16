﻿using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    [ProtectedPersonalData]
    public string? Bio { get; set; }

    public string ProfileImage { get; set; } = "avatar.jpg";

    public string? AddressId { get; set; }
    public AddressEntity? Address { get; set; }

    public ICollection<UserCourseRegistrationEntity>? CourseRegistration { get; set; } = new List<UserCourseRegistrationEntity>();

    public bool IsExternalAccount { get; set; }
}
