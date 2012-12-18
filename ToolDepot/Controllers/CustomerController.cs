using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Models;
using ToolDepot.Services.Authentication;
using ToolDepot.Services.CustomerService;
using ToolDepot.Services.Helpers;

namespace ToolDepot.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly ICustomerService _customerService;
        
        private readonly IAuthenticationService _authenticationService;
        public CustomerController(ICustomerRegistrationService customerRegistrationService,ICustomerService customerService,IAuthenticationService authenticationService)
        {
            _customerRegistrationService = customerRegistrationService;
            _customerService = customerService;
            
            _authenticationService = authenticationService;
        }

        //
        // GET: /Customer/
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var model = new LoginModel();
            
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_customerRegistrationService.ValidateCustomer(model.UserName, model.Password))
                {

                    var customer = _customerService.GetCustomerByUserName(model.UserName);

                    if (customer.TimeZoneId == null)
                    {
                        customer.TimeZoneId = DateTime.UtcNow.ToString();
                        _customerService.Update(customer);
                    }

                    //sign in new customer
                    _authenticationService.Login(customer, model.RememberMe);
                    
                    return RedirectToLocal(returnUrl);
                }
            }

           
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                // If we're a rep and have just logged in, send them to rep dashboard
                return RedirectToAction("Index", "Home", new { goToDashboardIfRep = true });
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        #endregion

    }
}
