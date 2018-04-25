using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PañaleraUpalala.Models
{
    public class UpalalaContext: DbContext
    {
        public UpalalaContext()
                :base("UpalalaDbConnection")
        {

        }

    }
}