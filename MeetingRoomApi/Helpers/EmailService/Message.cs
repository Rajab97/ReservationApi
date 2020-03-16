using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MeetingRoomApi.Helpers.EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> to,string subject , string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(email => new MailboxAddress(email)));
            Subject = subject;
            Content = content;
        }
        public static bool CheckMail(string mail)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
