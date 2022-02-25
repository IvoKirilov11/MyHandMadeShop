namespace MyHandMadeShop.Web.Areas.Administration.Controllers
{
    using MyHandMadeShop.Common;
    using MyHandMadeShop.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
