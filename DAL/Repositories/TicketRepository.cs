using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    class TicketRepository : IRepository<Ticket>
    {
        private DataSource _context;

        public TicketRepository(DataSource context)
        {
            _context = context;
        }

        public List<Ticket> GetAll()
        {
            return _context.Tickets;
        }

        public Ticket Get(int id)
        {
            return _context.Tickets.Find(t => t.Id == id);
        }

        public void Create(Ticket item)
        {
            _context.Tickets.Add(item);
        }

        public void Update(Ticket item)
        {
            var updItem = Get(item.Id);
            updItem = item;
        }

        public void Delete(int id)
        {
            var deleteItem = Get(id);
            if (deleteItem != null)
            {
                _context.Tickets.Remove(deleteItem);
            }
        }
    }
}
