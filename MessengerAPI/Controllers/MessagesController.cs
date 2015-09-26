using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MessengerAPI.Models;
using MessengerServiceLibrary.Classes;

namespace MessengerAPI.Controllers
{
    public class MessagesController : ApiController
    {
        private MessengerAPIContext db = new MessengerAPIContext();
        private MessengerServiceLibrary.MessengerService mMessage = new MessengerServiceLibrary.MessengerService();
        // GET: api/Messages
        //public IQueryable<Message> GetMessages()
        //{
        //    return mMessage;
        //}

        // GET: api/Messages/5
        [HttpGet]
        [ResponseType(typeof(Message))]
        public IHttpActionResult GetMessage(string userId, string recieverId, string pageNumber)
        {
            int mUserId = Convert.ToInt32(userId);
            int mRecieverId = Convert.ToInt32(recieverId);
            int mPageNumber = Convert.ToInt32(pageNumber);
            List<Message> messages = mMessage.GetMessages(mUserId, mRecieverId, mPageNumber);
            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        // POST: api/Messages
        [HttpPost]
        [ResponseType(typeof(Message))]
        public IHttpActionResult PostMessage([FromBody] Message message)
        {
            if (!ModelState.IsValid && message == null)
            {
                return BadRequest(ModelState);
            }
            return mMessage.SendMessage(message) ? (IHttpActionResult) this.Ok():  this.NotFound();
        }

        // DELETE: api/Messages/5
        [HttpDelete]
        [ResponseType(typeof(Message))]
        public IHttpActionResult DeleteMessage(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return mMessage.DeleteMessage(id) ? (IHttpActionResult)this.Ok() : this.NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageExists(int id)
        {
            return db.Messages.Count(e => e.id == id) > 0;
        }
    }
}