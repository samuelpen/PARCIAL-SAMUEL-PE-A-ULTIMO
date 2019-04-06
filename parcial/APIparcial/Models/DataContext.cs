using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIparcial.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConncetion")
        {

        }

        public System.Data.Entity.DbSet<APIparcial.Models.PepitaCarrilloFriend> PepitaCarrilloFriends { get; set; }
    }
}