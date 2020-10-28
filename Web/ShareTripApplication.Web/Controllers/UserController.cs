namespace ShareTripApplication.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShareTripApplication.Services.Data.Users;
    using ShareTripApplication.Web.ViewModels.Users.AllTrips;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult AllUsersCurrentTrip(string id)
        {
            var viewModel = new UsersCurrentTripViewModel
            {
                Users = this.userService.GetUsersForCurrentTrip<UsersTripViewModel>(id),
            };

            return this.View(viewModel);
        }
    }
}
