namespace ShareTripApplication.Web.Areas.Administration.Controllers
{
    using ShareTripApplication.Common;
    using ShareTripApplication.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
