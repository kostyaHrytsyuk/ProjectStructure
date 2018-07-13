//using System.Collections.Generic;
//using DAL.Models;

//namespace DAL.Repositories
//{
//    class PlaneTypeRepository : IRepository<PlaneType>
//    {
//        private DataSource _context;

//        public PlaneTypeRepository(DataSource context)
//        {
//            _context = context;
//        }

//        public List<PlaneType> GetAll()
//        {
//            return _context.PlaneTypes;
//        }
//        public PlaneType Get(int id)
//        {
//            return _context.PlaneTypes.Find(pt => pt.Id == id);
//        }

//        public void Create(PlaneType planeType)
//        {
//            _context.PlaneTypes.Add(planeType);
//        }

//        public void Update(PlaneType planeType)
//        {
//            var updItem = Get(planeType.Id);
//            updItem = planeType;
//        }

//        public void Delete(int id)
//        {
//            var deleteItem = Get(id);
//            if (deleteItem != null)
//            {
//                _context.PlaneTypes.Remove(deleteItem);
//            }
//        }
//    }
//}
