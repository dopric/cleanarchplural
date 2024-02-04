using GloboTickets.Application.Contracts.Infrastructure;
using GloboTickets.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GloboTickets.Infrastructure.Services.Mail;

public class EmailService : IEmailService
{
    public EmailSettings EmailSettings { get; }

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        EmailSettings = emailSettings.Value;
    }
    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(EmailSettings.ApiKey);
        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = EmailSettings.FromAddress,
            Name = EmailSettings.FromName
        };
        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(sendGridMessage);
        return response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK;
    }
}