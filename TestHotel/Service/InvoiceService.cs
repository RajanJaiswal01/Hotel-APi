using System.Text;
using TestHotel.DTOs;
using TestHotel.Entities;
using TestHotel.Repository.IRepository;
using TestHotel.Service.IService;
using Worklog.Repository;


namespace TestHotel.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingRepository _bookingRepository;
        private readonly ICustomerRepository _customerRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork, IBookingRepository bookingRepository, ICustomerRepository customerRepository)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
        }
        public IEnumerable<Invoice> GetAll()
        {
            var result = _invoiceRepository.GetMany();
            return result;
        }

        public async Task<Int64> Create(InvoiceDTO model)
        {
            long TotalPrice = 0;
            var datas = _bookingRepository.GetAll(x => x.CustomerId == model.CustomerId);
            var day = DateTime.Now.DayOfWeek.ToString().ToLower();
            int stayday = Convert.ToInt32(datas.First().CheckOutDate.Date.Subtract(datas.First().CheckInDate.Date).Days);
            if (day == "friday")
            {
                if (datas.Count() > 2)
                {
                    foreach (var data in datas)
                    {
                        TotalPrice = data.Price + TotalPrice;
                    }
                    TotalPrice = TotalPrice - ((TotalPrice * 15) / 100);
                    TotalPrice = TotalPrice - ((TotalPrice * 5) / 100);
                    TotalPrice = TotalPrice * stayday;
                }
                else
                {
                    foreach (var data in datas)
                    {
                        TotalPrice = data.Price + TotalPrice;

                    }
                    TotalPrice = TotalPrice - ((TotalPrice * 15) / 100);
                    TotalPrice = TotalPrice * stayday;
                }

            }
            else if (datas.Count() > 2)
            {
                foreach (var data in datas)
                {
                    TotalPrice = data.Price + TotalPrice;
                }
                TotalPrice = TotalPrice - ((TotalPrice * 5) / 100);
                TotalPrice = TotalPrice * stayday;
            }
            else
            {
                foreach (var data in datas)
                {
                    TotalPrice = data.Price + TotalPrice;
                }
                TotalPrice = TotalPrice * stayday;
            }

            Invoice invoice = new Invoice();
            invoice.InvoiceId = model.InvoiceId;
            invoice.isprinted = model.isprinted;
            invoice.CustomerId = model.CustomerId;
            invoice.BookingId = model.BookingId;
            invoice.TotalPrice = TotalPrice;
            await _invoiceRepository.Add(invoice);
            await _unitOfWork.Commit();
            return invoice.InvoiceId;
        }
        public async Task<Int64> Update(InvoiceDTO model)
        {
            Invoice invoice = new Invoice();
           invoice.InvoiceId = model.InvoiceId;
            invoice.isprinted = model.isprinted;
            invoice.TotalPrice = model.TotalPrice;
            invoice.CustomerId = model.CustomerId;
            invoice.BookingId = model.BookingId;
            await _invoiceRepository.Add(invoice);
            await _unitOfWork.Commit();
            return invoice.InvoiceId;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            Customer customers = await _customerRepository.GetSingle(id);
            return customers;
        }



        public async Task Delete(int id)
        {
            var data = _invoiceRepository.GetById(id);
            _invoiceRepository.Delete(data);
            await _unitOfWork.Commit();
        }


        public async Task<Invoice> GetById(int id)
        {
            return await _invoiceRepository.GetSingle(id);
        }

        public static class TemplateGenerator
        {
            public static string GetHTMLString(PrintInvoiceDTO invoices)
            {


                var sb = new StringBuilder();
                sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Id</th>
                                        <th>Full Name</th>
                                        <th>Age</th>
                                        <th>Address</th>
                                        <th>Gender</th>
                                        <th>TotalPrice:</th>
                                    </tr>");

                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                  </tr>", invoices.InvoiceId, invoices.Name, invoices.Age, invoices.PhoneNumber, invoices.Address, invoices.TotalPrice);

                sb.Append(@"
                                </table>
                            </body>
                        </html>");

                return sb.ToString();
            }
        }
    }
}
