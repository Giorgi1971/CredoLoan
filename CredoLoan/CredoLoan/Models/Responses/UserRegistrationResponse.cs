﻿namespace CredoLoan.Models.Responses
{
    public class UserRegistrationResponse
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string PersonalNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
    }
}
