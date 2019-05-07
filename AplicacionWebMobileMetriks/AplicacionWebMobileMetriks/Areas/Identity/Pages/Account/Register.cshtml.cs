using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AplicacionWebMobileMetriks.Models;
using AplicacionWebMobileMetriks.Utilidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AplicacionWebMobileMetriks.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        //Creo mi variable a asignar los roles mediante Inyeccion de dependencias
        private readonly RoleManager<IdentityRole> _rolAdministrador;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> rolAdministrador
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _rolAdministrador = rolAdministrador;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la confirmacion de contraseña no son iguales.")]
            public string ConfirmPassword { get; set; }

            //Aqui agrego mas propiedades a mi modelo de registrarse
            [Required]
            public string Empresa { get; set; }
            [Required]
            public string Nombre { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                //Cambio de donde obtendra los datos la variable "user" en lugar de usar el modelo  base de "IdentityUser" utilizo mi modelo que cree "UsuarioDeLaAplicacion" que en si hereda de IdentityUser :v
                var user = new UsuarioDeLaAplicacion {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nombre = Input.Nombre,
                    Empresa = Input.Empresa       
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //Aqui es donde se agregan los roles
                    //Primero checo si existe el rol a crear
                    if (!await _rolAdministrador.RoleExistsAsync(SD.UsuarioAdministrador))
                    {
                        //Si no existe creo el rol
                        await _rolAdministrador.CreateAsync(new IdentityRole(SD.UsuarioAdministrador));
                    }
                    //Primero checo si existe el rol a crear
                    if (!await _rolAdministrador.RoleExistsAsync(SD.UsuarioRegular))
                    {
                        //Si no existe creo el rol
                        await _rolAdministrador.CreateAsync(new IdentityRole(SD.UsuarioRegular));
                    }

                    //Despues ya asigno los roles especificos
                    //Aqui asigno a administrador
                    await _userManager.AddToRoleAsync(user, SD.UsuarioAdministrador);

                    _logger.LogInformation("User created a new account with password.");
                    //--Comento este codigo para que no me genere error por que aun no le agrego esa caracteristica.--
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
