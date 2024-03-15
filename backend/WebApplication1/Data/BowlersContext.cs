using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class BowlersContext: DbContext
{
        public BowlersContext(DbContextOptions<BowlersContext> options)
            : base(options)
        {
        }

    
    
}