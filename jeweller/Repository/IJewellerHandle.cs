using jeweller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jeweller.Repository
{
    public interface IJewellerHandle
    {
        List<JewellerDetails> GetJeweller();
        bool UpdateDetails(JewellerDetails jd);
    }
}