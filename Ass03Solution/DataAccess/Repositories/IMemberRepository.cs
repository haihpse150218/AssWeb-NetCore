using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IMemberRepository
    {
        List<Member> GetAllMembers();

        Member GetMemberByID(int id);
        Member GetMemberByEmail(string email);
        List<Member> SearchMemberByEmail(string email);
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);

        Member LoginUser(string email, string pass);
    }
}
