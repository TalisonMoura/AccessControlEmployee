﻿using System.Text.Json.Serialization;

namespace ChallengeUserAccess.Usecase.EmployeeUseCase.Request;

public class UpdateEmployeeRequest
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    [JsonIgnore] public DateTime ModifydAt { get; set; }
}