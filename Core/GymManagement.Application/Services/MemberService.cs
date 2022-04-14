using System;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using GymManagement.Application.Interfaces.Repositories;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.MemberViewModel;
using GymManagement.Domain.Entities;

namespace GymManagement.Application.Services
{
    public class MemberService : IMemberService
    {
        
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }


        public bool Register(MemberRegisterViewModel registerViewModel)
        {
            var member = _mapper.Map<Member>(registerViewModel);

            var emailCheckMember = _memberRepository.FindByEmail(registerViewModel.Email);

            if (emailCheckMember is not null)
                throw new InvalidOperationException("Email Mevcuttur");

            CreatePasswordHash(registerViewModel.Password, out var passwordHash, out var passwordSalt);
            member.PasswordHashtMvc = passwordHash;
            member.PasswordSaltMvc = passwordSalt;

            var result = _memberRepository.CreateMember(member);

            return true;
        }

        public bool Login(MemberLoginViewModel loginViewModel)
        {

            var member =  _memberRepository.FindByEmail(loginViewModel.Email);
            if (member is null)
            {
                throw new InvalidOperationException("Member dint find");
            }

            if (!VerifyPasswordHash(loginViewModel.Password,member.PasswordHashtMvc,member.PasswordSaltMvc))
            {
                throw new InvalidOperationException("Password is not correct");
            }

            return true;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
