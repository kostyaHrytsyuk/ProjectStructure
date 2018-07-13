//using System.Collections.Generic;
//using DAL.Models;

//namespace DAL.Repositories
//{
//    class CrewRepository : IRepository<Crew>
//    {
//        private DataSource _context;

//        public CrewRepository(DataSource context)
//        {
//            _context = context;
//        }

//        public List<Crew> GetAll()
//        {
//            return _context.Crews;
//        }

//        public Crew Get(int id)
//        {
//            return _context.Crews.Find(c => c.Id == id);
//        }

//        public void Create(Crew item)
//        {
//            _context.Crews.Add(item);
//        }

//        public void Update(Crew item)
//        {
//            var updItem = Get(item.Id);
//            updItem = item;
//        }

//        public void Delete(int id)
//        {
//            var deleteItem = Get(id);
//            if (deleteItem != null)
//            {
//                _context.Crews.Remove(deleteItem);
//            }
//        }
//    }
//}
