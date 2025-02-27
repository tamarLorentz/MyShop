using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entites;
using Microsoft.EntityFrameworkCore;

namespace Resources
{
    public class RatingRepository : IRatingRepository
    {
        ApiManagerContext context;
        public RatingRepository(ApiManagerContext apiManagerContext)
        {
            context = apiManagerContext;
        }
        public async Task PostRating(Rating rating)
        {

            await context.Ratings.AddAsync(rating);
            await context.SaveChangesAsync();
        }
    }
}
