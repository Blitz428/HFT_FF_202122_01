using DYLHS5_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYLHS5_HFT_2021221.Repository
{
    public class ShopRepository :IShopRepository
    {
        XYZDbContext ctx;
        public ShopRepository(XYZDbContext ctx)
        {
            this.ctx = ctx;
        }
    }
}
