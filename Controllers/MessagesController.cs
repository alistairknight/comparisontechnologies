using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageApi.Models;

namespace MessageBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessageContext _context;

        public MessagesController(MessageContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageItem>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageItem>> GetMessageItem(long id)
        {
            var messageItem = await _context.Messages.FindAsync(id);

            if (messageItem == null)
            {
                return NotFound();
            }

            return messageItem;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageItem(long id, MessageItem messageItem)
        {
            if (id != messageItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(messageItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Messages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MessageItem>> PostMessageItem(MessageItem messageItem)
        {
            _context.Messages.Add(messageItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageItem", new { id = messageItem.Id }, messageItem);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageItem>> DeleteMessageItem(long id)
        {
            var messageItem = await _context.Messages.FindAsync(id);
            if (messageItem == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(messageItem);
            await _context.SaveChangesAsync();

            return messageItem;
        }

        private bool MessageItemExists(long id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
