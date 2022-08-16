using TestHotel.DTOs;
using TestHotel.Entities;
using TestHotel.Repository;
using TestHotel.Repository.IRepository;
using TestHotel.Service.IService;
using Worklog.Repository;

namespace TestHotel.Service
{
    public class HotelStaffService : IHotelStaffService

    {
        private readonly IHotelStaffRepository _hotelStaffRepositiory;
        private readonly IUnitOfWork _unitOfWork;

        public HotelStaffService(IHotelStaffRepository hotelStaffRepositiory, IUnitOfWork unitOfWork)
        {
            _hotelStaffRepositiory = hotelStaffRepositiory;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<HotelStaff> GetAll()
        {
            var result = _hotelStaffRepositiory.GetMany();
            return result;
        }
        public async Task<Int64> Create(HotelStaffDTO model)
        {
            HotelStaff hotelStaff = new HotelStaff();
            hotelStaff.StaffName = model.StaffName;
            hotelStaff.Age = model.Age;
            hotelStaff.Gender = model.Gender;
            hotelStaff.Addres = model.Addres;
            hotelStaff.PhoneNumber= model.PhoneNumber;
            hotelStaff.Position= model.Position;
            hotelStaff.DateOfJoining= model.DateOfJoining;
            hotelStaff.Salary= model.Salary;
            await _hotelStaffRepositiory.Add(hotelStaff);
            await _unitOfWork.Commit();
            return hotelStaff.Id;

        }
        public async Task<long> Update(HotelStaffDTO model)
        {
            HotelStaff hotelStaff = await _hotelStaffRepositiory.GetSingle(model.Id);
            if (hotelStaff != null)
            {

                hotelStaff.Id = model.Id;
                hotelStaff.StaffName = model.StaffName;
                hotelStaff.Age = model.Age;
                hotelStaff.Gender = model.Gender;
                hotelStaff.Addres = model.Addres;
                hotelStaff.PhoneNumber = model.PhoneNumber;
                hotelStaff.Position = model.Position;
                hotelStaff.DateOfJoining = model.DateOfJoining;
                hotelStaff.Salary = model.Salary;
                await _hotelStaffRepositiory.Add(hotelStaff);
                await _unitOfWork.Commit();
            }


            return hotelStaff.Id;
        }
        public async Task Delete(int id)
        {
            var data = _hotelStaffRepositiory.GetById(id);
            _hotelStaffRepositiory.Delete(data);
            await _unitOfWork.Commit();
        }
        public async Task<HotelStaff> GetById(int id)
        {
            return await _hotelStaffRepositiory.GetSingle(id);
        }


    }
}
