using Plenumio.Application.Interfaces;
using Plenumio.Core.Interfaces;
using Plenumio.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Services {
    public class UserService(IUnitOfWork uof) : IUserService {
    }
}
