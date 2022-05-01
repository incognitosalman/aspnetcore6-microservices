using Catalog.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }
        public Task<bool> SendEmail(Application.Models.Email email)
        {
            _logger.LogInformation($"Sending email");
            return Task.FromResult(true);
        }
    }
}
