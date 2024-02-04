using GloboTickets.Application.Models;
using GloboTickets.Application.Models.Mail;

namespace GloboTickets.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}