using Microsoft.AspNetCore.Identity;

namespace Persistence.Contexts
{
     class ResumeIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "En az bir boyuk herf olmalidir."
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = "Bu mail qeydiyyatlidir."
            };
        }

    }
}
