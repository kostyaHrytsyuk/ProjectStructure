//using System.Collections.Generic;
//using DAL.Models;

//namespace DAL.Repositories
//{
//    class PilotRepository : IRepository<Pilot>
//    {
//        private DataSource _context;

//        public PilotRepository(DataSource context)
//        {
//            _context = context;
//        }

//        public List<Pilot> GetAll()
//        {
//            return _context.Pilots;
//        }

//        public Pilot Get(int id)
//        {
//            return _context.Pilots.Find(p => p.Id == id);
//        }

//        public void Create(Pilot item)
//        {
//            _context.Pilots.Add(item);
//        }

//        public void Update(Pilot item)
//        {
//            var updItem = Get(item.Id);
//            updItem = item;
//        }

//        public void Delete(int id)
//        {
//            var deleteItem = Get(id);
//            if (deleteItem != null)
//            {
//                _context.Pilots.Remove(deleteItem);
//            }
//        }
//    }
//}