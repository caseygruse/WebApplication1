using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public static class MemberDB
    {
        /// <summary>
        /// adds member to database
        /// </summary>
        /// <param name="m"></param>
        public static void AddMember(Member m)
        {
            DBContext context = new DBContext();
            context.Members.Add(m);
            context.SaveChanges();
        }

        public static void RemoveMember(Member m)
        {
            DBContext context = new DBContext();
            if(context.Members.Find(m) != null)
            {
                context.Members.Remove(m);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// returns true if matching credentials are found in db.
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static bool UserExists(LogInViewModel log)
        {
            DBContext context = new DBContext();

            bool doesExist = (from mem in context.Members
                              where mem.Username == log.Username
                              && mem.Password == log.Password 
                              select mem).Any();
            if (doesExist)
            {
                return true;
            }
            return false;
        }
    }
}