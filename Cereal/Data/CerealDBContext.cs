using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Data
{
    public class CerealDBContext : DbContext
    {
        public CerealDBContext(DbContextOptions<CerealDBContext> options) : base(options)
        {

        }
    }
}
