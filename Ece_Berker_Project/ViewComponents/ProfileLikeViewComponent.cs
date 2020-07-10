using Ece_Berker_Project.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewComponents
{
    [ViewComponent(Name = "ProfileLikeViewComponent")]
    public class ProfileLikeViewComponent: ViewComponent
    {


        private readonly ILike _likeService;
        public ProfileLikeViewComponent(ILike LikeService)
        {

            _likeService = LikeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)

        {

            var yors = _likeService.GetUserLikes(id);

            return View(yors);


        }

    }
}
