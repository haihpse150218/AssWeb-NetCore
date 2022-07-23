using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public string cn;
        public MemberRepository(string connection)
        {
            this.cn = connection;
        }

        public void DeleteMember(int id)
        {
            try
            {
                Member mem = GetMemberByID(id);
                if (mem != null)
                {
                    using (var context = new eStoreContext(cn))
                    {
                        context.Members.Remove(mem);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Can not delete member!!!");
            }
        }

        public List<Member> GetAllMembers()
        {
            var listMembers = new List<Member>();
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    listMembers = db.Members.ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception("Can not get all member!!!");
            }
            return listMembers;
        }

        public Member GetMemberByEmail(string email)
        {

            Member mem = null;
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    mem = db.Members.SingleOrDefault(c => c.Email.Equals(email));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Can not find this email!!!");
            }
            return mem;

        }

        public Member GetMemberByID(int id)
        {
            Member member = null;
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    member = db.Members.SingleOrDefault(c => c.MemberId == id);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Can not find this member by id!!!");
            }
            return member;
        }

        public void InsertMember(Member m)
        {
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    db.Members.Add(m);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Can not insert new member!!!");
            }
        }

        public Member LoginUser(string email, string pass)
        {
            Member mem = null;
            try
            {
                using(var db = new eStoreContext(cn))
                {
                    mem = db.Members.SingleOrDefault(m => m.Email == email && m.Password == pass);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Can not login!!!");
            }
            return mem;
        }

        public List<Member> SearchMemberByEmail(string email)
        {
            var listSearch = new List<Member>();
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    listSearch = db.Members.Where(c => c.Email.Contains(email)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Can not find this member by email!!!");
            }
            return listSearch;
        }

        public void UpdateMember(Member m)
        {
            try
            {
                using (var context = new eStoreContext(cn))
                {
                    context.Entry<Member>(m).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Can not update member!!!");
            }
        }
    }
}
