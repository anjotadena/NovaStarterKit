﻿namespace Application.Users.Dtos;

public record UserDto(Guid Id, string FirstName, string LastName, string Email, string Role);
