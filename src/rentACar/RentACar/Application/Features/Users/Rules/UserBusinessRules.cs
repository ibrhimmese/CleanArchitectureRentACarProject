using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules:BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task UserEmailShouldNotExistWhenInsert(string email)
        {
            bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Email == email, enableTracking: false);
            if (doesExist)
            {
                throw new BusinessException(AuthMessages.UserMailAlreadyExist);
            }
        }
    }
}
