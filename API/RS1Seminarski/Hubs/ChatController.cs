using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RS1Seminarski.Data;
using RS1Seminarski.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1Seminarski.Hubs
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> hubContext;
        public ApplicationDbContext _dbContext;

        public ChatController(IHubContext<ChatHub> hubContext, ApplicationDbContext dbContext)
        {
            this.hubContext = hubContext;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task SendMessage(ChatMessage message)
        {
            //additional business logic 

            await this.hubContext.Clients.All.SendAsync("messageReceivedFromApi", message);

            ChatMessage chatMessage;
            try
            {
                chatMessage = new ChatMessage()
                {
                    DateTime=message.DateTime,
                    ConnectionId=message.ConnectionId,
                    Text=message.Text,
                    IsRead=false
                };

                _dbContext.Add(chatMessage);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            //additional business logic 
        }

        [HttpGet]
        public ActionResult<PagedList<ChatMessage>> GetAllNotifications(int items_per_page = 10, int page_number = 1)
        {

            var data = _dbContext.ChatMessages.AsQueryable();
            return PagedList<ChatMessage>.Create(data, page_number, items_per_page);
        }

        [HttpPut]
        public ActionResult<ChatMessage> MarkNotificationAsRead(int id)
        {
            var poruka = _dbContext.ChatMessages.Where(r => r.Id == id).FirstOrDefault();
            poruka.IsRead = true;
            _dbContext.Update(poruka);
            _dbContext.SaveChanges();
            return Ok(poruka);
        }
    }
}
