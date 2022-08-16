using TestHotel.Entities;
using TestHotel.DTOs;
using TestHotel.Repository.IRepository;
using TestHotel.Service.IService;
using Worklog.Repository;


namespace TestHotel.Service
{
    public class CustomerService : ICustomerService
        
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        private RepositoryContext db;



        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IInvoiceRepository invoiceRepository, IBookingRepository bookingRepository, IRoomRepository roomRepository)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _invoiceRepository = invoiceRepository;
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        public IEnumerable<Customer> GetAll()
        {
            var result = _customerRepository.GetMany();
            return result;
        }

        public async Task FilterUser()
        {
            var customer = _customerRepository.GetMany();
            if (customer == null) return;
            foreach (var item in customer)
            {
                if (item.RegisteredDate.Year < DateTime.Now.Year && item.RegisteredDate.Month <= DateTime.Now.Month)
                {
                    var invoice = _invoiceRepository.GetAll(x => x.CustomerId == item.Id);
                    var booking = _bookingRepository.GetAll(x => x.CustomerId == item.Id);
                    var customerr = _customerRepository.FindBy(x => x.Id == item.Id);

                    foreach (var itemm in invoice)
                    {
                        _invoiceRepository.Delete(itemm);
                        _unitOfWork.Commit();
                    }
                    foreach (var ittem in booking)
                    {
                        _bookingRepository.Delete(ittem);
                        _unitOfWork.Commit();
                    }
                    foreach (var items in customerr)
                    {
                        _customerRepository.Delete(items);
                        _unitOfWork.Commit();
                    }
                }
            }
        }

        public async Task<Int64> Create(CustomerDTO model)
        {
            Customer customer = new Customer();
            customer.Id = model.Id;
            customer.Age = model.Age;
            customer.Name = model.Name;
            customer.Address = model.Address;
            customer.PhoneNumber = model.PhoneNumber;
            customer.Citizenship = model.Citizenship;
            customer.RegisteredDate = model.RegisteredDate;
            customer.Gender = model.Gender;
            await _customerRepository.Add(customer);
            await _unitOfWork.Commit();
            return customer.Id;
        }

        
        public async Task<Int64> Update(CustomerDTO model)
        {
            Customer customer = await _customerRepository.GetSingle(model.Id);
            if (customer != null)
            {
                customer.Id = model.Id;
                customer.Age = model.Age;
                customer.Name = model.Name;
                customer.Address = model.Address;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Citizenship = model.Citizenship;
                customer.RegisteredDate = model.RegisteredDate;
                customer.Gender = model.Gender;
                await _customerRepository.Add(customer);
                await _unitOfWork.Commit();
            }


            return customer.Id;
        }

        public async Task Delete(int id)

        {
            var data = _customerRepository.GetById(id);
            _customerRepository.Delete(data);
            await _unitOfWork.Commit();
        }


        public async Task<Customer> GetById(int id)
        {
            return await _customerRepository.GetSingle(id);
        }

       
    }
}
