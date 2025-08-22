using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Infrastructure.Services {
    public class EmailSender : IEmailSender {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage) {
            await Task.CompletedTask;
        }
    }
}
