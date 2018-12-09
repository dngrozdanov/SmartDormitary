using Microsoft.AspNetCore.Mvc;
using SmartDormitary.Controllers;

namespace SmartDormitary.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                nameof(AccountController.ConfirmEmail),
                "Account",
                new {userId, code},
                scheme);
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code,
            string scheme)
        {
            return urlHelper.Action(
                nameof(AccountController.ResetPassword),
                "Account",
                new {userId, code},
                scheme);
        }
    }
}