using Hackathon.ChatBot.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.ChatBot.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatDbContext _context;

        public ChatHub(ChatDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            ChatMessage chatMessage = new()
            {
                User = user,
                Message = message,
                Timestamp = DateTime.Now
            };

            // Save the message to the database
            _ = _context.ChatMessages.Add(chatMessage);
            _ = await _context.SaveChangesAsync();

            // Broadcast the message to all connected clients
            await Clients.All.SendAsync("ReceiveMessage", user, message, chatMessage.Timestamp);
        }

        public async Task<IEnumerable<ChatMessage>> GetChatHistory()
        {
            return await _context.ChatMessages
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }
    }
}
