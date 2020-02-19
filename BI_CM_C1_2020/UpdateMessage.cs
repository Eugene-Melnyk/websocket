using BI_CM_C1_2020.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BI_CM_C1_2020
{
    public class UpdateMessage : Hub
    {
        private DBContext db;
        public UpdateMessage(DBContext context) {
            db = context;
        }
        public async Task Update(Message getItem)
        {
            db.Add<Message>(getItem);
            db.SaveChanges();
            Object thisItem = new
                               {
                                   title = getItem.title,
                                   text = getItem.text,
                                   date = new
                                   {
                                       time = DateTime.Now.ToString("HH:mm"),
                                       hour_ago = Convert.ToInt32(DateTime.Now.Subtract(DateTime.Now).TotalHours)
                                   }
                               };
            await this.Clients.All.SendAsync("Update", thisItem);
        }
    }
}
