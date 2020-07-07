using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using AngularDotnetCore.Models;

namespace AngularDotnetCore.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ResendEmailConfirmationModel(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                //ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
                ModelState.AddModelError(string.Empty, "Đã gửi email xác minh. Xin vui lòng kiểm tra email của bạn");
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            string img = "<img alt='Rao Vặt Việt Mỹ' class='logo' src='https://raovatvietmy.com/assets/images/raovatvietmy.png'>";
            string msg = img +
                $"<h4>Cám ơn bạn đã đăng ký tài khoản tại website https://raovatvietmy.com </h4> " +
                $"<p>Để hoàn tất quá trình đăng ký, xin bạn vui lòng xác nhận địa chỉ Email bằng cách " +
                $"<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>nhấp chuột vào đây</a>.</p> " +
                $"<p>Trân trọng kính chào.</p>" +
                $"<p>https://raovatvietmy.com</p>";

            await _emailSender.SendEmailAsync(
                Input.Email,
                "Xác thực email của bạn", msg);

            ModelState.AddModelError(string.Empty, "Đã gửi email xác minh. Xin vui lòng kiểm tra email của bạn");
            return Page();
        }
    }
}
