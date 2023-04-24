using AutoMapper;
using MediatR;
using TableTennis4dView.Application.DTOs;
using TableTennis4dView.Core.Entities;
using TableTennis4dView.Core.Repositories.Command;

namespace TableTennis4dView.Application.Commands.Customers.Create
{
    // Customer create command with CustomerResponse
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateCustomerCommand()
        {
            this.CreatedDate = DateTime.Now;
        }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository, IMapper mapper) {
            _customerCommandRepository = customerCommandRepository;
            _mapper = mapper;
        }
        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Customer>(request);

            if (customerEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newCustomer = await _customerCommandRepository.AddAsync(customerEntity);
            var customerResponse = _mapper.Map<CustomerResponse>(newCustomer);
            return customerResponse;
        }
    }
}
